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

        public void Update(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
        }

        public void Remove(Unit unit)
        {
            _context.Units.Remove(unit);
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

        public async Task<IEnumerable<Unit>> GetUnitsByResidentIdAsync(int residentId)
        {
            return await _context.Units
                .Where(u => u.ResidentId == residentId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Unit>> GetByResidentIdAsync(int residentId)
        {
            return await _context.Units
                .Where(u => u.ResidentId == residentId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Unit>> GetByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return Enumerable.Empty<Unit>();
            }

            return await _context.Units
                .Where(u => ids.Contains(u.Id))
                .ToListAsync();
        }

        public async Task<int> GetCountByCondominiumIdsAsync(IEnumerable<int> condominiumIds)
        {
            if (condominiumIds == null || !condominiumIds.Any())
            {
                return 0;
            }

            return await _context.Units
                .CountAsync(u => condominiumIds.Contains(u.CondominiumId));
        }
    }
}