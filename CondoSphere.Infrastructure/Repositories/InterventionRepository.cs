using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class InterventionRepository : IInterventionRepository
    {
        private readonly CondominiumDbContext _context;

        public InterventionRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Intervention intervention)
        {
            await _context.Interventions.AddAsync(intervention);
        }

        public async Task<IEnumerable<Intervention>> GetByOccurrenceIdAsync(int occurrenceId)
        {
            return await _context.Interventions
                .Where(i => i.OccurrenceId == occurrenceId)
                .OrderBy(i => i.StartDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Intervention>> GetByAssignedUserIdAsync(int employeeId)
        {
            return await _context.Interventions
                .Where(i => i.AssignedToUserId == employeeId)
                .OrderBy(i => i.StartDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Intervention?> GetByIdAsync(int interventionId)
        {
            return await _context.Interventions.FindAsync(interventionId);
        }

        public void Update(Intervention intervention)
        {
            _context.Entry(intervention).State = EntityState.Modified;
        }
    }
}