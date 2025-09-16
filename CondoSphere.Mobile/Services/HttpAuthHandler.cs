using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CondoSphere.Mobile.Services
{
    public class HttpAuthHandler : DelegatingHandler
    {
        public HttpAuthHandler()
        {
            // For development, bypass SSL certificate validation.
            // In production, you would have a valid certificate.
            InnerHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Get the token from secure storage
            var token = await TokenStorage.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                // Add the token to the Authorization header for this request
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}