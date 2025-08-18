using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly FinancialsDbContext _context;
        public ReceiptRepository(FinancialsDbContext context) => _context = context;
        public async Task AddAsync(Receipt receipt) => await _context.Receipts.AddAsync(receipt);
        public async Task<Receipt?> GetByIdAsync(int receiptId) => await _context.Receipts.FindAsync(receiptId);
        public async Task<IEnumerable<Receipt>> GetReceiptsByPaymentIdsAsync(IEnumerable<int> paymentIds)
        {
            return await _context.Receipts
                .Where(r => paymentIds.Contains(r.QuotaPaymentId))
                .ToListAsync();
        }
    }
}