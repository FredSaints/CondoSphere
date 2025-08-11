using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.Employee)]
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly ApiClient _apiClient;

        public EmployeeController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var interventions = await _apiClient.GetMyInterventionsAsync();
            return View(interventions);
        }

        [HttpGet("{interventionId}")]
        public async Task<IActionResult> Details(int interventionId)
        {
            var intervention = await _apiClient.GetInterventionDetailsAsync(interventionId);
            if (intervention == null) return NotFound();

            var occurrence = await _apiClient.GetOccurrenceDetailsAsync(intervention.OccurrenceId);
            if (occurrence == null) return NotFound();

            var viewModel = new EmployeeInterventionViewModel
            {
                Intervention = intervention,
                Occurrence = occurrence,
                StatusUpdate = new UpdateInterventionStatusDto { Status = intervention.Status }
            };

            return View(viewModel);
        }

        [HttpPost("{interventionId}")] // This route now correctly handles the POST from the form
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int interventionId, [Bind(Prefix = "StatusUpdate")] UpdateInterventionStatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid status submitted.";
                return RedirectToAction("Details", new { interventionId });
            }

            var success = await _apiClient.UpdateInterventionStatusAsync(interventionId, dto);
            if (success)
            {
                TempData["SuccessMessage"] = "Task status updated successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update task status. You may not have permission or the task may be cancelled.";
            }

            return RedirectToAction("Details", new { interventionId });
        }
    }
}