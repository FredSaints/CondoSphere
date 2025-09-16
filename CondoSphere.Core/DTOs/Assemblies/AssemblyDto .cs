using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Assemblies
{
    public class AssemblyDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CondominiumId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Agenda { get; set; }
        public string? MinutesUrl { get; set; }
    }
}
