using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Web.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }

            return null;
        }
    }
}
