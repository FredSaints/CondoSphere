using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Occurrence;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/occurrences")]
    [Authorize]    public class OccurrencesController : ControllerBase
    {
        private readonly IOccurrenceService _occurrenceService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IOccurrenceRepository _occurrenceRepository;

        public OccurrencesController(
            IOccurrenceService occurrenceService,
            ICurrentUserService currentUserService,
            IAuthorizationService authorizationService,
            IOccurrenceRepository occurrenceRepository)
        {
            _occurrenceService = occurrenceService;
            _currentUserService = currentUserService;
            _authorizationService = authorizationService;
            _occurrenceRepository = occurrenceRepository;
        }


        [HttpGet("{id}")]        public async Task<IActionResult> GetById(int id)
        {
            var occurrence = await _occurrenceRepository.GetByIdAsync(id);
            if (occurrence == null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, occurrence, "CanAccessOccurrence");
            if (!authorizationResult.Succeeded) return Forbid();

            var occurrenceDto = await _occurrenceService.GetOccurrenceByIdAsync(id);
            return Ok(occurrenceDto);        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CondoResident)]        public async Task<IActionResult> CreateOccurrence([FromForm] CreateOccurrenceDto dto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var residentUserId = _currentUserService.UserId;
            if (residentUserId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }

            var newOccurrenceDto = await _occurrenceService.CreateOccurrenceAsync(dto, residentUserId.Value, imageFile);

            if (newOccurrenceDto == null)
            {
                return BadRequest(new { message = "Could not create occurrence. The user may not be assigned to a unit." });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = newOccurrenceDto.Id },
                newOccurrenceDto);
        }

        [HttpGet("~/api/condominiums/{condominiumId}/occurrences")]
        [Authorize(Policy = "IsCondoManagerPolicy")]
/// <summary>
/// Handles the Get Occurrences For Condominium action.
/// </summary>
public async Task<IActionResult> GetOccurrencesForCondominium(int condominiumId)
        {
            var occurrences = await _occurrenceService.GetOccurrencesForCondominiumAsync(condominiumId);
            return Ok(occurrences);
        }

        [HttpGet("my-occurrences")]
        [Authorize(Roles = RoleConstants.CondoResident)]        public async Task<IActionResult> GetMyOccurrences()
        {
            var residentUserId = _currentUserService.UserId;
            if (residentUserId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }           var occurrences = await _occurrenceService.GetOccurrencesForResidentAsync(residentUserId.Value);

            return Ok(occurrences);
        }

        [HttpPatch("{id}/status")]
/// <summary>
/// Handles the Update Status action.
/// </summary>
public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateOccurrenceStatusDto dto)
        {
            var occurrence = await _occurrenceRepository.GetByIdAsync(id);
            if (occurrence == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, occurrence, "CanAccessOccurrence");
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            if (User.IsInRole(RoleConstants.CondoResident))
            {
                return Forbid();
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized();
            }

            // NEW: Prevent changes if already closed
            if (occurrence.Status == OccurrenceStatus.Closed && dto.Status != OccurrenceStatus.Closed)
            {
                return BadRequest("This occurrence is closed and can no longer be modified.");
            }

            // Detect if this request is closing it now (for the warning)
            var isClosingNow = occurrence.Status != OccurrenceStatus.Closed && dto.Status == OccurrenceStatus.Closed;

            var success = await _occurrenceService.UpdateOccurrenceStatusAsync(id, dto.Status, companyId.Value);

            if (!success)
            {
                return BadRequest("Failed to update status.");
            }

            if (isClosingNow)
            {
                return Ok("The occurrence has been closed. You will not be able to change its status or add new expenses.");
            }

            return NoContent();
        }
    }
}