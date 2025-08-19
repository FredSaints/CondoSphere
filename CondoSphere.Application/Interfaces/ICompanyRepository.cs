using CondoSphere.Core.Entities.Users;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository that manages Company data.
    /// The responsibility for saving changes is handled by the IUnitOfWork.
    /// </summary>
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
        void Remove(Company company);
        void Update(Company company);
        Task<Company?> GetByIdAsync(int companyId);
    }
}