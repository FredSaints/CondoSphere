using AutoMapper;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Mappings
{
    public class FinancialsProfile : Profile
    {
        public FinancialsProfile()
        {
            CreateMap<CreateExpenseDto, Expense>();
            CreateMap<Expense, ExpenseDto>()
                .ForMember(
                    dest => dest.AttachmentUrls,
                    opt => opt.MapFrom(src => src.Attachments.Select(a => a.AttachmentUrl).ToList())
                );

            CreateMap<CreateUpdateFixedExpenseDto, Expense>();
            CreateMap<UnitQuota, UnitQuotaDto>();
        }
    }
}