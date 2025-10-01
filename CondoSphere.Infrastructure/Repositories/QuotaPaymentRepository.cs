using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Quota Payment Repository.
    /// </summary>
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

        public async Task<IEnumerable<QuotaPayment>> GetPaymentsForPeriodAsync(int condominiumId, int year, int month)
        {
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1);

            return await _context.QuotaPayments
                .Where(p => p.CondominiumId == condominiumId && p.PaymentDate >= startDate && p.PaymentDate < endDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalIncomeForPeriodAsync(int companyId, DateTime start, DateTime end)
        {
            return await _context.QuotaPayments
                .Where(p => p.CompanyId == companyId && p.PaymentDate >= start && p.PaymentDate < end)
                .SumAsync(p => p.Amount);
        }
    }
}