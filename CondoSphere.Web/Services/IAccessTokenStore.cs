using Microsoft.AspNetCore.Http;

namespace CondoSphere.Web.Services
{
    /// <summary>
    /// I Access Token Store.
    /// </summary>
    public interface IAccessTokenStore
    {
        string? GetToken(HttpContext context);
        void SaveToken(HttpContext context, string token);
        void ClearToken(HttpContext context);
    }
}
