using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Application.Services.Condominium
{
    public interface ICondominiumService
    {
        Task<CondominiumDto?> GetCondominiumByIdAsync(int id, int companyId);
        Task<IEnumerable<CondominiumDto>> GetAllCondominiumsAsync(int companyId, int pageNumber, int pageSize);
        Task<CondominiumDto> CreateCondominiumAsync(CreateUpdateCondominiumDto condominiumDto, int companyId);
        Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto condominiumDto, int companyId);
        Task<bool> DeleteCondominiumAsync(int id, int companyId);
        Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId);
    }
}
