using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Infrastructure.Repositories
{

    /// <summary>

    /// Resident Repository.

    /// </summary>

    public class ResidentRepository : IResidentRepository
    {
        private readonly CondominiumDbContext _condoCtx;
        private readonly UserManagementDbContext _userCtx;

        public ResidentRepository(CondominiumDbContext condoCtx, UserManagementDbContext userCtx)
        {
            _condoCtx = condoCtx;
            _userCtx = userCtx;
        }

        public async Task<IReadOnlyList<Resident>> GetByCondominiumAsync(int condominiumId)
        {
            // 1) ids de utilizadores residentes em unidades deste condomínio
            var residentIds = await _condoCtx.Units
                .Where(u => u.CondominiumId == condominiumId && u.ResidentId != null)
                .Select(u => u.ResidentId!.Value)
                .Distinct()
                .ToListAsync();

            if (residentIds.Count == 0) return Array.Empty<Resident>();

            // 2) ler da tabela de Users e projetar para Resident
            var residents = await _userCtx.Users
                .Where(u => residentIds.Contains(u.Id))
                .Select(u => new Resident
                {
                    Id = u.Id,
                    CompanyId = u.CompanyId,
                    FirstName = u.FirstName ?? "",
                    LastName = u.LastName ?? "",
                    Email = u.Email ?? "",
                    PhoneNumber = u.PhoneNumber
                })
                .AsNoTracking()
                .ToListAsync();

            return residents;
        }
    }
}
