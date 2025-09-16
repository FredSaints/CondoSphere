using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Users
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? RelatedEntityId { get; set; }
    }
}
