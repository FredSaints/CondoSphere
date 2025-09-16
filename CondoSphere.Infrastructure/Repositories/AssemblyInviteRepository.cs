using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class AssemblyInviteRepository : IAssemblyInviteRepository
    {
        private readonly CondominiumDbContext _context;
        public AssemblyInviteRepository(CondominiumDbContext context) => _context = context;

        public async Task AddRangeAsync(IEnumerable<AssemblyInvite> invites)
            => await _context.AssemblyInvites.AddRangeAsync(invites);

        public async Task<bool> IsInvitedAsync(int assemblyId, int userId)
            => await _context.AssemblyInvites
                .AnyAsync(i => i.AssemblyId == assemblyId && i.InvitedUserId == userId);

        public async Task<IEnumerable<AssemblyInvite>> GetByAssemblyAsync(int assemblyId)
            => await _context.AssemblyInvites
                .Where(i => i.AssemblyId == assemblyId)
                .AsNoTracking()
                .ToListAsync();
    }
}
