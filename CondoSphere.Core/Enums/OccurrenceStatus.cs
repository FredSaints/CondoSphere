using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Occurrence Status.
    /// </summary>
    public enum OccurrenceStatus
    {
        /// <summary>
        /// The occurrence has been reported but not yet acted upon.
        /// </summary>
        Open = 1,

        /// <summary>
        /// The occurrence is currently being worked on.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The occurrence is temporarily on hold.
        /// </summary>
        OnHold = 3,

        /// <summary>
        /// The issue has been resolved but is pending final confirmation.
        /// </summary>
        Resolved = 4,

        /// <summary>
        /// The occurrence has been fully resolved and closed.
        /// </summary>
        Closed = 5
    }
}
