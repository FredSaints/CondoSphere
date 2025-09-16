namespace CondoSphere.Core.DTOs.Reports
{
    public class AdminDashboardDto
    {
        public int TotalCondominiums { get; set; }
        public int TotalUnits { get; set; }
        public int TotalResidents { get; set; }
        public decimal TotalIncomeThisMonth { get; set; }
        public decimal TotalExpensesThisMonth { get; set; }
        public int OpenOccurrences { get; set; }
    }
}