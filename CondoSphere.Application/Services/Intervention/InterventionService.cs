using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CoreIntervention = CondoSphere.Core.Entities.Condominiums.Intervention;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Intervention
{
    public class InterventionService : IInterventionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentUserService _currentUserService;

        public InterventionService(
            IUnitOfWork unitOfWork,
            IMapper mapper, UserManager<CoreUser> userManager,
            IAuthorizationService authorizationService,
            ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _currentUserService = currentUserService;
        }

        public async Task<InterventionDto?> CreateInterventionAsync(CreateInterventionDto dto, int managerCompanyId)
        {
            var parentOccurrence = await _unitOfWork.Occurrences.GetByIdAsync(dto.OccurrenceId);
            if (parentOccurrence == null || parentOccurrence.CompanyId != managerCompanyId)
            {
                return null;
            }

            var newIntervention = _mapper.Map<CoreIntervention>(dto);

            newIntervention.Status = InterventionStatus.Scheduled;
            newIntervention.CompanyId = parentOccurrence.CompanyId;
            newIntervention.CondominiumId = parentOccurrence.CondominiumId;
            newIntervention.UnitId = parentOccurrence.UnitId;

            await _unitOfWork.Interventions.AddAsync(newIntervention);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<InterventionDto>(newIntervention);
        }

        public async Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId)
        {
            var interventions = await _unitOfWork.Interventions.GetByOccurrenceIdAsync(occurrenceId);
            if (!interventions.Any())
            {
                return Enumerable.Empty<InterventionDto>();
            }

            var interventionDtos = _mapper.Map<List<InterventionDto>>(interventions);

            var assignedUserIds = interventions
                .Where(i => i.AssignedToUserId.HasValue)
                .Select(i => i.AssignedToUserId.Value)
                .Distinct()
                .ToList();

            if (assignedUserIds.Any())
            {
                var assignees = await _userManager.Users
                    .Where(u => assignedUserIds.Contains(u.Id))
                    .ToDictionaryAsync(u => u.Id, u => $"{u.FirstName} {u.LastName}");

                foreach (var dto in interventionDtos)
                {
                    if (dto.AssignedToUserId.HasValue && assignees.ContainsKey(dto.AssignedToUserId.Value))
                    {
                        dto.AssignedToUserName = assignees[dto.AssignedToUserId.Value];
                    }
                }
            }
            return interventionDtos;
        }

        public async Task<IEnumerable<InterventionDto>> GetMyInterventionsAsync(int employeeId)
        {
            var interventions = await _unitOfWork.Interventions.GetByAssignedUserIdAsync(employeeId);
            return _mapper.Map<IEnumerable<InterventionDto>>(interventions);
        }

        public async Task<bool> UpdateInterventionStatusAsync(int interventionId, InterventionStatus newStatus)
        {
            var intervention = await _unitOfWork.Interventions.GetByIdAsync(interventionId);
            if (intervention == null)
            {
                return false;
            }

            intervention.Status = newStatus;
            _unitOfWork.Interventions.Update(intervention);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}