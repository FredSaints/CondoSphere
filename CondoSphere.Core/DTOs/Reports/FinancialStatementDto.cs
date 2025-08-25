namespace CondoSphere.Core.DTOs.Reports
{
    public class FinancialStatementDto
    {
        public DateTime ReportDate { get; set; }
        public string CondominiumName { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Balance => TotalIncome - TotalExpenses;
        public IEnumerable<IncomeItemDto> IncomeItems { get; set; } = new List<IncomeItemDto>();
        public IEnumerable<ExpenseItemDto> ExpenseItems { get; set; } = new List<ExpenseItemDto>();
    }
}