using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class EmployeeInterventionViewModel
    {
        public InterventionDto Intervention { get; set; }
        public OccurrenceDto Occurrence { get; set; }
        public UpdateInterventionStatusDto StatusUpdate { get; set; } = new UpdateInterventionStatusDto();
    }
}