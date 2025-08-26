using System.Net.Http.Json;

namespace CondoSphere.Mobile.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        // IMPORTANT:
        // For Android Emulator on Windows, use 10.0.2.2 to connect to your PC's localhost.
        // For iOS Simulator on Mac, use localhost or 127.0.0.1.
        // For a physical device, find your PC's local IP address (e.g., ipconfig in cmd) and use that.
        private const string ApiBaseUrl = "https://192.168.1.70:7177";

        public AuthService()
        {
            // This handler is for DEVELOPMENT ONLY to bypass SSL certificate validation errors from localhost.
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler) { BaseAddress = new Uri(ApiBaseUrl) };
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            try
            {
                var request = new LoginRequest { Email = email, Password = password };
                var response = await _httpClient.PostAsJsonAsync("/api/accounts/login", request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    return content?.Token;
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Login Error: {ex.Message}");
            }
            return null;
        }
    }
}