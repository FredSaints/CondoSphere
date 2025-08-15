using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.Entities.Financials;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Application.Services.Financials
{
    public interface IExpenseService
    {
        Task<ExpenseDto?> CreateExpenseAsync(CreateExpenseDto dto, int companyId, List<IFormFile> attachmentFiles);
        Task<IEnumerable<ExpenseDto>> GetExpensesForOccurrenceAsync(int occurrenceId);
        Task<ExpenseDto?> GetExpenseByIdAsync(int expenseId, int companyId);
        Task<IEnumerable<ExpenseDto>> GetFixedExpensesForCondominiumAsync(int condominiumId);
        Task<ExpenseDto?> CreateFixedExpenseAsync(CreateUpdateFixedExpenseDto dto, int companyId);
        Task<ExpenseDto?> UpdateFixedExpenseAsync(int expenseId, CreateUpdateFixedExpenseDto dto, int companyId);
        Task<bool> ToggleFixedExpenseStatusAsync(int expenseId, int companyId);
        Task<bool> DeleteFixedExpenseAsync(int expenseId, int companyId);
    }
}