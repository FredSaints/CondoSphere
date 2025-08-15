using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CondoSphere.Application.Services.Financials
{
    public class FinancialService : IFinancialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FinancialService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<UnitQuotaDto>> GetQuotasForUserAsync(int userId)
        {
            var userUnits = (await _unitOfWork.Units.GetByResidentIdAsync(userId)).ToList();
            if (!userUnits.Any())
            {
                return Enumerable.Empty<UnitQuotaDto>();
            }

            var unitIds = userUnits.Select(u => u.Id).ToList();
            var quotas = await _unitOfWork.UnitQuotas.GetQuotasByUnitIdsAsync(unitIds);
            if (!quotas.Any())
            {
                return Enumerable.Empty<UnitQuotaDto>();
            }

            var unitIdentifierLookup = userUnits.ToDictionary(u => u.Id, u => u.Identifier);
            var quotaDtos = _mapper.Map<List<UnitQuotaDto>>(quotas);

            foreach (var dto in quotaDtos)
            {
                if (unitIdentifierLookup.TryGetValue(dto.UnitId, out var identifier))
                {
                    dto.UnitIdentifier = identifier;
                }
                else
                {
                    dto.UnitIdentifier = "N/A";
                }
            }

            return quotaDtos;
        }

        public async Task<bool> GenerateMonthlyQuotasAsync(int condominiumId, int year, int month, int companyId)
        {
            // Security Check: Ensure the condo belongs to the calling manager's company
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condo == null) return false;

            // 1. Get all units in the condominium
            var units = (await _unitOfWork.Units.GetAllAsync(condominiumId)).ToList();
            if (!units.Any())
            {
                // Cannot generate fees if there are no units
                return false;
            }

            // 2. Get all active, recurring expenses for this condominium
            var fixedExpenses = await _unitOfWork.Expenses.GetFixedExpensesByCondominiumAsync(condominiumId);
            var activeFixedExpenses = fixedExpenses.Where(e => e.IsActive).ToList();

            // 3. Get all one-time expenses for the specified month and year
            // NOTE: This requires a new repository method
            var oneTimeExpenses = await _unitOfWork.Expenses.GetOneTimeExpensesForPeriodAsync(condominiumId, year, month);

            // 4. Calculate total expenses
            decimal totalFixed = activeFixedExpenses.Sum(e => e.Amount);
            decimal totalOneTime = oneTimeExpenses.Sum(e => e.Amount);
            decimal totalExpenses = totalFixed + totalOneTime;

            if (totalExpenses <= 0)
            {
                // No expenses to bill for this month
                return true; // Or false if you want to indicate nothing was generated
            }

            // 5. Calculate the amount per unit (simple division for now)
            decimal amountPerUnit = totalExpenses / units.Count;

            // 6. Create a new UnitQuota for each unit
            var dueDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1); // Last day of the billing month
            var description = $"Condominium Fee - {new DateTime(year, month, 1):MMMM yyyy}";

            foreach (var unit in units)
            {
                var newQuota = new Core.Entities.Financials.UnitQuota
                {
                    UnitId = unit.Id,
                    CondominiumId = condominiumId,
                    CompanyId = companyId,
                    Description = description,
                    AmountDue = amountPerUnit,
                    AmountPaid = 0,
                    DueDate = dueDate,
                    Status = Core.Enums.UnitQuotaStatus.Pending
                };
                await _unitOfWork.UnitQuotas.AddAsync(newQuota);
            }

            // 7. Save all new quotas to the database in one transaction
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<QuotaBreakdownDto?> GetQuotaBreakdownAsync(int quotaId, int userId)
        {
            // 1. Fetch the quota itself from the Financials DB
            var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(quotaId); // Assumes GetByIdAsync exists
            if (quota == null)
            {
                return null; // Quota not found
            }

            // 2. Security Check: Ensure the user owns this quota
            var unit = await _unitOfWork.Units.GetByIdAsync(quota.UnitId);
            if (unit == null || unit.ResidentId != userId)
            {
                return null; // User does not own this unit/quota, access denied
            }

            // 3. Determine the billing period from the quota's due date
            var billingMonth = quota.DueDate.Month;
            var billingYear = quota.DueDate.Year;

            // 4. Fetch all expenses for that condominium for that period
            var fixedExpenses = (await _unitOfWork.Expenses.GetFixedExpensesByCondominiumAsync(quota.CondominiumId))
                                  .Where(e => e.IsActive);

            var oneTimeExpenses = await _unitOfWork.Expenses.GetOneTimeExpensesForPeriodAsync(quota.CondominiumId, billingYear, billingMonth);

            // 5. Get the total number of units for the calculation display
            var allUnitsInCondo = await _unitOfWork.Units.GetAllAsync(quota.CondominiumId);
            var totalUnits = allUnitsInCondo.Count();

            // 6. Assemble the DTO
            var breakdown = new QuotaBreakdownDto
            {
                QuotaDetails = _mapper.Map<UnitQuotaDto>(quota),
                FixedExpenses = _mapper.Map<IEnumerable<ExpenseDto>>(fixedExpenses),
                OneTimeExpenses = _mapper.Map<IEnumerable<ExpenseDto>>(oneTimeExpenses),
                TotalUnitsInCondo = totalUnits
            };

            return breakdown;
        }

        public async Task<UnitQuotaDto?> SubmitPaymentProofAsync(int quotaId, int userId, IFormFile proofFile)
        {
            var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(quotaId);
            if (quota == null) return null;

            var unit = await _unitOfWork.Units.GetByIdAsync(quota.UnitId);
            if (unit == null || unit.ResidentId != userId) return null; // Security check

            // You can't submit proof for an already paid quota
            if (quota.Status == UnitQuotaStatus.Paid) return null;

            // File saving logic (similar to your other uploads)
            var uploadRootSetting = _configuration["FileUpload:Path"];
            var uploadRoot = Environment.ExpandEnvironmentVariables(uploadRootSetting);
            if (!Path.IsPathRooted(uploadRoot))
                uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));

            var subfolder = "payment-proofs";
            var targetFolder = Path.Combine(uploadRoot, subfolder);
            Directory.CreateDirectory(targetFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{proofFile.FileName}";
            var filePath = Path.Combine(targetFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await proofFile.CopyToAsync(stream);
            }

            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            var fileUrl = $"{baseUrl}/uploads/{subfolder}/{uniqueFileName}";

            // Update the quota
            quota.ProofOfPaymentUrl = fileUrl;
            quota.Status = UnitQuotaStatus.PendingConfirmation; 
            _unitOfWork.UnitQuotas.Update(quota);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UnitQuotaDto>(quota);
        }

        // --- IMPLEMENTATION for ConfirmPaymentAsync ---
        public async Task<bool> ConfirmPaymentAsync(int quotaId, int companyId)
        {
            var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(quotaId);
            if (quota == null || quota.CompanyId != companyId) return false;

            // Can only confirm payments that are pending confirmation
            if (quota.Status != UnitQuotaStatus.PendingConfirmation) return false;

            quota.Status = UnitQuotaStatus.Paid;
            quota.PaymentDate = DateTime.UtcNow;
            quota.AmountPaid = quota.AmountDue;
            _unitOfWork.UnitQuotas.Update(quota);

            // Future step: Generate a `Receipt` entity here

            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<UnitQuotaDto>> GetQuotasForCondominiumAsync(int condominiumId)
        {
            var quotas = await _unitOfWork.UnitQuotas.GetQuotasByCondominiumAsync(condominiumId);
            if (!quotas.Any())
            {
                return Enumerable.Empty<UnitQuotaDto>();
            }
            var unitsInCondo = await _unitOfWork.Units.GetAllAsync(condominiumId);
            var unitIdentifierLookup = unitsInCondo.ToDictionary(u => u.Id, u => u.Identifier);

            var quotaDtos = _mapper.Map<List<UnitQuotaDto>>(quotas);

            foreach (var dto in quotaDtos)
            {
                if (unitIdentifierLookup.TryGetValue(dto.UnitId, out var identifier))
                {
                    dto.UnitIdentifier = identifier;
                }
                else
                {
                    dto.UnitIdentifier = "N/A";
                }
            }
            return quotaDtos;
        }
    }
}