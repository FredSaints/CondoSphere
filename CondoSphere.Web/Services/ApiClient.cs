using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Messages;
using CondoSphere.Core.DTOs.Notifications;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.DTOs.Reports;
using CondoSphere.Core.DTOs.Assemblies;
using CondoSphere.Web.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;

namespace CondoSphere.Web.Services
{
    /// <summary>
    /// Api Client.
    /// </summary>
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient) => _httpClient = httpClient;

        // ---------- Accounts / Auth ----------
        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/login", loginDto);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<UserDto>();
            return null;
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

        public async Task<bool> RegisterManagerAsync(RegisterManagerDto registerDto)
            => (await _httpClient.PostAsJsonAsync("/api/accounts/register-manager", registerDto)).IsSuccessStatusCode;

        public async Task<(bool Success, string Message)> RegisterCompanyAdminAsync(RegisterDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-admin", dto);
            var responseContent = await response.Content.ReadFromJsonAsync<object>();
            if (response.IsSuccessStatusCode)
            {
                var message = responseContent?.GetType().GetProperty("message")?.GetValue(responseContent)?.ToString();
                return (true, message ?? "Registration successful! Please check your email to confirm your account.");
            }
            return (false, "Registration failed. The email address may already be in use.");
        }

        public async Task<(bool Success, string Message)> ConfirmEmailAsync(string userId, string token)
        {
            var uri = QueryHelpers.AddQueryString("/api/accounts/confirm-email", new Dictionary<string, string>
            {
                { "userId", userId }, { "token", token }
            });
            var response = await _httpClient.GetAsync(uri);
            return response.IsSuccessStatusCode
                ? (true, "Your email has been successfully confirmed! You can now log in.")
                : (false, "Email could not be confirmed. The link may be invalid or have expired.");
        }

        public async Task<(bool Confirmed, string RawMessage)> IsEmailConfirmedAsync(string email)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/IsEmailConfirmed", new { Email = email });
            var body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return (false, body);
            try
            {
                using var json = JsonDocument.Parse(body);
                return (json.RootElement.GetProperty("confirmed").GetBoolean(), body);
            }
            catch { return (false, body); }
        }

        public async Task<(bool Success, string RawMessage)> ResendConfirmationEmailAsync(string email)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/ResendConfirmationEmail", new { Email = email });
            var body = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, body);
        }

        // ---------- 2FA ----------
        public async Task<(bool Success, string Message)> SwitchTwoFactorAsync(ToggleTwoFactorDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/switch", dto);
            var raw = await resp.Content.ReadAsStringAsync();
            if (resp.IsSuccessStatusCode)
            {
                try
                {
                    using var json = JsonDocument.Parse(raw);
                    return (true, json.RootElement.TryGetProperty("message", out var m) ? m.GetString() ?? "Two-factor switched." : "Two-factor switched.");
                }
                catch { return (true, "Two-factor switched."); }
            }
            try
            {
                using var json = JsonDocument.Parse(raw);
                return (false, json.RootElement.TryGetProperty("message", out var m) ? m.GetString() ?? raw : raw);
            }
            catch { return (false, raw); }
        }

        public async Task<(bool Success, string Message)> SendTwoFactorCodeAsync(SendTwoFactorCodeDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/send-code", dto);
            var raw = await resp.Content.ReadAsStringAsync();
            if (resp.IsSuccessStatusCode)
            {
                try
                {
                    using var json = JsonDocument.Parse(raw);
                    return (true, json.RootElement.TryGetProperty("message", out var m) ? m.GetString() ?? "Two-factor code sent." : "Two-factor code sent.");
                }
                catch { return (true, "Two-factor code sent."); }
            }
            try
            {
                using var json = JsonDocument.Parse(raw);
                return (false, json.RootElement.TryGetProperty("message", out var m) ? m.GetString() ?? raw : raw);
            }
            catch { return (false, raw); }
        }

        public async Task<(bool Success, string Message, string? Token)> VerifyTwoFactorCodeAsync(VerifyTwoFactorCodeDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/verify", dto);
            var raw = await resp.Content.ReadAsStringAsync();

            if (resp.IsSuccessStatusCode)
            {
                string? message = "Two-factor code verified.";
                string? token = null;

                try
                {
                    using var json = JsonDocument.Parse(raw);
                    var root = json.RootElement;
                    if (root.TryGetProperty("message", out var msgProp))
                    {
                        message = msgProp.GetString() ?? message;
                    }
                    if (root.TryGetProperty("token", out var tokenProp))
                    {
                        token = tokenProp.GetString();
                    }
                }
                catch
                {
                    // ignore malformed success payloads
                }

                return (true, message ?? "Two-factor code verified.", token);
            }

            return (false, TryExtractMessage(raw), null);
        }

        public async Task<bool> IsTwoFactorEnabledAsync(EmailDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/2fa/IsEnable", dto);
            if (!response.IsSuccessStatusCode) return false;
            var raw = await response.Content.ReadAsStringAsync();
            if (bool.TryParse(raw.Trim().Trim('"'), out var b)) return b;
            try
            {
                using var doc = JsonDocument.Parse(raw);
                var root = doc.RootElement;
                if (root.TryGetProperty("enabled", out var e) && e.ValueKind is JsonValueKind.True or JsonValueKind.False) return e.GetBoolean();
                if (root.TryGetProperty("isEnabled", out var ie) && ie.ValueKind is JsonValueKind.True or JsonValueKind.False) return ie.GetBoolean();
                if (root.TryGetProperty("twoFactorEnabled", out var tfe) && tfe.ValueKind is JsonValueKind.True or JsonValueKind.False) return tfe.GetBoolean();
            }
            catch { }
            return false;
        }

        // ---------- Me ----------
        public async Task<int> GetMyCondominiumIdAsync()
        {
            var resp = await _httpClient.GetAsync("/api/me/condominium-id");
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                return 0;

            if (!resp.IsSuccessStatusCode)
                return 0; // ou lançar uma exceção com mensagem mais amigável

            var dto = await resp.Content.ReadFromJsonAsync<IdDto>();
            return dto?.Id ?? 0;
        }

        // ---------- Condominiums / Users / Units ----------
        public Task<IEnumerable<CondominiumDto>> GetCondominiumsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums");

        public Task<IEnumerable<UserListDto>> GetUsersAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/company-users");

        public Task<IEnumerable<CondominiumDto>> GetMyManagedCondominiumsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums/my-managed");

        public Task<CondominiumDto> GetCondominiumDetailsAsync(int id)
            => _httpClient.GetFromJsonAsync<CondominiumDto>($"/api/condominiums/{id}");

        public Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
            => _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>($"/api/condominiums/{condominiumId}/units");

        public async Task<bool> RegisterResidentAsync(int condominiumId, RegisterResidentDto dto)
            => (await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/residents", dto)).IsSuccessStatusCode;

        public Task<IEnumerable<UserListDto>> GetAvailableResidentsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/available-residents")!;

        public async Task<bool> AssignResidentAsync(int condominiumId, int unitId, AssignResidentDto dto)
            => (await _httpClient.PatchAsJsonAsync($"/api/condominiums/{condominiumId}/units/{unitId}/assign-resident", dto)).IsSuccessStatusCode;

        public Task<IEnumerable<UserListDto>> GetAvailableManagersAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/managers")!;

        public async Task<bool> AssignManagerAsync(int condominiumId, AssignManagerDto dto)
            => (await _httpClient.PatchAsJsonAsync($"/api/condominiums/{condominiumId}/assign-manager", dto)).IsSuccessStatusCode;

        public async Task<bool> UnassignManagerAsync(int condominiumId)
            => (await _httpClient.PatchAsync($"/api/condominiums/{condominiumId}/unassign-manager", null)).IsSuccessStatusCode;

        public async Task<bool> CreateCondominiumAsync(CreateUpdateCondominiumDto dto)
            => (await _httpClient.PostAsJsonAsync("/api/condominiums", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto dto)
            => (await _httpClient.PutAsJsonAsync($"/api/condominiums/{id}", dto)).IsSuccessStatusCode;

        public async Task<(bool Success, string Message)> DeleteCondominiumAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/condominiums/{id}");
            if (response.IsSuccessStatusCode) return (true, "Condominium deleted successfully.");
            var error = await response.Content.ReadFromJsonAsync<JsonElement>();
            return (false, error.GetProperty("message").GetString() ?? "An unknown error occurred.");
        }

        public async Task<bool> RegisterEmployeeAsync(RegisterManagerDto registerDto)
            => (await _httpClient.PostAsJsonAsync("/api/accounts/register-employee", registerDto)).IsSuccessStatusCode;

        public Task<IEnumerable<UserListDto>> GetAvailableEmployeesAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/employees")!;

        public Task<IEnumerable<UnitDto>> GetMyUnitsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>("/api/users/my-units")!;

        public async Task<bool> DeactivateUserAsync(int userId)
            => (await _httpClient.PostAsync($"/api/accounts/users/{userId}/deactivate", null)).IsSuccessStatusCode;

        public async Task<bool> ActivateUserAsync(int userId)
            => (await _httpClient.PostAsync($"/api/accounts/users/{userId}/activate", null)).IsSuccessStatusCode;

        public async Task<UnitDto?> GetUnitByIdAsync(int unitId)
        {
            var resp = await _httpClient.GetAsync($"/api/units/{unitId}");
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<UnitDto>() : null;
        }

        public async Task<bool> CreateUnitAsync(int condominiumId, CreateUpdateUnitDto dto)
            => (await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/units", dto)).IsSuccessStatusCode;

        // ---------- Occurrences / Interventions / Expenses ----------
        public Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId)
            => _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>($"/api/condominiums/{condominiumId}/occurrences")!;

        public Task<IEnumerable<OccurrenceDto>> GetMyOccurrencesAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>("/api/occurrences/my-occurrences")!;

        public async Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, IFormFile? imageFile)
        {
            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(dto.Title), nameof(CreateOccurrenceDto.Title));
            formData.Add(new StringContent(dto.Description), nameof(CreateOccurrenceDto.Description));
            formData.Add(new StringContent(dto.UnitId.ToString()), nameof(CreateOccurrenceDto.UnitId));
            if (imageFile is { Length: > 0 })
            {
                var fileContent = new StreamContent(imageFile.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);
                formData.Add(fileContent, "imageFile", imageFile.FileName);
            }
            var resp = await _httpClient.PostAsync("/api/occurrences", formData);
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<OccurrenceDto>() : null;
        }

        public Task<OccurrenceDto?> GetOccurrenceDetailsAsync(int occurrenceId)
            => _httpClient.GetFromJsonAsync<OccurrenceDto>($"/api/occurrences/{occurrenceId}");

        public async Task<(bool Success, string Message)> UpdateOccurrenceStatusAsync(int occurrenceId, UpdateOccurrenceStatusDto dto)
        {
            var resp = await _httpClient.PatchAsJsonAsync($"/api/occurrences/{occurrenceId}/status", dto);
            var message = (await resp.Content.ReadAsStringAsync()).Trim('"');
            return (resp.IsSuccessStatusCode, string.IsNullOrWhiteSpace(message)
                ? (resp.IsSuccessStatusCode ? "Occurrence status has been updated." : "Failed to update status.")
                : message);
        }

        public async Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId)
        {
            var resp = await _httpClient.GetAsync($"/api/occurrences/{occurrenceId}/interventions");
            return resp.IsSuccessStatusCode
                ? await resp.Content.ReadFromJsonAsync<IEnumerable<InterventionDto>>() ?? new List<InterventionDto>()
                : new List<InterventionDto>();
        }

        public async Task<InterventionDto?> CreateInterventionAsync(CreateInterventionDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync("/api/interventions", dto);
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<InterventionDto>() : null;
        }

        public Task<IEnumerable<InterventionDto>> GetMyInterventionsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<InterventionDto>>("/api/interventions/my-tasks")!;

        public async Task<bool> UpdateInterventionStatusAsync(int interventionId, UpdateInterventionStatusDto dto)
            => (await _httpClient.PatchAsJsonAsync($"/api/interventions/{interventionId}/status", dto)).IsSuccessStatusCode;

        public async Task<InterventionDto?> GetInterventionDetailsAsync(int interventionId)
        {
            var resp = await _httpClient.GetAsync($"/api/interventions/{interventionId}");
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<InterventionDto>() : null;
        }

        public Task<IEnumerable<ExpenseDto>> GetExpensesForOccurrenceAsync(int occurrenceId)
            => _httpClient.GetFromJsonAsync<IEnumerable<ExpenseDto>>($"/api/occurrences/{occurrenceId}/expenses")!;

        public async Task<(ExpenseDto? Expense, string? Error)> CreateExpenseAsync(CreateExpenseDto dto, List<IFormFile> attachmentFiles)
        {
            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(dto.Title), nameof(dto.Title));
            formData.Add(new StringContent(dto.Description ?? string.Empty), nameof(dto.Description));
            formData.Add(new StringContent(dto.Amount.ToString(CultureInfo.InvariantCulture)), nameof(dto.Amount));
            formData.Add(new StringContent(dto.ExpenseDate.ToString("o")), nameof(dto.ExpenseDate));
            formData.Add(new StringContent(dto.CondominiumId.ToString()), nameof(dto.CondominiumId));
            if (dto.OccurrenceId.HasValue)
                formData.Add(new StringContent(dto.OccurrenceId.Value.ToString()), nameof(dto.OccurrenceId));
            if (attachmentFiles != null)
                foreach (var file in attachmentFiles)
                    if (file.Length > 0)
                    {
                        var fc = new StreamContent(file.OpenReadStream());
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        formData.Add(fc, "attachmentFiles", file.FileName);
                    }

            var resp = await _httpClient.PostAsync("/api/expenses", formData);
            if (resp.IsSuccessStatusCode)
                return (await resp.Content.ReadFromJsonAsync<ExpenseDto>(), null);
            var err = await resp.Content.ReadAsStringAsync();
            return (null, string.IsNullOrWhiteSpace(err) ? resp.ReasonPhrase : err);
        }

        // ---------- Financials ----------
        public Task<IEnumerable<UnitQuotaDto>> GetMyQuotasAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<UnitQuotaDto>>("/api/users/my-quotas")!;

        public async Task<(bool Success, string Message)> GenerateMonthlyQuotasAsync(int condominiumId, int year, int month)
        {
            var resp = await _httpClient.PostAsJsonAsync($"/api/financials/condominiums/{condominiumId}/generate-quotas", new { year, month });
            var body = await resp.Content.ReadFromJsonAsync<JsonElement>();
            return (resp.IsSuccessStatusCode, body.GetProperty("message").GetString() ?? "An unknown error occurred.");
        }

        public Task<QuotaBreakdownDto?> GetQuotaBreakdownAsync(int quotaId)
            => _httpClient.GetFromJsonAsync<QuotaBreakdownDto>($"/api/financials/quotas/{quotaId}/breakdown");

        public async Task<UnitQuotaDto?> SubmitPaymentProofAsync(int quotaId, IFormFile proofFile)
        {
            using var formData = new MultipartFormDataContent();
            var fileContent = new StreamContent(proofFile.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(proofFile.ContentType);
            formData.Add(fileContent, "proofFile", proofFile.FileName);
            var resp = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/submit-payment-proof", formData);
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<UnitQuotaDto>() : null;
        }

        public async Task<(bool Success, string Message)> ConfirmPaymentAsync(int quotaId)
        {
            var resp = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/confirm-payment", null);
            if (resp.IsSuccessStatusCode)
            {
                var ok = await resp.Content.ReadFromJsonAsync<JsonElement>();
                return (true, ok.GetProperty("message").GetString() ?? "Payment confirmed.");
            }
            var err = await resp.Content.ReadFromJsonAsync<JsonElement>();
            return (false, err.GetProperty("message").GetString() ?? "Failed to confirm payment.");
        }

        public Task<IEnumerable<UnitQuotaDto>> GetQuotasForCondominiumAsync(int condominiumId)
            => _httpClient.GetFromJsonAsync<IEnumerable<UnitQuotaDto>>($"/api/financials/condominiums/{condominiumId}/quotas")!;

        public async Task<string?> CreateStripeCheckoutSessionAsync(int quotaId)
        {
            var resp = await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/create-checkout-session", null);
            if (!resp.IsSuccessStatusCode) return null;
            var body = await resp.Content.ReadFromJsonAsync<JsonElement>();
            return body.GetProperty("sessionId").GetString();
        }

        public async Task<bool> MarkQuotaAsPaidAsync(int quotaId)
            => (await _httpClient.PostAsync($"/api/financials/quotas/{quotaId}/mark-as-paid", null)).IsSuccessStatusCode;

        public Task<ReceiptDto?> GetReceiptDetailsForResidentAsync(int receiptId)
            => _httpClient.GetFromJsonAsync<ReceiptDto>($"/api/financials/receipts/{receiptId}");

        public Task<ReceiptDto?> GetReceiptDetailsForManagerAsync(int receiptId)
            => _httpClient.GetFromJsonAsync<ReceiptDto>($"/api/financials/manager/receipts/{receiptId}");

        // ---------- Documents ----------
        public async Task<DocumentDto?> UploadDocumentAsync(int condominiumId, CreateDocumentDto dto, IFormFile file)
        {
            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(dto.Title), nameof(dto.Title));
            formData.Add(new StringContent(dto.Description ?? string.Empty), nameof(dto.Description));
            formData.Add(new StringContent(dto.Category), nameof(dto.Category));

            var fileContent = new StreamContent(file.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            formData.Add(fileContent, "file", file.FileName);

            var resp = await _httpClient.PostAsync($"/api/condominiums/{condominiumId}/documents", formData);
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<DocumentDto>() : null;
        }

        public Task<IEnumerable<DocumentDto>> GetDocumentsForCondominiumAsync(int condominiumId)
            => _httpClient.GetFromJsonAsync<IEnumerable<DocumentDto>>($"/api/condominiums/{condominiumId}/documents")!;

        public async Task<bool> DeleteDocumentAsync(int documentId)
            => (await _httpClient.DeleteAsync($"/api/documents/{documentId}")).IsSuccessStatusCode;

        public Task<HttpResponseMessage> DownloadDocumentAsync(int documentId)
            => _httpClient.GetAsync($"/api/documents/{documentId}/download");

        public Task<IEnumerable<DocumentDto>> GetMyDocumentsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<DocumentDto>>("/api/users/my-documents")!;

        // ---------- Messages ----------
        public async Task<IEnumerable<MessageListDto>> GetInboxAsync(int pageNumber = 1, int pageSize = 20)
        {
            var resp = await _httpClient.GetAsync($"/api/messages/inbox?pageNumber={pageNumber}&pageSize={pageSize}");
            return resp.IsSuccessStatusCode
                ? await resp.Content.ReadFromJsonAsync<IEnumerable<MessageListDto>>() ?? new List<MessageListDto>()
                : new List<MessageListDto>();
        }

        public async Task<IEnumerable<MessageListDto>> GetSentMessagesAsync(int pageNumber = 1, int pageSize = 20)
        {
            var resp = await _httpClient.GetAsync($"/api/messages/sent?pageNumber={pageNumber}&pageSize={pageSize}");
            return resp.IsSuccessStatusCode
                ? await resp.Content.ReadFromJsonAsync<IEnumerable<MessageListDto>>() ?? new List<MessageListDto>()
                : new List<MessageListDto>();
        }

        public async Task<MessageDto?> GetMessageAsync(int messageId)
        {
            var resp = await _httpClient.GetAsync($"/api/messages/{messageId}");
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<MessageDto>() : null;
        }

        public async Task<bool> SendMessageAsync(SendMessageDto dto)
            => (await _httpClient.PostAsJsonAsync("/api/messages", dto)).IsSuccessStatusCode;

        public async Task<int> GetUnreadMessageCountAsync()
        {
            var resp = await _httpClient.GetAsync("/api/messages/unread-count");
            if (!resp.IsSuccessStatusCode) return 0;
            try
            {
                var json = await resp.Content.ReadFromJsonAsync<JsonElement>();
                if (json.ValueKind == JsonValueKind.Object && json.TryGetProperty("unreadCount", out var uc))
                    return uc.GetInt32();
            }
            catch { }
            return 0;
        }

        public async Task<IEnumerable<SimpleUserDto>> GetContactsAsync()
        {
            var resp = await _httpClient.GetAsync("/api/messages/contacts");
            return resp.IsSuccessStatusCode
                ? await resp.Content.ReadFromJsonAsync<IEnumerable<SimpleUserDto>>() ?? new List<SimpleUserDto>()
                : new List<SimpleUserDto>();
        }

        public async Task<bool> MarkMessageAsReadAsync(int messageId)
            => (await _httpClient.PostAsync($"/api/messages/{messageId}/mark-read", null)).IsSuccessStatusCode;

        // ---------- Assemblies ----------
        public async Task<IEnumerable<AssemblyDto>> GetAssembliesForCondominiumAsync(int condominiumId)
            => await _httpClient.GetFromJsonAsync<IEnumerable<AssemblyDto>>($"/api/assemblies/condominium/{condominiumId}")
               ?? Enumerable.Empty<AssemblyDto>();

        public async Task<AssemblyDto?> CreateAssemblyAsync(CreateAssemblyDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync("/api/assemblies", dto);
            return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<AssemblyDto>() : null;
        }

        public async Task<int> SendAssemblyInvitesAsync(int assemblyId, SendAssemblyInvitesDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync($"/api/assemblies/{assemblyId}/invites", dto);
            if (!resp.IsSuccessStatusCode) return 0;
            var raw = await resp.Content.ReadAsStringAsync();
            if (int.TryParse(raw, out var sent)) return sent;
            try
            {
                var payload = await resp.Content.ReadFromJsonAsync<Dictionary<string, int>>();
                return payload != null && payload.TryGetValue("sent", out var v) ? v : 0;
            }
            catch { return 0; }
        }




        public async Task<IEnumerable<AssemblyDto>> GetCompanyAssembliesAsync()
        {
            var resp = await _httpClient.GetAsync("/api/assemblies/company");
            if (!resp.IsSuccessStatusCode)
            {
                var raw = await resp.Content.ReadAsStringAsync();
                throw new HttpRequestException($"GET /api/assemblies/company => {(int)resp.StatusCode} {resp.StatusCode}: {raw}");
            }
            return await resp.Content.ReadFromJsonAsync<IEnumerable<AssemblyDto>>() ?? Enumerable.Empty<AssemblyDto>();
        }

        public Task<AssemblyRoomInfoDto?> GetAssemblyRoomInfoAsync(int assemblyId)
            => _httpClient.GetFromJsonAsync<AssemblyRoomInfoDto>($"/api/assemblies/{assemblyId}/room-info");

        // ---------- Reports / Notifications / Company ----------
        public async Task<AdminDashboardDto?> GetAdminDashboardAsync()
        {
            var resp = await _httpClient.GetAsync("/api/reports/admin-dashboard");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<AdminDashboardDto>();
        }

        public Task<IEnumerable<MonthlyFinancialsDto>> GetMonthlyFinancialsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<MonthlyFinancialsDto>>("/api/reports/monthly-financials")!;

        public Task<IEnumerable<StatusSummaryDto>> GetOccurrenceStatusSummaryAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<StatusSummaryDto>>("/api/reports/occurrence-status-summary")!;

        public Task<IEnumerable<CondoHotspotDto>> GetCondoHotspotsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<CondoHotspotDto>>("/api/reports/condo-hotspots")!;

        public Task<CompanyProfileDto?> GetCompanyProfileAsync()
            => _httpClient.GetFromJsonAsync<CompanyProfileDto>("/api/company/my-profile");

        public async Task<bool> UpdateCompanyProfileAsync(CompanyProfileDto dto)
            => (await _httpClient.PutAsJsonAsync("/api/company/my-profile", dto)).IsSuccessStatusCode;

        public Task<IEnumerable<NotificationDto>> GetMyNotificationsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<NotificationDto>>("/api/notifications/my-notifications")!;

        public Task MarkAllNotificationsAsReadAsync()
            => _httpClient.PostAsync("/api/notifications/mark-all-as-read", null);

        public Task<IEnumerable<NotificationDto>> GetAllMyNotificationsAsync()
            => _httpClient.GetFromJsonAsync<IEnumerable<NotificationDto>>("/api/notifications/my-notifications-all")!;

        // ---------- Helpers ----------
        private static string TryExtractMessage(string raw)
        {
            try
            {
                using var json = JsonDocument.Parse(raw);
                return json.RootElement.TryGetProperty("message", out var m) ? m.GetString() ?? raw : raw;
            }
            catch { return raw; }
        }

        public async Task<bool> UnassignResidentFromUnitAsync(int residentId, int unitId)
        {
            var response = await _httpClient.PostAsync($"/api/residents/{residentId}/unassign-from/{unitId}", null);
            return response.IsSuccessStatusCode;
        }
        public async Task<ExpenseDto?> GetExpenseDetailsAsync(int expenseId)
        {
            var response = await _httpClient.GetAsync($"/api/expenses/{expenseId}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ExpenseDto>();
            return null;
        }
        // Lista de despesas fixas do condomínio
        public async Task<IEnumerable<ExpenseDto>> GetFixedExpensesAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExpenseDto>>(
                       $"/api/condominiums/{condominiumId}/fixed-expenses")
                   ?? new List<ExpenseDto>();
        }
        // ----------------- Fixed Expenses -----------------



        // Criar nova despesa fixa
        public async Task<ExpenseDto?> CreateFixedExpenseAsync(int condominiumId, CreateUpdateFixedExpenseDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                $"/api/condominiums/{condominiumId}/fixed-expenses", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ExpenseDto>();
            }
            return null;
        }

        // Atualizar despesa fixa
        public async Task<ExpenseDto?> UpdateFixedExpenseAsync(int expenseId, int condominiumId, CreateUpdateFixedExpenseDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ExpenseDto>();
            }
            return null;
        }

        // Ativar/desativar despesa fixa
        public async Task<bool> ToggleFixedExpenseStatusAsync(int expenseId, int condominiumId)
        {
            var response = await _httpClient.PatchAsync(
                $"/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}/toggle-status", null);
            return response.IsSuccessStatusCode;
        }

        // Apagar despesa fixa
        public async Task<bool> DeleteFixedExpenseAsync(int expenseId, int condominiumId)
        {
            var response = await _httpClient.DeleteAsync(
                $"/api/condominiums/{condominiumId}/fixed-expenses/{expenseId}");
            return response.IsSuccessStatusCode;
        }
        // Enviar anúncio / comunicado para um condomínio
        public async Task<(bool Success, string Message)> SendAnnouncementAsync(int condominiumId, AnnouncementDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/announcements", dto);

            if (resp.IsSuccessStatusCode)
            {
                try
                {
                    var json = await resp.Content.ReadFromJsonAsync<JsonElement>();
                    var msg = json.TryGetProperty("message", out var m) ? m.GetString() : null;
                    return (true, msg ?? "Announcement sent.");
                }
                catch
                {
                    return (true, "Announcement sent.");
                }
            }

            // erro → tenta extrair mensagem
            try
            {
                var json = await resp.Content.ReadFromJsonAsync<JsonElement>();
                var msg = json.TryGetProperty("message", out var m) ? m.GetString() : null;
                return (false, msg ?? (resp.ReasonPhrase ?? "Failed to send announcement."));
            }
            catch
            {
                var raw = await resp.Content.ReadAsStringAsync();
                return (false, string.IsNullOrWhiteSpace(raw) ? (resp.ReasonPhrase ?? "Failed to send announcement.") : raw);
            }
        }
        // Rejeitar comprovativo de pagamento de uma quota
        public async Task<(bool Success, string Message)> RejectPaymentProofAsync(int quotaId, RejectPaymentDto dto)
        {
            var resp = await _httpClient.PostAsJsonAsync($"/api/financials/quotas/{quotaId}/reject-payment", dto);

            if (resp.IsSuccessStatusCode)
            {
                try
                {
                    var ok = await resp.Content.ReadFromJsonAsync<JsonElement>();
                    var msg = ok.TryGetProperty("message", out var m) ? m.GetString() : null;
                    return (true, msg ?? "Payment rejected.");
                }
                catch
                {
                    return (true, "Payment rejected.");
                }
            }

            try
            {
                var err = await resp.Content.ReadFromJsonAsync<JsonElement>();
                var msg = err.TryGetProperty("message", out var m) ? m.GetString() : null;
                return (false, msg ?? (resp.ReasonPhrase ?? "Failed to reject payment."));
            }
            catch
            {
                var raw = await resp.Content.ReadAsStringAsync();
                return (false, string.IsNullOrWhiteSpace(raw) ? (resp.ReasonPhrase ?? "Failed to reject payment.") : raw);
            }
        }

        // Relatório financeiro mensal de um condomínio
        public async Task<FinancialStatementDto?> GetFinancialStatementAsync(int condominiumId, int year, int month)
        {
            var url = $"/api/reports/condominiums/{condominiumId}/financial-statement?year={year}&month={month}";
            var resp = await _httpClient.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;
            return await resp.Content.ReadFromJsonAsync<FinancialStatementDto>();
        }
        // Alterar password do utilizador autenticado
        public async Task<(bool Success, string Message)> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/profile/change-password", model);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }
        // Pedido de recuperação de password (envia email com link)
        public async Task<(bool Success, string RawMessage)> ForgotPasswordAsync(string email)
        {
            var payload = new ForgotPasswordDto { Email = email };
            var resp = await _httpClient.PostAsJsonAsync("/api/accounts/forgot-password", payload);
            var body = await resp.Content.ReadAsStringAsync(); // devolvemos o corpo bruto p/ o controller tratar a mensagem
            return (resp.IsSuccessStatusCode, body);
        }
        // Atualizar o perfil do utilizador (devolve msg e, se houver, novo JWT)
        public async Task<(bool Success, string Message, string? NewToken)> UpdateProfileAsync(UpdateProfileDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/profile", dto);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return (false, responseBody, null);

            try
            {
                using var jsonDoc = JsonDocument.Parse(responseBody);
                jsonDoc.RootElement.TryGetProperty("token", out var tokenElement);
                return (true, "Profile updated successfully.", tokenElement.GetString());
            }
            catch
            {
                // endpoint pode não devolver token; considera só a msg de sucesso
                return (true, "Profile updated successfully.", null);
            }
        }
        public async Task<IReadOnlyList<CondominiumDto>> GetManagedCondominiumsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IReadOnlyList<CondominiumDto>>("/api/condominiums/managed")
                   ?? Array.Empty<CondominiumDto>();
        }
        public async Task<IReadOnlyList<AssemblyDto>> GetCondominiumAssembliesAsync(int condominiumId)
        {
            var url = $"/api/assemblies/condominium/{condominiumId}";
            var resp = await _httpClient.GetAsync(url);

            if (!resp.IsSuccessStatusCode)
            {
                var raw = await resp.Content.ReadAsStringAsync();
                throw new HttpRequestException($"GET {url} => {(int)resp.StatusCode} {resp.ReasonPhrase}: {raw}");
            }

            var data = await resp.Content.ReadFromJsonAsync<IReadOnlyList<AssemblyDto>>();
            return data ?? Array.Empty<AssemblyDto>();
        }
        public async Task<IReadOnlyList<ResidentDto>> GetCondominiumResidentsAsync(int condominiumId)
        {
            var url = $"/api/condominiums/{condominiumId}/residents";
            var resp = await _httpClient.GetAsync(url);
            if (!resp.IsSuccessStatusCode)
            {
                var raw = await resp.Content.ReadAsStringAsync();
                throw new HttpRequestException($"GET {url} => {(int)resp.StatusCode} {resp.ReasonPhrase}: {raw}");
            }
            return await resp.Content.ReadFromJsonAsync<IReadOnlyList<ResidentDto>>() ?? Array.Empty<ResidentDto>();
        }

    }
}
