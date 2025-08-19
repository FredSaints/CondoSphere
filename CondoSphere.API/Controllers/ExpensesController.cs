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

        [HttpGet("~/api/condominiums/{condominiumId}/fixed-expenses")]
        public async Task<IActionResult> GetFixedExpenses(int condominiumId)
        {
            var expenses = await _expenseService.GetFixedExpensesForCondominiumAsync(condominiumId);
            return Ok(expenses);
        }

        [HttpPost("~/api/condominiums/{condominiumId}/fixed-expenses")]
        public async Task<IActionResult> CreateFixedExpense(int condominiumId, [FromBody] CreateUpdateFixedExpenseDto dto)
        {
            if (!ModelState.IsValid || condominiumId != dto.CondominiumId) return BadRequest();

            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var newExpense = await _expenseService.CreateFixedExpenseAsync(dto, companyId.Value);
            return CreatedAtAction(nameof(GetExpenseById), new { expenseId = newExpense.Id }, newExpense);
        }


        // PUT: /api/condominiums/{condominiumId}/fixed-expenses/{expenseId}
        [HttpPut("~/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}")]
        public async Task<IActionResult> UpdateFixedExpense(int condominiumId, int expenseId, [FromBody] CreateUpdateFixedExpenseDto dto)
        {
            if (!ModelState.IsValid || condominiumId != dto.CondominiumId) return BadRequest();

            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var updatedExpense = await _expenseService.UpdateFixedExpenseAsync(expenseId, dto, companyId.Value);

            if (updatedExpense == null) return NotFound();

            return Ok(updatedExpense);
        }

        // PATCH: /api/condominiums/{condominiumId}/fixed-expenses/{expenseId}/toggle-status
        [HttpPatch("~/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}/toggle-status")]
        public async Task<IActionResult> ToggleFixedExpenseStatus(int condominiumId, int expenseId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            // Optional: Check if the expense belongs to the condominium for added security
            var expense = await _expenseService.GetExpenseByIdAsync(expenseId, companyId.Value);
            if (expense == null || expense.CondominiumId != condominiumId) return Forbid();

            var success = await _expenseService.ToggleFixedExpenseStatusAsync(expenseId, companyId.Value);
            if (!success) return NotFound();

            return NoContent();
        }

        // DELETE: /api/condominiums/{condominiumId}/fixed-expenses/{expenseId}
        [HttpDelete("~/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}")]
        public async Task<IActionResult> DeleteFixedExpense(int condominiumId, int expenseId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            // Optional: Security check similar to the Patch method above
            var expense = await _expenseService.GetExpenseByIdAsync(expenseId, companyId.Value);
            if (expense == null || expense.CondominiumId != condominiumId) return Forbid();

            var success = await _expenseService.DeleteFixedExpenseAsync(expenseId, companyId.Value);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}