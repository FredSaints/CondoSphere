using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Intervention Repository.
    /// </summary>
    public interface IInterventionRepository
    {
        Task AddAsync(Intervention intervention);
        Task<IEnumerable<Intervention>> GetByOccurrenceIdAsync(int occurrenceId);
        Task<IEnumerable<Intervention>> GetByAssignedUserIdAsync(int employeeId);
        Task<Intervention?> GetByIdAsync(int interventionId);
        void Update(Intervention intervention);
    }
}