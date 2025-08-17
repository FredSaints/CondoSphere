using CondoSphere.Core.DTOs.Financials;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Application.Services.Financials
{
    public interface IFinancialService
    {
        Task<IEnumerable<UnitQuotaDto>> GetQuotasForUserAsync(int userId);
        Task<bool> GenerateMonthlyQuotasAsync(int condominiumId, int year, int month, int companyId);
        Task<QuotaBreakdownDto?> GetQuotaBreakdownAsync(int quotaId, int userId);
        Task<UnitQuotaDto?> SubmitPaymentProofAsync(int quotaId, int userId, IFormFile proofFile);
        Task<bool> ConfirmPaymentAsync(int quotaId, int companyId);
        Task<IEnumerable<UnitQuotaDto>> GetQuotasForCondominiumAsync(int condominiumId);
        Task<string?> CreateStripeCheckoutSessionAsync(int quotaId, int userId);
        Task<bool> MarkQuotaAsPaidAsync(int quotaId, int userId);
    }
}
