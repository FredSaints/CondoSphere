using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var condo = await _apiClient.GetCondominiumDetailsAsync(id);
            var units = await _apiClient.GetUnitsForCondominiumAsync(id);
            var users = await _apiClient.GetUsersAsync();
            var userLookup = users.ToDictionary(u => u.Id, u => $"{u.FirstName} {u.LastName}");

            var unitViewModels = units.Select(unit => new UnitDetailViewModel
            {
                Id = unit.Id,
                Identifier = unit.Identifier,
                ResidentId = unit.ResidentId,
                ResidentName = unit.ResidentId.HasValue && userLookup.ContainsKey(unit.ResidentId.Value)
                    ? userLookup[unit.ResidentId.Value]
                    : null
            });

            var viewModel = new CondominiumDetailsViewModel
            {
                Condominium = condo,
                Units = unitViewModels
            };

            return View(viewModel);
        }

        [HttpGet("units/{unitId}/register-resident")]
        public IActionResult RegisterResident(int unitId, int condominiumId)
        {
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
                return View(model);
            }

            // Create the DTO to send to the API from the ViewModel
            var dto = new RegisterResidentDto
            {
                UnitId = model.UnitId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            // ===== CORRECTED LOGIC HERE =====
            // The ApiClient method returns a simple boolean, not a tuple.
            var success = await _apiClient.RegisterResidentAsync(model.CondominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident registered successfully! A welcome email has been sent.";
                return RedirectToAction(nameof(Details), new { id = model.CondominiumId });
            }

            // Use a generic error message since the current ApiClient doesn't return a specific one.
            ModelState.AddModelError(string.Empty, "Failed to register resident. The unit may be occupied or the email may be in use.");
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

        [HttpPost("{condominiumId}/units/{unitId}/unassign")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnassignResident(int condominiumId, int unitId)
        {
            var success = await _apiClient.UnassignResidentAsync(condominiumId, unitId);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident has been unassigned and the unit is now vacant.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to unassign resident."; // We'll need to display this in the layout
            }

            return RedirectToAction(nameof(Details), new { id = condominiumId });
        }
    }
}