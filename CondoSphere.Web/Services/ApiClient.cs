using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;

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

        public async Task<bool> RegisterManagerAsync(RegisterManagerDto registerDto)
        {
            // We need to send the token with this request. This is the next major step.
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-manager", registerDto);
            return response.IsSuccessStatusCode;
        }

        // --- ADD THESE NEW METHODS ---
        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsAsync()
        {
            // TODO: Add paging parameters
            return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums");
        }

        public async Task<IEnumerable<UserListDto>> GetUsersAsync()
        {
            // TODO: We need to create this API endpoint next.
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/company-users");
        }
    }
}
