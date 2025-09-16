using CondoSphere.Core.Entities.Messages;
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
        /// Represents the 'Messages' table.
        /// </summary>
        public DbSet<Message> Messages { get; set; }

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

            builder.Entity<User>().HasQueryFilter(u => u.IsActive);
            builder.Entity<Company>().HasQueryFilter(c => c.IsActive);

            builder.Entity<Message>(entity =>
            {
                entity.HasIndex(m => new { m.ReceiverId, m.SentDate })
                      .HasDatabaseName("IX_Messages_Receiver_SentDate");

                entity.HasIndex(m => new { m.SenderId, m.SentDate })
                      .HasDatabaseName("IX_Messages_Sender_SentDate");

                entity.HasIndex(m => new { m.CompanyId, m.ReceiverId, m.ReadDate })
                      .HasDatabaseName("IX_Messages_Company_Receiver_ReadDate");

                entity.Property(m => m.Subject)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(m => m.Content)
                      .IsRequired()
                      .HasMaxLength(2000);
            });
        }
    }
}
