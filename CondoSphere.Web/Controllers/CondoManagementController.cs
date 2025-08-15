using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CondoManager)]
    [Route("condo-management")]
    public class CondoManagementController : Controller
    {
        private readonly ApiClient _apiClient;

        public CondoManagementController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var condominiums = await _apiClient.GetMyManagedCondominiumsAsync();
            return View(condominiums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var condoTask = _apiClient.GetCondominiumDetailsAsync(id);
            var unitsTask = _apiClient.GetUnitsForCondominiumAsync(id);
            var occurrencesTask = _apiClient.GetOccurrencesForCondominiumAsync(id);

            await Task.WhenAll(condoTask, unitsTask, occurrencesTask);

            var condo = await condoTask;
            var units = await unitsTask;
            var occurrences = await occurrencesTask;

            if (condo == null)
            {
                return NotFound();
            }

            var viewModel = new CondominiumDetailsViewModel
            {
                Condominium = condo,
                Units = units,
                Occurrences = occurrences
            };

            return View(viewModel);
        }

        [HttpGet("units/{unitId}/assign-resident")]
        public async Task<IActionResult> AssignResident(int unitId, int condominiumId)
        {
            var unit = await _apiClient.GetUnitByIdAsync(unitId);
            if (unit == null) return NotFound();

            var availableResidents = await _apiClient.GetAvailableResidentsAsync();

            ViewData["UnitIdentifier"] = unit.Identifier;

            var viewModel = new AssignResidentViewModel
            {
                UnitId = unitId,
                CondominiumId = condominiumId,
                AvailableResidents = availableResidents.Select(r => new SelectListItem
                {
                    Text = r.FullName,
                    Value = r.Id.ToString()
                })
            };

            return View(viewModel);
        }

        [HttpGet("units/{unitId}/register-resident")]
        public async Task<IActionResult> RegisterResident(int unitId, int condominiumId)
        {
            var unit = await _apiClient.GetUnitByIdAsync(unitId);
            if (unit == null) return NotFound();

            ViewData["UnitIdentifier"] = unit.Identifier;

            var model = new RegisterResidentViewModel
            {
                UnitId = unitId,
                CondominiumId = condominiumId
            };
            return View(model);
        }

        [HttpPost("units/{unitId}/register-resident")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterResident(RegisterResidentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var unit = await _apiClient.GetUnitByIdAsync(model.UnitId);
                if (unit != null) ViewData["UnitIdentifier"] = unit.Identifier;
                return View(model);
            }

            var dto = new RegisterResidentDto
            {
                UnitId = model.UnitId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var success = await _apiClient.RegisterResidentAsync(model.CondominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "New resident registered and assigned successfully!";
                return RedirectToAction(nameof(Details), new { id = model.CondominiumId });
            }

            ModelState.AddModelError(string.Empty, "Failed to register resident. The email may be in use or the unit may have become occupied.");
            var finalUnit = await _apiClient.GetUnitByIdAsync(model.UnitId);
            if (finalUnit != null) ViewData["UnitIdentifier"] = finalUnit.Identifier;
            return View(model);
        }



        [HttpGet("{condominiumId}/units/create")]
        public IActionResult CreateUnit(int condominiumId)
        {
            ViewData["CondominiumId"] = condominiumId;
            return View();
        }

        [HttpPost("{condominiumId}/units/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUnit(int condominiumId, CreateUpdateUnitDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["CondominiumId"] = condominiumId;
                return View(dto);
            }

            var success = await _apiClient.CreateUnitAsync(condominiumId, dto);
            if (success)
            {
                TempData["SuccessMessage"] = $"Unit '{dto.Identifier}' was created successfully!";
                return RedirectToAction(nameof(Details), new { id = condominiumId });
            }

            ModelState.AddModelError(string.Empty, "Failed to create the unit. Please try again.");
            ViewData["CondominiumId"] = condominiumId;
            return View(dto);
        }

        [HttpPost("units/{unitId}/assign-resident")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignResident(AssignResidentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var availableResidents = await _apiClient.GetAvailableResidentsAsync();
                model.AvailableResidents = availableResidents.Select(r => new SelectListItem
                {
                    Text = $"{r.FirstName} {r.LastName} ({r.Email})",
                    Value = r.Id.ToString()
                });
                return View(model);
            }

            var dto = new AssignResidentDto { ResidentId = model.SelectedResidentId };
            var success = await _apiClient.AssignResidentAsync(model.CondominiumId, model.UnitId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident assigned successfully!";
                return RedirectToAction(nameof(Details), new { id = model.CondominiumId });
            }

            ModelState.AddModelError(string.Empty, "Failed to assign resident. Please ensure the resident is valid and the unit is vacant.");

            var residents = await _apiClient.GetAvailableResidentsAsync();
            model.AvailableResidents = residents.Select(r => new SelectListItem
            {
                Text = $"{r.FirstName} {r.LastName} ({r.Email})",
                Value = r.Id.ToString()
            });
            return View(model);
        }

        [HttpGet("{condominiumId}/occurrences/{occurrenceId}")]
        public async Task<IActionResult> OccurrenceDetails(int condominiumId, int occurrenceId)
        {
            var occurrenceTask = _apiClient.GetOccurrenceDetailsAsync(occurrenceId);
            var interventionsTask = _apiClient.GetInterventionsForOccurrenceAsync(occurrenceId);
            var employeesTask = _apiClient.GetAvailableEmployeesAsync();
            var expensesTask = _apiClient.GetExpensesForOccurrenceAsync(occurrenceId);

            await Task.WhenAll(occurrenceTask, interventionsTask, employeesTask, expensesTask);

            var occurrence = await occurrenceTask;
            var interventions = await interventionsTask;
            var employees = await employeesTask;
            var expenses = await expensesTask;

            if (occurrence == null)
            {
                return NotFound();
            }
            if (occurrence.CondominiumId != condominiumId)
            {
                return Forbid();
            }

            ViewData["AvailableEmployees"] = new SelectList(employees, "Id", "FullName");

            var viewModel = new OccurrenceDetailsViewModel
            {
                Occurrence = occurrence,
                Interventions = interventions,
                LinkedExpenses = expenses,
                NewIntervention = new CreateInterventionDto
                {
                    OccurrenceId = occurrenceId,
                    StartDate = DateTime.Now
                },
                NewExpense = new CreateExpenseDto
                {
                    OccurrenceId = occurrenceId,
                    CondominiumId = condominiumId,
                    ExpenseDate = DateTime.Now
                }
            };
            if (string.IsNullOrWhiteSpace(viewModel.NewExpense.Title))
            {
                viewModel.NewExpense.Title = $"Expense for: {viewModel.Occurrence.Title}";
            }
            return View(viewModel);
        }

        [HttpPost("{condominiumId}/occurrences/{occurrenceId}/update-status")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOccurrenceStatus(int condominiumId, int occurrenceId, UpdateOccurrenceStatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid status selected.";
                return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
            }

            var (success, message) = await _apiClient.UpdateOccurrenceStatusAsync(occurrenceId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = message;
            }
            else
            {
                TempData["ErrorMessage"] = message;
            }

            return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
        }

        [HttpPost("{condominiumId}/occurrences/{occurrenceId}/create-intervention")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIntervention(int condominiumId, int occurrenceId, [Bind(Prefix = "NewIntervention")] CreateInterventionDto interventionDto)
        {
            if (!ModelState.IsValid)
            {
                var occurrenceTask = _apiClient.GetOccurrenceDetailsAsync(occurrenceId);
                var interventionsTask = _apiClient.GetInterventionsForOccurrenceAsync(occurrenceId);
                var employeesTask = _apiClient.GetAvailableEmployeesAsync();
                var expensesTask = _apiClient.GetExpensesForOccurrenceAsync(occurrenceId);
                await Task.WhenAll(occurrenceTask, interventionsTask, employeesTask, expensesTask);

                var occurrence = await occurrenceTask;

                if (occurrence == null)
                {
                    return NotFound();
                }

                var interventions = await interventionsTask;
                var employees = await employeesTask;
                var expenses = await expensesTask;

                ViewData["AvailableEmployees"] = new SelectList(employees, "Id", "FullName");

                var viewModel = new OccurrenceDetailsViewModel
                {
                    Occurrence = occurrence,
                    Interventions = interventions,
                    LinkedExpenses = expenses,
                    NewIntervention = interventionDto,
                    NewExpense = new CreateExpenseDto { OccurrenceId = occurrenceId, CondominiumId = condominiumId, ExpenseDate = DateTime.Now }
                };
                return View("OccurrenceDetails", viewModel);
            }
            var result = await _apiClient.CreateInterventionAsync(interventionDto);
            if (result != null)
            {
                TempData["SuccessMessage"] = "Intervention successfully created.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create intervention.";
            }

            return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
        }

        [HttpPost("{condominiumId}/occurrences/{occurrenceId}/update-intervention-status")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInterventionStatus(int condominiumId, int occurrenceId, int interventionId, InterventionStatus status)
        {
            var dto = new UpdateInterventionStatusDto { Status = status };

            var success = await _apiClient.UpdateInterventionStatusAsync(interventionId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Intervention status has been updated.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update intervention status.";
            }

            return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
        }

        [HttpPost("{condominiumId}/occurrences/{occurrenceId}/record-expense")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecordExpense(
    int condominiumId,
    int occurrenceId,
    [Bind(Prefix = "NewExpense")] CreateExpenseDto expenseDto,
    List<IFormFile> attachmentFiles)
        {
            if (string.IsNullOrWhiteSpace(expenseDto.Title) ||
                string.IsNullOrWhiteSpace(expenseDto.Description) ||
                expenseDto.Amount <= 0 ||
                expenseDto.ExpenseDate == default ||
                expenseDto.CondominiumId <= 0)
            {
                ModelState.AddModelError(string.Empty, "Preencha Título, Montante (>0), Data e Condomínio.");
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the errors in the expense form and try again.";

                var occurrenceTask = _apiClient.GetOccurrenceDetailsAsync(occurrenceId);
                var interventionsTask = _apiClient.GetInterventionsForOccurrenceAsync(occurrenceId);
                var employeesTask = _apiClient.GetAvailableEmployeesAsync();
                var expensesTask = _apiClient.GetExpensesForOccurrenceAsync(occurrenceId);
                await Task.WhenAll(occurrenceTask, interventionsTask, employeesTask, expensesTask);

                var occurrence = await occurrenceTask;
                if (occurrence == null) return NotFound();

                var viewModel = new OccurrenceDetailsViewModel
                {
                    Occurrence = occurrence,
                    Interventions = await interventionsTask,
                    LinkedExpenses = await expensesTask,
                    NewExpense = expenseDto,
                    NewIntervention = new CreateInterventionDto
                    {
                        OccurrenceId = occurrenceId,
                        StartDate = DateTime.Now
                    }
                };

                ViewData["AvailableEmployees"] = new SelectList(await employeesTask, "Id", "FullName");
                return View("OccurrenceDetails", viewModel);
            }

            var (expense, apiError) = await _apiClient.CreateExpenseAsync(expenseDto, attachmentFiles);
            if (expense != null)
            {
                TempData["SuccessMessage"] = "Expense recorded successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = string.IsNullOrWhiteSpace(apiError)
                    ? "Failed to record expense."
                    : $"Failed to record expense: {apiError}";
            }

            return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
        }


        [HttpPost("unassign-resident")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnassignResidentFromUnit(int condominiumId, int residentId, int unitId)
        {
            var success = await _apiClient.UnassignResidentFromUnitAsync(residentId, unitId);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident has been unassigned from the unit.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to unassign resident.";
            }

            return RedirectToAction(nameof(Details), new { id = condominiumId });
        }

        [HttpGet("expenses/{expenseId}")]
        public async Task<IActionResult> ExpenseDetails(int expenseId, int occurrenceId, int condominiumId)
        {
            var expense = await _apiClient.GetExpenseDetailsAsync(expenseId);
            if (expense == null)
            {
                return NotFound();
            }

            // Pass these IDs to the view so the "Back" button works correctly.
            ViewData["OccurrenceId"] = occurrenceId;
            ViewData["CondominiumId"] = condominiumId;

            return View(expense);
        }
    }
}