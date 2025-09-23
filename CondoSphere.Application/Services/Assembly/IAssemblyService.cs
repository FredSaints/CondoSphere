using CondoSphere.Core.DTOs.Assemblies;

namespace CondoSphere.Application.Interfaces
{
    public interface IAssemblyService
    {
        // CRUD básico
        Task<AssemblyDto?> CreateAsync(CreateAssemblyDto dto);
        Task<AssemblyDto?> GetByIdAsync(int id);
        Task<AssemblyDto?> UpdateAsync(int id, AssemblyDto dto);

        // Listagens
        Task<IEnumerable<AssemblyDto>> GetForCondominiumAsync(int condominiumId);
        Task<IEnumerable<AssemblyDto>> GetAllForCompanyAsync(int companyId);
        Task<IEnumerable<AssemblyDto>> GetByCondominiumAsync(int condominiumId);

        // Convites
        Task<int> SendInvitesAsync(int assemblyId, SendAssemblyInvitesDto dto);

        // Chat / Sala (placeholders + info Jitsi)
        Task<IEnumerable<AssemblyMessageDto>> GetMessagesAsync(int assemblyId);
        Task<AssemblyMessageDto?> PostMessageAsync(int assemblyId, PostAssemblyMessageDto dto);
        Task<AssemblyRoomInfoDto?> GetRoomInfoAsync(int assemblyId);
    }
}
