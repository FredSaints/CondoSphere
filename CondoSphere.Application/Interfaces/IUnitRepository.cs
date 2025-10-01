using CondoSphere.Core.Entities.Condominiums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Unit Repository.
    /// </summary>
    public interface IUnitRepository
    {
        /// <summary>
        /// Adds a new Unit entity to the database context.
        /// </summary>
        Task AddAsync(Unit unit);

        /// <summary>
        /// Marks an existing Unit entity as modified in the database context.
        /// </summary>
        void Update(Unit unit);

        /// <summary>
        /// Marks an existing Unit entity for deletion in the database context.
        /// </summary>
        void Remove(Unit unit);

        /// <summary>
        /// Gets a single Unit by its primary key.
        /// </summary>
        Task<Unit?> GetByIdAsync(int unitId);

        /// <summary>
        /// Gets all Units that belong to a specific Condominium.
        /// </summary>
        Task<IEnumerable<Unit>> GetAllAsync(int condominiumId);

        /// <summary>
        /// Gets all Units assigned to a specific resident User ID.
        /// </summary>
        Task<IEnumerable<Unit>> GetUnitsByResidentIdAsync(int residentId);
        Task<IEnumerable<Unit>> GetByResidentIdAsync(int residentId);
        Task<IEnumerable<Unit>> GetByIdsAsync(IEnumerable<int> ids);
        Task<int> GetCountByCondominiumIdsAsync(IEnumerable<int> condominiumIds);
    }
}