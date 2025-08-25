using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    public class QuotaPayment : IEntity
    {
        public int Id { get; set; }
        public int CondominiumId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? TransactionReference { get; set; }
        public int UnitQuotaId { get; set; }
        public int UnitId { get; set; }
        public int CompanyId { get; set; }
    }
}
