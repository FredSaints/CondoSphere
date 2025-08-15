using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CondoResident)]
    [Route("portal")]
    public class PortalController : Controller
    {
        private readonly ApiClient _apiClient;

        public PortalController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var occurrencesTask = _apiClient.GetMyOccurrencesAsync();
            var unitsTask = _apiClient.GetMyUnitsAsync();
            var quotasTask = _apiClient.GetMyQuotasAsync();

            await Task.WhenAll(occurrencesTask, unitsTask, quotasTask);

            var viewModel = new PortalDashboardViewModel
            {
                Occurrences = await occurrencesTask ?? new List<OccurrenceDto>(),
                MyUnits = await unitsTask ?? new List<UnitDto>(),
                MyQuotas = await quotasTask ?? new List<UnitQuotaDto>()
            };

            return View(viewModel);
        }

        [HttpGet("create-occurrence")]
        public async Task<IActionResult> CreateOccurrence()
        {
            var myUnits = await _apiClient.GetMyUnitsAsync();
            if (!myUnits.Any())
            {
                // Handle case where user has no units - maybe redirect with an error
                TempData["ErrorMessage"] = "You are not assigned to any unit. Cannot report an occurrence.";
                return RedirectToAction("Index");
            }

            var viewModel = new CreateOccurrenceViewModel
            {
                AvailableUnits = myUnits.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Identifier
                })
            };

            return View(viewModel);
        }

        [HttpPost("create-occurrence")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOccurrence(CreateOccurrenceViewModel model, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                var myUnits = await _apiClient.GetMyUnitsAsync();
                model.AvailableUnits = myUnits.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Identifier
                });
                return View(model);
            }

            var dto = new CreateOccurrenceDto
            {
                Title = model.Title,
                Description = model.Description,
                UnitId = model.UnitId
            };

            var result = await _apiClient.CreateOccurrenceAsync(dto, imageFile);

            if (result != null)
            {
                TempData["SuccessMessage"] = $"Occurrence '{model.Title}' was reported successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while reporting the occurrence. Please try again.");
            var finalUnits = await _apiClient.GetMyUnitsAsync();
            model.AvailableUnits = finalUnits.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Identifier
            });
            return View(model);
        }

        [HttpGet("occurrences/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var occurrence = await _apiClient.GetOccurrenceDetailsAsync(id);
            if (occurrence == null)
            {
                return NotFound();
            }
            return View(occurrence);
        }

        [HttpGet("quotas/{id}/details")]
        public async Task<IActionResult> QuotaDetails(int id)
        {
            var breakdown = await _apiClient.GetQuotaBreakdownAsync(id);
            if (breakdown == null)
            {
                return NotFound();
            }
            return View(breakdown);
        }

        [HttpPost("quotas/{id}/details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitProof(int id, IFormFile proofFile)
        {
            if (proofFile == null || proofFile.Length == 0)
            {
                TempData["ErrorMessage"] = "Please select a file to upload.";
                return RedirectToAction("QuotaDetails", new { id });
            }

            var result = await _apiClient.SubmitPaymentProofAsync(id, proofFile);

            if (result != null)
            {
                TempData["SuccessMessage"] = "Proof of payment submitted successfully. Awaiting manager confirmation.";
            }
            else
            {
                TempData["ErrorMessage"] = "There was an error submitting your proof of payment.";
            }

            return RedirectToAction("QuotaDetails", new { id });
        }
    }
}