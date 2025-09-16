using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Notifications;
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
        private readonly INotificationService _notificationService;

        public OccurrenceService(
            IUnitOfWork unitOfWork,
            UserManager<CoreUser> userManager,
            IMapper mapper,
            IConfiguration configuration,
             IHttpContextAccessor httpContextAccessor,
             INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _notificationService = notificationService;
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
            // 1. Fetch the unit the resident is reporting for.
            var unit = await _unitOfWork.Units.GetByIdAsync(dto.UnitId);
            if (unit == null)
            {
                // The unit specified in the request does not exist.
                return null;
            }

            // 2. Security Check: Verify the logged-in resident is the actual resident of the unit they are reporting for.
            if (unit.ResidentId != residentUserId)
            {
                // This is a forbidden action. The user is trying to report an issue for a unit they do not live in.
                return null;
            }

            // 3. Map the incoming data (Title, Description, UnitId) to our database entity.
            var newOccurrence = _mapper.Map<CoreOccurrence>(dto);

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadRootSetting = _configuration["FileUpload:Path"];
                var uploadRoot = Environment.ExpandEnvironmentVariables(
                    string.IsNullOrWhiteSpace(uploadRootSetting) ? "CondoSphere_Uploads" : uploadRootSetting);

                if (!Path.IsPathRooted(uploadRoot))
                {
                    uploadRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadRoot));
                }
                var subfolder = "occurences-photos";
                var occurrenceFolder = Path.Combine(uploadRoot, subfolder);
                if (!Directory.Exists(occurrenceFolder))
                {
                    Directory.CreateDirectory(occurrenceFolder);
                }

                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(occurrenceFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}";

                newOccurrence.ImageUrl = $"{baseUrl}/uploads/{subfolder}/{uniqueFileName}";
            }

            // 5. Populate the remaining system-managed properties for the new occurrence.
            newOccurrence.ReportedDate = DateTime.UtcNow;
            newOccurrence.Status = OccurrenceStatus.Open;
            newOccurrence.ReportedByUserId = residentUserId;
            // The UnitId is already mapped from the DTO.
            newOccurrence.CondominiumId = unit.CondominiumId;
            newOccurrence.CompanyId = unit.CompanyId;       

            // 6. Add the new entity and save the changes.
            await _unitOfWork.Occurrences.AddAsync(newOccurrence);
            await _unitOfWork.CompleteAsync();
            await _notificationService.NotifyManagerOfNewOccurrenceAsync(newOccurrence);

            // 7. Map the newly created entity back to a DTO to return to the caller.
            // We need to enrich it with the reporter's name.
            var resultDto = _mapper.Map<OccurrenceDto>(newOccurrence);
            var reporter = await _userManager.FindByIdAsync(residentUserId.ToString());
            if (reporter != null)
            {
                resultDto.ReportedByUserName = $"{reporter.FirstName} {reporter.LastName}";
            }

            return resultDto;
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

            // NEW: once closed, never allow changing away from Closed
            if (occurrence.Status == OccurrenceStatus.Closed && newStatus != OccurrenceStatus.Closed)
            {
                return false;
            }

            occurrence.Status = newStatus;
            _unitOfWork.Occurrences.Update(occurrence);
            await _unitOfWork.CompleteAsync();
            await _notificationService.NotifyResidentOfStatusChangeAsync(occurrence);
            return true;
        }
    }
}