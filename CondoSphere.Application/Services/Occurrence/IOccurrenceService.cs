using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Application.Services.Occurrence
{
    public interface IOccurrenceService
    {
        Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId);
        Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, int residentUserId);
        Task<OccurrenceDto?> GetOccurrenceByIdAsync(int occurrenceId);
        Task<IEnumerable<OccurrenceDto>> GetOccurrencesForResidentAsync(int residentUserId);
    }
}