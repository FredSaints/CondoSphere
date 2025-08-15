namespace CondoSphere.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        ICondominiumRepository Condominiums { get; }
        IUnitRepository Units { get; }
        IOccurrenceRepository Occurrences { get; }
        IInterventionRepository Interventions { get; }
        IExpenseRepository Expenses { get; }
        IUnitQuotaRepository UnitQuotas { get; }
        Task<int> CompleteAsync();

    }
}
