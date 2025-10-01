using CondoSphere.Application.Authorization;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using Microsoft.AspNetCore.Authorization;
using CoreIntervention = CondoSphere.Core.Entities.Condominiums.Intervention;

namespace CondoSphere.Infrastructure.Authorization
{
    /// <summary>
    /// Can Manage Intervention Handler.
    /// </summary>
    public class CanManageInterventionHandler : AuthorizationHandler<CanManageInterventionRequirement, CoreIntervention>
    {
        private readonly ICurrentUserService _currentUserService;

        public CanManageInterventionHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CanManageInterventionRequirement requirement,
            CoreIntervention resource)
        {
            var userId = _currentUserService.UserId;
            if (userId == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Rule 1: Allow if the user is the employee assigned to the intervention.
            if (resource.AssignedToUserId.HasValue && resource.AssignedToUserId.Value == userId.Value)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            // Rule 2: Allow if the user is a CompanyAdmin or CondoManager.
            // (The check for company is implicit in how we fetch the resource).
            if (context.User.IsInRole(RoleConstants.CompanyAdmin) || context.User.IsInRole(RoleConstants.CondoManager))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}