using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Web.Services
{
    /// <summary>
    /// Session Access Token Store.
    /// </summary>
    public class SessionAccessTokenStore : IAccessTokenStore
    {
        private const string AccessTokenSessionKey = "AccessToken";

        public string? GetToken(HttpContext context)
        {
            if (context == null) return null;

            var token = context.Session.GetString(AccessTokenSessionKey);
            if (!string.IsNullOrEmpty(token))
            {
                return token;
            }

            // Fallback to legacy claim if the session was cleared but the cookie still contains the token
            var claimToken = context.User.FindFirst("access_token")?.Value;
            if (!string.IsNullOrEmpty(claimToken))
            {
                context.Session.SetString(AccessTokenSessionKey, claimToken);
                return claimToken;
            }

            return null;
        }

        public void SaveToken(HttpContext context, string token)
        {
            if (context == null || string.IsNullOrEmpty(token))
            {
                return;
            }

            context.Session.SetString(AccessTokenSessionKey, token);
        }

        public void ClearToken(HttpContext context)
        {
            context?.Session.Remove(AccessTokenSessionKey);
        }
    }
}
