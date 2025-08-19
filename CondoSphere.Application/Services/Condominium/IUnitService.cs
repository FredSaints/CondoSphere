using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondoSphere.Application.Services.Condominium
{
    public interface IUnitService
    {
        /// <summary>
        /// Gets a list of all units for a specific condominium, enriched with resident information.
        /// </summary>
        Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId);

        /// <summary>
        /// Gets a single unit by its ID.
        /// </summary>
        Task<UnitDto?> GetUnitByIdAsync(int unitId);

        /// <summary>
        /// Creates a new unit within a condominium.
        /// </summary>
        Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId);

        /// <summary>
        /// Updates the details of an existing unit.
        /// </summary>
        Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto);

        /// <summary>
        /// Deletes a unit.
        /// </summary>
        Task<bool> DeleteUnitAsync(int unitId);
    }
}