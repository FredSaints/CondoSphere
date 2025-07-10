using Microsoft.AspNetCore.Authorization;

namespace CondoSphere.Application.Authorization
{
    /// <summary>
    /// This requirement ensures that the authenticated user is the assigned manager
    /// of the specific condominium they are trying to access.
    /// </summary>
    public class IsCondoManagerRequirement : IAuthorizationRequirement
    {
    }
}