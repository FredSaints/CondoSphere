using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Occurrences
{
    /// <summary>
    /// Create Occurrence DTO.
    /// </summary>
    public class CreateOccurrenceDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Title must be between 5 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "The Description must be between 10 and 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select the unit for this occurrence.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid unit.")]
        public int UnitId { get; set; }
    }
}