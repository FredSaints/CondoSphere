using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.ViewComponents
{
    public class NotificationBellViewComponent : ViewComponent
    {
        private readonly ApiClient _apiClient;

        public NotificationBellViewComponent(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = (await _apiClient.GetMyNotificationsAsync()).ToList();

            var viewModel = new NotificationBellViewModel
            {
                Notifications = notifications,
                UnreadCount = notifications.Count(n => !n.IsRead)
            };

            return View(viewModel);
        }
    }
}