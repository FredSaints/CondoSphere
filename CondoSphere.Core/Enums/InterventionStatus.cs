using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the possible statuses for a maintenance intervention.
    /// </summary>
    public enum InterventionStatus
    {
        /// <summary>
        /// The intervention has been planned but not yet started.
        /// </summary>
        Scheduled = 1,

        /// <summary>
        /// The intervention is currently in progress.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The intervention work has been completed.
        /// </summary>
        Completed = 3,

        /// <summary>
        /// The intervention has been cancelled.
        /// </summary>
        Cancelled = 4
    }
}
