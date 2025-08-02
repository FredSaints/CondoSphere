using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class RegisterResidentViewModel
    {
        [Required]
        public int UnitId { get; set; }

        [Required]
        public int CondominiumId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}