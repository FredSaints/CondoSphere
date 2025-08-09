using CondoSphere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Occurrences
{
    public class UpdateOccurrenceStatusDto
    {
        [Required]
        [EnumDataType(typeof(OccurrenceStatus))]
        public OccurrenceStatus Status { get; set; }
    }
}