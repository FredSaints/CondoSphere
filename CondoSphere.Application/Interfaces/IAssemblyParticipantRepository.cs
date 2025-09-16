using CondoSphere.Core.Entities.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    public interface IAssemblyParticipantRepository
    {
        Task AddRangeAsync(IEnumerable<AssemblyParticipant> items);
        Task<IEnumerable<AssemblyParticipant>> GetByAssemblyAsync(int assemblyId);
    }

}
