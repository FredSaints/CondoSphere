using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CondoSphere.Shared.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            // This method is called every time a user's browser connects.
            // We can add logic here later if needed, for example, to add users to groups.
            await base.OnConnectedAsync();
        }
    }
}