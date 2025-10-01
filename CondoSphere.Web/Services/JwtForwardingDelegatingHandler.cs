using System.Net;
using System.Net.Http.Headers;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Web.Services
{
    /// <summary>
    /// Jwt Forwarding Delegating Handler.
    /// </summary>
    public class JwtForwardingDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccessTokenStore _accessTokenStore;

        public JwtForwardingDelegatingHandler(IHttpContextAccessor httpContextAccessor, IAccessTokenStore accessTokenStore)
        {
            _httpContextAccessor = httpContextAccessor;
            _accessTokenStore = accessTokenStore;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var token = _accessTokenStore.GetToken(httpContext);
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized && httpContext != null)
            {
                _accessTokenStore.ClearToken(httpContext);
                httpContext.Session?.Clear();

                if (httpContext.User?.Identity?.IsAuthenticated == true)
                {
                    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
            }

            return response;
        }
    }
}
