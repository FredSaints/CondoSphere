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

        public async Task<IEnumerable<CondominiumDto>> GetMyManagedCondominiumsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums/my-managed");
        }

        public async Task<CondominiumDto> GetCondominiumDetailsAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CondominiumDto>($"/api/condominiums/{id}");
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>($"/api/condominiums/{condominiumId}/units");
        }

        public async Task<bool> RegisterResidentAsync(int condominiumId, RegisterResidentDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/residents", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<(bool Success, string Message)> SetPasswordAsync(SetPasswordDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/set-password", dto);
            var responseContent = await response.Content.ReadFromJsonAsync<object>(); // Or a specific response DTO

            if (response.IsSuccessStatusCode)
            {
                // A simple way to get the message back
                var message = responseContent?.GetType().GetProperty("message")?.GetValue(responseContent)?.ToString();
                return (true, message ?? "Password set successfully.");
            }

            // Handle error messages if the API returns them in a structured way
            return (false, "Failed to set password. The link may have expired or the password may not meet complexity requirements.");
        }

        public async Task<bool> CreateCondominiumAsync(CreateUpdateCondominiumDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/condominiums", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableManagersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/managers");
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, AssignManagerDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/condominiums/{condominiumId}/assign-manager", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateUnitAsync(int condominiumId, CreateUpdateUnitDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/units", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UnassignResidentAsync(int condominiumId, int unitId)
        {
            var response = await _httpClient.PatchAsync($"/api/condominiums/{condominiumId}/units/{unitId}/unassign-resident", null);
            return response.IsSuccessStatusCode;
        }
    }
}
