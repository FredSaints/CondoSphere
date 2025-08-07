using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Occurrence;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Occurrences;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/occurrences")]
    [Authorize]
    public class OccurrencesController : ControllerBase
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // First, get the raw entity from the repository to check authorization against.
            CoreOccurrence? occurrence = await _occurrenceRepository.GetByIdAsync(id);
            if (occurrence == null)
            {
                return NotFound();
            }

            // Check if the current user is authorized to view this specific occurrence resource.
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, occurrence, "CanAccessOccurrence");
            if (!authorizationResult.Succeeded)
            {
                // Return 403 Forbidden if the policy check fails.
                return Forbid();
            }

            // If authorized, get the rich DTO from the service to return to the client.
            var occurrenceDto = await _occurrenceService.GetOccurrenceByIdAsync(id);
            return Ok(occurrenceDto);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CondoResident)]
        public async Task<IActionResult> CreateOccurrence([FromBody] CreateOccurrenceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // The controller's job is to get the user ID from the security context.
            var residentUserId = _currentUserService.UserId;
            if (residentUserId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }

            // The controller passes the clean ID to the service layer.
            var newOccurrenceDto = await _occurrenceService.CreateOccurrenceAsync(dto, residentUserId.Value);

            if (newOccurrenceDto == null)
            {
                // The service returned null, meaning the business rule failed (user not in a unit).
                return BadRequest(new { Message = "Could not create occurrence. The user may not be assigned to a unit." });
            }

            // Return a 201 Created status with a Location header pointing to the new resource.
            return CreatedAtAction(
                nameof(GetById),
                new { id = newOccurrenceDto.Id },
                newOccurrenceDto);
        }

        [HttpGet("~/api/condominiums/{condominiumId}/occurrences")]
        [Authorize(Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetOccurrencesForCondominium(int condominiumId)
        {
            var occurrences = await _occurrenceService.GetOccurrencesForCondominiumAsync(condominiumId);
            return Ok(occurrences);
        }

        [HttpGet("my-occurrences")]
        [Authorize(Roles = RoleConstants.CondoResident)]
        public async Task<IActionResult> GetMyOccurrences()
        {
            var residentUserId = _currentUserService.UserId;
            if (residentUserId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }

            var occurrences = await _occurrenceService.GetOccurrencesForResidentAsync(residentUserId.Value);

            return Ok(occurrences);
        }
    }
}