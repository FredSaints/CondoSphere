using CondoSphere.Core.Entities.Users;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Infrastructure.Data
{
    /// <summary>
    /// Responsible for seeding initial data into the database.
    /// </summary>
    public class SeedDb
    {
        private readonly UserManagementDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public SeedDb(UserManagementDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
        }

        private async Task CheckRolesAsync()
        {
            // Check if a specific role already exists. If not, create all of them.
            if (!await _roleManager.RoleExistsAsync(SystemRole.CompanyAdmin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(SystemRole.CompanyAdmin.ToString()));
                await _roleManager.CreateAsync(new IdentityRole<int>(SystemRole.CondoManager.ToString()));
                await _roleManager.CreateAsync(new IdentityRole<int>(SystemRole.CondoResident.ToString()));
                await _roleManager.CreateAsync(new IdentityRole<int>(SystemRole.Employee.ToString()));
                await _roleManager.CreateAsync(new IdentityRole<int>(SystemRole.PlatformSuperAdmin.ToString()));
            }
        }
    }
}