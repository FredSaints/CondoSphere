using AutoMapper;
using CondoSphere.Core.DTOs.Messages;
using CondoSphere.Core.Entities.Messages;

namespace CondoSphere.Application.Mappings
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
            CreateMap<Message, MessageDto>()
                .ForMember(d => d.SenderName, opt => opt.Ignore())
                .ForMember(d => d.ReceiverName, opt => opt.Ignore())
                .ForMember(d => d.CondominiumName, opt => opt.Ignore());

            CreateMap<Message, MessageListDto>()
                .ForMember(d => d.SenderName, opt => opt.Ignore())
                .ForMember(d => d.ReceiverName, opt => opt.Ignore())
                .ForMember(d => d.CondominiumName, opt => opt.Ignore());

            CreateMap<SendMessageDto, Message>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SenderId, opt => opt.Ignore())
                .ForMember(d => d.CompanyId, opt => opt.Ignore())
                .ForMember(d => d.SentDate, opt => opt.Ignore())
                .ForMember(d => d.ReadDate, opt => opt.Ignore());
        }
    }
}
