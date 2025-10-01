using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required to register a new company and its first administrator.
    /// </summary>
    public class RegisterDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CompanyName { get; set; } = string.Empty;

        [EmailAddress]
        [Display(Name = "Company Email")]
        public string? CompanyEmail { get; set; }

        [Phone]
        [Display(Name = "Company Phone Number")]
        public string? CompanyPhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "VAT Number")]
        public string? VatNumber { get; set; }

        [StringLength(255)]
        [Display(Name = "Company Address")]
        public string? Address { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone] 
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]//TODO: Aumentar a segurança da password (por enquanto vamos usar 123456)
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}