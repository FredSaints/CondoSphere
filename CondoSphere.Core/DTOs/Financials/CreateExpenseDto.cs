
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Financials
{
    /// <summary>
    /// Create Expense DTO.
    /// </summary>
    public class CreateExpenseDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 1_000_000)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public int CondominiumId { get; set; }

        public int? OccurrenceId { get; set; }
    }
}