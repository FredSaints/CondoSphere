using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents the data needed to create or update a condominium.
    /// </summary>
    public class CreateUpdateCondominiumDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Address { get; set; } = string.Empty;
    }
}