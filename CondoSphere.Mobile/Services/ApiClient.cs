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

        // --- METHODS FOR PHASE 2 ---

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
    }
}