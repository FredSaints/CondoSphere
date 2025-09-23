using AutoMapper;
using CondoSphere.Core.DTOs.Assemblies;


// evita choque com o namespace Services.Assembly
using AssemblyEntity = CondoSphere.Core.Entities.Assembly.Assembly;


namespace CondoSphere.Application.Mappings // ou onde guardas os profiles
{
    public class AssemblyProfile : Profile
    {
        public AssemblyProfile()
        {
            // Entidade -> DTO
            CreateMap<AssemblyEntity, AssemblyDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.CompanyId, o => o.MapFrom(s => s.CompanyId))
                .ForMember(d => d.CondominiumId, o => o.MapFrom(s => s.CondominiumId))
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date))     // <- era ScheduledAt
                .ForMember(d => d.Topic, o => o.MapFrom(s => s.Topic))    // <- era Title
                .ForMember(d => d.JitsiRoomName, o => o.MapFrom(s => s.JitsiRoomName))
                .ForMember(d => d.JitsiRoomPassword, o => o.MapFrom(s => s.JitsiRoomPassword))
                .ForAllMembers(o => o.Condition((src, dest, srcMember) => srcMember != null));

            // DTO -> Entidade (para Create/Update)
            CreateMap<AssemblyDto, AssemblyEntity>()
                .ForMember(e => e.Id, o => o.Ignore()) // normalmente não deixas o DTO definir Id
                .ForMember(e => e.CompanyId, o => o.MapFrom(d => d.CompanyId))
                .ForMember(e => e.CondominiumId, o => o.MapFrom(d => d.CondominiumId))
                .ForMember(e => e.Date, o => o.MapFrom(d => d.Date))     // <- era ScheduledAt
                .ForMember(e => e.Topic, o => o.MapFrom(d => d.Topic))    // <- era Title
                .ForMember(e => e.JitsiRoomName, o => o.MapFrom(d => d.JitsiRoomName))
                .ForMember(e => e.JitsiRoomPassword, o => o.MapFrom(d => d.JitsiRoomPassword))
                .ForAllMembers(o => o.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
