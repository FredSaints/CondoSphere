using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly CondominiumDbContext _context;

        public CondominiumRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        // ========== CRUD ==========
        public async Task AddAsync(Condominium entity)
        {
            await _context.Condominiums.AddAsync(entity);
        }

        public void Update(Condominium entity)
        {
            _context.Condominiums.Update(entity);
        }

        public void Remove(Condominium entity)
        {
            _context.Condominiums.Remove(entity);
        }

        // ========== READ ==========
        public async Task<Condominium?> GetByIdAsync(int id, int companyId)
        {
            return await _context.Condominiums
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == companyId);
        }

        public async Task<IReadOnlyList<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            return await _context.Condominiums
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .OrderBy(c => c.Name)          // ou .OrderByDescending(c => c.Id) se preferires
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Condominium>> GetAllForCompanyAsync(int companyId)
        {
            return await _context.Condominiums
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Condominium>> GetByManagerIdAsync(int managerId)
        {
            return await _context.Condominiums
                .AsNoTracking()
                .Where(c => c.ManagerId == managerId)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Condominium>> GetByIdsAsync(IEnumerable<int> ids)
        {
            var set = ids?.Distinct().ToList() ?? new List<int>();
            if (set.Count == 0) return new List<Condominium>();

            return await _context.Condominiums
                .AsNoTracking()
                .Where(c => set.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<int> CountAsync(int companyId)
        {
            return await _context.Condominiums
                .Where(c => c.CompanyId == companyId)
                .CountAsync();
        }
    }
}
