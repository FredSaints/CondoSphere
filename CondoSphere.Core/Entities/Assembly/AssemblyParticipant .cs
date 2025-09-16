using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Entities.Assembly
{
    public class AssemblyParticipant : IEntity
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int UserId { get; set; }
        public bool IsInvited { get; set; } = true;
        public bool IsAccepted { get; set; } = false;
        public bool IsEmployee { get; set; } = false; // para distinguir funcionário
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
    }
}
