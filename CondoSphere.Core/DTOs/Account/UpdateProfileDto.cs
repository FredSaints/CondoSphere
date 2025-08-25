using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class UpdateProfileDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }

        [Required]
        [Phone] 
        public string PhoneNumber { get; set; }
    }
}