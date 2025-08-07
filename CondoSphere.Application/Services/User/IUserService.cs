using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using CoreUser = CondoSphere.Core.Entities.Users.User;

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
        Task<IEnumerable<UserListDto>> GetAvailableResidentsAsync(int companyId);
        Task<bool> DeactivateUserAsync(int userIdToDeactivate, int adminCompanyId);
        Task<bool> ActivateUserAsync(int userIdToActivate, int adminCompanyId);
        Task<bool> ForgotPasswordAsync(string email);
        Task<(bool Success, IEnumerable<IdentityError>? Errors)> UpdateProfileAsync(int userId, UpdateProfileDto dto);
        Task<(bool Success, IEnumerable<IdentityError>? Errors)> ChangePasswordAsync(int userId, ChangePasswordDto dto);
        Task<UserProfileDto?> GetUserProfileAsync(int userId);
        Task<CoreUser?> GetUserByIdAsync(int userId);
    }
}
