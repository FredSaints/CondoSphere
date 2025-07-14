using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly CondominiumDbContext _context;

        public UnitRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
        }

        public async Task<IEnumerable<Unit>> GetAllAsync(int condominiumId)
        {
            return await _context.Units
                .Where(u => u.CondominiumId == condominiumId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Unit?> GetByIdAsync(int unitId)
        {
            return await _context.Units.FindAsync(unitId);
        }

        public void Remove(Unit unit)
        {
            _context.Units.Remove(unit);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
        }
    }
}