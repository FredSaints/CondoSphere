//namespace CondoSphere.Application.Interfaces
//{
//    /// <summary>
//    /// Defines a unit of work that can coordinate transactions across multiple repositories.
//    /// </summary>
//    public interface IUnitOfWork : IAsyncDisposable
//    {
//        ICompanyRepository Companies { get; }
//        // TODO: We can add other repositories here later, e.g., IUserRepository
//        Task BeginTransactionAsync();
//        Task CommitAsync();
//        Task RollbackAsync();
//        Task<int> CompleteAsync();
//    }
//}

namespace CondoSphere.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        ICondominiumRepository Condominiums { get; }
        IUnitRepository Units { get; }
        IOccurrenceRepository Occurrences { get; }
        Task<int> CompleteAsync();
    }
}
