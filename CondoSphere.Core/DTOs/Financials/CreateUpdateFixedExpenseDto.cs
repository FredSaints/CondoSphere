using CondoSphere.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Financials
{
    /// <summary>
    /// Create Update Fixed Expense DTO.
    /// </summary>
    public class CreateUpdateFixedExpenseDto
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
        public ExpenseFrequency Frequency { get; set; }

        [Required]
        [Range(1, 28, ErrorMessage = "Day of Billing must be between 1 and 28.")]
        public int DayOfBilling { get; set; } = 1;

        [Required]
        public int CondominiumId { get; set; }
    }
}
