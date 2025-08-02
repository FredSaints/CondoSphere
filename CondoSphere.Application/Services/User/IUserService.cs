using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Application.Services.User
{
    /// <summary>
    /// Defines the contract for user management services.
    /// </summary>
    public interface IUserService
    {
        Task<IdentityResult> RegisterCompanyAdminAsync(RegisterDto registerDto);
        Task<UserDto?> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> RegisterManagerAsync(RegisterManagerDto registerDto, int companyId);
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);
        Task<IdentityResult> RegisterResidentAsync(RegisterResidentDto dto, int companyId, int condominiumId);
        Task<IEnumerable<UserListDto>> GetAvailableManagersAsync(int companyId);
    }
}
