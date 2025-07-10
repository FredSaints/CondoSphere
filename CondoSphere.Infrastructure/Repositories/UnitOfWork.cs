using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _context;
        private IDbContextTransaction? _transaction;

        public ICompanyRepository Companies { get; }

        public UnitOfWork(UserManagementDbContext context)
        {
            _context = context;
            Companies = new CompanyRepository(_context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async Task<int> CompleteAsync()
        {
            // SaveChangesAsync will automatically participate in the active transaction.
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            // Ensure the transaction is disposed of properly.
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            await _context.DisposeAsync();
        }
    }
}
