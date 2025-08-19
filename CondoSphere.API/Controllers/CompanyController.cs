using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Company;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = RoleConstants.CompanyAdmin)]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ICurrentUserService _currentUserService;

        public CompanyController(ICompanyService companyService, ICurrentUserService currentUserService)
        {
            _companyService = companyService;
            _currentUserService = currentUserService;
        }

        [HttpGet("my-profile")]
        public async Task<ActionResult<CompanyProfileDto>> GetMyCompanyProfile()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var profile = await _companyService.GetCompanyProfileAsync(companyId.Value);
            if (profile == null) return NotFound();

            return Ok(profile);
        }

        [HttpPut("my-profile")]
        public async Task<IActionResult> UpdateMyCompanyProfile([FromBody] CompanyProfileDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var success = await _companyService.UpdateCompanyProfileAsync(companyId.Value, dto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}