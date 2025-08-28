using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Messages;
using CondoSphere.Core.DTOs.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ICurrentUserService _currentUserService;

        public MessagesController(IMessageService messageService, ICurrentUserService currentUserService)
        {
            _messageService = messageService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
        {
            var userId = _currentUserService.UserId;
            var companyId = _currentUserService.CompanyId;

            if (userId == null || companyId == null)
                return Unauthorized();

            try
            {
                var message = await _messageService.SendMessageAsync(dto, userId.Value, companyId.Value);
                return Ok(message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("inbox")]
        public async Task<IActionResult> GetInbox([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var userId = _currentUserService.UserId;
            var companyId = _currentUserService.CompanyId;

            if (userId == null || companyId == null)
                return Unauthorized();

            var messages = await _messageService.GetInboxAsync(userId.Value, companyId.Value, pageNumber, pageSize);
            return Ok(messages);
        }

        [HttpGet("sent")]
        public async Task<IActionResult> GetSentMessages([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var userId = _currentUserService.UserId;
            var companyId = _currentUserService.CompanyId;

            if (userId == null || companyId == null)
                return Unauthorized();

            var messages = await _messageService.GetSentMessagesAsync(userId.Value, companyId.Value, pageNumber, pageSize);
            return Ok(messages);
        }

        [HttpGet("{messageId}")]
        public async Task<IActionResult> GetMessage(int messageId)
        {
            var userId = _currentUserService.UserId;
            var companyId = _currentUserService.CompanyId;

            if (userId == null || companyId == null)
                return Unauthorized();

            var message = await _messageService.GetMessageByIdAsync(messageId, userId.Value, companyId.Value);
            if (message == null)
                return NotFound();

            return Ok(message);
        }

        [HttpPost("{messageId}/mark-read")]
        public async Task<IActionResult> MarkAsRead(int messageId)
        {
            var userId = _currentUserService.UserId;
            var companyId = _currentUserService.CompanyId;

            if (userId == null || companyId == null)
                return Unauthorized();

            var success = await _messageService.MarkAsReadAsync(messageId, userId.Value, companyId.Value);
            return success ? Ok() : BadRequest();
        }

        [HttpGet("unread-count")]
        public async Task<IActionResult> GetUnreadCount()
        {
            var userId = _currentUserService.UserId;
            var companyId = _currentUserService.CompanyId;

            if (userId == null || companyId == null)
                return Unauthorized();

            var count = await _messageService.GetUnreadCountAsync(userId.Value, companyId.Value);
            return Ok(new { unreadCount = count });
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetContacts()
        {
            var userId = _currentUserService.UserId;
            var companyId = _currentUserService.CompanyId;

            if (userId == null || companyId == null)
                return Unauthorized();

            var contacts = await _messageService.GetAvailableContactsAsync(userId.Value, companyId.Value);
            return Ok(contacts);
        }
    }
}