using CondoSphere.Core.Entities.Users;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository that manages Company data.
    /// </summary>
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
        void Remove(Company company);
        Task<int> SaveChangesAsync();
    }
}