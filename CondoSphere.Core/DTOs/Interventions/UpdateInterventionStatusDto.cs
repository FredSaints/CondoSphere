using CondoSphere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Interventions
{
    /// <summary>
    /// Update Intervention Status DTO.
    /// </summary>
    public class UpdateInterventionStatusDto
    {
        [Required]
        [EnumDataType(typeof(InterventionStatus))]
        public InterventionStatus Status { get; set; }
    }
}