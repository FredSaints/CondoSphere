using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Identity;
using CoreCondominium = CondoSphere.Core.Entities.Condominiums.Condominium;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Condominium
{
    public class CondominiumService : ICondominiumService
    {
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IMapper _mapper;

        public CondominiumService(
            ICondominiumRepository condominiumRepository,
            UserManager<CoreUser> userManager,
            IMapper mapper)
        {
            _condominiumRepository = condominiumRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CondominiumDto> CreateCondominiumAsync(CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = _mapper.Map<CoreCondominium>(condominiumDto);
            condominium.CompanyId = companyId;

            await _condominiumRepository.AddAsync(condominium);
            await _condominiumRepository.SaveChangesAsync();

            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<IEnumerable<CondominiumDto>> GetAllCondominiumsAsync(int companyId, int pageNumber, int pageSize)
        {
            var condominiums = await _condominiumRepository.GetAllAsync(companyId, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<CondominiumDto>>(condominiums);
        }

        public async Task<CondominiumDto?> GetCondominiumByIdAsync(int id, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id, companyId);
            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _mapper.Map(condominiumDto, condominium);

            _condominiumRepository.Update(condominium);
            return await _condominiumRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteCondominiumAsync(int id, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _condominiumRepository.Remove(condominium);
            return await _condominiumRepository.SaveChangesAsync();
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(condominiumId, companyId);
            if (condominium == null) return false;

            var manager = await _userManager.FindByIdAsync(managerId.ToString());
            if (manager == null || manager.CompanyId != companyId) return false;

            var roles = await _userManager.GetRolesAsync(manager);
            if (!roles.Contains(nameof(Core.Enums.SystemRole.CondoManager))) return false;

            condominium.ManagerId = managerId;
            _condominiumRepository.Update(condominium);
            return await _condominiumRepository.SaveChangesAsync();
        }
    }
}