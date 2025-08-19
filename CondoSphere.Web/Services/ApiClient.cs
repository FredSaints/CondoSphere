using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Web.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Globalization;
using System.Text.Json;

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

        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums");
        }

        public async Task<IEnumerable<UserListDto>> GetUsersAsync()
        {
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
            var responseContent = await response.Content.ReadFromJsonAsync<object>();

            if (response.IsSuccessStatusCode)
            {
                var message = responseContent?.GetType().GetProperty("message")?.GetValue(responseContent)?.ToString();
                return (true, message ?? "Password set successfully.");
            }

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

        public async Task<(bool Success, string Message)> RegisterCompanyAdminAsync(RegisterDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-admin", dto);

            var responseContent = await response.Content.ReadFromJsonAsync<object>();

            if (response.IsSuccessStatusCode)
            {
                var message = responseContent?.GetType().GetProperty("message")?.GetValue(responseContent)?.ToString();
                return (true, message ?? "Registration successful! Please check your email to confirm your account.");
            }
            else
            {
                return (false, "Registration failed. The email address may already be in use.");
            }
        }

        public async Task<(bool Success, string Message)> ConfirmEmailAsync(string userId, string token)
        {
            var path = "/api/accounts/confirm-email";

            var queryParams = new Dictionary<string, string>
            {
                { "userId", userId },
                { "token", token }
            };

            var uri = QueryHelpers.AddQueryString(path, queryParams);

            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return (true, "Your email has been successfully confirmed! You can now log in.");
            }
            else
            {
                return (false, "Email could not be confirmed. The link may be invalid or have expired.");
            }
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableResidentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/available-residents");
        }

        public async Task<bool> AssignResidentAsync(int condominiumId, int unitId, AssignResidentDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/condominiums/{condominiumId}/units/{unitId}/assign-resident", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var response = await _httpClient.PostAsync($"/api/accounts/users/{userId}/deactivate", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ActivateUserAsync(int userId)
        {
            var response = await _httpClient.PostAsync($"/api/accounts/users/{userId}/activate", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>($"/api/condominiums/{condominiumId}/occurrences");
        }

        public async Task<IEnumerable<OccurrenceDto>> GetMyOccurrencesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>("/api/occurrences/my-occurrences") ?? new List<OccurrenceDto>();
        }

        public async Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, IFormFile? imageFile)
        {
            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(dto.Title), name: nameof(CreateOccurrenceDto.Title));
            formData.Add(new StringContent(dto.Description), name: nameof(CreateOccurrenceDto.Description));
            formData.Add(new StringContent(dto.UnitId.ToString()), name: nameof(CreateOccurrenceDto.UnitId));

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileContent = new StreamContent(imageFile.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);
                formData.Add(fileContent, name: "imageFile", fileName: imageFile.FileName);
            }

            var response = await _httpClient.PostAsync("/api/occurrences", formData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OccurrenceDto>();
            }
            return null;
        }

        public async Task<OccurrenceDto?> GetOccurrenceDetailsAsync(int occurrenceId)
        {
            return await _httpClient.GetFromJsonAsync<OccurrenceDto>($"/api/occurrences/{occurrenceId}");
        }

        public async Task<(bool Success, string Message)> ForgotPasswordAsync(string email)
        {
            var requestDto = new ForgotPasswordDto { Email = email };
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/forgot-password", requestDto);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        public async Task<(bool Success, string Message, string? NewToken)> UpdateProfileAsync(UpdateProfileDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/profile", dto);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return (false, responseBody, null);
            }

            try
            {
                using var jsonDoc = JsonDocument.Parse(responseBody);
                jsonDoc.RootElement.TryGetProperty("token", out var tokenElement);
                return (true, "Profile updated successfully.", tokenElement.GetString());
            }
            catch { return (true, "Profile updated successfully.", null); }
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/profile/change-password", model);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        public async Task<UserProfileDto?> GetMyProfileAsync()
        {
            return await _httpClient.GetFromJsonAsync<UserProfileDto>("/api/profile");
        }

        public async Task<(bool Success, string Message)> UpdateOccurrenceStatusAsync(int occurrenceId, UpdateOccurrenceStatusDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/occurrences/{occurrenceId}/status", dto);
            var message = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(message) && message.StartsWith("\"") && message.EndsWith("\""))
            {
                message = message.Trim('"');
            }

            return (response.IsSuccessStatusCode, string.IsNullOrWhiteSpace(message)
                ? (response.IsSuccessStatusCode ? "Occurrence status has been updated." : "Failed to update status.")
                : message);
        }

        public async Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId)
        {
            var response = await _httpClient.GetAsync($"/api/occurrences/{occurrenceId}/interventions");
            if (!response.IsSuccessStatusCode)
            {
                return new List<InterventionDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<InterventionDto>>() ?? new List<InterventionDto>();
        }

        public async Task<InterventionDto?> CreateInterventionAsync(CreateInterventionDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/interventions", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InterventionDto>();
            }
            return null;
        }

        public async Task<bool> RegisterEmployeeAsync(RegisterManagerDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-employee", registerDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/employees") ?? new List<UserListDto>();
        }

        public async Task<IEnumerable<InterventionDto>> GetMyInterventionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<InterventionDto>>("/api/interventions/my-tasks") ?? new List<InterventionDto>();
        }

        public async Task<(bool Confirmed, string RawMessage)> IsEmailConfirmedAsync(string email)
        {
            var payload = new { Email = email };
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/IsEmailConfirmed", payload);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return (false, body);

            try
            {
                using var json = JsonDocument.Parse(body);
                bool confirmed = json.RootElement.GetProperty("confirmed").GetBoolean();
                return (confirmed, body);
            }
            catch
            {
                return (false, body);
            }
        }

        public async Task<(bool Success, string RawMessage)> ResendConfirmationEmailAsync(string email)
        {
            var payload = new { Email = email };
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/ResendConfirmationEmail", payload);
            var body = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, body);
        }


        public async Task<bool> UpdateInterventionStatusAsync(int interventionId, UpdateInterventionStatusDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/interventions/{interventionId}/status", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<InterventionDto?> GetInterventionDetailsAsync(int interventionId)
        {
            var response = await _httpClient.GetAsync($"/api/interventions/{interventionId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InterventionDto>();
            }
            return null;
        }

        public async Task<IEnumerable<ExpenseDto>> GetExpensesForOccurrenceAsync(int occurrenceId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExpenseDto>>($"/api/occurrences/{occurrenceId}/expenses") ?? new List<ExpenseDto>();
        }

        public async Task<(ExpenseDto? Expense, string? Error)> CreateExpenseAsync(CreateExpenseDto dto, List<IFormFile> attachmentFiles)
        {
            Console.WriteLine($"[WEB.ApiClient] Start CreateExpenseAsync. Files={(attachmentFiles == null ? "null" : attachmentFiles.Count.ToString())}");
               if (attachmentFiles != null)
                       foreach (var f in attachmentFiles)
                Console.WriteLine($"[WEB.ApiClient] File part => FileName='{f.FileName}', Length={f.Length}, ContentType='{f.ContentType}'");
            using var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(dto.Title), nameof(dto.Title));
            formData.Add(new StringContent(dto.Description ?? string.Empty), nameof(dto.Description));
            formData.Add(new StringContent(dto.Amount.ToString(CultureInfo.InvariantCulture)), nameof(dto.Amount));
            formData.Add(new StringContent(dto.ExpenseDate.ToString("o")), nameof(dto.ExpenseDate));
            formData.Add(new StringContent(dto.CondominiumId.ToString()), nameof(dto.CondominiumId));

            if (dto.OccurrenceId.HasValue)
            {
                formData.Add(new StringContent(dto.OccurrenceId.Value.ToString()), nameof(dto.OccurrenceId));
            }

            if (attachmentFiles != null)
            {
                foreach (var file in attachmentFiles)
                {
                    if (file.Length > 0)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        formData.Add(fileContent, "attachmentFiles", file.FileName);
                    }
                }
            }
            Console.WriteLine("[WEB.ApiClient] POST /api/expenses ...");
            var response = await _httpClient.PostAsync("/api/expenses", formData);
            Console.WriteLine($"[WEB.ApiClient] Response {(int)response.StatusCode} {response.ReasonPhrase}");

            if (response.IsSuccessStatusCode)
            {
                var expense = await response.Content.ReadFromJsonAsync<ExpenseDto>();
                return (expense, null);
            }

            var errorBody = await response.Content.ReadAsStringAsync();
            var errorText = string.IsNullOrWhiteSpace(errorBody) ? response.ReasonPhrase : errorBody;
            return (null, errorText);
        }

        public async Task<IEnumerable<UserListDto>> GetResidentsForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>($"/api/condominiums/{condominiumId}/residents")
                   ?? new List<UserListDto>();
        }

        public async Task<bool> UnassignResidentFromUnitAsync(int residentId, int unitId)
        {
            var response = await _httpClient.PostAsync($"/api/residents/{residentId}/unassign-from/{unitId}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<UnitDto?> GetUnitByIdAsync(int unitId)
        {
            var response = await _httpClient.GetAsync($"/api/units/{unitId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UnitDto>();
            }
            return null;
        }

        public async Task<IEnumerable<UnitDto>> GetMyUnitsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>("/api/users/my-units") ?? new List<UnitDto>();
        }

        public async Task<ExpenseDto?> GetExpenseDetailsAsync(int expenseId)
        {
            var response = await _httpClient.GetAsync($"/api/expenses/{expenseId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ExpenseDto>();
            }
            return null;
        }

        public async Task<IEnumerable<ExpenseDto>> GetFixedExpensesAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExpenseDto>>($"/api/condominiums/{condominiumId}/fixed-expenses")
                   ?? new List<ExpenseDto>();
        }

        public async Task<ExpenseDto?> CreateFixedExpenseAsync(int condominiumId, CreateUpdateFixedExpenseDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/fixed-expenses", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ExpenseDto>();
            }
            return null;
        }

        public async Task<ExpenseDto?> UpdateFixedExpenseAsync(int expenseId, int condominiumId, CreateUpdateFixedExpenseDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ExpenseDto>();
            }
            return null;
        }

        public async Task<bool> ToggleFixedExpenseStatusAsync(int expenseId, int condominiumId)
        {
            var response = await _httpClient.PatchAsync($"/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}/toggle-status", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteFixedExpenseAsync(int expenseId, int condominiumId)
        {
            var response = await _httpClient.DeleteAsync($"/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<UnitQuotaDto>> GetMyQuotasAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UnitQuotaDto>>("/api/users/my-quotas")
                   ?? new List<UnitQuotaDto>();
        }

        public async Task<(bool Success, string Message)> GenerateMonthlyQuotasAsync(int condominiumId, int year, int month)
        {
            var payload = new { year, month };
            var response = await _httpClient.PostAsJsonAsync($"/api/financials/condominiums/{condominiumId}/generate-quotas", payload);
            var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
            var message = responseBody.GetProperty("message").GetString() ?? "An unknown error occurred.";

            return (response.IsSuccessStatusCode, message);
        }

        public async Task<QuotaBreakdownDto?> GetQuotaBreakdownAsync(int quotaId)
        {
            var response = await _httpClient.GetAsync($"/api/financials/quotas/{quotaId}/breakdown");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QuotaBreakdownDto>();
            }
            return null;
        }

        public async Task<UnitQuotaDto?> SubmitPaymentProofAsync(int quotaId, IFormFile proofFile)
        {
            using var formData = new MultipartFormDataContent();

            var fileContent = new StreamContent(proofFile.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(proofFile.ContentType);

            formData.Add(fileContent, name: "proofFile", fileName: proofFile.FileName);

            var response = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/submit-payment-proof", formData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UnitQuotaDto>();
            }
            return null;
        }

        public async Task<(bool Success, string Message)> ConfirmPaymentAsync(int quotaId)
        {
            var response = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/confirm-payment", null);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
                var message = responseBody.GetProperty("message").GetString() ?? "Payment confirmed.";
                return (true, message);
            }

            var errorBody = await response.Content.ReadFromJsonAsync<JsonElement>();
            var errorMessage = errorBody.GetProperty("message").GetString() ?? "Failed to confirm payment.";
            return (false, errorMessage);
        }

        public async Task<IEnumerable<UnitQuotaDto>> GetQuotasForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UnitQuotaDto>>($"/api/financials/condominiums/{condominiumId}/quotas")
                ?? new List<UnitQuotaDto>();
        }

        public async Task<string?> CreateStripeCheckoutSessionAsync(int quotaId)
        {
            var response = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/create-checkout-session", null);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadFromJsonAsync<JsonElement>();
                return body.GetProperty("sessionId").GetString();
            }
            return null;
        }

        public async Task<bool> MarkQuotaAsPaidAsync(int quotaId)
        {
            var response = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/mark-as-paid", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<ReceiptDto?> GetReceiptDetailsForResidentAsync(int receiptId)
        {
            var response = await _httpClient.GetAsync($"/api/financials/receipts/{receiptId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReceiptDto>();
            }
            return null;
        }

        public async Task<ReceiptDto?> GetReceiptDetailsForManagerAsync(int receiptId)
        {
            var response = await _httpClient.GetAsync($"/api/financials/manager/receipts/{receiptId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReceiptDto>();
            }
            return null;
        }

        public async Task<CompanyProfileDto?> GetCompanyProfileAsync()
        {
            return await _httpClient.GetFromJsonAsync<CompanyProfileDto>("/api/company/my-profile");
        }

        public async Task<bool> UpdateCompanyProfileAsync(CompanyProfileDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/company/my-profile", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<DocumentDto?> UploadDocumentAsync(int condominiumId, CreateDocumentDto dto, IFormFile file)
        {
            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(dto.Title), nameof(dto.Title));
            formData.Add(new StringContent(dto.Description ?? string.Empty), nameof(dto.Description));
            formData.Add(new StringContent(dto.Category), nameof(dto.Category));

            var fileContent = new StreamContent(file.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            formData.Add(fileContent, name: "file", fileName: file.FileName);

            var response = await _httpClient.PostAsync($"/api/condominiums/{condominiumId}/documents", formData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DocumentDto>();
            }
            return null;
        }

        public async Task<IEnumerable<DocumentDto>> GetDocumentsForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DocumentDto>>($"/api/condominiums/{condominiumId}/documents")
                ?? new List<DocumentDto>();
        }

        public async Task<bool> DeleteDocumentAsync(int documentId)
        {
            var response = await _httpClient.DeleteAsync($"/api/documents/{documentId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> DownloadDocumentAsync(int documentId)
        {
            return await _httpClient.GetAsync($"/api/documents/{documentId}/download");
        }

        public async Task<IEnumerable<DocumentDto>> GetMyDocumentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DocumentDto>>("/api/users/my-documents")
                ?? new List<DocumentDto>();
        }
        // --- Two-Factor (2SV) ---
        public async Task<(bool Success, string Message)> SwitchTwoFactorAsync(ToggleTwoFactorDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/switch", dto);
            var raw = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    using var json = JsonDocument.Parse(raw);
                    var msg = json.RootElement.TryGetProperty("message", out var m) ? m.GetString() : "Two-factor switched.";
                    return (true, msg ?? "Two-factor switched.");
                }
                catch
                {
                    return (true, "Two-factor switched.");
                }
            }

            try
            {
                using var json = JsonDocument.Parse(raw);
                var msg = json.RootElement.TryGetProperty("message", out var m) ? m.GetString() : raw;
                return (false, msg ?? raw);
            }
            catch
            {
                return (false, raw);
            }
        }

        public async Task<(bool Success, string Message)> SendTwoFactorCodeAsync(SendTwoFactorCodeDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/send-code", dto);
            var raw = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    using var json = JsonDocument.Parse(raw);
                    var msg = json.RootElement.TryGetProperty("message", out var m) ? m.GetString() : "Two-factor code sent.";
                    return (true, msg ?? "Two-factor code sent.");
                }
                catch
                {
                    return (true, "Two-factor code sent.");
                }
            }

            try
            {
                using var json = JsonDocument.Parse(raw);
                var msg = json.RootElement.TryGetProperty("message", out var m) ? m.GetString() : raw;
                return (false, msg ?? raw);
            }
            catch
            {
                return (false, raw);
            }
        }

        public async Task<(bool Success, string Message)> VerifyTwoFactorCodeAsync(VerifyTwoFactorCodeDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/verify", dto);
            var raw = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // O teu endpoint devolve 200 OK sem body
                return (true, "Two-factor code verified.");
            }

            try
            {
                using var json = JsonDocument.Parse(raw);
                var msg = json.RootElement.TryGetProperty("message", out var m) ? m.GetString() : raw;
                return (false, msg ?? raw);
            }
            catch
            {
                return (false, raw);
            }
        }

        public async Task<bool> IsTwoFactorEnabledAsync(EmailDto dto)
        {
            // 1) envia um objeto JSON com a propriedade Email (não envies só a string)
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/IsEnable", dto);

            if (!response.IsSuccessStatusCode)
                return false;

            // 2) lê o corpo como string e tenta várias formas de interpretar
            var raw = await response.Content.ReadAsStringAsync();

            try
            {
                // a) se for um booleano puro: true/false (JSON)
                //    também cobre o caso de vir "true"/"false" como string
                if (bool.TryParse(raw.Trim().Trim('"'), out var directBool))
                    return directBool;

                // b) se for um objeto: { "enabled": true }, { "isEnabled": true }, { "twoFactorEnabled": true }
                using var doc = JsonDocument.Parse(raw);
                var root = doc.RootElement;
                if (root.ValueKind == JsonValueKind.Object)
                {
                    if (root.TryGetProperty("enabled", out var e) && e.ValueKind == JsonValueKind.True || e.ValueKind == JsonValueKind.False)
                        return e.GetBoolean();

                    if (root.TryGetProperty("isEnabled", out var ie) && (ie.ValueKind == JsonValueKind.True || ie.ValueKind == JsonValueKind.False))
                        return ie.GetBoolean();

                    if (root.TryGetProperty("twoFactorEnabled", out var tfe) && (tfe.ValueKind == JsonValueKind.True || tfe.ValueKind == JsonValueKind.False))
                        return tfe.GetBoolean();
                }
            }
            catch
            {
                // ignora parsing errors e cai para false
            }
            //TODO rever isto 
            return false;
        }

    }
}
