using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Messages;
using CondoSphere.Application.Services.Notifications;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Messages;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly INotificationService _notificationService;
        private readonly IMessageService _messageService;
        private readonly IConfiguration _configuration;

        public InterventionService(
            IUnitOfWork unitOfWork,
            IMapper mapper, UserManager<CoreUser> userManager,
            IAuthorizationService authorizationService,
            ICurrentUserService currentUserService,
            INotificationService notificationService,
            IMessageService messageService,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _currentUserService = currentUserService;
            _notificationService = notificationService;
            _messageService = messageService;
            _configuration = configuration;
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

            if (!parentOccurrence.AssignedToUserId.HasValue && newIntervention.AssignedToUserId.HasValue)
            {
                parentOccurrence.AssignedToUserId = newIntervention.AssignedToUserId;
                _unitOfWork.Occurrences.Update(parentOccurrence);
            }

            await _unitOfWork.Interventions.AddAsync(newIntervention);
            await _unitOfWork.CompleteAsync();

            if (newIntervention.AssignedToUserId.HasValue)
            {
                // This sends the email/push notification
                await _notificationService.NotifyEmployeeOfNewTaskAsync(newIntervention);
                
                // --- Send Inbox Message to Employee ---
                try
                {
                    var managerId = _currentUserService.UserId;
                    if (managerId.HasValue)
                    {
                        var webAppBaseUrl = _configuration["ClientSettings:WebAppBaseUrl"];
                        var taskLink = $"{webAppBaseUrl}/employee/{newIntervention.Id}";
                        var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(newIntervention.OccurrenceId);

                        var messageDto = new SendMessageDto
                        {
                            ReceiverId = newIntervention.AssignedToUserId.Value,
                            Subject = $"New Task Assigned: {occurrence.Title}",
                            Content = $"You have been assigned a new task: '{newIntervention.Description}'.\n\nPlease review the details here: {taskLink}",
                            CondominiumId = newIntervention.CondominiumId
                        };
                        await _messageService.SendMessageAsync(messageDto, managerId.Value, newIntervention.CompanyId);
                    }
                }
                catch (Exception ex)
                {
                    // Log the error but don't fail the entire operation
                    // For example: _logger.LogError(ex, "Failed to send inbox message for new task {InterventionId}", newIntervention.Id);
                }
            }

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

            if (intervention.Status == InterventionStatus.Completed || intervention.Status == InterventionStatus.Cancelled)
            {
                return false;
            }

            intervention.Status = newStatus;
            _unitOfWork.Interventions.Update(intervention);
            await _unitOfWork.CompleteAsync();
            
            // --- Send Notification and Message on Completion ---
            if (newStatus == InterventionStatus.Completed)
            {
                // Send email/push notification to manager
                await _notificationService.NotifyManagerOfTaskCompletionAsync(intervention);

                // Send inbox message to manager
                try
                {
                    var condo = await _unitOfWork.Condominiums.GetByIdAsync(intervention.CondominiumId, intervention.CompanyId);
                    if (condo?.ManagerId != null)
                    {
                        var employee = await _unitOfWork.Users.GetUserByIdAsync(intervention.AssignedToUserId ?? 0);
                        var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(intervention.OccurrenceId);

                        var webAppBaseUrl = _configuration["ClientSettings:WebAppBaseUrl"];
                        var occurrenceLink = $"{webAppBaseUrl}/condo-management/{intervention.CondominiumId}/occurrences/{intervention.OccurrenceId}";

                        var messageDto = new SendMessageDto
                        {
                            ReceiverId = condo.ManagerId.Value,
                            Subject = $"Task Completed: {occurrence.Title}",
                            Content = $"The task '{intervention.Description}' has been marked as complete by {employee?.FirstName} {employee?.LastName}.\n\nYou can review the occurrence details here: {occurrenceLink}",
                            CondominiumId = intervention.CondominiumId
                        };
                        // The sender is the employee who completed the task
                        await _messageService.SendMessageAsync(messageDto, employee.Id, intervention.CompanyId);
                    }
                }
                catch (Exception ex)
                {
                    // Log the error
                    // For example: _logger.LogError(ex, "Failed to send inbox message for completed task {InterventionId}", intervention.Id);
                }
            }

            return true;
        }

        public async Task<InterventionDto?> GetInterventionByIdAsync(int interventionId)
        {
            var intervention = await _unitOfWork.Interventions.GetByIdAsync(interventionId);
            if (intervention == null)
            {
                return null;
            }

            var interventionDto = _mapper.Map<InterventionDto>(intervention);

            if (intervention.AssignedToUserId.HasValue)
            {
                var assignee = await _userManager.FindByIdAsync(intervention.AssignedToUserId.Value.ToString());
                if (assignee != null)
                {
                    interventionDto.AssignedToUserName = $"{assignee.FirstName} {assignee.LastName}";
                }
            }

            return interventionDto;
        }
    }
}