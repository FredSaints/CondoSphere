using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    public class CondominiumDbContext : DbContext
    {
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }

        // TODO: Add DbSets for the virtual assembly features later

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