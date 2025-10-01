using CondoSphere.Core.Entities.Assembly;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Assembly Invite Repository.
    /// </summary>
    public interface IAssemblyInviteRepository
    {
        Task AddRangeAsync(IEnumerable<AssemblyInvite> invites);
        Task AddAsync(AssemblyInvite invite);
        Task<IEnumerable<AssemblyInvite>> GetByAssemblyIdAsync(int assemblyId);
    }
}
