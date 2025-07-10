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

        public async Task<bool> SaveChangesAsync()
        {
            // SaveChangesAsync returns the number of rows affected.
            // We return true if at least one row was changed.
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Condominium condominium)
        {
            _context.Entry(condominium).State = EntityState.Modified;
        }
    }
}