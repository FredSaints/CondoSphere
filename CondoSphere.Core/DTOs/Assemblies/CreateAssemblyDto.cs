// CondoSphere.Core/DTOs/Assemblies/CreateAssemblyDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Assemblies
{
    public class CreateAssemblyDto
    {
        [Required]
        public int CondominiumId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, StringLength(150)]
        public string Topic { get; set; } = string.Empty;
    }
}
