using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Application.Services.Document
{
    public interface IDocumentService
    {
        Task<DocumentDto?> UploadDocumentAsync(int condominiumId, int companyId, int uploadedByUserId, CreateDocumentDto dto, IFormFile file);
        Task<IEnumerable<DocumentDto>> GetDocumentsForCondominiumAsync(int condominiumId, int companyId);
        Task<(byte[] FileContents, string ContentType, string FileName)?> GetDocumentForDownloadAsync(int documentId, int userId);
        Task<bool> DeleteDocumentAsync(int documentId, int companyId);
        Task<IEnumerable<DocumentDto>> GetDocumentsForUserAsync(int userId);
    }
}