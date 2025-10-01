using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Financials
{
    /// <summary>
    /// Reject Payment DTO.
    /// </summary>
    public class RejectPaymentDto
    {
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string RejectionReason { get; set; } = string.Empty;
    }
}