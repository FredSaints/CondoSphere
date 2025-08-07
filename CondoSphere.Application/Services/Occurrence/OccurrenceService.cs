using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;
using CoreUser = CondoSphere.Core.Entities.Users.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Application.Services.Occurrence
{
    public class OccurrenceService : IOccurrenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IMapper _mapper;

        public OccurrenceService(
            IUnitOfWork unitOfWork,
            UserManager<CoreUser> userManager,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
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

        public async Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, int residentUserId)
        {
            // 1. Find the unit associated with the logged-in resident using the Unit of Work.
            var unit = await _unitOfWork.Units.GetUnitByResidentIdAsync(residentUserId);
            if (unit == null)
            {
                // SECURITY: This resident is not assigned to a unit, so they cannot create an occurrence.
                return null;
            }

            // 2. Create the new Occurrence entity from the DTO using AutoMapper.
            var newOccurrence = _mapper.Map<CoreOccurrence>(dto);

            // 3. Populate all system-managed properties.
            newOccurrence.ReportedDate = DateTime.UtcNow;
            newOccurrence.Status = OccurrenceStatus.Open;
            newOccurrence.ReportedByUserId = residentUserId;
            newOccurrence.UnitId = unit.Id;
            newOccurrence.CondominiumId = unit.CondominiumId;
            newOccurrence.CompanyId = unit.CompanyId;

            // 4. Add the new entity to the database via the repository and save all changes.
            await _unitOfWork.Occurrences.AddAsync(newOccurrence);
            await _unitOfWork.CompleteAsync();

            // 5. Map the newly created entity (which now has an ID) back to a DTO to return.
            return _mapper.Map<OccurrenceDto>(newOccurrence);
        }

        public async Task<OccurrenceDto?> GetOccurrenceByIdAsync(int occurrenceId)
        {
            var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(occurrenceId);
            if (occurrence == null)
            {
                return null;
            }

            return _mapper.Map<OccurrenceDto>(occurrence);
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForResidentAsync(int residentUserId)
        {
            var occurrences = await _unitOfWork.Occurrences.GetAllForResidentAsync(residentUserId);

            return _mapper.Map<IEnumerable<OccurrenceDto>>(occurrences);
        }
    }
}