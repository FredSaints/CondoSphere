using CondoSphere.Core.Entities.Financials;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    public class FinancialsDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseAttachment> ExpenseAttachments { get; set; }
        public DbSet<UnitQuota> UnitQuotas { get; set; }
        public DbSet<QuotaPayment> QuotaPayments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public FinancialsDbContext(DbContextOptions<FinancialsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ExpenseAttachment>()
                .HasOne(a => a.Expense)
                .WithMany(e => e.Attachments)
                .HasForeignKey(a => a.ExpenseId);

            modelBuilder.Entity<UnitQuota>(entity =>
            {
                entity.Property(e => e.AmountDue).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<QuotaPayment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            });
        }
    }
}