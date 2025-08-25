using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CoreCondominium = CondoSphere.Core.Entities.Condominiums.Condominium;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Condominium
{
    public class CondominiumService : ICondominiumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IMapper _mapper;

        public CondominiumService(
            IUnitOfWork unitOfWork,
            UserManager<CoreUser> userManager,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CondominiumDto> CreateCondominiumAsync(CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = _mapper.Map<CoreCondominium>(condominiumDto);
            condominium.CompanyId = companyId;

            await _unitOfWork.Condominiums.AddAsync(condominium);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<IEnumerable<CondominiumDto>> GetAllCondominiumsAsync(int companyId, int pageNumber, int pageSize)
        {
            // 1. Fetch the raw condominium data from the repository via UnitOfWork
            var condominiums = await _unitOfWork.Condominiums.GetAllAsync(companyId, pageNumber, pageSize);
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
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(id, companyId);
            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _mapper.Map(condominiumDto, condominium);

            _unitOfWork.Condominiums.Update(condominium);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<(bool Success, string Message)> DeleteCondominiumAsync(int id, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return (false, "Condominium not found or you do not have permission to access it.");
            }

            var units = await _unitOfWork.Units.GetAllAsync(id);
            if (units.Any())
            {
                return (false, "Error: Cannot delete a condominium that contains units. Please remove all units first.");
            }
            if (condominium.ManagerId.HasValue)
            {
                return (false, "Error: Cannot delete a condominium that has a manager assigned. Please un-assign the manager first.");
            }
            _unitOfWork.Condominiums.Remove(condominium);
            await _unitOfWork.CompleteAsync();

            return (true, "Condominium deleted successfully.");
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condominium == null) return false;

            var manager = await _userManager.FindByIdAsync(managerId.ToString());
            if (manager == null || manager.CompanyId != companyId) return false;

            var roles = await _userManager.GetRolesAsync(manager);
            if (!roles.Contains(RoleConstants.CondoManager)) return false;

            condominium.ManagerId = managerId;
            _unitOfWork.Condominiums.Update(condominium);

            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsByManagerIdAsync(int managerId)
        {
            var condominiums = await _unitOfWork.Condominiums.GetByManagerIdAsync(managerId);
            return _mapper.Map<IEnumerable<CondominiumDto>>(condominiums);
        }

        public async Task<bool> UnassignManagerAsync(int condominiumId, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condominium == null)
            {
                return false;
            }

            condominium.ManagerId = null;
            _unitOfWork.Condominiums.Update(condominium);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}