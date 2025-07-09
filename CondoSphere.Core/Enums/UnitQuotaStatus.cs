using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the possible statuses for a unit's quota (bill).
    /// </summary>
    public enum UnitQuotaStatus
    {
        /// <summary>
        /// The quota has been issued but not yet paid.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// The quota has been paid in full.
        /// </summary>
        Paid = 2,

        /// <summary>
        /// The quota has been partially paid.
        /// </summary>
        PartiallyPaid = 3,

        /// <summary>
        /// The quota's due date has passed, and it remains unpaid.
        /// </summary>
        Overdue = 4,

        /// <summary>
        /// The quota has been cancelled or voided.
        /// </summary>
        Cancelled = 5
    }
}
