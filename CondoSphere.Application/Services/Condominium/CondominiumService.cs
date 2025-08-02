using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.EntityFrameworkCore;
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
            // 1. Fetch the raw condominium data from the repository
            var condominiums = await _condominiumRepository.GetAllAsync(companyId, pageNumber, pageSize);
            if (!condominiums.Any())
            {
                return Enumerable.Empty<CondominiumDto>();
            }

            // 2. Map the entities to DTOs
            var condominiumDtos = _mapper.Map<List<CondominiumDto>>(condominiums);

            // 3. Efficiently fetch the names for all required managers in a single query
            var managerIds = condominiums
                .Where(c => c.ManagerId.HasValue)
                .Select(c => c.ManagerId.Value)
                .Distinct()
                .ToList();

            if (managerIds.Any())
            {
                var managers = await _userManager.Users
                    .Where(u => managerIds.Contains(u.Id))
                    .ToDictionaryAsync(u => u.Id, u => $"{u.FirstName} {u.LastName}");

                // 4. Stitch the manager names onto the DTOs
                foreach (var dto in condominiumDtos)
                {
                    var condo = condominiums.First(c => c.Id == dto.Id);
                    if (condo.ManagerId.HasValue && managers.ContainsKey(condo.ManagerId.Value))
                    {
                        dto.ManagerName = managers[condo.ManagerId.Value];
                    }
                }
            }

            return condominiumDtos;
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
            return await _condominiumRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCondominiumAsync(int id, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _condominiumRepository.Remove(condominium);
            return await _condominiumRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(condominiumId, companyId);
            if (condominium == null) return false;

            var manager = await _userManager.FindByIdAsync(managerId.ToString());
            if (manager == null || manager.CompanyId != companyId) return false;

            var roles = await _userManager.GetRolesAsync(manager);
            if (!roles.Contains(RoleConstants.CondoManager)) return false;

            condominium.ManagerId = managerId;
            _condominiumRepository.Update(condominium);
            return await _condominiumRepository.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsByManagerIdAsync(int managerId)
        {
            var condominiums = await _condominiumRepository.GetByManagerIdAsync(managerId);
            return _mapper.Map<IEnumerable<CondominiumDto>>(condominiums);
        }
    }
}