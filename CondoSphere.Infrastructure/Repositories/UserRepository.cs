using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _context;

        public UserRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId)
        {
            // This query is correct and should remain.
            var usersWithRoles = await _context.Users
                .IgnoreQueryFilters()
                .Where(u => u.CompanyId == companyId)
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    IsActive = u.IsActive,
                    Role = (from userRole in _context.UserRoles
                            join role in _context.Roles on userRole.RoleId equals role.Id
                            where userRole.UserId == u.Id
                            select role.Name).FirstOrDefault() ?? "No Role"
                })
                .AsNoTracking()
                .ToListAsync();

            return usersWithRoles;
        }

        public async Task<IEnumerable<UserListDto>> GetUsersInRoleAsync(string roleName, int companyId)
        {
            // This query is also correct and should remain.
            var usersInRole = await _context.Users
                .Where(u => u.CompanyId == companyId && _context.UserRoles.Any(ur => ur.UserId == u.Id && _context.Roles.Any(r => r.Id == ur.RoleId && r.Name == roleName)))
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    IsActive = u.IsActive,
                    Role = roleName
                })
                .AsNoTracking()
                .ToListAsync();

            return usersInRole;
        }
    }
}