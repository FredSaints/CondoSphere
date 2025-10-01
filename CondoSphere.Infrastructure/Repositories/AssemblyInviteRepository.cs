using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Assembly Invite Repository.
    /// </summary>
    public class AssemblyInviteRepository : IAssemblyInviteRepository
    {
        private readonly CondominiumDbContext _ctx;
        public AssemblyInviteRepository(CondominiumDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(AssemblyInvite invite)
        {
            await _ctx.AssemblyInvites.AddAsync(invite);
        }

        public async Task AddRangeAsync(IEnumerable<AssemblyInvite> invites)
        {
            await _ctx.AssemblyInvites.AddRangeAsync(invites);
        }

        public async Task<IEnumerable<AssemblyInvite>> GetByAssemblyIdAsync(int assemblyId)
        {
            return await _ctx.AssemblyInvites
                .Where(i => i.AssemblyId == assemblyId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
