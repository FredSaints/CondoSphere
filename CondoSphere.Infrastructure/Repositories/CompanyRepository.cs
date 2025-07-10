using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICompanyRepository using Entity Framework Core.
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
            await _context.Companies.AddAsync(company);
        }

        public void Remove(Company company)
        {
            _context.Companies.Remove(company);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}