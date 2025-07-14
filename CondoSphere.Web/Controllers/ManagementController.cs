using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.Controllers
{
    // This entire controller should only be accessible to CompanyAdmins.
    // The [Authorize] attribute uses the cookie authentication scheme we set up.
    [Authorize(Roles = RoleConstants.CompanyAdmin)]
    public class ManagementController : Controller
    {
        private readonly ApiClient _apiClient;

        public ManagementController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            // NOTE: This will fail with a 401 Unauthorized until we solve the
            // next problem: passing the auth token from the Web App to the API.
            var users = await _apiClient.GetUsersAsync();
            var condominiums = await _apiClient.GetCondominiumsAsync();

            var viewModel = new ManagementDashboardViewModel
            {
                Users = users ?? new List<UserListDto>(),
                Condominiums = condominiums ?? new List<CondominiumDto>()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult RegisterManager()
        {
            // This just displays the form, so it's a simple ViewResult.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterManager(RegisterManagerDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // NOTE: This will also fail with a 401 Unauthorized for now.
            var success = await _apiClient.RegisterManagerAsync(model);

            if (success)
            {
                // Add a success message to TempData to display on the next page.
                TempData["SuccessMessage"] = "Manager registered successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to register manager. The email may already be in use.");
            return View(model);
        }
    }
}