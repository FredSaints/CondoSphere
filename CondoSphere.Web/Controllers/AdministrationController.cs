using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Reports;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CompanyAdmin)]
    [Route("administration")]    public class AdministrationController : Controller
    {
        private readonly ApiClient _apiClient;

        public AdministrationController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]        public async Task<IActionResult> Index()
        {
            var usersTask = _apiClient.GetUsersAsync();
            var condominiumsTask = _apiClient.GetCondominiumsAsync();

            await Task.WhenAll(usersTask, condominiumsTask);

            var viewModel = new ManagementDashboardViewModel
            {
                Users = await usersTask ?? new List<UserListDto>(),
                Condominiums = await condominiumsTask ?? new List<CondominiumDto>()
            };

            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            int.TryParse(userIdClaim, out var currentUserId);
            ViewData["CurrentUserId"] = currentUserId;          return View(viewModel);
        }

        [HttpGet("register-manager")]        public IActionResult RegisterManager()
        {
            return View();
        }

        [HttpPost("register-manager")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Register Manager action.
/// </summary>
public async Task<IActionResult> RegisterManager(RegisterManagerDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.RegisterManagerAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Manager registration initiated. They will receive an email to set their password.";
                return RedirectToAction(nameof(Index));
            }       ModelState.AddModelError(string.Empty, "Failed to register manager. The email may already be in use.");
            return View(model);
        }

        [HttpGet("create-condominium")]
/// <summary>
/// Handles the Create Condominium action.
/// </summary>
public IActionResult CreateCondominium()
        {
            return View();
        }

        [HttpPost("create-condominium")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Create Condominium action.
/// </summary>
public async Task<IActionResult> CreateCondominium(CreateUpdateCondominiumDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.CreateCondominiumAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Condominium created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the condominium. Please try again.");
            return View(model);
        }

        [HttpGet("condominiums/{condominiumId}/assign-manager")]
/// <summary>
/// Handles the Assign Manager action.
/// </summary>
public async Task<IActionResult> AssignManager(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null)
            {              return NotFound();
            }

            var managers = await _apiClient.GetAvailableManagersAsync();

            ViewData["Condominium"] = condo;ViewData["AvailableManagers"] = managers.Select(m => new SelectListItem
            {
                Text = $"{m.FirstName} {m.LastName} ({m.Email})",
                Value = m.Id.ToString()
            });

            return View(new AssignManagerViewModel());
        }

        [HttpPost("condominiums/{condominiumId}/assign-manager")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Assign Manager action.
/// </summary>
public async Task<IActionResult> AssignManager(int condominiumId, AssignManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await RepopulateAssignManagerViewDataAsync(condominiumId);
                return View(model);
            }

            var dto = new AssignManagerDto { ManagerId = model.SelectedManagerId };
            var success = await _apiClient.AssignManagerAsync(condominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Manager assigned successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while assigning the manager. Please verify the manager is valid and try again.");

            await RepopulateAssignManagerViewDataAsync(condominiumId);       return View(model);
        }

        private async Task RepopulateAssignManagerViewDataAsync(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            var managers = await _apiClient.GetAvailableManagersAsync();
            ViewData["Condominium"] = condo;
            ViewData["AvailableManagers"] = managers.Select(m => new SelectListItem
            {
                Text = $"{m.FirstName} {m.LastName} ({m.Email})",
                Value = m.Id.ToString()
            });
        }

        [HttpPost("users/{userId}/deactivate")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Deactivate User action.
/// </summary>
public async Task<IActionResult> DeactivateUser(int userId)
        {
            var success = await _apiClient.DeactivateUserAsync(userId);
            if (success)
            {
                TempData["SuccessMessage"] = "User successfully deactivated.";
            }           else
            {
                TempData["ErrorMessage"] = "Failed to deactivate user.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("users/{userId}/activate")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Activate User action.
/// </summary>
public async Task<IActionResult> ActivateUser(int userId)
        {
            var success = await _apiClient.ActivateUserAsync(userId);
            if (success)
            {
                TempData["SuccessMessage"] = "User successfully activated.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to activate user.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("register-employee")]
/// <summary>
/// Handles the Register Employee action.
/// </summary>
public IActionResult RegisterEmployee()
        {    return View();
        }

        [HttpPost("register-employee")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Register Employee action.
/// </summary>
public async Task<IActionResult> RegisterEmployee(RegisterManagerDto model)
        {
            if (!ModelState.IsValid)
            {return View(model);
            }

            var success = await _apiClient.RegisterEmployeeAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Employee registration initiated. They will receive an email to set their password.";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to register employee. The email may already be in use.");
            return View(model);
        }

        [HttpGet("company-profile")]
/// <summary>
/// Handles the Company Profile action.
/// </summary>
public async Task<IActionResult> CompanyProfile()
        {
            var model = await _apiClient.GetCompanyProfileAsync();
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost("company-profile")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Company Profile action.
/// </summary>
public async Task<IActionResult> CompanyProfile(CompanyProfileDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.UpdateCompanyProfileAsync(model);
            if (success)
            {
                TempData["SuccessMessage"] = "Company profile updated successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the profile.");
            return View(model);
        }

        [HttpGet("dashboard")]
/// <summary>
/// Handles the Dashboard action.
/// </summary>
public async Task<IActionResult> Dashboard()
        {
            // 1. Start all API calls in parallel
            var statsTask = _apiClient.GetAdminDashboardAsync();
            var financialTrendTask = _apiClient.GetMonthlyFinancialsAsync();
            var occurrenceSummaryTask = _apiClient.GetOccurrenceStatusSummaryAsync();
            var hotspotsTask = _apiClient.GetCondoHotspotsAsync();

            // 2. Wait for all of them to complete
            await Task.WhenAll(statsTask, financialTrendTask, occurrenceSummaryTask, hotspotsTask);

            // 3. Get the results from the completed tasks
            var stats = await statsTask;
            if (stats == null)
            {
                // If the main stats fail, we probably can't show a useful dashboard.
                // You could show an error or a limited view. For now, we'll show an empty one.  return View(new AdminBiDashboardViewModel
                {
                    MainStats = new Core.DTOs.Reports.AdminDashboardDto(),
                    FinancialTrend = new List<Core.DTOs.Reports.MonthlyFinancialsDto>(),
                    OccurrenceSummary = new List<Core.DTOs.Reports.StatusSummaryDto>(),
                    CondoHotspots = new List<Core.DTOs.Reports.CondoHotspotDto>()
                });
            }

            // 4. Assemble the complete ViewModel
            var viewModel = new AdminBiDashboardViewModel
            {
                MainStats = stats,
                FinancialTrend = await financialTrendTask,
                OccurrenceSummary = await occurrenceSummaryTask,
                CondoHotspots = await hotspotsTask
            };

            return View(viewModel);
        }

        // GET: /administration/condominiums/{id}/edit
        [HttpGet("condominiums/{id}/edit")]
/// <summary>
/// Handles the Edit Condominium action.
/// </summary>
public async Task<IActionResult> EditCondominium(int id)
        {  var condo = await _apiClient.GetCondominiumDetailsAsync(id);
            if (condo == null)
            {
                return NotFound();
            }

            // Create a DTO to pre-populate the form fields
            var model = new CreateUpdateCondominiumDto
            {
                Name = condo.Name,
                Address = condo.Address
            };

            ViewData["CondominiumName"] = condo.Name;
            return View(model);
        }

        [HttpPost("condominiums/{id}/delete")]
        [ValidateAntiForgeryToken]
        publicasync Task<IActionResult> DeleteCondominium(int id)
        {
            var (success, message) = await _apiClient.DeleteCondominiumAsync(id);

            if (success)
            {
                TempData["SuccessMessage"] = message;
            }
            else      {
                TempData["ErrorMessage"] = message;
            }

            return RedirectToAction("Index");
        }

        // POST: /administration/condominiums/{id}/edit
        [HttpPost("condominiums/{id}/edit")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Edit Condominium action.
/// </summary>
public async Task<IActionResult> EditCondominium(int id, CreateUpdateCondominiumDto dto)
        {
            if (!ModelState.IsValid)
            {
                var condo = await _apiClient.GetCondominiumDetailsAsync(id);
                ViewData["CondominiumName"] = condo?.Name ?? "Condominium";
                return View(dto);
            }

            var success = await _apiClient.UpdateCondominiumAsync(id, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Condominium details updated successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the condominium.");
            var finalCondo = await _apiClient.GetCondominiumDetailsAsync(id);
            ViewData["CondominiumName"] = finalCondo?.Name ?? "Condominium";
            return View(dto);
        }

        [HttpPost("condominiums/{condominiumId}/unassign-manager")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Unassign Manager action.
/// </summary>
public async Task<IActionResult> UnassignManager(int condominiumId)
        {
            var success = await _apiClient.UnassignManagerAsync(condominiumId);
            if (success)
            {
                TempData["SuccessMessage"] = "Manager has been un-assigned successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to un-assign manager.";
            }
            return RedirectToAction("Index");
        }
    }
}