using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Application.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a list of all users within a specific company, including their assigned role.
        /// Bypasses the IsActive filter to allow admins to see deactivated users.
        /// </summary>
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);

        /// <summary>
        /// Gets a list of all active users within a specific company who have a given role.
        /// </summary>
        Task<IEnumerable<UserListDto>> GetUsersInRoleAsync(string roleName, int companyId);

        Task<IEnumerable<UserListDto>> GetUsersByIdsAsync(List<int> userIds);
        Task<Core.Entities.Users.User?> GetUserByIdAsync(int userId);
    }
}