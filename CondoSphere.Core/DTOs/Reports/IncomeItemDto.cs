namespace CondoSphere.Core.DTOs.Reports
{
    public class IncomeItemDto
    {
        public DateTime PaymentDate { get; set; }
        public string UnitIdentifier { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}