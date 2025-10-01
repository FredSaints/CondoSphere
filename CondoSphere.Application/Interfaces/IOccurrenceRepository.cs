using CondoSphere.Core.DTOs.Reports;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Occurrence Repository.
    /// </summary>
    public interface IOccurrenceRepository
    {
        Task<IEnumerable<Occurrence>> GetAllForCondominiumAsync(int condominiumId);
        Task<Occurrence?> GetByIdAsync(int occurrenceId);
        Task AddAsync(Occurrence occurrence);
        Task<IEnumerable<Occurrence>> GetAllForResidentAsync(int residentUserId);
        void Update(Occurrence occurrence);
        Task<int> GetOpenCountForCompanyAsync(int companyId);
        Task<IEnumerable<StatusSummaryDto>> GetOccurrenceStatusSummaryAsync(int companyId);
        Task<IEnumerable<CondoHotspotDto>> GetCondoHotspotsAsync(int companyId, int topN = 5);
    }
}