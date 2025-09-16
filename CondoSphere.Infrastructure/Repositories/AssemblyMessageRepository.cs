using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class AssemblyMessageRepository : IAssemblyMessageRepository
    {
        private readonly CondominiumDbContext _context;
        public AssemblyMessageRepository(CondominiumDbContext context) => _context = context;

        public async Task AddAsync(AssemblyMessage message)
            => await _context.AssemblyMessages.AddAsync(message);

        public async Task<IEnumerable<AssemblyMessage>> GetByAssemblyAsync(int assemblyId, int take = 100, int skip = 0)
            => await _context.AssemblyMessages
                .Where(m => m.AssemblyId == assemblyId)
                .OrderByDescending(m => m.CreatedAt)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
    }
}
