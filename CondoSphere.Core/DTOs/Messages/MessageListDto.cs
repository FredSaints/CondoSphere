namespace CondoSphere.Core.DTOs.Messages
{
    /// <summary>
    /// Message List DTO.
    /// </summary>
    public class MessageListDto
    {
        public int Id { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
        public string? CondominiumName { get; set; }
    }
}
