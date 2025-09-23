namespace CondoSphere.Core.Entities.Assembly
{
    public class AssemblyParticipant : IEntity
    {
        public int Id { get; set; }

        public int AssemblyId { get; set; }
        public int CompanyId { get; set; }
        public int CondominiumId { get; set; }

        public int? UserId { get; set; }            
        public string? ExternalName { get; set; }    

        public DateTime? JoinedAt { get; set; }
        public DateTime? LeftAt { get; set; }
    }
}
