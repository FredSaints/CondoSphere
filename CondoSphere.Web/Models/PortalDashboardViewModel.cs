using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class PortalDashboardViewModel
    {
        public IEnumerable<OccurrenceDto> Occurrences { get; set; } = new List<OccurrenceDto>();
    }
}