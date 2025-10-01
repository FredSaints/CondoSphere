using CondoSphere.Core.Enums;

namespace CondoSphere.Core.DTOs.Interventions
{
    /// <summary>
    /// Intervention DTO.
    /// </summary>
    public class InterventionDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public InterventionStatus Status { get; set; }
        public int OccurrenceId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string? AssignedToUserName { get; set; }
    }
}