using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Web.Models
{
    public class ManagementDashboardViewModel
    {
        public IEnumerable<UserListDto> Users { get; set; } = new List<UserListDto>();
        public IEnumerable<CondominiumDto> Condominiums { get; set; } = new List<CondominiumDto>();
    }
}
