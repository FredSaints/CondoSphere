using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Financials
{
    /// <summary>
    /// Represents a single quota (bill or charge) issued to a condominium unit.
    /// This is the core record for what a resident owes.
    /// </summary>
    public class UnitQuota : IEntity
    {
        /// <summary>
        /// The unique identifier for the quota.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the specific unit this quota is for.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// The foreign key to the condominium, denormalized for easier querying.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// A description of the quota (e.g., "Monthly Fee - August 2024").
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The total amount that is due for this quota.
        /// </summary>
        public decimal AmountDue { get; set; }

        /// <summary>
        /// The date by which this quota should be paid.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The amount that has been paid towards this quota so far.
        /// </summary>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// The date the quota was fully paid. Null if not yet paid.
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// The current status of the quota (e.g., "Pending", "Paid", "PartiallyPaid", "Overdue").
        /// </summary>
        public UnitQuotaStatus Status { get; set; }

        /// <summary>
        /// A payment reference number, if applicable (e.g., Multibanco reference).
        /// </summary>
        public string? ReferenceNumber { get; set; }
        /// <summary>
        /// A URL to the proof of payment, if available.
        /// </summary>
        public string? ProofOfPaymentUrl { get; set; }
    }
}
