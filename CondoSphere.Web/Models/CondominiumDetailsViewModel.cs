using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{

    public class CondominiumDetailsViewModel
    {
        public CondominiumDto Condominium { get; set; }
        public IEnumerable<UnitDto> Units { get; set; } = new List<UnitDto>();
        public IEnumerable<OccurrenceDto> Occurrences { get; set; } = new List<OccurrenceDto>();
        public IEnumerable<ExpenseDto> FixedExpenses { get; set; } = new List<ExpenseDto>();
        public IEnumerable<UnitQuotaDto> AllQuotas { get; set; } = new List<UnitQuotaDto>();
        public IEnumerable<DocumentDto> Documents { get; set; } = new List<DocumentDto>();
    }
}