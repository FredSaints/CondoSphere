using CondoSphere.Core.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Interventions
{
    /// <summary>
    /// Create Intervention DTO.
    /// </summary>
    public class CreateInterventionDto
    {
        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "The Description must be at least 10 characters long.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DateNotInPast]
        public DateTime StartDate { get; set; }

        // The ID of the parent occurrence this intervention is for.
        [Required]
        public int OccurrenceId { get; set; }

        // The ID of the employee assigned.
        [Required(ErrorMessage = "You must assign an employee.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid employee.")]
        public int AssignedToUserId { get; set; }
    }
}