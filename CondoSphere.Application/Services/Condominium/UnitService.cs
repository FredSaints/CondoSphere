using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Condominiums;
using CoreUnit = CondoSphere.Core.Entities.Condominiums.Unit;

namespace CondoSphere.Application.Services.Condominium
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UnitService(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId)
        {
            var unit = _mapper.Map<CoreUnit>(unitDto);
            unit.CondominiumId = condominiumId;
            unit.CompanyId = companyId;

            await _unitRepository.AddAsync(unit);
            await _unitRepository.SaveChangesAsync();

            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<bool> DeleteUnitAsync(int unitId)
        {
            var unit = await _unitRepository.GetByIdAsync(unitId);
            if (unit == null) return false;

            _unitRepository.Remove(unit);
            return await _unitRepository.SaveChangesAsync() > 0;
        }

        public async Task<UnitDto?> GetUnitByIdAsync(int unitId)
        {
            var unit = await _unitRepository.GetByIdAsync(unitId);
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            var units = await _unitRepository.GetAllAsync(condominiumId);
            return _mapper.Map<IEnumerable<UnitDto>>(units);
        }

        public async Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto)
        {
            var unit = await _unitRepository.GetByIdAsync(unitId);
            if (unit == null) return false;

            _mapper.Map(unitDto, unit);
            _unitRepository.Update(unit);
            return await _unitRepository.SaveChangesAsync() > 0;
        }
    }
}