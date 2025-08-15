using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using CoreExpense = CondoSphere.Core.Entities.Financials.Expense;

namespace CondoSphere.Application.Services.Financials
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExpenseService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ExpenseDto?> CreateExpenseAsync(CreateExpenseDto dto, int companyId, List<IFormFile> attachmentFiles)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(dto.CondominiumId, companyId);
            if (condo == null)
            {
                return null;
            }

            // NEW: Block expenses for closed occurrences
            if (dto.OccurrenceId.HasValue)
            {
                var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(dto.OccurrenceId.Value);
                if (occurrence == null || occurrence.CompanyId != companyId)
                {
                    return null;
                }
                if (occurrence.Status == OccurrenceStatus.Closed)
                {
                    // No new expenses allowed for closed occurrences
                    return null;
                }
            }

            var newExpense = _mapper.Map<CoreExpense>(dto);
            newExpense.CompanyId = companyId;

            if (attachmentFiles != null && attachmentFiles.Any())
            {
                var uploadRootSetting = _configuration["FileUpload:Path"];
                var uploadRoot = Environment.ExpandEnvironmentVariables(
                    string.IsNullOrWhiteSpace(uploadRootSetting) ? "CondoSphere_Uploads" : uploadRootSetting);

                if (!Path.IsPathRooted(uploadRoot))
                {
                    uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));
                }

                var request = _httpContextAccessor.HttpContext?.Request;
                if (request == null)
                {
                    return null;
                }

                var baseUrl = $"{request.Scheme}://{request.Host}";
                var subfolder = "expenses-photos";
                var expenseFolder = Path.Combine(uploadRoot, subfolder);

                if (!Directory.Exists(expenseFolder))
                {
                    Directory.CreateDirectory(expenseFolder);
                }

                foreach (var file in attachmentFiles)
                {
                    if (file.Length > 0)
                    {
                        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        var filePath = Path.Combine(expenseFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        newExpense.Attachments.Add(new ExpenseAttachment
                        {
                            AttachmentUrl = $"{baseUrl}/uploads/{subfolder}/{uniqueFileName}",
                            OriginalFileName = file.FileName
                        });
                    }
                }
            }

            await _unitOfWork.Expenses.AddAsync(newExpense);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ExpenseDto>(newExpense);
        }


        public async Task<IEnumerable<ExpenseDto>> GetExpensesForOccurrenceAsync(int occurrenceId)
        {
            var expenses = await _unitOfWork.Expenses.GetByOccurrenceIdAsync(occurrenceId);
            return _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }

        public async Task<ExpenseDto?> GetExpenseByIdAsync(int expenseId, int companyId)
        {
            var expense = await _unitOfWork.Expenses.GetByIdAsync(expenseId);

            if (expense == null || expense.CompanyId != companyId)
            {
                return null;
            }

            return _mapper.Map<ExpenseDto>(expense);
        }
    }
}