using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Notifications;
using CondoSphere.Application.Services.Pdf;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;

namespace CondoSphere.Application.Services.Financials
{
    /// <summary>
    /// Financial Service.
    /// </summary>
    public class FinancialService : IFinancialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPdfService _pdfService;
        private readonly INotificationService _notificationService;

        public FinancialService(IUnitOfWork unitOfWork,
                                IMapper mapper,
                                IConfiguration configuration,
                                IHttpContextAccessor httpContextAccessor,
                                IPdfService pdfService,
                                INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _pdfService = pdfService;
            _notificationService = notificationService;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }

        public async Task<IEnumerable<UnitQuotaDto>> GetQuotasForUserAsync(int userId)
        {
            // 1. Get User's Units
            var userUnits = (await _unitOfWork.Units.GetByResidentIdAsync(userId)).ToList();
            if (!userUnits.Any())
            {
                return Enumerable.Empty<UnitQuotaDto>();
            }
            var unitIds = userUnits.Select(u => u.Id).ToList();

            // 2. Get Quotas for those Units
            var quotas = await _unitOfWork.UnitQuotas.GetQuotasByUnitIdsAsync(unitIds);
            if (!quotas.Any())
            {
                return Enumerable.Empty<UnitQuotaDto>();
            }

            var quotaIds = quotas.Select(q => q.Id).ToList();
            var payments = await _unitOfWork.QuotaPayments.GetPaymentsByQuotaIdsAsync(quotaIds);
            var paymentIds = payments.Select(p => p.Id).ToList();
            var receipts = await _unitOfWork.Receipts.GetReceiptsByPaymentIdsAsync(paymentIds);

            var paymentIdToReceiptIdLookup = receipts.ToDictionary(r => r.QuotaPaymentId, r => r.Id);
            var quotaIdToReceiptIdLookup = payments
                .Where(p => paymentIdToReceiptIdLookup.ContainsKey(p.Id))
                .ToDictionary(p => p.UnitQuotaId, p => paymentIdToReceiptIdLookup[p.Id]);

            var unitIdentifierLookup = userUnits.ToDictionary(u => u.Id, u => u.Identifier);
            var quotaDtos = _mapper.Map<List<UnitQuotaDto>>(quotas);

            foreach (var dto in quotaDtos)
            {
                // Populate Unit Identifier
                if (unitIdentifierLookup.TryGetValue(dto.UnitId, out var identifier))
                {
                    dto.UnitIdentifier = identifier;
                }
                else
                {
                    dto.UnitIdentifier = "N/A";
                }

                // Populate Receipt ID
                if (quotaIdToReceiptIdLookup.TryGetValue(dto.Id, out var receiptId))
                {
                    dto.ReceiptId = receiptId;
                }
            }

            return quotaDtos;
        }

        public async Task<ReceiptDto?> GetReceiptDetailsForManagerAsync(int receiptId, int companyId)
        {
            var receipt = await _unitOfWork.Receipts.GetByIdAsync(receiptId);
            if (receipt == null || receipt.CompanyId != companyId)
            {
                return null;
            }

            var payment = await _unitOfWork.QuotaPayments.GetByIdAsync(receipt.QuotaPaymentId);
            if (payment == null) return null;

            var unit = await _unitOfWork.Units.GetByIdAsync(payment.UnitId);
            if (unit == null) return null;

            var user = await _unitOfWork.Users.GetUserByIdAsync(unit.ResidentId ?? 0);
            var company = await _unitOfWork.Companies.GetByIdAsync(receipt.CompanyId);
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(receipt.CondominiumId, receipt.CompanyId);

            var receiptDto = _mapper.Map<ReceiptDto>(receipt);
            receiptDto.ResidentName = (user != null) ? $"{user.FirstName} {user.LastName}" : "N/A";
            receiptDto.UnitIdentifier = unit.Identifier;
            receiptDto.CompanyName = company?.Name ?? "N/A";
            receiptDto.CompanyAddress = company?.Address;
            receiptDto.CompanyPhone = company?.PhoneNumber;
            receiptDto.CondominiumName = condominium?.Name ?? "N/A";

            return receiptDto;
        }

        public async Task<(bool Success, string Message)> GenerateMonthlyQuotasAsync(int condominiumId, int year, int month, int companyId)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condo == null)
            {
                return (false, "Condominium not found or access denied.");
            }

            var alreadyExists = await _unitOfWork.UnitQuotas.QuotasExistForPeriodAsync(condominiumId, year, month);
            if (alreadyExists)
            {
                return (false, $"Fees for {new DateTime(year, month, 1):MMMM yyyy} have already been generated.");
            }

            var units = (await _unitOfWork.Units.GetAllAsync(condominiumId)).ToList();
            if (!units.Any())
            {
                return (false, "Cannot generate fees because there are no units in this condominium.");
            }

            var fixedExpenses = await _unitOfWork.Expenses.GetFixedExpensesByCondominiumAsync(condominiumId);
            var activeFixedExpenses = fixedExpenses.Where(e => e.IsActive).ToList();

            var oneTimeExpenses = await _unitOfWork.Expenses.GetOneTimeExpensesForPeriodAsync(condominiumId, year, month);

            decimal totalFixed = activeFixedExpenses.Sum(e => e.Amount);
            decimal totalOneTime = oneTimeExpenses.Sum(e => e.Amount);
            decimal totalExpenses = totalFixed + totalOneTime;

            if (totalExpenses <= 0)
            {
                return (false, "No expenses were found for this period, so no fees were generated.");
            }

            decimal amountPerUnit = totalExpenses / units.Count;

            var dueDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            var description = $"Condominium Fee - {new DateTime(year, month, 1):MMMM yyyy}";

            var newQuotasList = new List<Core.Entities.Financials.UnitQuota>();

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
                newQuotasList.Add(newQuota);
            }

            await _unitOfWork.CompleteAsync();
            if (newQuotasList.Any())
            {
                await _notificationService.NotifyResidentsOfNewQuotasAsync(newQuotasList, condo.Name);
            }
            return (true, "Monthly fees generated successfully.");
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
            await _notificationService.NotifyManagerOfPaymentProofSubmittedAsync(quota);

            return _mapper.Map<UnitQuotaDto>(quota);
        }

        public async Task<bool> ConfirmPaymentAsync(int quotaId, int companyId)
        {
            var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(quotaId);
            if (quota == null || quota.CompanyId != companyId) return false;
            if (quota.Status != UnitQuotaStatus.PendingConfirmation) return false;

            // Call a shared private method to do the work
            await CreatePaymentAndReceipt(quota, "Manual Confirmation");

            return true;
        }

        public async Task<bool> RejectPaymentProofAsync(int quotaId, int companyId, string rejectionReason)
        {
            var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(quotaId);
            if (quota == null || quota.CompanyId != companyId || quota.Status != UnitQuotaStatus.PendingConfirmation)
            {
                return false;
            }

            // Delete the physical proof of payment file
            if (!string.IsNullOrEmpty(quota.ProofOfPaymentUrl))
            {
                var uploadRootSetting = _configuration["FileUpload:Path"];
                var uploadRoot = Environment.ExpandEnvironmentVariables(uploadRootSetting);
                if (!Path.IsPathRooted(uploadRoot))
                    uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));

                // Extract the relative path from the full URL
                var uri = new Uri(quota.ProofOfPaymentUrl);
                var relativeFilePath = uri.AbsolutePath.TrimStart('/');
                // The first part of the path is "uploads", which is the request path, not part of the physical path
                relativeFilePath = relativeFilePath.Substring(relativeFilePath.IndexOf('/') + 1);

                var fullPath = Path.Combine(uploadRoot, relativeFilePath.Replace('/', Path.DirectorySeparatorChar));

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }

            // Reset the quota's status and clear the proof URL
            quota.Status = quota.DueDate < DateTime.UtcNow ? UnitQuotaStatus.Overdue : UnitQuotaStatus.Pending;
            quota.ProofOfPaymentUrl = null;
            _unitOfWork.UnitQuotas.Update(quota);
            await _unitOfWork.CompleteAsync();

            // Notify the resident of the rejection
            await _notificationService.NotifyResidentOfPaymentRejectionAsync(quota, rejectionReason);

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

            // 1. Fetch all payments associated with these quotas in a single query
            var quotaIds = quotas.Select(q => q.Id).ToList();
            var payments = await _unitOfWork.QuotaPayments.GetPaymentsByQuotaIdsAsync(quotaIds); // Requires new repo method

            // 2. Fetch all receipts associated with these payments in a single query
            var paymentIds = payments.Select(p => p.Id).ToList();
            var receipts = await _unitOfWork.Receipts.GetReceiptsByPaymentIdsAsync(paymentIds); // Requires new repo method

            // 3. Create a lookup dictionary to easily find a receipt by its QuotaPaymentId, then by QuotaId
            var paymentIdToReceiptIdLookup = receipts.ToDictionary(r => r.QuotaPaymentId, r => r.Id);
            var quotaIdToReceiptIdLookup = payments
                .Where(p => paymentIdToReceiptIdLookup.ContainsKey(p.Id))
                .ToDictionary(p => p.UnitQuotaId, p => paymentIdToReceiptIdLookup[p.Id]);


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

                // --- POPULATE THE NEW RECEIPT ID ---
                if (quotaIdToReceiptIdLookup.TryGetValue(dto.Id, out var receiptId))
                {
                    dto.ReceiptId = receiptId;
                }
            }
            return quotaDtos;
        }

        public async Task<string?> CreateStripeCheckoutSessionAsync(int quotaId, int userId)
        {
            var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(quotaId);
            if (quota == null) return null;

            var unit = await _unitOfWork.Units.GetByIdAsync(quota.UnitId);
            if (unit == null || unit.ResidentId != userId) return null;

            if (quota.Status == UnitQuotaStatus.Paid || quota.Status == UnitQuotaStatus.PendingConfirmation) return null;

            var webAppBaseUrl = _configuration["ClientSettings:WebAppBaseUrl"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(quota.AmountDue * 100),
                        Currency = "eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = quota.Description,
                        },
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment",
                SuccessUrl = $"{webAppBaseUrl}/portal/payment-success?quotaId={quotaId}",
                CancelUrl = $"{webAppBaseUrl}/portal/quotas/{quotaId}/details",
                Metadata = new Dictionary<string, string>
            {
                { "quota_id", quota.Id.ToString() }
            }
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return session.Id;
        }

        public async Task<bool> MarkQuotaAsPaidAsync(int quotaId, int userId)
        {
            var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(quotaId);
            if (quota == null) return false;

            var unit = await _unitOfWork.Units.GetByIdAsync(quota.UnitId);
            if (unit == null || unit.ResidentId != userId) return false;

            // Call a shared private method to do the work
            await CreatePaymentAndReceipt(quota, "Stripe Gateway");

            return true;
        }

        public async Task<ReceiptDto?> GetReceiptDetailsAsync(int receiptId, int userId)
        {
            // 1. Fetch the receipt
            var receipt = await _unitOfWork.Receipts.GetByIdAsync(receiptId);
            if (receipt == null) return null;

            // 2. Security Check & Data Gathering
            var payment = await _unitOfWork.QuotaPayments.GetByIdAsync(receipt.QuotaPaymentId);
            if (payment == null) return null;
            var unit = await _unitOfWork.Units.GetByIdAsync(payment.UnitId);
            if (unit == null || unit.ResidentId != userId) return null;

            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);

            var company = await _unitOfWork.Companies.GetByIdAsync(receipt.CompanyId);
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(receipt.CondominiumId, receipt.CompanyId);

            var receiptDto = _mapper.Map<ReceiptDto>(receipt);
            receiptDto.ResidentName = (user != null) ? $"{user.FirstName} {user.LastName}" : "N/A";
            receiptDto.UnitIdentifier = unit.Identifier;
            receiptDto.CompanyName = company?.Name ?? "N/A";
            receiptDto.CompanyAddress = company?.Address;
            receiptDto.CompanyPhone = company?.PhoneNumber;
            receiptDto.CondominiumName = condominium?.Name ?? "N/A";

            return receiptDto;
        }

        private async Task CreatePaymentAndReceipt(Core.Entities.Financials.UnitQuota quota, string paymentMethod)
        {
            // 1. Update the Quota
            quota.Status = UnitQuotaStatus.Paid;
            quota.PaymentDate = DateTime.UtcNow;
            quota.AmountPaid = quota.AmountDue;
            _unitOfWork.UnitQuotas.Update(quota);

            // 2. Create the QuotaPayment record
            var payment = new Core.Entities.Financials.QuotaPayment
            {
                Amount = quota.AmountDue,
                PaymentDate = DateTime.UtcNow,
                PaymentMethod = paymentMethod,
                UnitQuotaId = quota.Id,
                UnitId = quota.UnitId,
                CompanyId = quota.CompanyId,
                CondominiumId = quota.CondominiumId
            };
            await _unitOfWork.QuotaPayments.AddAsync(payment);

            // Save changes to get the new Payment ID for the receipt
            await _unitOfWork.CompleteAsync();

            // 3. Create the Receipt record
            var receipt = new Core.Entities.Financials.Receipt
            {
                Amount = quota.AmountDue,
                IssueDate = DateTime.UtcNow,
                QuotaPaymentId = payment.Id,
                Details = $"Receipt for payment of '{quota.Description}'",
                CompanyId = quota.CompanyId,
                CondominiumId = quota.CondominiumId
            };
            await _unitOfWork.Receipts.AddAsync(receipt);

            // Save changes to get the new Receipt ID
            await _unitOfWork.CompleteAsync();


            // 4. Get the full, enriched ReceiptDto needed for the PDF
            var receiptDto = await GetReceiptDetailsForManagerAsync(receipt.Id, quota.CompanyId);
            if (receiptDto == null)
            {
                return;
            }

            // 5. Generate the PDF file from the DTO
            var pdfBytes = await _pdfService.GenerateReceiptPdfAsync(receiptDto);

            // 6. Save the PDF file to disk (just like a document)
            var uploadRootSetting = _configuration["FileUpload:Path"];
            var uploadRoot = Environment.ExpandEnvironmentVariables(uploadRootSetting);
            if (!Path.IsPathRooted(uploadRoot))
                uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));

            var subfolder = $"condo-{quota.CondominiumId}/documents/receipts";
            var targetFolder = Path.Combine(uploadRoot, subfolder);
            Directory.CreateDirectory(targetFolder);

            var fileName = $"Receipt-{receipt.Id}-{quota.DueDate:yyyy-MM}.pdf";
            var relativeFilePath = Path.Combine(subfolder, fileName);
            var absoluteFilePath = Path.Combine(uploadRoot, relativeFilePath);
            await System.IO.File.WriteAllBytesAsync(absoluteFilePath, pdfBytes);

            // 7. Create a Document entity that points to the new PDF
            var document = new Core.Entities.Condominiums.Document
            {
                Title = $"Receipt for {quota.Description}",
                Description = $"Official receipt for payment of {quota.AmountDue:C}.",
                Category = "Receipts",
                FileName = fileName,
                FilePathOrUrl = relativeFilePath,
                CondominiumId = quota.CondominiumId,
                CompanyId = quota.CompanyId,
                UploadedByUserId = (await _unitOfWork.Units.GetByIdAsync(quota.UnitId))?.ResidentId ?? 0,
                UploadDate = DateTime.UtcNow
            };
            await _unitOfWork.Documents.AddAsync(document);
            await _unitOfWork.CompleteAsync();
            await _notificationService.NotifyResidentOfPaymentConfirmationAsync(quota);
        }
    }
}