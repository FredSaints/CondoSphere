using CondoSphere.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CondoSphere.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
    }
}
