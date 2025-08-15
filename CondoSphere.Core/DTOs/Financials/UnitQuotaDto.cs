using CondoSphere.Core.Enums;
namespace CondoSphere.Core.DTOs.Financials
{
    /// <summary>
    /// Represents a single quota (bill or charge) issued to a condominium unit for transfer to the Web app.
    /// </summary>
    public class UnitQuotaDto
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public int CondominiumId { get; set; }

        public string Description { get; set; } = string.Empty;
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public UnitQuotaStatus Status { get; set; }
        public string? ProofOfPaymentUrl { get; set; }
        public string UnitIdentifier { get; set; } = string.Empty;
    }
}