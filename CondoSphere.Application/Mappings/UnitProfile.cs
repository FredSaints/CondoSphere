using AutoMapper;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUpdateUnitDto, Unit>();
        }
    }
}