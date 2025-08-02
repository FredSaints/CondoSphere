using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.User;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/residents")]
    [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
    public class ResidentsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public ResidentsController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterResident(int condominiumId, [FromBody] RegisterResidentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                // This should not happen due to the authorization policy, but it's a good safeguard.
                return Unauthorized("Company information is missing from the token.");
            }

            var result = await _userService.RegisterResidentAsync(dto, companyId.Value, condominiumId);

            if (result.Succeeded)
            {
                return StatusCode(201, new { Message = "Resident registered successfully. A welcome email has been sent for them to set their password." });
            }

            return BadRequest(result.Errors);
        }
    }
}