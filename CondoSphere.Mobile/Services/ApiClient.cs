using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.DTOs.Reports;
using System.Net.Http.Json;
using System.Text.Json;

namespace CondoSphere.Mobile.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public const string ApiBaseUrl = "https://192.168.1.70:7177";
        public const string WebBaseUrl = "http://192.168.1.70:5017";

        public ApiClient()
        {
            _httpClient = new HttpClient(new HttpAuthHandler())
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
        }


        public async Task<IEnumerable<UnitQuotaDto>> GetMyQuotasAsync()
        {
            try
            {
                // The original request attempt
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<UnitQuotaDto>>("/api/users/my-quotas");
                System.Diagnostics.Debug.WriteLine("[DEBUG] GetMyQuotasAsync: API call SUCCEEDED.");
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                // This catches network errors (DNS, server not found) and HTTP error codes (404, 500)
                System.Diagnostics.Debug.WriteLine($"[DEBUG] HttpRequestException in GetMyQuotasAsync: {httpEx.Message}");
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Status Code: {httpEx.StatusCode}");
                if (httpEx.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Inner Exception: {httpEx.InnerException.Message}");
                }
                // We will show this error to the user
                await Shell.Current.DisplayAlert("API Request Error", $"HTTP Error: {httpEx.Message}", "OK");
                return null;
            }
            catch (JsonException jsonEx)
            {
                // This catches errors if the API returns something that isn't valid JSON
                System.Diagnostics.Debug.WriteLine($"[DEBUG] JsonException in GetMyQuotasAsync: {jsonEx.Message}");
                await Shell.Current.DisplayAlert("API Data Error", $"Failed to parse response: {jsonEx.Message}", "OK");
                return null;
            }
            catch (Exception ex)
            {
                // This catches any other unexpected errors
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Generic Exception in GetMyQuotasAsync: {ex.Message}");
                await Shell.Current.DisplayAlert("Generic Error", $"An unexpected error occurred: {ex.Message}", "OK");
                return null;
            }
        }

        public async Task<IEnumerable<OccurrenceDto>> GetMyOccurrencesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>("/api/occurrences/my-occurrences");
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async Task<IEnumerable<DocumentDto>> GetMyDocumentsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<DocumentDto>>("/api/users/my-documents");
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async Task<IEnumerable<CondominiumDto>> GetMyManagedCondominiumsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums/my-managed");
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>($"/api/condominiums/{condominiumId}/occurrences");
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async Task<AdminDashboardDto> GetAdminDashboardAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<AdminDashboardDto>("/api/reports/admin-dashboard");
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async Task<IEnumerable<UnitDto>> GetMyUnitsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>("/api/users/my-units");
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async Task<bool> CreateOccurrenceAsync(CreateOccurrenceRequest occurrence)
        {
            try
            {
                // Always use MultipartFormDataContent for this endpoint
                using var formData = new MultipartFormDataContent();

                // Add the text-based data as StringContent
                formData.Add(new StringContent(occurrence.Title), "Title");
                formData.Add(new StringContent(occurrence.Description), "Description");
                formData.Add(new StringContent(occurrence.UnitId.ToString()), "UnitId");

                // --- THIS IS THE KEY LOGIC ---
                // Check if an image file was provided
                if (occurrence.ImageFile != null)
                {
                    // If there is a file, add it as StreamContent
                    var fileStream = await occurrence.ImageFile.OpenReadAsync();
                    var streamContent = new StreamContent(fileStream);
                    streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(occurrence.ImageFile.ContentType);

                    // The name "imageFile" MUST match the parameter name in your API controller
                    formData.Add(streamContent, "imageFile", occurrence.ImageFile.FileName);
                }
                // If occurrence.ImageFile is null, we simply don't add the file part.
                // The request is still valid.

                // Send the form data to the original endpoint
                var response = await _httpClient.PostAsync("/api/occurrences", formData);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateOccurrence Error: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<InterventionDto>>($"/api/occurrences/{occurrenceId}/interventions");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetInterventions Error: {ex.Message}");
                return null;
            }
        }

        public async Task<QuotaBreakdownDto> GetQuotaBreakdownAsync(int quotaId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<QuotaBreakdownDto>($"/api/financials/quotas/{quotaId}/breakdown");
                System.Diagnostics.Debug.WriteLine($"[DEBUG] GetQuotaBreakdownAsync: API call SUCCEEDED for quota {quotaId}");
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] HttpRequestException in GetQuotaBreakdownAsync: {httpEx.Message}");
                await Shell.Current.DisplayAlert("API Request Error", $"Failed to load quota details: {httpEx.Message}", "OK");
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Exception in GetQuotaBreakdownAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> SubmitPaymentProofAsync(int quotaId, FileResult proofFile)
        {
            try
            {
                using var formData = new MultipartFormDataContent();

                var fileStream = await proofFile.OpenReadAsync();
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(proofFile.ContentType);

                formData.Add(streamContent, "proofFile", proofFile.FileName);

                var response = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/submit-payment-proof", formData);

                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] SubmitPaymentProofAsync: Successfully uploaded proof for quota {quotaId}");
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] SubmitPaymentProofAsync: Failed with status {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] SubmitPaymentProof Error: {ex.Message}");
                await Shell.Current.DisplayAlert("Upload Error", $"Failed to upload payment proof: {ex.Message}", "OK");
                return false;
            }
        }

        public async Task<IEnumerable<MessageListDto>> GetInboxAsync(int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<MessageListDto>>($"/api/messages/inbox?pageNumber={pageNumber}&pageSize={pageSize}");
                return response ?? new List<MessageListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetInbox Error: {ex.Message}");
                return new List<MessageListDto>();
            }
        }

        public async Task<IEnumerable<MessageListDto>> GetSentMessagesAsync(int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<MessageListDto>>($"/api/messages/sent?pageNumber={pageNumber}&pageSize={pageSize}");
                return response ?? new List<MessageListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetSentMessages Error: {ex.Message}");
                return new List<MessageListDto>();
            }
        }

        public async Task<MessageDto> GetMessageAsync(int messageId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MessageDto>($"/api/messages/{messageId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetMessage Error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> SendMessageAsync(SendMessageDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/messages", dto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SendMessage Error: {ex.Message}");
                return false;
            }
        }

        public async Task<int> GetUnreadMessageCountAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<dynamic>("/api/messages/unread-count");
                return response?.unreadCount ?? 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetUnreadMessageCount Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<IEnumerable<SimpleUserDto>> GetContactsAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<SimpleUserDto>>("/api/messages/contacts");
                return response ?? new List<SimpleUserDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetContacts Error: {ex.Message}");
                return new List<SimpleUserDto>();
            }
        }

        public async Task<bool> MarkMessageAsReadAsync(int messageId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/messages/{messageId}/mark-read", null);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MarkMessageAsRead Error: {ex.Message}");
                return false;
            }
        }

        public async Task<UserProfileDto> GetMyProfileAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<UserProfileDto>("/api/profile");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetMyProfile Error: {ex.Message}");
                return null;
            }
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(ChangePasswordDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/profile/change-password", dto);

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Password changed successfully.");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        using var jsonDoc = JsonDocument.Parse(errorContent);
                        if (jsonDoc.RootElement.TryGetProperty("message", out var messageElement))
                        {
                            return (false, messageElement.GetString());
                        }
                    }
                    catch { }
                    return (false, "Failed to change password. Please check your current password.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChangePassword Error: {ex.Message}");
                return (false, "An error occurred while connecting to the server.");
            }
        }

        private async Task<string> UploadProfileImageAsync(FileResult imageFile)
        {
            try
            {
                using var formData = new MultipartFormDataContent();
                var fileStream = await imageFile.OpenReadAsync();
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);

                // "file" must match the IFormFile parameter name in our new UploadController
                formData.Add(streamContent, "file", imageFile.FileName);

                var response = await _httpClient.PostAsync("/api/upload/profile-picture", formData);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
                    return responseBody.GetProperty("url").GetString();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UploadProfileImage Error: {ex.Message}");
                return null;
            }
        }

        // Method 2: The public method that the ViewModel will call
        public async Task<(bool Success, string Message, string NewToken)> UpdateProfileAsync(UpdateProfileDto dto, FileResult newImageFile)
        {
            try
            {
                // Step A: If there's a new image, upload it first and get the new URL.
                if (newImageFile != null)
                {
                    var newImageUrl = await UploadProfileImageAsync(newImageFile);
                    if (!string.IsNullOrEmpty(newImageUrl))
                    {
                        // Set the URL in the DTO that we will send to the profile update endpoint
                        dto.ProfilePictureUrl = newImageUrl;
                    }
                    else
                    {
                        // If the upload fails, stop the whole process.
                        return (false, "Failed to upload new profile picture.", null);
                    }
                }

                // Step B: Call the existing profile update endpoint with a clean JSON payload.
                var response = await _httpClient.PutAsJsonAsync("/api/profile", dto);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using var jsonDoc = JsonDocument.Parse(responseBody);
                    jsonDoc.RootElement.TryGetProperty("token", out var tokenElement);
                    return (true, "Profile updated successfully.", tokenElement.GetString());
                }

                return (false, responseBody, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateProfile Error: {ex.Message}");
                return (false, "An error occurred while connecting to the server.", null);
            }
        }

        public async Task<IEnumerable<UserListDto>> GetUsersAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/company-users");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetUsersAsync Error: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<CondominiumDto>> GetAllCondosForAdminAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums/for-admin");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllCondosForAdminAsync Error: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            try
            {
                var url = $"/api/condominiums/{condominiumId}/units";
                return await _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetUnitsForCondominiumAsync Error: {ex.Message}");
                return null;
            }
        }

        public async Task<(bool Success, string Message)> SendAnnouncementAsync(int condominiumId, AnnouncementDto dto)
        {
            try
            {
                var url = $"/api/condominiums/{condominiumId}/announcements";
                var response = await _httpClient.PostAsJsonAsync(url, dto);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                    var message = result.GetProperty("message").GetString();
                    return (true, message);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return (false, error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SendAnnouncementAsync Error: {ex.Message}");
                return (false, "An error occurred while connecting to the server.");
            }
        }

        public async Task<(bool Success, string Message)> CreateExpenseAsync(CreateExpenseRequest dto)
        {
            try
            {
                using var formData = new MultipartFormDataContent();

                formData.Add(new StringContent(dto.Title), nameof(dto.Title));
                formData.Add(new StringContent(dto.Description ?? string.Empty), nameof(dto.Description));
                formData.Add(new StringContent(dto.Amount.ToString()), nameof(dto.Amount));
                formData.Add(new StringContent(dto.ExpenseDate.ToString("o")), nameof(dto.ExpenseDate));
                formData.Add(new StringContent(dto.CondominiumId.ToString()), nameof(dto.CondominiumId));
                if (dto.OccurrenceId.HasValue)
                {
                    formData.Add(new StringContent(dto.OccurrenceId.Value.ToString()), nameof(dto.OccurrenceId));
                }

                if (dto.AttachmentFiles != null)
                {
                    foreach (var file in dto.AttachmentFiles)
                    {
                        var fileStream = await file.OpenReadAsync();
                        var streamContent = new StreamContent(fileStream);
                        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        formData.Add(streamContent, "attachmentFiles", file.FileName);
                    }
                }

                var response = await _httpClient.PostAsync("/api/expenses", formData);

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Expense created successfully.");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return (false, $"Failed to create expense: {error}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateExpenseAsync Error: {ex.Message}");
                return (false, "An error occurred while connecting to the server.");
            }
        }

        public async Task<IEnumerable<InterventionDto>> GetMyTasksAsync()
        {
            try
            {
                var url = "/api/interventions/my-tasks";
                System.Diagnostics.Debug.WriteLine($"[ApiClient] ==> Calling GET {url}");

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var tasks = await response.Content.ReadFromJsonAsync<IEnumerable<InterventionDto>>();
                    System.Diagnostics.Debug.WriteLine($"[ApiClient] <== SUCCESS: Received {tasks?.Count() ?? 0} tasks.");
                    return tasks;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"[ApiClient] <== FAILED with status {(int)response.StatusCode}.");
                    System.Diagnostics.Debug.WriteLine($"[ApiClient] <== Error Body: {errorContent}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ApiClient] <== CRITICAL FAILURE: Exception during API call.");
                System.Diagnostics.Debug.WriteLine($"[ApiClient] <== Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<InterventionDto> GetInterventionDetailsAsync(int interventionId)
        {
            try
            {
                var url = $"/api/interventions/{interventionId}";
                System.Diagnostics.Debug.WriteLine($"[ApiClient] ==> Calling GET {url}");
                var response = await _httpClient.GetFromJsonAsync<InterventionDto>(url);
                System.Diagnostics.Debug.WriteLine($"[ApiClient] <== SUCCESS: Received intervention details for ID {interventionId}.");
                return response;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ApiClient] <== FAILED to get intervention details for ID {interventionId}. Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<OccurrenceDto> GetOccurrenceDetailsAsync(int occurrenceId)
        {
            try
            {
                var url = $"/api/occurrences/{occurrenceId}";
                System.Diagnostics.Debug.WriteLine($"[ApiClient] ==> Calling GET {url}");
                var response = await _httpClient.GetFromJsonAsync<OccurrenceDto>(url);
                System.Diagnostics.Debug.WriteLine($"[ApiClient] <== SUCCESS: Received occurrence details for ID {occurrenceId}.");
                return response;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ApiClient] <== FAILED to get occurrence details for ID {occurrenceId}. Exception: {ex.Message}");
                return null;
            }

          
        }
     
    }
}