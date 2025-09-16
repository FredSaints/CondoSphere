using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Reports;

namespace CondoSphere.Application.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FinancialStatementDto?> GenerateFinancialStatementAsync(int condominiumId, int year, int month, int companyId)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condo == null) return null;

            // 1. Fetch Income
            var payments = await _unitOfWork.QuotaPayments.GetPaymentsForPeriodAsync(condominiumId, year, month);
            var units = await _unitOfWork.Units.GetByIdsAsync(payments.Select(p => p.UnitId).Distinct());
            var unitLookup = units.ToDictionary(u => u.Id, u => u.Identifier);

            var incomeItems = payments.Select(p => new IncomeItemDto
            {
                PaymentDate = p.PaymentDate,
                Amount = p.Amount,
                UnitIdentifier = unitLookup.TryGetValue(p.UnitId, out var identifier) ? identifier : "N/A",
                Description = $"Payment for Quota #{p.UnitQuotaId}"
            }).ToList();

            // 2. Fetch Expenses
            var oneTimeExpenses = await _unitOfWork.Expenses.GetOneTimeExpensesForPeriodAsync(condominiumId, year, month);
            var fixedExpenses = (await _unitOfWork.Expenses.GetFixedExpensesByCondominiumAsync(condominiumId)).Where(e => e.IsActive);

            var allExpenses = oneTimeExpenses.Concat(fixedExpenses);

            var expenseItems = allExpenses.Select(e => new ExpenseItemDto
            {
                ExpenseDate = e.ExpenseDate,
                Title = e.Title,
                Category = e.Category,
                Amount = e.Amount
            }).ToList();

            // 3. Assemble the final report DTO
            var report = new FinancialStatementDto
            {
                ReportDate = DateTime.UtcNow,
                CondominiumName = condo.Name,
                Year = year,
                Month = month,
                IncomeItems = incomeItems,
                ExpenseItems = expenseItems,
                TotalIncome = incomeItems.Sum(i => i.Amount),
                TotalExpenses = expenseItems.Sum(e => e.Amount)
            };

            return report;
        }

        public async Task<AdminDashboardDto?> GetAdminDashboardAsync(int companyId)
        {
            var now = DateTime.UtcNow;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var nextMonth = firstDayOfMonth.AddMonths(1);

            var condos = (await _unitOfWork.Condominiums.GetAllForCompanyAsync(companyId)).ToList();
            var condoIds = condos.Select(c => c.Id).ToList();

            var totalUnits = await _unitOfWork.Units.GetCountByCondominiumIdsAsync(condoIds);
            var totalResidents = await _unitOfWork.Users.GetCountByRoleAsync(RoleConstants.CondoResident, companyId);
            var totalIncome = await _unitOfWork.QuotaPayments.GetTotalIncomeForPeriodAsync(companyId, firstDayOfMonth, nextMonth);
            var totalExpenses = await _unitOfWork.Expenses.GetTotalExpensesForPeriodAsync(companyId, firstDayOfMonth, nextMonth);
            var openOccurrences = await _unitOfWork.Occurrences.GetOpenCountForCompanyAsync(companyId);

            var dashboard = new AdminDashboardDto
            {
                TotalCondominiums = condos.Count(),
                TotalUnits = totalUnits,
                TotalResidents = totalResidents,
                TotalIncomeThisMonth = totalIncome,
                TotalExpensesThisMonth = totalExpenses,
                OpenOccurrences = openOccurrences
            };

            return dashboard;
        }

        public async Task<IEnumerable<MonthlyFinancialsDto>> GetMonthlyFinancialsAsync(int companyId)
        {
            var monthlyData = new List<MonthlyFinancialsDto>();
            var today = DateTime.UtcNow;

            for (int i = 0; i > -6; i--)
            {
                var targetDate = today.AddMonths(i);
                var year = targetDate.Year;
                var month = targetDate.Month;

                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1);

                var totalIncome = await _unitOfWork.QuotaPayments.GetTotalIncomeForPeriodAsync(companyId, startDate, endDate);
                var totalExpenses = await _unitOfWork.Expenses.GetTotalExpensesForPeriodAsync(companyId, startDate, endDate);

                monthlyData.Add(new MonthlyFinancialsDto
                {
                    Month = startDate.ToString("MMM yyyy"),
                    TotalIncome = totalIncome,
                    TotalExpenses = totalExpenses
                });
            }

            monthlyData.Reverse();
            return monthlyData;
        }

        public async Task<IEnumerable<StatusSummaryDto>> GetOccurrenceStatusSummaryAsync(int companyId)
        {
            return await _unitOfWork.Occurrences.GetOccurrenceStatusSummaryAsync(companyId);
        }

        public async Task<IEnumerable<CondoHotspotDto>> GetCondoHotspotsAsync(int companyId)
        {
            return await _unitOfWork.Occurrences.GetCondoHotspotsAsync(companyId, 5);
        }
    }
}