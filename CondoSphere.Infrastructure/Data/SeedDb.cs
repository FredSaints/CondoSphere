using CondoSphere.Core;
using CondoSphere.Core.Entities.Users;
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
            // Use the constant for the check
            if (!await _roleManager.RoleExistsAsync(RoleConstants.CompanyAdmin))
            {
                // Use the constants for creation
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CompanyAdmin));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CondoManager));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CondoResident));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.Employee));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.PlatformSuperAdmin));
            }
        }
    }
}