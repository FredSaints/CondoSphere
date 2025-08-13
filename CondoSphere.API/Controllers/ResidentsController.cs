using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.User;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Authorize]

    [Route("api")]
    public class ResidentsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public ResidentsController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [HttpPost("condominiums/{condominiumId}/residents")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> RegisterResident(int condominiumId, [FromBody] RegisterResidentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var result = await _userService.RegisterResidentAsync(dto, companyId.Value, condominiumId);

            if (result.Succeeded)
            {
                return StatusCode(201, new { message = "Resident registered successfully." });
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("condominiums/{condominiumId}/residents")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetResidentsForCondominium(int condominiumId)
        {
            var residents = await _userService.GetResidentsForCondominiumAsync(condominiumId);
            return Ok(residents);
        }

        [HttpPost("residents/{residentId}/unassign-from/{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> UnassignResidentFromUnit(int residentId, int unitId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var success = await _userService.UnassignResidentFromUnitAsync(residentId, unitId, companyId.Value);

            if (success)
            {
                return NoContent();
            }

            return BadRequest("Failed to unassign resident.");
        }
    }
}