using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Notifications
{
    /// <summary>
    /// Announcement DTO.
    /// </summary>
    public class AnnouncementDto
    {
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string Message { get; set; } = string.Empty;
    }
}