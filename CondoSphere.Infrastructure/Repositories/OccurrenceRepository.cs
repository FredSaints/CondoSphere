using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
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
    }
}