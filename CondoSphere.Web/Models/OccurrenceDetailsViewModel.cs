using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class OccurrenceDetailsViewModel
    {
        public OccurrenceDto Occurrence { get; set; }
        public IEnumerable<InterventionDto> Interventions { get; set; } = new List<InterventionDto>();
        public CreateInterventionDto NewIntervention { get; set; } = new CreateInterventionDto();
    }
}