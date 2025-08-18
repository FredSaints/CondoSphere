using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Interfaces
{
    public interface IQuotaPaymentRepository
    {
        Task AddAsync(QuotaPayment payment);
        Task<QuotaPayment?> GetByIdAsync(int paymentId);
        Task<IEnumerable<QuotaPayment>> GetPaymentsByQuotaIdsAsync(IEnumerable<int> quotaIds);
    }
}