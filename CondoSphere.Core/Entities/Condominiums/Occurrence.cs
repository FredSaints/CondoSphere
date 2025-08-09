using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Occurrence : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReportedDate { get; set; } = DateTime.UtcNow;
        public OccurrenceStatus Status { get; set; }
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
        public int ReportedByUserId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
