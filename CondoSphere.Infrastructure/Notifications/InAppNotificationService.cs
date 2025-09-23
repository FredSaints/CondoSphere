using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Repositories;
using Microsoft.AspNetCore.SignalR;
using CondoSphere.Shared.Hubs;

public class InAppNotificationService : IInAppNotificationService
{
    private readonly INotificationRepository _repo;
    private readonly IHubContext<NotificationHub> _hub;
    private readonly IUnitOfWork _uow;

    public InAppNotificationService(INotificationRepository repo, IHubContext<NotificationHub> hub, IUnitOfWork uow)
    {
        _repo = repo;
        _hub = hub;
        _uow = uow;
    }

    public async Task<int> NotifyAsync(int userId, string title, string message, string linkUrl)
    {
        var n = new Notification
        {
            UserId = userId,
            Title = title,
            Message = message,
            LinkUrl = linkUrl,
            IsRead = false,
            SentDate = DateTime.UtcNow
        };

        await _repo.AddAsync(n);
        await _uow.CompleteAsync(); // <— em vez de _repo.SaveChangesAsync()

        await _hub.Clients.User(userId.ToString())
            .SendAsync("ReceiveNotification", new
            {
                title,
                message,
                linkUrl,
                sentDate = n.SentDate
            });

        return n.Id;
    }

}
