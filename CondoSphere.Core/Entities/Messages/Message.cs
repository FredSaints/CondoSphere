using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.Entities.Messages
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public int? CondominiumId { get; set; }

        [Required]
        [StringLength(150)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime SentDate { get; set; }

        public DateTime? ReadDate { get; set; }

        public bool IsRead => ReadDate.HasValue;
    }
}
