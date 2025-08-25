using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Notifications;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.DTOs.Reports;
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
            var fixedExpensesTask = _apiClient.GetFixedExpensesAsync(id);
            var quotasTask = _apiClient.GetQuotasForCondominiumAsync(id);
            var documentsTask = _apiClient.GetDocumentsForCondominiumAsync(id);

            await Task.WhenAll(condoTask, unitsTask, occurrencesTask, fixedExpensesTask, quotasTask, documentsTask);

            var condo = await condoTask;
            if (condo == null)
            {
                return NotFound();
            }

            var viewModel = new CondominiumDetailsViewModel
            {
                Condominium = condo,
                Units = await unitsTask,
                Occurrences = await occurrencesTask,
                FixedExpenses = await fixedExpensesTask,
                AllQuotas = await quotasTask,
                Documents = await documentsTask
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
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var success = await _apiClient.RegisterResidentAsync(model.CondominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "New resident registered and assigned successfully!";
                TempData["ActiveTab"] = "units-tab";
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
                TempData["ActiveTab"] = "units-tab";
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
                TempData["ActiveTab"] = "units-tab";
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
                TempData["ActiveTab"] = "units-tab";
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

        [HttpGet("{condominiumId}/fixed-expenses")]
        public async Task<IActionResult> FixedExpenses(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null) return NotFound();

            var fixedExpenses = await _apiClient.GetFixedExpensesAsync(condominiumId);

            ViewData["Condominium"] = condo;
            return View(fixedExpenses);
        }

        // GET: /condo-management/{condominiumId}/fixed-expenses/create
        [HttpGet("{condominiumId}/fixed-expenses/create")]
        public async Task<IActionResult> CreateFixedExpense(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null) return NotFound();

            var model = new CreateUpdateFixedExpenseDto
            {
                CondominiumId = condominiumId
            };

            ViewData["CondominiumName"] = condo.Name;
            return View(model);
        }

        // POST: /condo-management/{condominiumId}/fixed-expenses/create
        [HttpPost("{condominiumId}/fixed-expenses/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFixedExpense(int condominiumId, CreateUpdateFixedExpenseDto model)
        {
            if (!ModelState.IsValid)
            {
                var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
                ViewData["CondominiumName"] = condo?.Name;
                return View(model);
            }

            var result = await _apiClient.CreateFixedExpenseAsync(condominiumId, model);

            if (result != null)
            {
                TempData["SuccessMessage"] = "Fixed expense created successfully.";
                return RedirectToAction("FixedExpenses", new { condominiumId = condominiumId });
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the expense.");
            var finalCondo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            ViewData["CondominiumName"] = finalCondo?.Name;
            return View(model);
        }

        // GET: /condo-management/{condominiumId}/fixed-expenses/edit/{expenseId}
        [HttpGet("{condominiumId}/fixed-expenses/edit/{expenseId}")]
        public async Task<IActionResult> EditFixedExpense(int condominiumId, int expenseId)
        {
            var companyId = int.Parse(User.FindFirst("companyId").Value);
            var expense = await _apiClient.GetExpenseDetailsAsync(expenseId); // Re-use the existing client method
            if (expense == null) return NotFound();

            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null) return NotFound();

            // Map the full ExpenseDto to the smaller DTO needed for the edit form
            var model = new CreateUpdateFixedExpenseDto
            {
                Title = expense.Title,
                Description = expense.Description,
                Amount = expense.Amount,
                Frequency = expense.Frequency,
                DayOfBilling = expense.DayOfBilling,
                CondominiumId = condominiumId
            };

            ViewData["CondominiumName"] = condo.Name;
            ViewData["ExpenseId"] = expenseId;
            return View(model);
        }

        // POST: /condo-management/{condominiumId}/fixed-expenses/edit/{expenseId}
        [HttpPost("{condominiumId}/fixed-expenses/edit/{expenseId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFixedExpense(int condominiumId, int expenseId, CreateUpdateFixedExpenseDto model)
        {
            if (!ModelState.IsValid)
            {
                var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
                ViewData["CondominiumName"] = condo?.Name;
                ViewData["ExpenseId"] = expenseId;
                return View(model);
            }

            var result = await _apiClient.UpdateFixedExpenseAsync(expenseId, condominiumId, model);

            if (result != null)
            {
                TempData["SuccessMessage"] = "Fixed expense updated successfully.";
                return RedirectToAction("FixedExpenses", new { condominiumId = condominiumId });
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the expense.");
            var finalCondo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            ViewData["CondominiumName"] = finalCondo?.Name;
            ViewData["ExpenseId"] = expenseId;
            return View(model);
        }

        // POST: /condo-management/{condominiumId}/fixed-expenses/toggle/{expenseId}
        [HttpPost("{condominiumId}/fixed-expenses/toggle/{expenseId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleFixedExpenseStatus(int condominiumId, int expenseId)
        {
            var success = await _apiClient.ToggleFixedExpenseStatusAsync(expenseId, condominiumId);
            if (success)
            {
                TempData["SuccessMessage"] = "Expense status updated.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update expense status.";
            }
            TempData["ActiveTab"] = "financials-tab";
            return RedirectToAction("Details", new { id = condominiumId });
        }

        // POST: /condo-management/{condominiumId}/fixed-expenses/delete/{expenseId}
        [HttpPost("{condominiumId}/fixed-expenses/delete/{expenseId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFixedExpense(int condominiumId, int expenseId)
        {
            var success = await _apiClient.DeleteFixedExpenseAsync(expenseId, condominiumId);
            if (success)
            {
                TempData["SuccessMessage"] = "Fixed expense has been deleted.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete expense.";
            }
            return RedirectToAction("FixedExpenses", new { condominiumId });
        }

        [HttpGet("{id}/generate-fees")]
        public async Task<IActionResult> GenerateFees(int id)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(id);
            if (condo == null) return NotFound();
            return View(condo);
        }

        [HttpPost("{id}/generate-fees")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateFees(int id, int year, int month)
        {
            var (success, message) = await _apiClient.GenerateMonthlyQuotasAsync(id, year, month);
            if (success)
            {
                TempData["SuccessMessage"] = message;
                TempData["ActiveTab"] = "financials-tab";
            }
            else
            {
                TempData["ErrorMessage"] = message;
            }
            return RedirectToAction("Details", new { id });
        }

        [HttpGet("{condominiumId}/quotas")]
        public async Task<IActionResult> QuotaManagement(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null) return NotFound();

            var quotas = await _apiClient.GetQuotasForCondominiumAsync(condominiumId);

            ViewData["Condominium"] = condo;
            return View(quotas);
        }

        [HttpPost("quotas/confirm")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmPayment(int quotaId, int condominiumId)
        {
            var (success, message) = await _apiClient.ConfirmPaymentAsync(quotaId);
            if (success)
            {
                TempData["SuccessMessage"] = message;
            }
            else
            {
                TempData["ErrorMessage"] = message;
            }

            TempData["ActiveTab"] = "financials-tab"; 
            return RedirectToAction("Details", new { id = condominiumId });
        }

        [HttpGet("receipts/{id}")]
        public async Task<IActionResult> Receipt(int id)
        {
            var receipt = await _apiClient.GetReceiptDetailsForManagerAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            return View(receipt);
        }


        [HttpGet("{condominiumId}/documents")]
        public async Task<IActionResult> Documents(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null) return NotFound();

            var documents = await _apiClient.GetDocumentsForCondominiumAsync(condominiumId);

            ViewData["Condominium"] = condo;
            ViewData["NewDocument"] = new CreateDocumentDto();

            return View(documents);
        }

        [HttpPost("{condominiumId}/documents/upload")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadDocument(int condominiumId, [Bind(Prefix = "newDocument")] CreateDocumentDto dto, IFormFile file)
        {
            if (!ModelState.IsValid || file == null || file.Length == 0)
            {
                if (file == null || file.Length == 0)
                {
                    ModelState.AddModelError("file", "Please select a file to upload.");
                }

                TempData["ErrorMessage"] = "Failed to upload document. Please correct the errors and try again.";
                TempData["ActiveTab"] = "documents-tab";

                var condoTask = _apiClient.GetCondominiumDetailsAsync(condominiumId);
                var unitsTask = _apiClient.GetUnitsForCondominiumAsync(condominiumId);
                var occurrencesTask = _apiClient.GetOccurrencesForCondominiumAsync(condominiumId);
                var fixedExpensesTask = _apiClient.GetFixedExpensesAsync(condominiumId);
                var quotasTask = _apiClient.GetQuotasForCondominiumAsync(condominiumId);
                var documentsTask = _apiClient.GetDocumentsForCondominiumAsync(condominiumId);

                await Task.WhenAll(condoTask, unitsTask, occurrencesTask, fixedExpensesTask, quotasTask, documentsTask);

                var condo = await condoTask;
                if (condo == null) return NotFound();

                var viewModel = new CondominiumDetailsViewModel
                {
                    Condominium = condo,
                    Units = await unitsTask,
                    Occurrences = await occurrencesTask,
                    FixedExpenses = await fixedExpensesTask,
                    AllQuotas = await quotasTask,
                    Documents = await documentsTask
                };
                ViewData["NewDocumentModel"] = dto;
                return View("Details", viewModel);
            }

            var result = await _apiClient.UploadDocumentAsync(condominiumId, dto, file);
            if (result != null)
            {
                TempData["SuccessMessage"] = "Document uploaded successfully.";
                TempData["ActiveTab"] = "documents-tab";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to upload document.";
            }

            return RedirectToAction("Details", new { id = condominiumId });
        }

        [HttpPost("documents/{documentId}/delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDocument(int documentId, int condominiumId)
        {
            var success = await _apiClient.DeleteDocumentAsync(documentId);
            if (success)
            {
                TempData["SuccessMessage"] = "Document deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete document.";
            }
            TempData["ActiveTab"] = "documents-tab";
            return RedirectToAction("Details", new { id= condominiumId });
        }

        [HttpGet("documents/{documentId}/view")]
        public async Task<IActionResult> ViewDocument(int documentId)
        {
            var response = await _apiClient.DownloadDocumentAsync(documentId);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";
                var fileName = response.Content.Headers.ContentDisposition?.FileName?.Trim('"') ?? "document";

                Response.Headers["Content-Disposition"] = new System.Net.Mime.ContentDisposition
                {
                    FileName = fileName,
                    Inline = true,
                }.ToString();

                return File(stream, contentType);
            }
            return NotFound();
        }

        [HttpGet("documents/{documentId}/download")]
        public async Task<IActionResult> DownloadDocument(int documentId)
        {
            var response = await _apiClient.DownloadDocumentAsync(documentId);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";
                var fileName = response.Content.Headers.ContentDisposition?.FileName?.Trim('"') ?? "downloaded-file";

                return File(stream, contentType, fileName);
            }
            return NotFound();
        }

        [HttpGet("{condominiumId}/announcement")]
        public async Task<IActionResult> Announcement(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null) return NotFound();

            ViewData["Condominium"] = condo;
            return View(new AnnouncementDto());
        }

        [HttpPost("{condominiumId}/announcement")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Announcement(int condominiumId, AnnouncementDto dto)
        {
            if (!ModelState.IsValid)
            {
                var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
                ViewData["Condominium"] = condo;
                return View(dto);
            }

            var (success, message) = await _apiClient.SendAnnouncementAsync(condominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = message;
                TempData["ActiveTab"] = "communications-tab";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to send announcement: " + message;
            }

            return RedirectToAction("Details", new { id = condominiumId });
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> AllNotifications()
        {
            var notifications = await _apiClient.GetAllMyNotificationsAsync();
            return View(notifications);
        }

        [HttpPost("quotas/reject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectPayment(int quotaId, int condominiumId, RejectPaymentDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Rejection reason must be at least 10 characters long.";
                return RedirectToAction("QuotaManagement", new { condominiumId });
            }

            var (success, message) = await _apiClient.RejectPaymentProofAsync(quotaId, dto);
            if (success)
            {
                TempData["SuccessMessage"] = message;
            }
            else
            {
                TempData["ErrorMessage"] = message;
            }

            return RedirectToAction("QuotaManagement", new { condominiumId });
        }

        [HttpGet("{condominiumId}/financial-report")]
        public async Task<IActionResult> FinancialReport(int condominiumId, int? year, int? month)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null)
            {
                return NotFound();
            }

            ViewData["Condominium"] = condo;
            FinancialStatementDto? report = null;

            if (year.HasValue && month.HasValue)
            {
                report = await _apiClient.GetFinancialStatementAsync(condominiumId, year.Value, month.Value);
            }
            return View(report);
        }
    }
}