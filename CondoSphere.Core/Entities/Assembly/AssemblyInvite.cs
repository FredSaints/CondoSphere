using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Assembly
{
    public class AssemblyInvite : IEntity
    {
        public int Id { get; set; }

        public int AssemblyId { get; set; }
        public int CompanyId { get; set; }
        public int CondominiumId { get; set; }

        public string? Email { get; set; }           // destino por email
        public string? PhoneE164 { get; set; }       // destino por SMS (E.164)

        public int InvitedByUserId { get; set; }     // quem enviou
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public AssemblyInvitationChannel Channel { get; set; }
    }
}
