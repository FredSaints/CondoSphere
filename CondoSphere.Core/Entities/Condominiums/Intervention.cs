using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Intervention : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public InterventionStatus Status { get; set; }
        public int? OccurrenceId { get; set; }
        public int CompanyId { get; set; }
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
    }
}
