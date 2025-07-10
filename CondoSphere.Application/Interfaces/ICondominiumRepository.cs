using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for data operations related to Condominiums.
    /// </summary>
    public interface ICondominiumRepository
    {
        Task AddAsync(Condominium condominium);
        void Update(Condominium condominium);
        void Remove(Condominium condominium);
        Task<Condominium?> GetByIdAsync(int id, int companyId);
        Task<IEnumerable<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize);

        Task<bool> SaveChangesAsync();
    }
}
