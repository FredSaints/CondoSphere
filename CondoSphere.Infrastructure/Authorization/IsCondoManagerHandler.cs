using CondoSphere.Application.Authorization;
using CondoSphere.Core;
using CondoSphere.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Authorization
{
    /// <summary>
    /// Is Condo Manager Handler.
    /// </summary>
    public class IsCondoManagerHandler : AuthorizationHandler<IsCondoManagerRequirement>
    {
        private readonly CondominiumDbContext _condoContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsCondoManagerHandler(CondominiumDbContext condoContext, IHttpContextAccessor httpContextAccessor)
        {
            _condoContext = condoContext;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsCondoManagerRequirement requirement)
        {
            // First, check for the override role. A CompanyAdmin can manage everything.
            if (context.User.IsInRole(RoleConstants.CompanyAdmin))
            {
                context.Succeed(requirement);
                return;
            }

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                context.Fail();
                return;
            }

            var userIdClaim = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                context.Fail();
                return;
            }

            var condominiumIdRouteValue = httpContext.GetRouteValue("condominiumId")?.ToString();
            if (!int.TryParse(condominiumIdRouteValue, out var condominiumId))
            {
                condominiumIdRouteValue = httpContext.GetRouteValue("id")?.ToString();
                if (!int.TryParse(condominiumIdRouteValue, out condominiumId))
                {
                    context.Fail();
                    return;
                }
            }

            // Check the database to see if this user is the manager of this condominium.
            // We do NOT use IgnoreQueryFilters() here. This is intentional.
            // We want this authorization check to respect any global filters, such as a
            // potential future soft-delete "IsActive" flag on condominiums.
            bool isManagerOfCondo = await _condoContext.Condominiums
                .AnyAsync(c => c.Id == condominiumId && c.ManagerId == userId);

            if (isManagerOfCondo)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}