using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Interventions
{
    public class CreateInterventionDto
    {
        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        // The ID of the parent occurrence this intervention is for.
        [Required]
        public int OccurrenceId { get; set; }

        // The ID of the employee assigned.
        public int? AssignedToUserId { get; set; }
    }
}