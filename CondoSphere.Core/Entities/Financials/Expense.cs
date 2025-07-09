using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    /// <summary>
    /// Represents a common expense incurred by the condominium (e.g., maintenance, utilities).
    /// </summary>
    public class Expense : IEntity
    {
        /// <summary>
        /// The unique identifier for the expense.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the condominium this expense belongs to.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// A descriptive title for the expense (e.g., "Elevator Maintenance Q3").
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// A more detailed description of the expense.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The total amount of the expense.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The date the expense was incurred.
        /// </summary>
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// The name of the supplier or vendor who provided the service/product.
        /// </summary>
        public string? SupplierName { get; set; }

        /// <summary>
        /// The reference number from the supplier's invoice.
        /// </summary>
        public string? InvoiceNumber { get; set; }

        /// <summary>
        /// The category of the expense for reporting (e.g., "Maintenance", "Utilities", "Cleaning").
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}
