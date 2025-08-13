using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.User;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUnit = CondoSphere.Core.Entities.Condominiums.Unit;

namespace CondoSphere.Application.Services.Condominium
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UnitService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }


        public async Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId)
        {
            var unit = _mapper.Map<CoreUnit>(unitDto);
            unit.CondominiumId = condominiumId;
            unit.CompanyId = companyId;

            await _unitOfWork.Units.AddAsync(unit);
            await _unitOfWork.CompleteAsync();

            // Return a DTO for the newly created, vacant unit.
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<bool> DeleteUnitAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null) return false;

            // Business Rule: A unit cannot be deleted if it is currently occupied.
            if (unit.ResidentId.HasValue)
            {
                return false;
            }

            _unitOfWork.Units.Remove(unit);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<UnitDto?> GetUnitByIdAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            // This will map the basic unit details. The Resident will be null.
            // A more advanced implementation might hydrate the resident here as well.
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            // 1. Get all unit entities for the condominium from the CondominiumDB.
            var units = await _unitOfWork.Units.GetAllAsync(condominiumId);
            if (!units.Any())
            {
                return Enumerable.Empty<UnitDto>();
            }

            // 2. Get the distinct IDs of all residents in those units.
            var residentIds = units
                .Where(u => u.ResidentId.HasValue)
                .Select(u => u.ResidentId.Value)
                .Distinct()
                .ToList();

            // 3. Fetch the full user details for those residents from the UserService in a single batch.
            var residents = new List<UserListDto>();
            if (residentIds.Any())
            {
                residents = (await _userService.GetUsersByIdsAsync(residentIds)).ToList();
            }
            var residentLookup = residents.ToDictionary(r => r.Id);

            // 4. Map the Unit entities to DTOs and stitch in the resident data.
            var unitDtos = _mapper.Map<List<UnitDto>>(units);
            foreach (var unitDto in unitDtos)
            {
                var originalUnit = units.First(u => u.Id == unitDto.Id);
                if (originalUnit.ResidentId.HasValue && residentLookup.TryGetValue(originalUnit.ResidentId.Value, out var resident))
                {
                    // Map the full UserListDto to the simpler SimpleUserDto for nesting.
                    unitDto.Resident = _mapper.Map<SimpleUserDto>(resident);
                }
            }
            return unitDtos;
        }

        public async Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null) return false;

            _mapper.Map(unitDto, unit);
            _unitOfWork.Units.Update(unit);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}