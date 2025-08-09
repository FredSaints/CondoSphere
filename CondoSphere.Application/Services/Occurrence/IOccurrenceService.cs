using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Application.Services.Occurrence
{
    public interface IOccurrenceService
    {
        Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId);
        Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, int residentUserId, IFormFile? imageFile);
        Task<OccurrenceDto?> GetOccurrenceByIdAsync(int occurrenceId);
        Task<IEnumerable<OccurrenceDto>> GetOccurrencesForResidentAsync(int residentUserId);
        Task<bool> UpdateOccurrenceStatusAsync(int occurrenceId, OccurrenceStatus newStatus, int companyId);
    }
}