using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Document;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/documents")]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly ICurrentUserService _currentUserService;

        public DocumentsController(IDocumentService documentService, ICurrentUserService currentUserService)
        {
            _documentService = documentService;
            _currentUserService = currentUserService;
        }

        [HttpPost("~/api/condominiums/{condominiumId}/documents")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<ActionResult<DocumentDto>> UploadDocument(int condominiumId, [FromForm] CreateDocumentDto dto, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file uploaded." });

            const long maxFileSize = 10 * 1024 * 1024;
            if (file.Length > maxFileSize)
            {
                return BadRequest(new { message = $"File size cannot exceed {maxFileSize / 1024 / 1024} MB." });
            }

            var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".jpg", ".jpeg", ".png", ".txt" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(fileExtension) || !allowedExtensions.Contains(fileExtension))
            {
                return BadRequest(new { message = "Invalid file type. Allowed types are: " + string.Join(", ", allowedExtensions) });
            }

            var companyId = _currentUserService.CompanyId;
            var userId = _currentUserService.UserId;
            if (companyId == null || userId == null) return Unauthorized();

            var document = await _documentService.UploadDocumentAsync(condominiumId, companyId.Value, userId.Value, dto, file);

            if (document == null) return Forbid();

            return CreatedAtAction(nameof(GetDocument), new { documentId = document.Id }, document);
        }

        // GET /api/condominiums/{condominiumId}/documents
        [HttpGet("~/api/condominiums/{condominiumId}/documents")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetDocumentsForCondominium(int condominiumId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var documents = await _documentService.GetDocumentsForCondominiumAsync(condominiumId, companyId.Value);
            return Ok(documents);
        }

        // GET /api/documents/{documentId}
        [HttpGet("{documentId}")]
        public IActionResult GetDocument(int documentId)
        {
            return Ok(new { message = $"Details for document {documentId} would be here." });
        }

        // GET /api/documents/{documentId}/download
        [HttpGet("{documentId}/download")]
        public async Task<IActionResult> DownloadDocument(int documentId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var result = await _documentService.GetDocumentForDownloadAsync(documentId, userId.Value);

            if (result == null)
            {
                return Forbid();
            }

            return File(result.Value.FileContents, result.Value.ContentType, result.Value.FileName);
        }

        // DELETE /api/documents/{documentId}
        [HttpDelete("{documentId}")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> DeleteDocument(int documentId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var success = await _documentService.DeleteDocumentAsync(documentId, companyId.Value);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}