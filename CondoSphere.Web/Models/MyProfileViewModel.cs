using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class MyProfileViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        public string? CurrentProfileImageUrl { get; set; }

        [Display(Name = "Upload New Profile Image")]
        public IFormFile? ProfileImage { get; set; }
    }
}