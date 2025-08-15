using CondoSphere.Application.Services.Financials;
using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        void Update(Expense expense);
        void Remove(Expense expense);
        Task<IEnumerable<Expense>> GetByOccurrenceIdAsync(int occurrenceId);
        Task<Expense?> GetByIdAsync(int expenseId);
        Task<IEnumerable<Expense>> GetFixedExpensesByCondominiumAsync(int condominiumId);
    }
}