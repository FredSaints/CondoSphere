using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondoSphere.Application.Interfaces;
using CoreAssembly = CondoSphere.Core.Entities.Assembly.Assembly;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class AssemblyRepository : IAssemblyRepository
    {
        private readonly CondominiumDbContext _context;
        public AssemblyRepository(CondominiumDbContext context) => _context = context;

        public async Task AddAsync(CoreAssembly assembly)
            => await _context.Assemblies.AddAsync(assembly);

        public async Task<CoreAssembly?> GetByIdAsync(int id)
            => await _context.Assemblies.FindAsync(id);

        public async Task<IEnumerable<CoreAssembly>> GetByCondominiumAsync(int condominiumId)
            => await _context.Assemblies
                .Where(a => a.CondominiumId == condominiumId)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<CoreAssembly>> GetAllForCompanyAsync(int companyId)
            => await _context.Assemblies
                .Where(a => a.CompanyId == companyId)
                .AsNoTracking()
                .ToListAsync();

        public void Update(CoreAssembly assembly)
            => _context.Assemblies.Update(assembly);
    }
}
