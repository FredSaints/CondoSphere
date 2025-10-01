using CondoSphere.Core.Entities.Assembly;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Assembly Repository.
    /// </summary>
    public interface IAssemblyRepository
    {
        Task AddAsync(Assembly entity);
        void Update(Assembly entity);
        Task<Assembly?> GetByIdAsync(int id);

        Task<IReadOnlyList<Assembly>> GetByCondominiumAsync(int condominiumId);
        Task<IReadOnlyList<Assembly>> GetAllForCompanyAsync(int companyId);
    }
}
