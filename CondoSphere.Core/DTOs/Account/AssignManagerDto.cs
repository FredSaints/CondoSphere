using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required to assign a manager to a condominium.
    /// </summary>
    public class AssignManagerDto
    {
        /// <summary>
        /// The ID of the User (who must have the CondoManager role) to be assigned.
        /// </summary>
        [Required]
        public int ManagerId { get; set; }
    }
}