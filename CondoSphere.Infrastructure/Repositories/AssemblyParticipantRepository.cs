using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Repositories
{
    public class AssemblyParticipantRepository : IAssemblyParticipantRepository
    {
        private readonly CondominiumDbContext _context;
        public AssemblyParticipantRepository(CondominiumDbContext context) => _context = context;

        public async Task AddRangeAsync(IEnumerable<AssemblyParticipant> items)
        {
            await _context.AssemblyParticipants.AddRangeAsync(items);
        }

        public async Task<IEnumerable<AssemblyParticipant>> GetByAssemblyAsync(int assemblyId)
        {
            return await _context.AssemblyParticipants
                .Where(p => p.AssemblyId == assemblyId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
