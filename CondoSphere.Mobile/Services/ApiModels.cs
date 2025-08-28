namespace CondoSphere.Mobile.Services
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }

    public class CreateOccurrenceRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public FileResult? ImageFile { get; set; }
    }

    public class InterventionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string AssignedToUserName { get; set; }
    }

    public class SendMessageDto
    {
        public int ReceiverId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? CondominiumId { get; set; }
    }

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

    public class MessageListDto
    {
        public int Id { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
        public string? CondominiumName { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }

    public class SimpleUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}