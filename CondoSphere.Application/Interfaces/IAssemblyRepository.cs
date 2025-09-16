using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAssembly = CondoSphere.Core.Entities.Assembly.Assembly;

namespace CondoSphere.Application.Interfaces
{
    public interface IAssemblyRepository
    {
        Task AddAsync(CoreAssembly assembly);
        Task<CoreAssembly?> GetByIdAsync(int id);
        Task<IEnumerable<CoreAssembly>> GetByCondominiumAsync(int condominiumId);
        Task<IEnumerable<CoreAssembly>> GetAllForCompanyAsync(int companyId);
        void Update(CoreAssembly assembly);
    }
}
