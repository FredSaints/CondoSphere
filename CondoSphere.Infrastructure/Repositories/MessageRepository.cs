using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Messages;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly UserManagementDbContext _context;

        public MessageRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message?> GetByIdAsync(int messageId)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
        }

        public async Task<IEnumerable<Message>> GetUserInboxAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20)
        {
            return await _context.Messages
                .Where(m => m.ReceiverId == userId && m.CompanyId == companyId)
                .OrderByDescending(m => m.SentDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetUserSentMessagesAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20)
        {
            return await _context.Messages
                .Where(m => m.SenderId == userId && m.CompanyId == companyId)
                .OrderByDescending(m => m.SentDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetUnreadCountAsync(int userId, int companyId)
        {
            return await _context.Messages
                .CountAsync(m => m.ReceiverId == userId && m.CompanyId == companyId && !m.ReadDate.HasValue);
        }

        public async Task MarkAsReadAsync(int messageId, int userId)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == messageId && m.ReceiverId == userId);

            if (message != null && !message.ReadDate.HasValue)
            {
                message.ReadDate = DateTime.UtcNow;
            }
        }

        public void Update(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
        }
    }
}
