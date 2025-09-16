using CondoSphere.Core.DTOs.Assemblies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Application.Services.Assembly
{
    public interface IAssemblyService
    {
        Task<AssemblyDto?> CreateAsync(CreateAssemblyDto dto); 
        Task<IEnumerable<AssemblyDto>> GetForCondominiumAsync(int condominiumId); 
        Task<IEnumerable<AssemblyDto>> GetAllForCompanyAsync(int companyId); 

        Task<int> SendInvitesAsync(int assemblyId, SendAssemblyInvitesDto dto); 
        Task<IEnumerable<AssemblyMessageDto>> GetMessagesAsync(int assemblyId); 
        Task<AssemblyMessageDto?> PostMessageAsync(int assemblyId, PostAssemblyMessageDto dto); 
    }
}
