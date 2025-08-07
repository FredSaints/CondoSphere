using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}