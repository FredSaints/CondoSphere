using AutoMapper;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class CondominiumProfile : Profile
    {
        public CondominiumProfile()
        {
            // This defines a map from the Condominium entity to the CondominiumDto.
            // AutoMapper is smart enough to map properties with the same name automatically.
            CreateMap<Condominium, CondominiumDto>();

            // This defines a map from the CreateUpdateCondominiumDto to the Condominium entity.
            // This will be used when creating or updating a condominium.
            CreateMap<CreateUpdateCondominiumDto, Condominium>();
        }
    }
}