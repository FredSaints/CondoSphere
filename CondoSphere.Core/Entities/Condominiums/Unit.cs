//using CondoSphere.Core;
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
       public class Unit : IEntity
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
    }
}
