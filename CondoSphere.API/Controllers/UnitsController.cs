using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Application.Services.User;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/units")]
    [Authorize]    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly IValidator<CreateUpdateUnitDto> _validator;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UnitsController(
            IUnitService unitService,
            IValidator<CreateUpdateUnitDto> validator,
            ICurrentUserService currentUserService,
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            _unitService = unitService;
            _validator = validator;
            _currentUserService = currentUserService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Policy = "IsCondoManagerPolicy")]        public async Task<IActionResult> GetUnitsForCondominium(int condominiumId)
        {
            var units = await _unitService.GetUnitsForCondominiumAsync(condominiumId);
            return Ok(units);
        }

        [HttpGet("{unitId}")]
        [Authorize(Policy = "IsCondoManagerPolicy")]        public async Task<IActionResult> GetUnitById(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [HttpGet("~/api/units/{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]        public async Task<IActionResult> GetSingleUnitById(int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null)
            {
                return NotFound();
            }

            var condo = await _unitOfWork.Condominiums.GetByIdAsync(unit.CondominiumId, _currentUserService.CompanyId.Value);
            if (condo == null)
            {
                return Forbid();
            }   return Ok(unit);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")] // Must be a manager AND be assigned to this condo.
/// <summary>
/// Handles the Create Unit action.
/// </summary>
public async Task<IActionResult> CreateUnit(int condominiumId, [FromBody] CreateUpdateUnitDto unitDto)
        {
            var validationResult = await _validator.ValidateAsync(unitDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (!companyId.HasValue)
            {
                return Forbid(); // Should not be possible if auth has passed, but is a good safeguard.
            }

            var newUnit = await _unitService.CreateUnitAsync(unitDto, condominiumId, companyId.Value);

            return CreatedAtAction(nameof(GetUnitById), new { condominiumId, unitId = newUnit.Id }, newUnit);
        }

        [HttpPut("{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
/// <summary>
/// Handles the Update Unit action.
/// </summary>
public async Task<IActionResult> UpdateUnit(int condominiumId, int unitId, [FromBody] CreateUpdateUnitDto unitDto)
        {
            var validationResult = await _validator.ValidateAsync(unitDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingUnit = await _unitService.GetUnitByIdAsync(unitId);
            if (existingUnit == null || existingUnit.CondominiumId != condominiumId)
            {
                return NotFound();}

            var success = await _unitService.UpdateUnitAsync(unitId, unitDto);  if (!success)
            {
                return NotFound(); // Or another appropriate error
            }

            return NoContent();
        }

        [HttpDelete("{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
/// <summary>
/// Handles the Delete Unit action.
/// </summary>
public async Task<IActionResult> DeleteUnit(int condominiumId, int unitId)
        {      var existingUnit = await _unitService.GetUnitByIdAsync(unitId);
            if (existingUnit == null || existingUnit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.DeleteUnitAsync(unitId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{unitId}/unassign-resident")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
/// <summary>
/// Handles the Unassign Resident action.
/// </summary>
public async Task<IActionResult> UnassignResident(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Forbid();
            }

            var residentId = unit.Resident?.Id;

            if (residentId == null)
            {
                return BadRequest(new { message = "The unit is already vacant." });
            }
            var success = await _userService.UnassignResidentFromUnitAsync(residentId.Value, unitId, companyId.Value);

            if (success)
            {
                return NoContent();
            }

            return BadRequest(new { message = "Failed to unassign resident." });
        }

        [HttpPatch("{unitId}/assign-resident")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
/// <summary>
/// Handles the Assign Resident action.
/// </summary>
public async Task<IActionResult> AssignResident(int condominiumId, int unitId, [FromBody] AssignResidentDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Forbid();
            }
            var success = await _userService.AssignResidentToUnitAsync(dto.ResidentId, unitId, companyId.Value);

            if (success)
            {
                return NoContent();
            }
            return BadRequest(new { message = "Failed to assign resident. The unit may be occupied or the resident invalid." });
        }
    }
}