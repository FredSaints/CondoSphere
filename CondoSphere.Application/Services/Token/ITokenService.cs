using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Token
{
    /// <summary>
    /// I Token Service.
    /// </summary>
    public interface ITokenService
    {
        Task<string> CreateToken(CoreUser user);
    }
}