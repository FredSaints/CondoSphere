using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Application.Services.Condominium
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId);
        Task<UnitDto?> GetUnitByIdAsync(int unitId);
        Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId);
        Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto);
        Task<bool> DeleteUnitAsync(int unitId);
        Task<bool> UnassignResidentAsync(int unitId);
        Task<bool> AssignExistingResidentAsync(int unitId, int residentId, int companyId);
    }
}
