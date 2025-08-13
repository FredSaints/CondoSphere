using AutoMapper;
using CondoSphere.Core.DTOs.Account;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CoreUser, SimpleUserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<CoreUser, UserListDto>();
            CreateMap<UserListDto, SimpleUserDto>();
        }
    }
}