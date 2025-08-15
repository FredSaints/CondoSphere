using CondoSphere.Core.DTOs.Financials;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Application.Services.Financials
{
    public interface IExpenseService
    {
        Task<ExpenseDto?> CreateExpenseAsync(CreateExpenseDto dto, int companyId, List<IFormFile> attachmentFiles);
        Task<IEnumerable<ExpenseDto>> GetExpensesForOccurrenceAsync(int occurrenceId);
        Task<ExpenseDto?> GetExpenseByIdAsync(int expenseId, int companyId);
    }
}