using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Financials
{
    public class RejectPaymentDto
    {
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string RejectionReason { get; set; } = string.Empty;
    }
}