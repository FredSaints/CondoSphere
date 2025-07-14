using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);
    }
}