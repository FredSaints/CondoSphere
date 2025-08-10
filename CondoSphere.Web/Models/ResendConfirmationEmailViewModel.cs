using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class ResendConfirmationEmailViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
