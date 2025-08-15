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
        public async Task<IActionResult> CreateExpense([FromForm] CreateExpenseDto dto, [FromForm] List<IFormFile> attachmentFiles)
        {
            Console.WriteLine($"[API] CreateExpense ContentType='{Request.ContentType}', HasFormContentType={Request.HasFormContentType}");
            Console.WriteLine($"[API] DTO => Title='{dto.Title}', Amount={dto.Amount}, Date={dto.ExpenseDate:o}, CondoId={dto.CondominiumId}, OccurrenceId={dto.OccurrenceId}");
            Console.WriteLine($"[API] attachmentFiles => {(attachmentFiles == null ? "null" : attachmentFiles.Count.ToString())}");
                if (attachmentFiles != null)
                        foreach (var f in attachmentFiles)
                Console.WriteLine($"[API] IFormFile => Name='{f.Name}', FileName='{f.FileName}', ContentType='{f.ContentType}', Length={f.Length}");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var companyId = _currentUserService.CompanyId;
            Console.WriteLine($"[API] CurrentUserService.CompanyId={(companyId.HasValue ? companyId.Value.ToString() : "null")}");
            if (companyId == null) return Unauthorized();

            var result = await _expenseService.CreateExpenseAsync(dto, companyId.Value, attachmentFiles);
            Console.WriteLine($"[API] ExpenseService.CreateExpenseAsync returned {(result == null ? "NULL" : "OK")}");

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

        [HttpGet("{expenseId}")]
        public async Task<IActionResult> GetExpenseById(int expenseId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized();
            }

            var expense = await _expenseService.GetExpenseByIdAsync(expenseId, companyId.Value);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }
    }
}