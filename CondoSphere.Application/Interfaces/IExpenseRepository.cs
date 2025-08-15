using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        Task<IEnumerable<Expense>> GetByOccurrenceIdAsync(int occurrenceId);
        Task<Expense?> GetByIdAsync(int expenseId);
    }
}