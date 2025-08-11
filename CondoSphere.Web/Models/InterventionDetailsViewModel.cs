using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class InterventionDetailsViewModel
    {
        public InterventionDto Intervention { get; set; }
        public OccurrenceDto Occurrence { get; set; }
    }
}