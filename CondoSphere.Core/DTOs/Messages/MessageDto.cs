namespace CondoSphere.Core.DTOs.Messages
{
    /// <summary>
    /// Message DTO.
    /// </summary>
    public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool IsRead => ReadDate.HasValue;
        public string? CondominiumName { get; set; }
        public int? CondominiumId { get; set; }
    }
}
