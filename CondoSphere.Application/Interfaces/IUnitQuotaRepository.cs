using CondoSphere.Core.Entities.Financials;


namespace CondoSphere.Application.Interfaces
{
    public interface IUnitQuotaRepository
    {
        Task AddAsync(UnitQuota unitQuota);
        Task<IEnumerable<UnitQuota>> GetQuotasByUnitIdsAsync(IEnumerable<int> unitIds);
        Task<UnitQuota?> GetByIdAsync(int quotaId);
        void Update (UnitQuota unitQuota);
        Task<IEnumerable<UnitQuota>> GetQuotasByCondominiumAsync(int condominiumId);
        Task<bool> QuotasExistForPeriodAsync(int condominiumId, int year, int month);
    }
}
