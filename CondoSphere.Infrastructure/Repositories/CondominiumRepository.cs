using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICondominiumRepository using Entity Framework Core.
    /// This repository modifies the change tracker but does not save to the database.
    /// </summary>
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly CondominiumDbContext _context;

        public CondominiumRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Condominium condominium)
        {
            await _context.Condominiums.AddAsync(condominium);
        }

        public async Task<IEnumerable<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize)
        {
            var query = _context.Condominiums
                .Where(c => c.CompanyId == companyId);

            var pagedQuery = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await pagedQuery.AsNoTracking().ToListAsync();
        }

        public async Task<Condominium?> GetByIdAsync(int id, int companyId)
        {
            return await _context.Condominiums
                .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == companyId);
        }

        public void Remove(Condominium condominium)
        {
            _context.Condominiums.Remove(condominium);
        }

        public void Update(Condominium condominium)
        {
            // This marks the entity for update in EF Core's change tracker.
            _context.Entry(condominium).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Condominium>> GetByManagerIdAsync(int managerId)
        {
            return await _context.Condominiums
                .Where(c => c.ManagerId == managerId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Condominium>> GetByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return Enumerable.Empty<Condominium>();
            }

            return await _context.Condominiums
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Condominium>> GetAllForCompanyAsync(int companyId)
        {
            return await _context.Condominiums
                .Where(c => c.CompanyId == companyId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}