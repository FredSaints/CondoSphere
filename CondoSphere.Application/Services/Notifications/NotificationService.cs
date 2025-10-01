using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Notifications;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Shared.Hubs;
using Microsoft.AspNetCore.SignalR;
using CoreDocument = CondoSphere.Core.Entities.Condominiums.Document;
using CoreIntervention = CondoSphere.Core.Entities.Condominiums.Intervention;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;
using CoreUnitQuota = CondoSphere.Core.Entities.Financials.UnitQuota;

namespace CondoSphere.Application.Services.Notifications
{
    /// <summary>
    /// Notification Service.
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IMapper _mapper;

        public NotificationService(
            IUnitOfWork unitOfWork,
            IMailService mailService,
            IHubContext<NotificationHub> hubContext,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        public async Task<bool> SendAnnouncementToCondominiumAsync(int condominiumId, int companyId, string subject, string message, string sentByUserName)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condo == null) return false;

            var units = await _unitOfWork.Units.GetAllAsync(condominiumId);
            var residentIds = units.Where(u => u.ResidentId.HasValue).Select(u => u.ResidentId.Value).Distinct().ToList();

            if (!residentIds.Any()) return true;

            var residents = await _unitOfWork.Users.GetUsersByIdsAsync(residentIds);

            string emailMessage = $"<p>{message.Replace("\n", "<br>")}</p><br/><em>Sent by: {sentByUserName}</em>";
            var notificationsToCreate = new List<Notification>();

            foreach (var resident in residents)
            {
                if (!string.IsNullOrEmpty(resident.Email))
                {
                    await _mailService.SendEmailAsync(resident.Email, subject, emailMessage);

                    var notification = new Notification
                    {
                        UserId = resident.Id,
                        CompanyId = companyId,
                        Type = "Announcement",
                        Title = subject,
                        Message = message
                    };
                    await _unitOfWork.Notifications.AddAsync(notification);
                    notificationsToCreate.Add(notification);
                }
            }
            await _unitOfWork.CompleteAsync();
            foreach (var n in notificationsToCreate)
            {
                await PushNotificationToClient(n);
            }
            return true;
        }

        public async Task NotifyManagerOfNewOccurrenceAsync(CoreOccurrence occurrence)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(occurrence.CondominiumId, occurrence.CompanyId);
            if (condo?.ManagerId == null) return;

            var manager = await _unitOfWork.Users.GetUserByIdAsync(condo.ManagerId.Value);
            if (manager?.Email == null) return;

            var resident = await _unitOfWork.Users.GetUserByIdAsync(occurrence.ReportedByUserId);
            var unit = await _unitOfWork.Units.GetByIdAsync(occurrence.UnitId ?? 0);

            var title = $"New Occurrence in {condo.Name}";
            var message = $"'{occurrence.Title}' was reported by {resident?.FirstName} {resident?.LastName} for Unit {unit?.Identifier}.";

            await _mailService.SendEmailAsync(manager.Email, title, message);

            var notification = new Notification
            {
                UserId = manager.Id,
                CompanyId = occurrence.CompanyId,
                Type = "New Occurrence",
                Title = title,
                Message = message,
                RelatedEntityId = occurrence.Id
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            await PushNotificationToClient(notification);
        }

        public async Task NotifyEmployeeOfNewTaskAsync(CoreIntervention intervention)
        {
            if (intervention.AssignedToUserId == null) return;

            var employee = await _unitOfWork.Users.GetUserByIdAsync(intervention.AssignedToUserId.Value);
            if (employee?.Email == null) return;

            var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(intervention.OccurrenceId);
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(intervention.CondominiumId, intervention.CompanyId);

            var title = $"New Task Assigned at {condo.Name}";
            var message = $"You have a new task for '{occurrence.Title}', scheduled for {intervention.StartDate:g}.";

            await _mailService.SendEmailAsync(employee.Email, title, message);

            var notification = new Notification
            {
                UserId = employee.Id,
                CompanyId = intervention.CompanyId,
                Type = "New Task",
                Title = title,
                Message = message,
                RelatedEntityId = intervention.Id
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            await PushNotificationToClient(notification);
        }

        public async Task NotifyManagerOfPaymentProofSubmittedAsync(CoreUnitQuota quota)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(quota.CondominiumId, quota.CompanyId);
            if (condo?.ManagerId == null) return;

            var manager = await _unitOfWork.Users.GetUserByIdAsync(condo.ManagerId.Value);
            if (manager?.Email == null) return;

            var unit = await _unitOfWork.Units.GetByIdAsync(quota.UnitId);
            var resident = await _unitOfWork.Users.GetUserByIdAsync(unit?.ResidentId ?? 0);

            var title = "Payment Proof Submitted";
            var message = $"{resident?.FirstName} {resident?.LastName} (Unit {unit?.Identifier}) has submitted proof for the fee: '{quota.Description}'.";

            await _mailService.SendEmailAsync(manager.Email, title, message);

            var notification = new Notification
            {
                UserId = manager.Id,
                CompanyId = quota.CompanyId,
                Type = "Payment Proof Submitted",
                Title = title,
                Message = message,
                RelatedEntityId = quota.Id
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            await PushNotificationToClient(notification);
        }

        public async Task NotifyResidentOfStatusChangeAsync(CoreOccurrence occurrence)
        {
            var resident = await _unitOfWork.Users.GetUserByIdAsync(occurrence.ReportedByUserId);
            if (resident?.Email == null) return;

            var title = $"Update on your report: '{occurrence.Title}'";
            var message = $"The status has been updated to: {occurrence.Status}.";

            await _mailService.SendEmailAsync(resident.Email, title, message);

            var notification = new Notification
            {
                UserId = resident.Id,
                CompanyId = occurrence.CompanyId,
                Type = "Status Change",
                Title = title,
                Message = message,
                RelatedEntityId = occurrence.Id
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            await PushNotificationToClient(notification);
        }

        public async Task NotifyResidentOfPaymentConfirmationAsync(CoreUnitQuota quota)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(quota.UnitId);
            if (unit?.ResidentId == null) return;
            var resident = await _unitOfWork.Users.GetUserByIdAsync(unit.ResidentId.Value);
            if (resident?.Email == null) return;

            var title = "Payment Confirmed";
            var message = $"Your payment of {quota.AmountDue:C} for '{quota.Description}' has been confirmed. Thank you!";

            await _mailService.SendEmailAsync(resident.Email, title, message);
            var notification = new Notification
            {
                UserId = resident.Id,
                CompanyId = quota.CompanyId,
                Type = "Payment Confirmed",
                Title = title,
                Message = message,
                RelatedEntityId = quota.Id
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            await PushNotificationToClient(notification);
        }

        public async Task NotifyResidentsOfNewQuotasAsync(List<CoreUnitQuota> newQuotas, string condominiumName)
        {
            if (!newQuotas.Any()) return;

            var unitIds = newQuotas.Select(q => q.UnitId).Distinct().ToList();
            var units = await _unitOfWork.Units.GetByIdsAsync(unitIds);
            var unitLookup = units.ToDictionary(u => u.Id);

            var residentToQuotaMap = new Dictionary<int, CoreUnitQuota>();
            foreach (var quota in newQuotas)
            {
                if (unitLookup.TryGetValue(quota.UnitId, out var unit) && unit.ResidentId.HasValue)
                {
                    residentToQuotaMap[unit.ResidentId.Value] = quota;
                }
            }
            if (!residentToQuotaMap.Any()) return;
            var residents = await _unitOfWork.Users.GetUsersByIdsAsync(residentToQuotaMap.Keys.ToList());

            var notificationsToCreate = new List<Notification>();

            foreach (var resident in residents)
            {
                if (residentToQuotaMap.TryGetValue(resident.Id, out var quotaForResident) && !string.IsNullOrEmpty(resident.Email))
                {
                    var title = $"New Fee Issued for {condominiumName}";
                    var message = $"A new fee of {quotaForResident.AmountDue:C} for '{quotaForResident.Description}' is now available in the portal.";
                    await _mailService.SendEmailAsync(resident.Email, title, message);

                    var notification = new Notification
                    {
                        UserId = resident.Id,
                        CompanyId = quotaForResident.CompanyId,
                        Type = "New Quota",
                        Title = title,
                        Message = message,
                        RelatedEntityId = quotaForResident.Id
                    };
                    await _unitOfWork.Notifications.AddAsync(notification);
                    notificationsToCreate.Add(notification);
                }
            }
            await _unitOfWork.CompleteAsync();
            foreach (var n in notificationsToCreate)
            {
                await PushNotificationToClient(n);
            }
        }

        public async Task NotifyResidentsOfNewDocumentAsync(CoreDocument document)
        {
            var units = await _unitOfWork.Units.GetAllAsync(document.CondominiumId);
            var residentIds = units.Where(u => u.ResidentId.HasValue).Select(u => u.ResidentId.Value).Distinct().ToList();
            if (!residentIds.Any()) return;

            var residents = await _unitOfWork.Users.GetUsersByIdsAsync(residentIds);
            var title = $"New Document Available: {document.Title}";
            var message = $"A new document '{document.Title}' has been added to the '{document.Category}' section.";

            var notificationsToCreate = new List<Notification>();

            foreach (var resident in residents)
            {
                if (!string.IsNullOrEmpty(resident.Email))
                {
                    await _mailService.SendEmailAsync(resident.Email, title, message);
                    var notification = new Notification
                    {
                        UserId = resident.Id,
                        CompanyId = document.CompanyId,
                        Type = "New Document",
                        Title = title,
                        Message = message,
                        RelatedEntityId = document.Id
                    };
                    await _unitOfWork.Notifications.AddAsync(notification);
                    notificationsToCreate.Add(notification);
                }
            }
            await _unitOfWork.CompleteAsync();
            foreach (var n in notificationsToCreate)
            {
                await PushNotificationToClient(n);
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsForUserAsync(int userId)
        {
            var notifications = await _unitOfWork.Notifications.GetUnreadByUserIdAsync(userId);

            var dtos = new List<NotificationDto>();
            foreach (var notification in notifications)
            {
                var dto = _mapper.Map<NotificationDto>(notification);
                dto.LinkUrl = await GenerateLinkForNotification(notification);
                dtos.Add(dto);
            }
            return dtos;
        }

        // --- Private Helper Methods ---

        private async Task PushNotificationToClient(Notification notification)
        {
            var notificationDto = _mapper.Map<NotificationDto>(notification);
            notificationDto.LinkUrl = await GenerateLinkForNotification(notification);

            await _hubContext.Clients.User(notification.UserId.ToString())
                             .SendAsync("ReceiveNotification", notificationDto);
        }

        private async Task<string> GenerateLinkForNotification(Notification notification)
        {
            switch (notification.Type)
            {
                case "New Occurrence":
                    var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(notification.RelatedEntityId ?? 0);
                    return $"/condo-management/{occurrence?.CondominiumId}/occurrences/{notification.RelatedEntityId}";

                case "New Task":
                    return $"/employee/{notification.RelatedEntityId}";

                case "Task Completed":
                    var parentOccurrence = await _unitOfWork.Occurrences.GetByIdAsync(notification.RelatedEntityId ?? 0);
                    return $"/condo-management/{parentOccurrence?.CondominiumId}/occurrences/{notification.RelatedEntityId}";

                case "Status Change":
                    return $"/portal/occurrences/{notification.RelatedEntityId}";

                case "Payment Proof Submitted":
                    var quota = await _unitOfWork.UnitQuotas.GetByIdAsync(notification.RelatedEntityId ?? 0);
                    return $"/condo-management/{quota?.CondominiumId}/quotas";

                case "New Quota":
                case "Payment Confirmed":
                    return $"/portal/quotas/{notification.RelatedEntityId}/details";

                case "Payment Rejected":
                    return $"/portal/quotas/{notification.RelatedEntityId}/details";

                case "Assembly Invitation":
                    return $"/assemblies/{notification.RelatedEntityId}/room";

                case "New Document":
                    return "/portal?activeTab=info-tab";

                case "Announcement":
                default:
                    return "/portal";
            }
        }

        public async Task MarkAllNotificationsAsReadAsync(int userId)
        {
            var unreadNotifications = await _unitOfWork.Notifications.GetUnreadByUserIdAsync(userId);

            if (!unreadNotifications.Any())
            {
                return;
            }

            foreach (var notification in unreadNotifications)
            {
                notification.IsRead = true;
                _unitOfWork.Notifications.Update(notification);
            }
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotificationsForUserAsync(int userId)
        {
            var notifications = await _unitOfWork.Notifications.GetAllByUserIdAsync(userId);

            var dtos = new List<NotificationDto>();
            foreach (var notification in notifications)
            {
                var dto = _mapper.Map<NotificationDto>(notification);
                dto.LinkUrl = await GenerateLinkForNotification(notification);
                dtos.Add(dto);
            }
            return dtos;
        }

        public async Task NotifyResidentOfPaymentRejectionAsync(CoreUnitQuota quota, string reason)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(quota.UnitId);
            if (unit?.ResidentId == null) return;
            var resident = await _unitOfWork.Users.GetUserByIdAsync(unit.ResidentId.Value);
            if (resident?.Email == null) return;

            var title = $"Action Required: Payment for '{quota.Description}'";
            var message = $"Your submitted payment proof was rejected. Reason provided: '{reason}'. Please log in to the portal to submit a valid proof.";

            await _mailService.SendEmailAsync(resident.Email, title, message);
            var notification = new Notification
            {
                UserId = resident.Id,
                CompanyId = quota.CompanyId,
                Type = "Payment Rejected",
                Title = title,
                Message = message,
                RelatedEntityId = quota.Id
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            await PushNotificationToClient(notification);
        }

        public async Task NotifyManagerOfTaskCompletionAsync(CoreIntervention intervention)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(intervention.CondominiumId, intervention.CompanyId);
            if (condo?.ManagerId == null) return;

            var manager = await _unitOfWork.Users.GetUserByIdAsync(condo.ManagerId.Value);
            if (manager?.Email == null) return;

            var employee = await _unitOfWork.Users.GetUserByIdAsync(intervention.AssignedToUserId ?? 0);
            var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(intervention.OccurrenceId);

            var title = $"Task Completed in {condo.Name}";
            var message = $"The task '{intervention.Description}' for occurrence '{occurrence.Title}' was marked as complete by {employee?.FirstName} {employee?.LastName}.";

            await _mailService.SendEmailAsync(manager.Email, title, message);

            var notification = new Notification
            {
                UserId = manager.Id,
                CompanyId = intervention.CompanyId,
                Type = "Task Completed",
                Title = title,
                Message = message,
                RelatedEntityId = occurrence.Id
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            await PushNotificationToClient(notification);
        }

        public async Task<bool> MarkNotificationAsReadAsync(int userId, int notificationId)
        {
            return await _unitOfWork.Notifications.MarkAsReadAsync(userId, notificationId);
        }
    }
}