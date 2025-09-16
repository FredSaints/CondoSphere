using CondoSphere.Core.DTOs.Notifications;

namespace CondoSphere.Web.Models
{
    public class NotificationBellViewModel
    {
        public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
        public int UnreadCount { get; set; }
    }
}