using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the core user roles within the system.
    /// The values should correspond to the IDs in the Roles database table.
    /// </summary>
    public enum SystemRole
    {
        CompanyAdmin = 1,
        CondoManager = 2,
        CondoResident = 3,
        Employee = 4,
        PlatformSuperAdmin = 5
    }
}
