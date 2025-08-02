using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CondominiumsController : ControllerBase
    {
        private readonly ICondominiumService _condominiumService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IValidator<CreateUpdateCondominiumDto> _validator;

        public CondominiumsController(
            ICondominiumService condominiumService,
            ICurrentUserService currentUserService,
             IValidator<CreateUpdateCondominiumDto> validator)
        {
            _condominiumService = condominiumService;
            _currentUserService = currentUserService;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var condominiums = await _condominiumService.GetAllCondominiumsAsync(companyId.Value, pageNumber, pageSize);
            return Ok(condominiums);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var condominium = await _condominiumService.GetCondominiumByIdAsync(id, companyId.Value);

            if (condominium == null)
            {
                return NotFound();
            }
            return Ok(condominium);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Create([FromBody] CreateUpdateCondominiumDto condominiumDto)
        {
            var validationResult = await _validator.ValidateAsync(condominiumDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var newCondominium = await _condominiumService.CreateCondominiumAsync(condominiumDto, companyId.Value);

            return CreatedAtAction(nameof(GetById), new { id = newCondominium.Id }, newCondominium);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateCondominiumDto condominiumDto)
        {
            var validationResult = await _validator.ValidateAsync(condominiumDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var success = await _condominiumService.UpdateCondominiumAsync(id, condominiumDto, companyId.Value);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Delete(int id)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var success = await _condominiumService.DeleteCondominiumAsync(id, companyId.Value);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{condominiumId}/assign-manager")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> AssignManager(int condominiumId, [FromBody] AssignManagerDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            // We use the manager ID from the request body (dto.ManagerId)
            var success = await _condominiumService.AssignManagerAsync(condominiumId, dto.ManagerId, companyId.Value);

            if (!success)
            {
                return BadRequest("Failed to assign manager. Verify condominium and manager IDs are valid for your company.");
            }

            return NoContent();
        }

        [HttpGet("my-managed")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public async Task<IActionResult> GetMyManagedCondominiums()
        {
            var managerId = _currentUserService.UserId;
            if (managerId == null)
            {
                return Unauthorized("User ID is missing from the token.");
            }

            // We need a new service method for this. Let's add it.
            var condominiums = await _condominiumService.GetCondominiumsByManagerIdAsync(managerId.Value);

            return Ok(condominiums);
        }
    }
}