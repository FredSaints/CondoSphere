using CondoSphere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Interventions
{
    public class UpdateInterventionStatusDto
    {
        [Required]
        [EnumDataType(typeof(InterventionStatus))]
        public InterventionStatus Status { get; set; }
    }
}