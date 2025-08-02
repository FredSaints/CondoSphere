using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);
        Task<IEnumerable<UserListDto>> GetUsersInRoleAsync(string roleName, int companyId);
    }
}