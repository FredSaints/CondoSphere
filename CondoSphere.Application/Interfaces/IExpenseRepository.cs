using CondoSphere.Application.Services.Financials;
using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Expense Repository.
    /// </summary>
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        void Update(Expense expense);
        void Remove(Expense expense);
        Task<IEnumerable<Expense>> GetByOccurrenceIdAsync(int occurrenceId);
        Task<Expense?> GetByIdAsync(int expenseId);
        Task<IEnumerable<Expense>> GetFixedExpensesByCondominiumAsync(int condominiumId);
        Task<IEnumerable<Expense>> GetOneTimeExpensesForPeriodAsync(int condominiumId, int year, int month);
        Task<decimal> GetTotalExpensesForPeriodAsync(int companyId, DateTime start, DateTime end);
    }
}