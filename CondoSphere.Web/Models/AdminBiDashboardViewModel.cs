using CondoSphere.Core.DTOs.Reports;

namespace CondoSphere.Web.Models
{
    public class AdminBiDashboardViewModel
    {
        public AdminDashboardDto MainStats { get; set; }
        public IEnumerable<MonthlyFinancialsDto> FinancialTrend { get; set; }
        public IEnumerable<StatusSummaryDto> OccurrenceSummary { get; set; }
        public IEnumerable<CondoHotspotDto> CondoHotspots { get; set; }
    }
}