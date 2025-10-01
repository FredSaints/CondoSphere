using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Notification Repository.
    /// </summary>
    public class NotificationRepository : INotificationRepository
    {
        private readonly UserManagementDbContext _context;

        public NotificationRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }

        public async Task<IEnumerable<Notification>> GetByUserIdAsync(int userId, int take = 20)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.SentDate)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetUnreadByUserIdAsync(int userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.SentDate)
                .ToListAsync();
        }

        public void Update(Notification notification)
        {
            _context.Notifications.Update(notification);
        }

        public async Task<bool> MarkAsReadAsync(int userId, int notificationId)
        {
            var notification = await _context.Notifications
                .FirstOrDefaultAsync(n => n.Id == notificationId && n.UserId == userId);

            if (notification == null || notification.IsRead)
            {
                return false;
            }

            notification.IsRead = true;
            notification.ReadDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Notification>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.SentDate)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}