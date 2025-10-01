using CondoSphere.Core.Entities.Messages;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Message Repository.
    /// </summary>
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<Message?> GetByIdAsync(int messageId);
        Task<IEnumerable<Message>> GetUserInboxAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20);
        Task<IEnumerable<Message>> GetUserSentMessagesAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20);
        Task<int> GetUnreadCountAsync(int userId, int companyId);
        Task MarkAsReadAsync(int messageId, int userId);
        void Update(Message message);
    }
}
