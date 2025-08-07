using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Condominiums
{
    public class AssignResidentDto
    {
        [Required]
        public int ResidentId { get; set; }
    }
}