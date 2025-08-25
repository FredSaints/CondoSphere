using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class TwoFactorChooseMethodViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        // "Email" ou "Sms"
        [Required]
        public string SelectedMethod { get; set; } = "Email";
    }
}
