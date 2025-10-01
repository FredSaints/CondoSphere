using CondoSphere.Core.Enums;

namespace CondoSphere.Core.DTOs.Occurrences
{
    /// <summary>
    /// Occurrence DTO.
    /// </summary>
    public class OccurrenceDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReportedDate { get; set; }
        public OccurrenceStatus Status { get; set; }
        public string ReportedByUserName { get; set; } = string.Empty;
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
        public string? ImageUrl { get; set; }
    }
}