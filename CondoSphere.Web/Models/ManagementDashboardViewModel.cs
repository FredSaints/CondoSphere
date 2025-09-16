using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Reports;

namespace CondoSphere.Web.Models
{
    public class ManagementDashboardViewModel
    {
        public AdminDashboardDto DashboardStats { get; set; }
        public IEnumerable<UserListDto> Users { get; set; } = new List<UserListDto>();
        public IEnumerable<CondominiumDto> Condominiums { get; set; } = new List<CondominiumDto>();
    }
}
