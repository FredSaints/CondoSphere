using CondoSphere.Core.DTOs.Financials;

namespace CondoSphere.Application.Services.Financials
{
    public interface IExpenseService
    {
        Task<ExpenseDto?> CreateExpenseAsync(CreateExpenseDto dto, int companyId);
        Task<IEnumerable<ExpenseDto>> GetExpensesForOccurrenceAsync(int occurrenceId);
    }
}