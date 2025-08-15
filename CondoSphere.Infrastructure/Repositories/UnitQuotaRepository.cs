using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Financials;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitQuotaRepository : IUnitQuotaRepository
    {
        private readonly FinancialsDbContext _context;

        public UnitQuotaRepository(FinancialsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UnitQuota unitQuota)
        {
            await _context.UnitQuotas.AddAsync(unitQuota);
        }

        public void Update(UnitQuota unitQuota)
        {
            _context.Entry(unitQuota).State = EntityState.Modified;
        }

        public async Task<IEnumerable<UnitQuota>> GetQuotasByUnitIdsAsync(IEnumerable<int> unitIds)
        {
            return await _context.UnitQuotas
                .Where(q => unitIds.Contains(q.UnitId))
                .OrderByDescending(q => q.DueDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UnitQuota?> GetByIdAsync(int quotaId)
        {
            return await _context.UnitQuotas.FindAsync(quotaId);
        }

        public async Task<IEnumerable<UnitQuota>> GetQuotasByCondominiumAsync(int condominiumId)
        {
            return await _context.UnitQuotas
                .Where(q => q.CondominiumId == condominiumId)
                .OrderByDescending(q => q.DueDate)
                .ThenBy(q => q.UnitId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}