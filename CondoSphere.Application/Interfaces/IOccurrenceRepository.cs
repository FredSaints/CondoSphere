using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    public interface IOccurrenceRepository
    {
        Task<IEnumerable<Occurrence>> GetAllForCondominiumAsync(int condominiumId);
        Task<Occurrence?> GetByIdAsync(int occurrenceId);
        Task AddAsync(Occurrence occurrence);
        Task<IEnumerable<Occurrence>> GetAllForResidentAsync(int residentUserId);
        void Update(Occurrence occurrence);
    }
}