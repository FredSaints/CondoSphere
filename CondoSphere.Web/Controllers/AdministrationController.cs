using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CompanyAdmin)]
    [Route("administration")] // Optional: You can add a base route for the entire controller
    public class AdministrationController : Controller
    {
        private readonly ApiClient _apiClient;

        public AdministrationController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")] // This will now map to "/administration"
        public async Task<IActionResult> Index()
        {
            var users = await _apiClient.GetUsersAsync();
            var condominiums = await _apiClient.GetCondominiumsAsync();

            var viewModel = new ManagementDashboardViewModel
            {
                Users = users ?? new List<UserListDto>(),
                Condominiums = condominiums ?? new List<CondominiumDto>()
            };

            return View(viewModel);
        }

        [HttpGet("register-manager")] // Maps to "/administration/register-manager"
        public IActionResult RegisterManager()
        {
            return View();
        }

        [HttpPost("register-manager")]
        [ValidateAntiForgeryToken]
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
            }

            ModelState.AddModelError(string.Empty, "Failed to register manager. The email may already be in use.");
            return View(model);
        }

        [HttpGet("create-condominium")] // Maps to "/administration/create-condominium"
        public IActionResult CreateCondominium()
        {
            return View();
        }

        [HttpPost("create-condominium")]
        [ValidateAntiForgeryToken]
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

        // ===== CORRECTED ROUTES BELOW =====
        [HttpGet("condominiums/{condominiumId}/assign-manager")]
        public async Task<IActionResult> AssignManager(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null)
            {
                return NotFound();
            }

            var managers = await _apiClient.GetAvailableManagersAsync();

            ViewData["Condominium"] = condo;
            ViewData["AvailableManagers"] = managers.Select(m => new SelectListItem
            {
                Text = $"{m.FirstName} {m.LastName} ({m.Email})",
                Value = m.Id.ToString()
            });

            return View(new AssignManagerViewModel());
        }

        [HttpPost("condominiums/{condominiumId}/assign-manager")]
        [ValidateAntiForgeryToken]
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

            await RepopulateAssignManagerViewDataAsync(condominiumId);
            return View(model);
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
    }
}