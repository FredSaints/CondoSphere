using CondoSphere.Core.DTOs.Messages;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly ApiClient _apiClient;

        public MessagesController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var inbox = await _apiClient.GetInboxAsync();
            return View(inbox);
        }

        public async Task<IActionResult> Sent()
        {
            var sentMessages = await _apiClient.GetSentMessagesAsync();
            return View(sentMessages);
        }

        public async Task<IActionResult> Compose(int? receiverId = null)
        {
            var contacts = await _apiClient.GetContactsAsync();
            ViewBag.Contacts = contacts;
            ViewBag.ReceiverId = receiverId;
            return View(new SendMessageDto { ReceiverId = receiverId ?? 0 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Compose(SendMessageDto dto)
        {
            if (!ModelState.IsValid)
            {
                var contacts = await _apiClient.GetContactsAsync();
                ViewBag.Contacts = contacts;
                return View(dto);
            }

            var success = await _apiClient.SendMessageAsync(dto);
            if (success)
            {
                TempData["Success"] = "Message sent successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Failed to send message. Please try again.";
            var contactsForError = await _apiClient.GetContactsAsync();
            ViewBag.Contacts = contactsForError;
            return View(dto);
        }

        public async Task<IActionResult> View(int id)
        {
            var message = await _apiClient.GetMessageAsync(id);
            if (message == null)
            {
                TempData["Error"] = "Message not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(message);
        }

        public async Task<IActionResult> Reply(int id)
        {
            var originalMessage = await _apiClient.GetMessageAsync(id);
            if (originalMessage == null)
            {
                TempData["Error"] = "Original message not found.";
                return RedirectToAction(nameof(Index));
            }

            var contacts = await _apiClient.GetContactsAsync();
            ViewBag.Contacts = contacts;

            var replyDto = new SendMessageDto
            {
                ReceiverId = originalMessage.SenderId,
                Subject = originalMessage.Subject.StartsWith("Re:") ? originalMessage.Subject : $"Re: {originalMessage.Subject}",
                CondominiumId = originalMessage.CondominiumId
            };

            ViewBag.OriginalMessage = originalMessage;
            return View("Compose", replyDto);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _apiClient.MarkMessageAsReadAsync(id);
            return Json(new { success = true });
        }
    }
}