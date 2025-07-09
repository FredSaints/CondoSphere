using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Condominium : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CompanyId { get; set; }
    }
}
