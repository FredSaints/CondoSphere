using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Intervention;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Authorize]
    public class InterventionsController : ControllerBase
    {
        private readonly IInterventionService _interventionService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InterventionsController(
            IInterventionService interventionService,
            ICurrentUserService currentUserService,
            IAuthorizationService authorizationService,
            IOccurrenceRepository occurrenceRepository,
            IUnitOfWork unitOfWork)
        {
            _interventionService = interventionService;
            _currentUserService = currentUserService;
            _authorizationService = authorizationService;
            _occurrenceRepository = occurrenceRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("api/interventions")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> CreateIntervention([FromBody] CreateInterventionDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var newIntervention = await _interventionService.CreateInterventionAsync(dto, companyId.Value);
            if (newIntervention == null)
            {
                return BadRequest("Invalid Occurrence ID or permission denied.");
            }

            return Ok(newIntervention);
        }

        [HttpGet("api/occurrences/{occurrenceId}/interventions")]
        public async Task<IActionResult> GetInterventionsForOccurrence(int occurrenceId)
        {
            var parentOccurrence = await _occurrenceRepository.GetByIdAsync(occurrenceId);
            if (parentOccurrence == null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, parentOccurrence, "CanAccessOccurrence");
            if (!authorizationResult.Succeeded) return Forbid();

            var interventions = await _interventionService.GetInterventionsForOccurrenceAsync(occurrenceId);
            return Ok(interventions);
        }

        [HttpGet("api/interventions/my-tasks")]
        [Authorize(Roles = RoleConstants.Employee)]
        public async Task<IActionResult> GetMyTasks()
        {
            var employeeId = _currentUserService.UserId;
            if (employeeId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }

            var interventions = await _interventionService.GetMyInterventionsAsync(employeeId.Value);
            return Ok(interventions);
        }

        [HttpPatch("api/interventions/{id}/status")]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateInterventionStatusDto dto)
        {
            var intervention = await _unitOfWork.Interventions.GetByIdAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, intervention, "CanManageIntervention");
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            var success = await _interventionService.UpdateInterventionStatusAsync(id, dto.Status);

            if (success)
            {
                return NoContent();
            }
            return BadRequest("Failed to update status.");
        }
    }
}