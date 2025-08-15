using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Core.Enums;
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
        public void Update(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
        }

        public void Remove(Expense expense)
        {
            _context.Expenses.Remove(expense);
        }

        public async Task<IEnumerable<Expense>> GetByOccurrenceIdAsync(int occurrenceId)
        {
            return await _context.Expenses
                .Where(e => e.OccurrenceId == occurrenceId)
                .Include(e => e.Attachments)
                .OrderBy(e => e.ExpenseDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Expense?> GetByIdAsync(int expenseId)
        {
            return await _context.Expenses
                .Include(e => e.Attachments)
                .FirstOrDefaultAsync(e => e.Id == expenseId);
        }

        public async Task<IEnumerable<Expense>> GetFixedExpensesByCondominiumAsync(int condominiumId)
        {
            return await _context.Expenses
                .Where(e => e.CondominiumId == condominiumId && e.Frequency != ExpenseFrequency.OneTime)
                .OrderBy(e => e.Title)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}