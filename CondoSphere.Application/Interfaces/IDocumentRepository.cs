using CondoSphere.Core.Entities.Condominiums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    public interface IDocumentRepository
    {
        Task AddAsync(Document document);
        void Remove(Document document);
        Task<Document?> GetByIdAsync(int documentId);
        Task<IEnumerable<Document>> GetByCondominiumIdAsync(int condominiumId);
    }
}