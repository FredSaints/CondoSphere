

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Assemblies
{
    public class PostAssemblyMessageDto
    {
        [Required, StringLength(4000, MinimumLength = 1)]
        public string Message { get; set; } = string.Empty;
    }
}
