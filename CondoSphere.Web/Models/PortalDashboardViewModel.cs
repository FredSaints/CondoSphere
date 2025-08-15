using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class PortalDashboardViewModel
    {
        public IEnumerable<OccurrenceDto> Occurrences { get; set; } = new List<OccurrenceDto>();
        public IEnumerable<UnitDto> MyUnits { get; set; } = new List<UnitDto>();
        public IEnumerable<UnitQuotaDto> MyQuotas { get; set; } = new List<UnitQuotaDto>();
    }
}