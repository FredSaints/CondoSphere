using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Assign Resident DTO.
    /// </summary>
    public class AssignResidentDto
    {
        [Required]
        public int ResidentId { get; set; }
    }
}