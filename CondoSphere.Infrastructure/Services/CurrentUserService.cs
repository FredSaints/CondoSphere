using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CondoSphere.Infrastructure.Services
{
    /// <summary>
    /// Current User Service.
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CondominiumDbContext _condoContext;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, CondominiumDbContext condoContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _condoContext = condoContext;
        }

        public int? UserId => GetClaimValue<int>(ClaimTypes.NameIdentifier);

        public int? CompanyId => GetClaimValue<int>("companyId");

        public string? UserEmail => GetClaimValue<string>(ClaimTypes.Email);

        public bool IsInRole(string roleName)
        {
            return _httpContextAccessor.HttpContext?.User.IsInRole(roleName) ?? false;
        }

        private T? GetClaimValue<T>(string claimType)
        {
            var claimValue = _httpContextAccessor.HttpContext?.User?.FindFirstValue(claimType);
            if (string.IsNullOrEmpty(claimValue))
            {
                return default;
            }
            return (T)Convert.ChangeType(claimValue, typeof(T));
        }

        public async Task<(bool IsAuthorized, int? CompanyId)> CanManageCondominium(int condominiumId)
        {
            var userId = this.UserId; // Get user ID from the existing property
            if (userId == null) return (false, null);

            // One single, efficient database call to check everything.
            var condo = await _condoContext.Condominiums
                                .AsNoTracking()
                                .FirstOrDefaultAsync(c => c.Id == condominiumId && c.ManagerId == userId);

            if (condo != null)
            {
                // If found, user is authorized, and we return the condo's CompanyId.
                return (true, condo.CompanyId);
            }

            // If not found, user is not authorized.
            return (false, null);
        }
    }
}
