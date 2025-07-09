using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Assembly : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string? MinutesUrl { get; set; }
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
    }
}
