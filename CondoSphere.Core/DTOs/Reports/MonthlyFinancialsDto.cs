namespace CondoSphere.Core.DTOs.Reports
{
    public class MonthlyFinancialsDto
    {
        public string Month { get; set; } = string.Empty;
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
    }
}