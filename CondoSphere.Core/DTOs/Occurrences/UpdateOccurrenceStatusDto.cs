using CondoSphere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Occurrences
{
    /// <summary>
    /// Update Occurrence Status DTO.
    /// </summary>
    public class UpdateOccurrenceStatusDto
    {
        [Required]
        [EnumDataType(typeof(OccurrenceStatus))]
        public OccurrenceStatus Status { get; set; }
    }
}