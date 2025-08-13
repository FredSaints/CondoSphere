using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{

    public class CondominiumDetailsViewModel
    {
        public CondominiumDto Condominium { get; set; }
        public IEnumerable<UnitDto> Units { get; set; } = new List<UnitDto>();
        public IEnumerable<OccurrenceDto> Occurrences { get; set; } = new List<OccurrenceDto>();
    }
}