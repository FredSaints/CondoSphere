using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Messages;

namespace CondoSphere.Application.Services.Messages
{
    /// <summary>
    /// I Message Service.
    /// </summary>
    public interface IMessageService
    {
        Task<MessageDto> SendMessageAsync(SendMessageDto dto, int senderId, int companyId);
        Task<IEnumerable<MessageListDto>> GetInboxAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20);
        Task<IEnumerable<MessageListDto>> GetSentMessagesAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20);
        Task<MessageDto?> GetMessageByIdAsync(int messageId, int userId, int companyId);
        Task<int> GetUnreadCountAsync(int userId, int companyId);
        Task<bool> MarkAsReadAsync(int messageId, int userId, int companyId);
        Task<IEnumerable<SimpleUserDto>> GetAvailableContactsAsync(int userId, int companyId);
    }
}
