using CondoSphere.Application.Authorization;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Infrastructure.Authorization
{
    public class CanAccessOccurrenceHandler
        : AuthorizationHandler<CanAccessOccurrenceRequirement, CoreOccurrence>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<CoreUser> _userManager;

        public CanAccessOccurrenceHandler(
            ICurrentUserService currentUserService,
            UserManager<CoreUser> userManager)
        {
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CanAccessOccurrenceRequirement requirement,
            CoreOccurrence resource)
        {
            var userId = _currentUserService.UserId;
            if (userId == null)
            {
                context.Fail();
                return;
            }

            // Rule 1: Allow if the user is the one who reported it.
            if (resource.ReportedByUserId == userId.Value)
            {
                context.Succeed(requirement);
                return;
            }

            // Eule 2: Allow if the user is the employee assigned to the OCCURRENCE.
            if (resource.AssignedToUserId.HasValue &&
                resource.AssignedToUserId.Value == userId.Value)
            {
                context.Succeed(requirement);
                return;
            }

            // Rule 3: Allow if the user is a CompanyAdmin or CondoManager for that company.
            var user = await _userManager.FindByIdAsync(userId.Value.ToString());
            if (user?.CompanyId == resource.CompanyId)
            {
                if (context.User.IsInRole(RoleConstants.CompanyAdmin) ||
                    context.User.IsInRole(RoleConstants.CondoManager))
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            context.Fail();
        }
    }
}
