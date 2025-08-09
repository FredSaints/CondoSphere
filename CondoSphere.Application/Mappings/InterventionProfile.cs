using AutoMapper;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class InterventionProfile : Profile
    {
        public InterventionProfile()
        {
            CreateMap<Intervention, InterventionDto>();
            CreateMap<CreateInterventionDto, Intervention>();
        }
    }
}