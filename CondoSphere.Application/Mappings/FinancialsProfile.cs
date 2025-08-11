using AutoMapper;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.Entities.Financials;

namespace CondoSphere.Application.Mappings
{
    public class FinancialsProfile : Profile
    {
        public FinancialsProfile()
        {
            CreateMap<Expense, ExpenseDto>();
            CreateMap<CreateExpenseDto, Expense>();
        }
    }
}