using CondoSphere.Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Assemblies
{
    public class CreateAssemblyDto
    {
        [Required]
        public int CondominiumId { get; set; }

        [Required, DateNotInPast]
        public DateTime ScheduledAt { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Agenda { get; set; }
    }

}
