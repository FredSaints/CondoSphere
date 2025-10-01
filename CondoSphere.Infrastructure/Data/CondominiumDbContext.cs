using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using AssemblyEntity = CondoSphere.Core.Entities.Assembly.Assembly;

namespace CondoSphere.Infrastructure.Data
{
    /// <summary>
    /// Condominium Db Context.
    /// </summary>
    public class CondominiumDbContext : DbContext
    {
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<AssemblyEntity> Assemblies { get; set; } = null!;
        public DbSet<AssemblyParticipant> AssemblyParticipants { get; set; }

        public DbSet<CondoSphere.Core.Entities.Assembly.AssemblyInvite> AssemblyInvites { get; set; }

        public CondominiumDbContext(DbContextOptions<CondominiumDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Unit>()
                .HasIndex(u => new { u.CondominiumId, u.Identifier })
                .IsUnique();
        }
    }
}