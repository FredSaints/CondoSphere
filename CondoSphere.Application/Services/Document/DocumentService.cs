using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Notifications;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CondoSphere.Application.Services.Document
{
    /// <summary>
    /// Document Service.
    /// </summary>
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificationService;

        public DocumentService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _notificationService = notificationService;
        }

        public async Task<DocumentDto?> UploadDocumentAsync(int condominiumId, int companyId, int uploadedByUserId, CreateDocumentDto dto, IFormFile file)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condo == null) return null;

            var uploadRootSetting = _configuration["FileUpload:Path"];
            var uploadRoot = Environment.ExpandEnvironmentVariables(uploadRootSetting);
            if (!Path.IsPathRooted(uploadRoot))
                uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));

            var subfolder = $"condo-{condominiumId}/documents";
            var targetFolder = Path.Combine(uploadRoot, subfolder);
            Directory.CreateDirectory(targetFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var relativeFilePath = Path.Combine(subfolder, uniqueFileName);
            var absoluteFilePath = Path.Combine(uploadRoot, relativeFilePath);

            using (var stream = new FileStream(absoluteFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new Core.Entities.Condominiums.Document
            {
                CondominiumId = condominiumId,
                CompanyId = companyId,
                UploadedByUserId = uploadedByUserId,
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                FileName = file.FileName,
                FilePathOrUrl = relativeFilePath,
                UploadDate = DateTime.UtcNow
            };

            await _unitOfWork.Documents.AddAsync(document);
            await _unitOfWork.CompleteAsync();
            await _notificationService.NotifyResidentsOfNewDocumentAsync(document);

            var user = await _unitOfWork.Users.GetUserByIdAsync(uploadedByUserId);
            var documentDto = _mapper.Map<DocumentDto>(document);
            documentDto.UploadedByUserName = (user != null) ? $"{user.FirstName} {user.LastName}" : "Unknown";

            return documentDto;
        }

        public async Task<IEnumerable<DocumentDto>> GetDocumentsForCondominiumAsync(int condominiumId, int companyId)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condo == null) return Enumerable.Empty<DocumentDto>();

            var documents = await _unitOfWork.Documents.GetByCondominiumIdAsync(condominiumId);
            var documentDtos = _mapper.Map<List<DocumentDto>>(documents);

            var userIds = documents.Select(d => d.UploadedByUserId).Distinct().ToList();
            var users = await _unitOfWork.Users.GetUsersByIdsAsync(userIds);
            var userLookup = users.ToDictionary(u => u.Id);

            foreach (var dto in documentDtos)
            {
                var originalDoc = documents.First(d => d.Id == dto.Id);
                if (userLookup.TryGetValue(originalDoc.UploadedByUserId, out var uploader))
                {
                    dto.UploadedByUserName = uploader.FullName;
                }
                else
                {
                    dto.UploadedByUserName = "Unknown";
                }
            }

            return documentDtos;
        }

        public async Task<(byte[] FileContents, string ContentType, string FileName)?> GetDocumentForDownloadAsync(int documentId, int userId)
        {
            var document = await _unitOfWork.Documents.GetByIdAsync(documentId);
            if (document == null) return null;

            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            if (user == null) return null;

            bool isAuthorized = false;
            if (user.CompanyId == document.CompanyId)
            {
                isAuthorized = true;
            }
            else
            {
                var userUnits = await _unitOfWork.Units.GetByResidentIdAsync(userId);
                if (userUnits.Any(u => u.CondominiumId == document.CondominiumId))
                {
                    isAuthorized = true;
                }
            }

            if (!isAuthorized) return null;

            // Construct the full physical path to the file
            var uploadRootSetting = _configuration["FileUpload:Path"];
            var uploadRoot = Environment.ExpandEnvironmentVariables(uploadRootSetting);
            if (!Path.IsPathRooted(uploadRoot))
                uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));

            var fullPath = Path.Combine(uploadRoot, document.FilePathOrUrl);

            if (!File.Exists(fullPath)) return null;

            var fileContents = await File.ReadAllBytesAsync(fullPath);
            // A simple way to get content type, can be improved with a library
            var contentType = "application/octet-stream";
            var fileExtension = Path.GetExtension(document.FileName).ToLowerInvariant();

            // Common MIME types
            var mimeTypes = new Dictionary<string, string>
            {
                {".pdf", "application/pdf"},
                {".doc", "application/msword"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".txt", "text/plain"}
            };

            if (mimeTypes.ContainsKey(fileExtension))
            {
                contentType = mimeTypes[fileExtension];
            }

            return (fileContents, contentType, document.FileName);
        }

        public async Task<bool> DeleteDocumentAsync(int documentId, int companyId)
        {
            var document = await _unitOfWork.Documents.GetByIdAsync(documentId);
            if (document == null || document.CompanyId != companyId)
            {
                return false;
            }

            var uploadRootSetting = _configuration["FileUpload:Path"];
            var uploadRoot = Environment.ExpandEnvironmentVariables(uploadRootSetting);
            if (!Path.IsPathRooted(uploadRoot))
                uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));

            var fullPath = Path.Combine(uploadRoot, document.FilePathOrUrl);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            _unitOfWork.Documents.Remove(document);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<IEnumerable<DocumentDto>> GetDocumentsForUserAsync(int userId)
        {
            // 1. Find user's units
            var userUnits = await _unitOfWork.Units.GetByResidentIdAsync(userId);
            if (!userUnits.Any()) return Enumerable.Empty<DocumentDto>();

            var condominiumIds = userUnits.Select(u => u.CondominiumId).Distinct();

            // 2. Fetch all documents for those condos
            var allDocuments = new List<Core.Entities.Condominiums.Document>();
            foreach (var condoId in condominiumIds)
            {
                var docsForCondo = await _unitOfWork.Documents.GetByCondominiumIdAsync(condoId);
                allDocuments.AddRange(docsForCondo);
            }

            // 3. Fetch related data for enrichment (Users and Condominiums)
            var userIds = allDocuments.Select(d => d.UploadedByUserId).Distinct().ToList();
            var users = await _unitOfWork.Users.GetUsersByIdsAsync(userIds);
            var userLookup = users.ToDictionary(u => u.Id);

            // --- NEW: Create a lookup for condominium names ---
            var allCondos = await _unitOfWork.Condominiums.GetByIdsAsync(condominiumIds);
            var condoLookup = allCondos.ToDictionary(c => c.Id, c => c.Name);

            // 4. Map and Enrich DTOs
            var documentDtos = _mapper.Map<List<DocumentDto>>(allDocuments);
            foreach (var dto in documentDtos)
            {
                var originalDoc = allDocuments.First(d => d.Id == dto.Id);

                // Enrich with uploader name
                if (userLookup.TryGetValue(originalDoc.UploadedByUserId, out var uploader))
                    dto.UploadedByUserName = uploader.FullName;
                else
                    dto.UploadedByUserName = "Management";

                //  Enrich with condominium name
                if (condoLookup.TryGetValue(originalDoc.CondominiumId, out var condoName))
                {
                    dto.CondominiumName = condoName;
                }
            }

            return documentDtos.OrderBy(d => d.CondominiumName).ThenByDescending(d => d.UploadDate);
        }
    }
}