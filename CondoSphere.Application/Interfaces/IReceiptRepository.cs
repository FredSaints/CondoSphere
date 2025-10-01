using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Receipt Repository.
    /// </summary>
    public interface IReceiptRepository
    {
        Task AddAsync(Receipt receipt);
        Task<Receipt?> GetByIdAsync(int receiptId);
        Task<IEnumerable<Receipt>> GetReceiptsByPaymentIdsAsync(IEnumerable<int> paymentIds);
    }
}