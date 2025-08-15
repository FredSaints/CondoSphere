using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Financials;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Financials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/financials")]
    [Authorize]
    public class FinancialsController : ControllerBase
    {
        private readonly IFinancialService _financialService;
        private readonly ICurrentUserService _currentUserService;

        public FinancialsController(IFinancialService financialService, ICurrentUserService currentUserService)
        {
            _financialService = financialService;
            _currentUserService = currentUserService;
        }

        [HttpPost("condominiums/{condominiumId}/generate-quotas")]
        public async Task<IActionResult> GenerateQuotas(int condominiumId, [FromBody] GenerateQuotasRequest request)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var success = await _financialService.GenerateMonthlyQuotasAsync(condominiumId, request.Year, request.Month, companyId.Value);

            if (success)
            {
                return Ok(new { message = "Monthly fees generated successfully." });
            }

            return BadRequest(new { message = "Failed to generate fees. There may be no units or expenses for this period." });
        }

        [HttpGet("quotas/{quotaId}/breakdown")]
        public async Task<ActionResult<QuotaBreakdownDto>> GetQuotaBreakdown(int quotaId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var breakdown = await _financialService.GetQuotaBreakdownAsync(quotaId, userId.Value);

            if (breakdown == null)
            {
                return Forbid();
            }

            return Ok(breakdown);
        }

        [HttpPost("quotas/{quotaId}/submit-payment-proof")]
        public async Task<IActionResult> SubmitPaymentProof(int quotaId, IFormFile proofFile)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var updatedQuota = await _financialService.SubmitPaymentProofAsync(quotaId, userId.Value, proofFile);

            if (updatedQuota == null)
            {
                return BadRequest(new { message = "Failed to submit proof. The quota may not exist or you may not have permission." });
            }

            return Ok(updatedQuota);
        }

        [HttpPost("quotas/{quotaId}/confirm-payment")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> ConfirmPayment(int quotaId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var success = await _financialService.ConfirmPaymentAsync(quotaId, companyId.Value);

            if (!success)
            {
                return BadRequest(new { message = "Failed to confirm payment. The quota may not exist or is not pending confirmation." });
            }

            return Ok(new { message = "Payment confirmed successfully." });
        }

        [HttpGet("condominiums/{condominiumId}/quotas")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetQuotasForCondominium(int condominiumId)
        {
            // Requires new service & repo methods
            var quotas = await _financialService.GetQuotasForCondominiumAsync(condominiumId);
            return Ok(quotas);
        }
    }
}