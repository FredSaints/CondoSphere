using AutoMapper;
using CondoSphere.Core.DTOs.Assemblies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAssembly = CondoSphere.Core.Entities.Assembly.Assembly;

namespace CondoSphere.Application.Mappings
{
    public class AssemblyProfile : Profile
    {
        public AssemblyProfile()
        {

            CreateMap<CoreAssembly, AssemblyDto>()
                .ForMember(d => d.ScheduledAt, m => m.MapFrom(s => s.Date))
                .ForMember(d => d.Title, m => m.MapFrom(s => s.Topic));
        }
    }
}
