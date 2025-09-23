using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Shared.Hubs;
using Microsoft.AspNetCore.SignalR;

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

    public async Task<int> NotifyAsync(int userId, string title, string message, string? linkUrl, string type, int? relatedEntityId)
    {
        var n = new Notification
        {
            UserId = userId,
            Title = title,
            Message = message,
            LinkUrl = linkUrl,
            Type = type,
            RelatedEntityId = relatedEntityId,
            IsRead = false,
            SentDate = DateTime.UtcNow
        };

        await _repo.AddAsync(n);
        await _uow.CompleteAsync();

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