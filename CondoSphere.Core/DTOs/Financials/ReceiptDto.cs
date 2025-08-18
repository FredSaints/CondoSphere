namespace CondoSphere.Core.DTOs.Financials
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public int CondominiumId { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public string Details { get; set; } = string.Empty;

        // Enriched Data for Display
        public string CompanyName { get; set; } = string.Empty;
        public string CondominiumName { get; set; } = string.Empty;
        public string? CompanyAddress { get; set; }
        public string? CompanyPhone { get; set; }
        public string UnitIdentifier { get; set; } = string.Empty;
        public string ResidentName { get; set; } = string.Empty;
    }
}