using CondoSphere.Core.Entities.Condominiums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Document Repository.
    /// </summary>
    public interface IDocumentRepository
    {
        Task AddAsync(Document document);
        void Remove(Document document);
        Task<Document?> GetByIdAsync(int documentId);
        Task<IEnumerable<Document>> GetByCondominiumIdAsync(int condominiumId);
    }
}