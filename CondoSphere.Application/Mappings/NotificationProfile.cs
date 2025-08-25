using AutoMapper;
using CondoSphere.Core.DTOs.Notifications;
using CondoSphere.Core.Entities.Users;

namespace CondoSphere.Application.Mappings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>();
        }
    }
}