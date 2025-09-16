namespace CondoSphere.Core.DTOs.Reports
{
    public class ExpenseItemDto
    {
        public DateTime ExpenseDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}