using CondoSphere.Core.Enums;

namespace CondoSphere.Core.DTOs.Financials
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? OccurrenceId { get; set; }
        public ExpenseFrequency Frequency { get; set; }
        public int CondominiumId { get; set; }
        public int DayOfBilling { get; set; }
        public bool IsActive { get; set; }
        public List<string> AttachmentUrls { get; set; } = new List<string>();
    }
}