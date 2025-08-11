using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinancialsDbContext _context;

        public ExpenseRepository(FinancialsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task<IEnumerable<Expense>> GetByOccurrenceIdAsync(int occurrenceId)
        {
            return await _context.Expenses
                .Where(e => e.OccurrenceId == occurrenceId)
                .OrderBy(e => e.ExpenseDate)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}