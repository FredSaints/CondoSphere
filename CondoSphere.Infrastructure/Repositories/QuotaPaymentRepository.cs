using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class QuotaPaymentRepository : IQuotaPaymentRepository
    {
        private readonly FinancialsDbContext _context;
        public QuotaPaymentRepository(FinancialsDbContext context) => _context = context;
        public async Task AddAsync(QuotaPayment payment) => await _context.QuotaPayments.AddAsync(payment);
        public async Task<QuotaPayment?> GetByIdAsync(int paymentId) => await _context.QuotaPayments.FindAsync(paymentId);
        public async Task<IEnumerable<QuotaPayment>> GetPaymentsByQuotaIdsAsync(IEnumerable<int> quotaIds)
        {
            return await _context.QuotaPayments
                .Where(p => quotaIds.Contains(p.UnitQuotaId))
                .ToListAsync();
        }
    }
}