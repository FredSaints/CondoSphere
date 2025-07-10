using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Token
{
    public interface ITokenService
    {
        Task<string> CreateToken(CoreUser user);
    }
}