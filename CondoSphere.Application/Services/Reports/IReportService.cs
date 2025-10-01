using CondoSphere.Core.DTOs.Reports;

namespace CondoSphere.Application.Services.Reports
{
    /// <summary>
    /// I Report Service.
    /// </summary>
    public interface IReportService
    {
        Task<FinancialStatementDto?> GenerateFinancialStatementAsync(int condominiumId, int year, int month, int companyId);
        Task<AdminDashboardDto?> GetAdminDashboardAsync(int companyId);
        Task<IEnumerable<MonthlyFinancialsDto>> GetMonthlyFinancialsAsync(int companyId);
        Task<IEnumerable<StatusSummaryDto>> GetOccurrenceStatusSummaryAsync(int companyId);
        Task<IEnumerable<CondoHotspotDto>> GetCondoHotspotsAsync(int companyId);
    }
}