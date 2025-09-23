using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class AssemblyRepository : IAssemblyRepository
    {
        private readonly CondominiumDbContext _context;

        public AssemblyRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Assembly entity) =>
            await _context.Assemblies.AddAsync(entity);

        public void Update(Assembly entity) =>
            _context.Assemblies.Update(entity);

        public async Task<Assembly?> GetByIdAsync(int id) =>
            await _context.Assemblies.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IReadOnlyList<Assembly>> GetByCondominiumAsync(int condominiumId) =>
            await _context.Assemblies
                .Where(a => a.CondominiumId == condominiumId)
                .OrderByDescending(a => a.Date)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IReadOnlyList<Assembly>> GetAllForCompanyAsync(int companyId) =>
            await _context.Assemblies
                .Where(a => a.CompanyId == companyId)
                .OrderByDescending(a => a.Date)
                .AsNoTracking()
                .ToListAsync();
    }
}
