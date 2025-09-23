using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class AssemblyParticipantRepository : IAssemblyParticipantRepository
    {
        private readonly CondominiumDbContext _ctx;
        public AssemblyParticipantRepository(CondominiumDbContext ctx) => _ctx = ctx;

        public async Task AddRangeAsync(IEnumerable<AssemblyParticipant> participants)
        {
            await _ctx.AssemblyParticipants.AddRangeAsync(participants);
        }

        public async Task<IEnumerable<AssemblyParticipant>> GetByAssemblyIdAsync(int assemblyId)
        {
            return await _ctx.AssemblyParticipants
                .Where(p => p.AssemblyId == assemblyId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
