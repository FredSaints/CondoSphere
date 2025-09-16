using CondoSphere.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Entities.Assembly
{
    public class AssemblyInvite
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int? InvitedUserId { get; set; }
        public string? Email { get; set; }
        public string? PhoneE164 { get; set; }
        public AssemblyInviteStatus Status { get; set; } = AssemblyInviteStatus.Pending;
        public int InvitedByUserId { get; set; }
        public AssemblyInvitationChannel Channel { get; set; } = AssemblyInvitationChannel.Both;
        public string Token { get; set; } = Guid.NewGuid().ToString("N");
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RespondedAt { get; set; }
    }
}
