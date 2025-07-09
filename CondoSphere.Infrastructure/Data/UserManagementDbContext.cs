using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    /// <summary>
    /// Represents the database context for the User Management database.
    /// Inherits from IdentityDbContext to include tables for ASP.NET Core Identity.
    /// </summary>
    public class UserManagementDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        // DbSet properties tell EF Core which of our entities should become tables.

        /// <summary>
        /// Represents the 'Companies' table.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Represents the 'Notifications' table.
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}