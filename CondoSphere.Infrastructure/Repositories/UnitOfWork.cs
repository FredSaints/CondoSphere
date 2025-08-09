using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _userContext;
        private readonly CondominiumDbContext _condoContext;

        // Implement all properties from the interface
        public ICompanyRepository Companies { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICondominiumRepository Condominiums { get; private set; }
        public IUnitRepository Units { get; private set; }
        public IOccurrenceRepository Occurrences { get; private set; }
        public IInterventionRepository Interventions { get; private set; }

        public UnitOfWork(UserManagementDbContext userContext, CondominiumDbContext condoContext)
        {
            _userContext = userContext;
            _condoContext = condoContext;

            // Instantiate all repositories with their respective DbContexts
            Companies = new CompanyRepository(_userContext);
            Users = new UserRepository(_userContext);
            Condominiums = new CondominiumRepository(_condoContext);
            Units = new UnitRepository(_condoContext);
            Occurrences = new OccurrenceRepository(_condoContext);
            Interventions = new InterventionRepository(_condoContext);
        }

        public async Task<int> CompleteAsync()
        {
            // Save changes for both contexts. The sum of records affected is returned.
            var userDbResult = await _userContext.SaveChangesAsync();
            var condoDbResult = await _condoContext.SaveChangesAsync();
            return userDbResult + condoDbResult;
        }

        public async ValueTask DisposeAsync()
        {
            await _userContext.DisposeAsync();
            await _condoContext.DisposeAsync();
        }


    }
}
