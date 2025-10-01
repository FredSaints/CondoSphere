namespace CondoSphere.Core.DTOs.Notifications
{
    /// <summary>
    /// Notification DTO.
    /// </summary>
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
        public string LinkUrl { get; set; } = string.Empty;
    }
}