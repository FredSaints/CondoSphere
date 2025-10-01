namespace CondoSphere.Core.DTOs.Financials
{
    /// <summary>
    /// Quota Breakdown DTO.
    /// </summary>
    public class QuotaBreakdownDto
    {
        public UnitQuotaDto QuotaDetails { get; set; }
        public IEnumerable<ExpenseDto> FixedExpenses { get; set; }
        public IEnumerable<ExpenseDto> OneTimeExpenses { get; set; }
        public int TotalUnitsInCondo { get; set; }
    }
}