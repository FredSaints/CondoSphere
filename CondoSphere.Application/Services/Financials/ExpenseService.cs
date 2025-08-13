using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.Entities.Financials;
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
            configuration = configuration;
            httpContextAccessor = httpContextAccessor;
        }

        public async Task<ExpenseDto?> CreateExpenseAsync(CreateExpenseDto dto, int companyId, List<IFormFile> attachmentFiles)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(dto.CondominiumId, companyId);
            if (condo == null) return null;

            var newExpense = _mapper.Map<CoreExpense>(dto);
            newExpense.CompanyId = companyId;

            if (attachmentFiles != null && attachmentFiles.Any())
            {
                var uploadPath = _configuration["FileUpload:Path"];
                if (string.IsNullOrEmpty(uploadPath)) return null;

                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}";

                foreach (var file in attachmentFiles)
                {
                    if (file.Length > 0)
                    {
                        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        var filePath = Path.Combine(uploadPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        newExpense.Attachments.Add(new ExpenseAttachment
                        {
                            AttachmentUrl = $"{baseUrl}/uploads/{uniqueFileName}",
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
    }
}