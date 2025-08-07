using AutoMapper;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class OccurrenceProfile : Profile
    {
        public OccurrenceProfile()
        {
            CreateMap<Occurrence, OccurrenceDto>();
            CreateMap<CreateOccurrenceDto, Occurrence>();
        }
    }
}