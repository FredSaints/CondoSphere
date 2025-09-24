using CondoSphere.Core.DTOs.Notifications;
using CoreDocument = CondoSphere.Core.Entities.Condominiums.Document;
using CoreIntervention = CondoSphere.Core.Entities.Condominiums.Intervention;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;
using CoreUnitQuota = CondoSphere.Core.Entities.Financials.UnitQuota;

namespace CondoSphere.Application.Services.Notifications
{
    public interface INotificationService
    {
        Task<bool> SendAnnouncementToCondominiumAsync(int condominiumId, int companyId, string subject, string message, string sentByUserName);
        Task NotifyManagerOfNewOccurrenceAsync(CoreOccurrence occurrence);
        Task NotifyEmployeeOfNewTaskAsync(CoreIntervention intervention);
        Task NotifyManagerOfPaymentProofSubmittedAsync(CoreUnitQuota quota);
        Task NotifyResidentOfStatusChangeAsync(CoreOccurrence occurrence);
        Task NotifyResidentOfPaymentConfirmationAsync(CoreUnitQuota quota);
        Task NotifyResidentsOfNewQuotasAsync(List<CoreUnitQuota> newQuotas, string condominiumName);
        Task NotifyResidentsOfNewDocumentAsync(CoreDocument document);
        Task NotifyManagerOfTaskCompletionAsync(CoreIntervention intervention);
        Task<IEnumerable<NotificationDto>> GetNotificationsForUserAsync(int userId);
        Task MarkAllNotificationsAsReadAsync(int userId);
        Task<IEnumerable<NotificationDto>> GetAllNotificationsForUserAsync(int userId);
        Task NotifyResidentOfPaymentRejectionAsync(CoreUnitQuota quota, string reason);
        Task<bool> MarkNotificationAsReadAsync(int userId, int notificationId);
    }
}