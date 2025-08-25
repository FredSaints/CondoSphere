using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Reports;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/reports")]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ICurrentUserService _currentUserService;

        public ReportsController(IReportService reportService, ICurrentUserService currentUserService)
        {
            _reportService = reportService;
            _currentUserService = currentUserService;
        }

        [HttpGet("condominiums/{condominiumId}/financial-statement")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetFinancialStatement(int condominiumId, [FromQuery] int year, [FromQuery] int month)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var report = await _reportService.GenerateFinancialStatementAsync(condominiumId, year, month, companyId.Value);
            if (report == null) return NotFound();

            return Ok(report);
        }

        [HttpGet("admin-dashboard")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<ActionResult<AdminDashboardDto>> GetAdminDashboard()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var dashboardData = await _reportService.GetAdminDashboardAsync(companyId.Value);
            return Ok(dashboardData);
        }

        [HttpGet("monthly-financials")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<ActionResult<IEnumerable<MonthlyFinancialsDto>>> GetMonthlyFinancials()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var financialData = await _reportService.GetMonthlyFinancialsAsync(companyId.Value);

            return Ok(financialData);
        }

        [HttpGet("occurrence-status-summary")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<ActionResult<IEnumerable<StatusSummaryDto>>> GetOccurrenceStatusSummary()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var summaryData = await _reportService.GetOccurrenceStatusSummaryAsync(companyId.Value);

            return Ok(summaryData);
        }

        [HttpGet("condo-hotspots")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<ActionResult<IEnumerable<CondoHotspotDto>>> GetCondoHotspots()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var hotspotData = await _reportService.GetCondoHotspotsAsync(companyId.Value);

            return Ok(hotspotData);
        }
    }
}