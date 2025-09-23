using CondoSphere.Core.Entities.Assembly;

namespace CondoSphere.Application.Interfaces
{
    public interface IAssemblyParticipantRepository
    {
        Task AddRangeAsync(IEnumerable<AssemblyParticipant> participants);
        Task<IEnumerable<AssemblyParticipant>> GetByAssemblyIdAsync(int assemblyId);
    }
}
