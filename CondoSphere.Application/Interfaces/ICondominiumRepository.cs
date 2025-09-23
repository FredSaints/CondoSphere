using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    public interface ICondominiumRepository
    {
        // CRUD
        Task AddAsync(Condominium entity);
        void Update(Condominium entity);
        void Remove(Condominium entity);

        // READ (scoped por empresa)
        Task<Condominium?> GetByIdAsync(int id, int companyId);

        // Listagens
        Task<IReadOnlyList<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize);
        Task<IReadOnlyList<Condominium>> GetAllForCompanyAsync(int companyId);
        Task<IReadOnlyList<Condominium>> GetByManagerIdAsync(int managerId);

        // Utilitários
        Task<IReadOnlyList<Condominium>> GetByIdsAsync(IEnumerable<int> ids);
        Task<int> CountAsync(int companyId);
    }
}
