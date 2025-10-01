using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Company Profile DTO.
    /// </summary>
    public class CompanyProfileDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "VAT Number")]
        public string? VatNumber { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }
    }
}