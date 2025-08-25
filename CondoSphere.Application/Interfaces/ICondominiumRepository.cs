using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for data operations related to Condominiums.
    /// The responsibility for saving changes is handled by the IUnitOfWork.
    /// </summary>
    public interface ICondominiumRepository
    {
        Task AddAsync(Condominium condominium);
        void Update(Condominium condominium);
        void Remove(Condominium condominium);
        Task<Condominium?> GetByIdAsync(int id, int companyId);
        Task<IEnumerable<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize);
        Task<IEnumerable<Condominium>> GetByManagerIdAsync(int managerId);
        Task<IEnumerable<Condominium>> GetByIdsAsync(IEnumerable<int> ids);
        Task<IEnumerable<Condominium>> GetAllForCompanyAsync(int companyId);
    }
}