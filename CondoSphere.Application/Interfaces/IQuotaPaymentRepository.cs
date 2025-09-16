using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Interfaces
{
    public interface IQuotaPaymentRepository
    {
        Task AddAsync(QuotaPayment payment);
        Task<QuotaPayment?> GetByIdAsync(int paymentId);
        Task<IEnumerable<QuotaPayment>> GetPaymentsByQuotaIdsAsync(IEnumerable<int> quotaIds);
        Task<IEnumerable<QuotaPayment>> GetPaymentsForPeriodAsync(int condominiumId, int year, int month);
        Task<decimal> GetTotalIncomeForPeriodAsync(int companyId, DateTime start, DateTime end);
    }
}