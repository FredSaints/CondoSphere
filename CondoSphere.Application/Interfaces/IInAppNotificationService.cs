using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    public interface IInAppNotificationService
    {
        Task<int> NotifyAsync(int userId, string title, string message, string? linkUrl, string type, int? relatedEntityId);
    }
}
