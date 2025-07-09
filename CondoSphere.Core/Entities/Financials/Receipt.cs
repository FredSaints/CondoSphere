using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    public class Receipt : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public int QuotaPaymentId { get; set; }
        public string Details { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int CondominiumId { get; set; }
    }
}
