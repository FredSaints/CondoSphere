using AutoMapper;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class CondominiumProfile : Profile
    {
        public CondominiumProfile()
        {
            CreateMap<Condominium, CondominiumDto>();
            CreateMap<CreateUpdateCondominiumDto, Condominium>();
            CreateMap<Document, DocumentDto>();
        }
    }
}