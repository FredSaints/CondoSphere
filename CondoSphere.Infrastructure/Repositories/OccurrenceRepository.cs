using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Reports;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Core.Enums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Occurrence Repository.
    /// </summary>
    public class OccurrenceRepository : IOccurrenceRepository
    {
        private readonly CondominiumDbContext _context;

        public OccurrenceRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Occurrence occurrence)
        {
            // This adds the entity to EF Core's change tracker.
            await _context.Occurrences.AddAsync(occurrence);
        }

        public async Task<IEnumerable<Occurrence>> GetAllForCondominiumAsync(int condominiumId)
        {
            return await _context.Occurrences
                .Where(o => o.CondominiumId == condominiumId)
                .OrderByDescending(o => o.ReportedDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Occurrence?> GetByIdAsync(int occurrenceId)
        {
            return await _context.Occurrences.FindAsync(occurrenceId);
        }

        public async Task<IEnumerable<Occurrence>> GetAllForResidentAsync(int residentUserId)
        {
            return await _context.Occurrences
                .Where(o => o.ReportedByUserId == residentUserId)
                .OrderByDescending(o => o.ReportedDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Update(Occurrence occurrence)
        {
            _context.Entry(occurrence).State = EntityState.Modified;
        }

        public async Task<int> GetOpenCountForCompanyAsync(int companyId)
        {
            // Define which statuses are considered "open"
            var openStatuses = new[] { OccurrenceStatus.Open, OccurrenceStatus.InProgress, OccurrenceStatus.OnHold };

            return await _context.Occurrences
                .CountAsync(o => o.CompanyId == companyId && openStatuses.Contains(o.Status));
        }

        public async Task<IEnumerable<StatusSummaryDto>> GetOccurrenceStatusSummaryAsync(int companyId)
        {
            return await _context.Occurrences
                .Where(o => o.CompanyId == companyId)
                .GroupBy(o => o.Status)
                .Select(g => new StatusSummaryDto
                {
                    StatusName = g.Key.ToString(),
                    Count = g.Count()
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<CondoHotspotDto>> GetCondoHotspotsAsync(int companyId, int topN = 5)
        {
            var openStatuses = new[] { OccurrenceStatus.Open, OccurrenceStatus.InProgress, OccurrenceStatus.OnHold };

            var hotspots = await _context.Occurrences
                .Where(o => o.CompanyId == companyId && openStatuses.Contains(o.Status))
                .GroupBy(o => o.CondominiumId)
                .Select(g => new { CondominiumId = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(topN)
                .Join(
                    _context.Condominiums,
                    occurrenceGroup => occurrenceGroup.CondominiumId,
                    condominium => condominium.Id,
                    (occurrenceGroup, condominium) => new CondoHotspotDto
                    {
                        CondominiumName = condominium.Name,
                        OpenIssuesCount = occurrenceGroup.Count
                    })
                .AsNoTracking()
                .ToListAsync();

            return hotspots;
        }
    }
}