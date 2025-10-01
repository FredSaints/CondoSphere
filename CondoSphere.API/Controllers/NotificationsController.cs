using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Notifications;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    [Authorize]    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ICurrentUserService _currentUserService;

        public NotificationsController(INotificationService notificationService, ICurrentUserService currentUserService)
        {
            _notificationService = notificationService;
            _currentUserService = currentUserService;
        }

        [HttpPost("~/api/condominiums/{condominiumId}/announcements")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]        public async Task<IActionResult> SendAnnouncement(int condominiumId, [FromBody] AnnouncementDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            var userName = User.Identity?.Name ?? "Management";
            if (companyId == null) return Unauthorized();

            var success = await _notificationService.SendAnnouncementToCondominiumAsync(condominiumId, companyId.Value, dto.Subject, dto.Message, userName);

            if (!success)
            {
                return Forbid("You do not have permission to send announcements to this condominium.");
            }

            return Ok(new { message = "Announcement sent successfully." });
        }

        [HttpGet("my-notifications")]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetMyNotifications()
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var notifications = await _notificationService.GetNotificationsForUserAsync(userId.Value);
            return Ok(notifications);}

        // --- NEW METHOD START ---
        [HttpPost("mark-one-as-read/{notificationId}")]        public async Task<IActionResult> MarkOneAsRead(int notificationId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var success = await _notificationService.MarkNotificationAsReadAsync(userId.Value, notificationId);

            if (success)
            {
                return NoContent(); // Success, no content to return
            }

            return NotFound(); // Notification not found or user doesn't have permission
        }
        // --- NEW METHOD END ---

        [HttpPost("mark-all-as-read")]        public async Task<IActionResult> MarkAllAsRead()
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            await _notificationService.MarkAllNotificationsAsReadAsync(userId.Value);

            return NoContent();
        }

        [HttpGet("my-notifications-all")]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetAllMyNotifications()
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var notifications = await _notificationService.GetAllNotificationsForUserAsync(userId.Value);
            return Ok(notifications);
        }
    }
}