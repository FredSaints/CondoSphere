using System.Collections.Generic;
using System.Linq;
using System.Net;
using CondoSphere.Core.DTOs.Notifications;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.ViewComponents
{
    /// <summary>
    /// Notification Bell View Component.
    /// </summary>
    public class NotificationBellViewComponent : ViewComponent
    {
        private readonly ApiClient _apiClient;
        private readonly IAccessTokenStore _accessTokenStore;

        public NotificationBellViewComponent(ApiClient apiClient, IAccessTokenStore accessTokenStore)
        {
            _apiClient = apiClient;
            _accessTokenStore = accessTokenStore;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = _accessTokenStore.GetToken(HttpContext);
            if (string.IsNullOrEmpty(token))
            {
                return View(new NotificationBellViewModel
                {
                    Notifications = new List<NotificationDto>(),
                    UnreadCount = 0
                });
            }

            try
            {
                var notifications = (await _apiClient.GetMyNotificationsAsync()).ToList();

                var viewModel = new NotificationBellViewModel
                {
                    Notifications = notifications,
                    UnreadCount = notifications.Count(n => !n.IsRead)
                };

                return View(viewModel);
            }
            catch (HttpRequestException httpEx) when (httpEx.StatusCode == HttpStatusCode.Unauthorized)
            {
                _accessTokenStore.ClearToken(HttpContext);
                return View(new NotificationBellViewModel
                {
                    Notifications = new List<NotificationDto>(),
                    UnreadCount = 0
                });
            }
        }
    }
}
