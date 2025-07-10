using CondoSphere.Application.Authorization;
using CondoSphere.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace CondoSphere.Infrastructure.Authorization
{
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
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                context.Fail();
                return;
            }

            // Get the current user's ID from their token claims.
            var userIdClaim = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                context.Fail();
                return;
            }

            // Get the ID of the condominium from the URL route data (e.g., from /api/condominiums/{condominiumId}/units).
            var condominiumIdRouteValue = httpContext.GetRouteValue("condominiumId")?.ToString();
            if (!int.TryParse(condominiumIdRouteValue, out var condominiumId))
            {
                // Fallback for routes that use "id" instead of "condominiumId"
                condominiumIdRouteValue = httpContext.GetRouteValue("id")?.ToString();
                if (!int.TryParse(condominiumIdRouteValue, out condominiumId))
                {
                    context.Fail();
                    return;
                }
            }

            // Check the database to see if this user is the manager of this condominium.
            bool isManagerOfCondo = await _condoContext.Condominiums
                .AnyAsync(c => c.Id == condominiumId && c.ManagerId == userId);

            if (isManagerOfCondo)
            {
                // If they are the manager, the requirement is met.
                context.Succeed(requirement);
            }
            else
            {
                // Otherwise, they fail authorization.
                context.Fail();
            }
        }
    }
}