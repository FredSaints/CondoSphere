using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Identity;
using CoreUnit = CondoSphere.Core.Entities.Condominiums.Unit;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Condominium
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CoreUser> _userManager;

        public UnitService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<CoreUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId)
        {
            var unit = _mapper.Map<CoreUnit>(unitDto);
            unit.CondominiumId = condominiumId;
            unit.CompanyId = companyId;

            await _unitOfWork.Units.AddAsync(unit);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<bool> DeleteUnitAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null) return false;

            _unitOfWork.Units.Remove(unit);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<UnitDto?> GetUnitByIdAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            var units = await _unitOfWork.Units.GetAllAsync(condominiumId);
            return _mapper.Map<IEnumerable<UnitDto>>(units);
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

        public async Task<bool> UnassignResidentAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit?.ResidentId == null)
            {
                return false;
            }
            unit.ResidentId = null;
            _unitOfWork.Units.Update(unit);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> AssignExistingResidentAsync(int unitId, int residentId, int companyId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null || unit.CompanyId != companyId || unit.ResidentId.HasValue)
            {
                return false;
            }

            var resident = await _userManager.FindByIdAsync(residentId.ToString());
            if (resident == null || resident.CompanyId != companyId)
            {
                return false;
            }

            if (!await _userManager.IsInRoleAsync(resident, RoleConstants.CondoResident))
            {
                return false;
            }

            unit.ResidentId = residentId;
            _unitOfWork.Units.Update(unit);

            // If a resident is assigned, ensure their account is active.
            if (!resident.IsActive)
            {
                resident.IsActive = true;
                await _userManager.UpdateAsync(resident);
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}