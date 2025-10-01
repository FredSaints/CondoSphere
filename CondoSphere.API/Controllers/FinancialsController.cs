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
    [Authorize]    public class FinancialsController : ControllerBase
    {
        private readonly IFinancialService _financialService;
        private readonly ICurrentUserService _currentUserService;

        public FinancialsController(IFinancialService financialService, ICurrentUserService currentUserService)
        {
            _financialService = financialService;
            _currentUserService = currentUserService;
        }

        [HttpPost("condominiums/{condominiumId}/generate-quotas")]        public async Task<IActionResult> GenerateQuotas(int condominiumId, [FromBody] GenerateQuotasRequest request)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var (success, message) = await _financialService.GenerateMonthlyQuotasAsync(condominiumId, request.Year, request.Month, companyId.Value);

            if (success)
            {
                return Ok(new { message });
            }
            return BadRequest(new { message });
        }

        [HttpGet("quotas/{quotaId}/breakdown")]        public async Task<ActionResult<QuotaBreakdownDto>> GetQuotaBreakdown(int quotaId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var breakdown = await _financialService.GetQuotaBreakdownAsync(quotaId, userId.Value);

            if (breakdown == null)
            {
                return Forbid();
            }return Ok(breakdown);
        }

        [HttpPost("quotas/{quotaId}/submit-payment-proof")]        public async Task<IActionResult> SubmitPaymentProof(int quotaId, IFormFile proofFile)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var updatedQuota = await _financialService.SubmitPaymentProofAsync(quotaId, userId.Value, proofFile);

            if (updatedQuota == null)
            {
                return BadRequest(new { message = "Failed to submit proof. The quota may not exist or you may not have permission." });
            }         return Ok(updatedQuota);
        }

        [HttpPost("quotas/{quotaId}/confirm-payment")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
/// <summary>
/// Handles the Confirm Payment action.
/// </summary>
public async Task<IActionResult> ConfirmPayment(int quotaId)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var success = await _financialService.ConfirmPaymentAsync(quotaId, companyId.Value);

            if (!success)
            {
                return BadRequest(new { message = "Failed to confirm payment. The quota may not exist oris not pending confirmation." });
            }

            return Ok(new { message = "Payment confirmed successfully." });
        }

        [HttpGet("condominiums/{condominiumId}/quotas")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]   public async Task<IActionResult> GetQuotasForCondominium(int condominiumId)
        {
            var quotas = await _financialService.GetQuotasForCondominiumAsync(condominiumId);
            return Ok(quotas);
        }

        [HttpPost("quotas/{quotaId}/create-checkout-session")]
/// <summary>
/// Handles the Create Checkout Session action.
/// </summary>
public async Task<IActionResult> CreateCheckoutSession(int quotaId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var sessionId = await _financialService.CreateStripeCheckoutSessionAsync(quotaId, userId.Value);

            if (sessionId == null)
            {
                return BadRequest(new { message = "Could not create payment session." });
            }

            return Ok(new { sessionId });
        }

        [HttpPost("quotas/{quotaId}/mark-as-paid")]
/// <summary>
/// Handles the Mark As Paid action.
/// </summary>
public async Task<IActionResult> MarkAsPaid(int quotaId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var success = await _financialService.MarkQuotaAsPaidAsync(quotaId, userId.Value);

            if (!success)
            {
                return BadRequest(new { message = "Failed to update quota status." });
            }

            return Ok(new { message = "Quota marked as paid." });
        }

        [HttpGet("receipts/{receiptId}")]
/// <summary>
/// Handles the Get Receipt action.
/// </summary>
public async Task<ActionResult<ReceiptDto>> GetReceipt(int receiptId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var receipt = await _financialService.GetReceiptDetailsAsync(receiptId, userId.Value);

            if (receipt == null)
            {
                return Forbid();
            }

            return Ok(receipt);
        }

        [HttpGet("manager/receipts/{receiptId}")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
/// <summary>
/// Handles the Get Receipt For Manager action.
/// </summary>
public async Task<ActionResult<ReceiptDto>> GetReceiptForManager(int receiptId)
        {
            var companyId =_currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var receipt = await _financialService.GetReceiptDetailsForManagerAsync(receiptId, companyId.Value);

            if (receipt == null)
            {
                return Forbid();
            }

            return Ok(receipt);
        }

        [HttpPost("quotas/{quotaId}/reject-payment")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
/// <summary>
/// Handles the Reject Payment action.
/// </summary>
public async Task<IActionResult> RejectPayment(int quotaId, [FromBody] RejectPaymentDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var success = await _financialService.RejectPaymentProofAsync(quotaId, companyId.Value, dto.RejectionReason);

            if (!success)
            {
                return BadRequest(new { message = "Failed to reject payment. The quota may not exist or is not pending confirmation." });
            }
            return Ok(new { message = "Payment proof rejected and resident has been notified." });
        }
    }
}