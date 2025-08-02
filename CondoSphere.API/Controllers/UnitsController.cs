using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/units")]
    [Authorize] // All actions in this controller require an authenticated user.
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly IValidator<CreateUpdateUnitDto> _validator;
        private readonly ICurrentUserService _currentUserService;

        public UnitsController(
            IUnitService unitService,
            IValidator<CreateUpdateUnitDto> validator,
            ICurrentUserService currentUserService)
        {
            _unitService = unitService;
            _validator = validator;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        [Authorize(Policy = "IsCondoManagerPolicy")] // Checks if user is CompanyAdmin OR assigned manager.
        public async Task<IActionResult> GetUnitsForCondominium(int condominiumId)
        {
            var units = await _unitService.GetUnitsForCondominiumAsync(condominiumId);
            return Ok(units);
        }

        [HttpGet("{unitId}")]
        [Authorize(Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetUnitById(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")] // Must be a manager AND be assigned to this condo.
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
                return NotFound();
            }

            var success = await _unitService.UpdateUnitAsync(unitId, unitDto);
            if (!success)
            {
                return NotFound(); // Or another appropriate error
            }

            return NoContent();
        }

        [HttpDelete("{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> DeleteUnit(int condominiumId, int unitId)
        {
            var existingUnit = await _unitService.GetUnitByIdAsync(unitId);
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
        public async Task<IActionResult> UnassignResident(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.UnassignResidentAsync(unitId);

            if (success)
            {
                return NoContent();
            }

            return BadRequest(new { Message = "Failed to unassign resident. The unit might already be vacant." });
        }
    }
}