namespace CondoSphere.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        int? CompanyId { get; }
        string? UserEmail { get; }
        bool IsInRole(string roleName);
    }
}