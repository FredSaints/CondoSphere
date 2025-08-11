using CondoSphere.Core.Entities.Financials;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    public class FinancialsDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseAttachment> ExpenseAttachments { get; set; }
        // We will add DbSet for UnitQuota, Receipt, etc. here later.

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
            // This defines the one-to-many relationship:
            // An ExpenseAttachment has one Expense.
            // An Expense has many ExpenseAttachments.
            // The foreign key is ExpenseId.
            modelBuilder.Entity<ExpenseAttachment>()
                .HasOne(a => a.Expense)
                .WithMany(e => e.Attachments)
                .HasForeignKey(a => a.ExpenseId);
        }
    }
}