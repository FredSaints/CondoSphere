using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Document Repository.
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
        private readonly CondominiumDbContext _context;
        public DocumentRepository(CondominiumDbContext context) => _context = context;

        public async Task AddAsync(Document document) => await _context.Documents.AddAsync(document);
        public void Remove(Document document) => _context.Documents.Remove(document);
        public async Task<Document?> GetByIdAsync(int documentId) => await _context.Documents.FindAsync(documentId);

        public async Task<IEnumerable<Document>> GetByCondominiumIdAsync(int condominiumId)
        {
            return await _context.Documents
                .Where(d => d.CondominiumId == condominiumId)
                .OrderByDescending(d => d.UploadDate)
                .ToListAsync();
        }
    }
}