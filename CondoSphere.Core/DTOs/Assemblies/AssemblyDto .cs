using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Assemblies
{
    /// <summary>
    /// Assembly DTO.
    /// </summary>
    public class AssemblyDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; } = string.Empty;
        public int CondominiumId { get; set; }
        public string? CondominiumName { get; set; }
        public int CompanyId { get; set; }
        public string? JitsiRoomName { get; set; }
        public string? JitsiRoomPassword { get; set; }
        public List<string> participants { get; set; } = new List<string>();
    }
}
