using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    public interface IUnitRepository
    {
        Task AddAsync(Unit unit);
        void Update(Unit unit);
        void Remove(Unit unit);
        Task<Unit?> GetByIdAsync(int unitId);
        Task<IEnumerable<Unit>> GetAllAsync(int condominiumId);
        Task<int> SaveChangesAsync();
    }
}
