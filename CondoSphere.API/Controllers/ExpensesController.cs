using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Financials;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Financials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly ICurrentUserService _currentUserService;

        public ExpensesController(IExpenseService expenseService, ICurrentUserService currentUserService)
        {
            _expenseService = expenseService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromForm] CreateExpenseDto dto, List<IFormFile> attachmentFiles)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var result = await _expenseService.CreateExpenseAsync(dto, companyId.Value, attachmentFiles);

            if (result == null)
            {
                return BadRequest("Invalid Condominium ID or permission denied.");
            }

            return Ok(result);
        }

        [HttpGet("~/api/occurrences/{occurrenceId}/expenses")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetExpensesForOccurrence(int occurrenceId)
        {
            var expenses = await _expenseService.GetExpensesForOccurrenceAsync(occurrenceId);
            return Ok(expenses);
        }
    }
}