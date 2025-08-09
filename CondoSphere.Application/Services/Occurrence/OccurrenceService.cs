using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Occurrence
{
    public class OccurrenceService : IOccurrenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OccurrenceService(
            IUnitOfWork unitOfWork,
            UserManager<CoreUser> userManager,
            IMapper mapper,
            IConfiguration configuration,
             IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId)
        {
            var occurrences = await _unitOfWork.Occurrences.GetAllForCondominiumAsync(condominiumId);
            if (!occurrences.Any())
            {
                return Enumerable.Empty<OccurrenceDto>();
            }

            var occurrenceDtos = _mapper.Map<List<OccurrenceDto>>(occurrences);

            var reporterIds = occurrences.Select(o => o.ReportedByUserId).Distinct().ToList();
            var reporters = await _userManager.Users
                .Where(u => reporterIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, u => $"{u.FirstName} {u.LastName}");

            foreach (var dto in occurrenceDtos)
            {
                var originalOccurrence = occurrences.First(o => o.Id == dto.Id);
                if (reporters.ContainsKey(originalOccurrence.ReportedByUserId))
                {
                    dto.ReportedByUserName = reporters[originalOccurrence.ReportedByUserId];
                }
            }

            return occurrenceDtos;
        }

        public async Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, int residentUserId, IFormFile? imageFile)
        {
            // 1. Find the unit associated with the logged-in resident to get context.
            var unit = await _unitOfWork.Units.GetUnitByResidentIdAsync(residentUserId);
            if (unit == null)
            {
                // Fail because this user is not an active resident of any unit.
                return null;
            }

            // 2. Map the incoming data (Title, Description) to our database entity.
            var newOccurrence = _mapper.Map<CoreOccurrence>(dto);

            // 3. Handle the optional image upload.
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadPath = _configuration["FileUpload:Path"];
                if (string.IsNullOrEmpty(uploadPath))
                {
                    return null;
                }

                // Create a unique, random filename to prevent name collisions and obscure the original filename.
                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                // Save the file stream to the configured physical path on the server's disk.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                // Get the current HTTP request context to build the base URL (e.g., https://localhost:7177)
                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}";

                // Combine the base URL with the public path to the file.
                newOccurrence.ImageUrl = $"{baseUrl}/uploads/{uniqueFileName}";
            }

            // 4. Populate the system-managed properties for the new occurrence.
            newOccurrence.ReportedDate = DateTime.UtcNow;
            newOccurrence.Status = OccurrenceStatus.Open;
            newOccurrence.ReportedByUserId = residentUserId;
            newOccurrence.UnitId = unit.Id;
            newOccurrence.CondominiumId = unit.CondominiumId;
            newOccurrence.CompanyId = unit.CompanyId;

            // 5. Add the new entity to the repository and save the changes via the Unit of Work.
            await _unitOfWork.Occurrences.AddAsync(newOccurrence);
            await _unitOfWork.CompleteAsync();

            // 6. Map the fully populated entity (with its new ID and absolute ImageUrl) back to a DTO to return.
            return _mapper.Map<OccurrenceDto>(newOccurrence);
        }

        public async Task<OccurrenceDto?> GetOccurrenceByIdAsync(int occurrenceId)
        {
            var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(occurrenceId);
            if (occurrence == null)
            {
                return null;
            }

            var dto = _mapper.Map<OccurrenceDto>(occurrence);

            var reporter = await _userManager.FindByIdAsync(occurrence.ReportedByUserId.ToString());
            if (reporter != null)
            {
                dto.ReportedByUserName = $"{reporter.FirstName} {reporter.LastName}";
            }

            return dto;
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForResidentAsync(int residentUserId)
        {
            var occurrences = await _unitOfWork.Occurrences.GetAllForResidentAsync(residentUserId);

            return _mapper.Map<IEnumerable<OccurrenceDto>>(occurrences);
        }

        public async Task<bool> UpdateOccurrenceStatusAsync(int occurrenceId, OccurrenceStatus newStatus, int companyId)
        {
            var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(occurrenceId);

            if (occurrence == null || occurrence.CompanyId != companyId)
            {
                return false;
            }

            occurrence.Status = newStatus;

            _unitOfWork.Occurrences.Update(occurrence);

            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}