using CondoSphere.Core.Entities.Financials;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    public class FinancialsDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        // We will add DbSet for UnitQuota, Receipt, etc. here later.

        public FinancialsDbContext(DbContextOptions<FinancialsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for financial data - this is a best practice.
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)");
        }
    }
}