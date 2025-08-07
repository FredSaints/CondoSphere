using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICompanyRepository using Entity Framework Core.
    /// This repository modifies the change tracker but does not save to the database.
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly UserManagementDbContext _context;

        public CompanyRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Company company)
        {
            // This adds the entity to EF Core's change tracker.
            await _context.Companies.AddAsync(company);
        }

        public void Remove(Company company)
        {
            // This marks the entity for deletion in EF Core's change tracker.
            _context.Companies.Remove(company);
        }
    }
}