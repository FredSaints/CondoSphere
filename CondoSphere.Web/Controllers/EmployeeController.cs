using CondoSphere.Core;
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
    }
}