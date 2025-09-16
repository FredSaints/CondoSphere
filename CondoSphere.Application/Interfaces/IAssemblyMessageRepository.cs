using CondoSphere.Core.Entities.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    public interface IAssemblyMessageRepository
    {
        Task AddAsync(AssemblyMessage message);
        Task<IEnumerable<AssemblyMessage>> GetByAssemblyAsync(int assemblyId, int take = 100, int skip = 0);
    }
}
