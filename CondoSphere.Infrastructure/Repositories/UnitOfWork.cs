using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _userContext;
        private readonly CondominiumDbContext _condoContext;
        private readonly FinancialsDbContext _financialsContext;

        public ICompanyRepository Companies { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICondominiumRepository Condominiums { get; private set; }
        public IUnitRepository Units { get; private set; }
        public IOccurrenceRepository Occurrences { get; private set; }
        public IInterventionRepository Interventions { get; private set; }
        public IExpenseRepository Expenses { get; private set; }

        public UnitOfWork(UserManagementDbContext userContext, CondominiumDbContext condoContext, FinancialsDbContext financialsContext)
        {
            _userContext = userContext;
            _condoContext = condoContext;
            _financialsContext = financialsContext;

            Companies = new CompanyRepository(_userContext);
            Users = new UserRepository(_userContext);
            Condominiums = new CondominiumRepository(_condoContext);
            Units = new UnitRepository(_condoContext);
            Occurrences = new OccurrenceRepository(_condoContext);
            Interventions = new InterventionRepository(_condoContext);
            Expenses = new ExpenseRepository(_financialsContext);
        }

        public async Task<int> CompleteAsync()
        {
            var userDbResult = await _userContext.SaveChangesAsync();
            var condoDbResult = await _condoContext.SaveChangesAsync();
            var financialsDbResult = await _financialsContext.SaveChangesAsync();

            return userDbResult + condoDbResult + financialsDbResult;
        }

        public async ValueTask DisposeAsync()
        {
            await _userContext.DisposeAsync();
            await _condoContext.DisposeAsync();
            await _financialsContext.DisposeAsync();
        }
    }
}