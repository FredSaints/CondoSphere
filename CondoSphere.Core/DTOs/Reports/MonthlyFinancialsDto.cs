namespace CondoSphere.Core.DTOs.Reports
{
    /// <summary>
    /// Monthly Financials DTO.
    /// </summary>
    public class MonthlyFinancialsDto
    {
        public string Month { get; set; } = string.Empty;
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
    }
}