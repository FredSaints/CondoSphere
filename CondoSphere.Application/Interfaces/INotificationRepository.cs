using CondoSphere.Core.Entities.Users;

namespace CondoSphere.Application.Interfaces
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<IEnumerable<Notification>> GetByUserIdAsync(int userId, int take = 20);
        Task<IEnumerable<Notification>> GetUnreadByUserIdAsync(int userId);
        void Update(Notification notification);
        Task<IEnumerable<Notification>> GetAllByUserIdAsync(int userId);
    }
}