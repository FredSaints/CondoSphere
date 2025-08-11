using CondoSphere.Core;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.Entities.Financials
{
    public class ExpenseAttachment : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The public, absolute URL to the stored file.
        /// </summary>
        [Required]
        public string AttachmentUrl { get; set; } = string.Empty;

        /// <summary>
        /// The original filename, stored for user reference.
        /// </summary>
        [StringLength(255)]
        public string? OriginalFileName { get; set; }

        /// <summary>
        /// Foreign key linking this attachment back to its parent Expense.
        /// </summary>
        public int ExpenseId { get; set; }

        // Navigation property for EF Core to understand the relationship
        public Expense Expense { get; set; }
    }
}