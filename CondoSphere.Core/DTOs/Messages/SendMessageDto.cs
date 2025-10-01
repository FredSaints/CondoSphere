using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Messages
{
    /// <summary>
    /// Send Message DTO.
    /// </summary>
    public class SendMessageDto
    {
        [Required]
        public int ReceiverId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [StringLength(2000, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;

        public int? CondominiumId { get; set; }
    }
}
