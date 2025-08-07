using CondoSphere.Core;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Core.Entities.Users
{
    /// <summary>
    /// Represents a user in the system. Extends the default ASP.NET Core IdentityUser
    /// to use an integer as the primary key and adds custom properties.
    /// The 'Id' from IdentityUser<int> satisfies the IEntity interface contract.
    /// </summary>
    public class User : IdentityUser<int>, IEntity
    {
     
        public int? CompanyId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ProfilePictureUrl { get; set; }
    }
}
