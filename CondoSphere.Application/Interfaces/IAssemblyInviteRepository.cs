using CondoSphere.Core.Entities.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CondoSphere.Application.Interfaces
{
    public interface IAssemblyInviteRepository
    {
        Task AddRangeAsync(IEnumerable<AssemblyInvite> invites);
        Task<bool> IsInvitedAsync(int assemblyId, int userId);
        Task<IEnumerable<AssemblyInvite>> GetByAssemblyAsync(int assemblyId);
    }
}
