using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Financials;
using CoreExpense = CondoSphere.Core.Entities.Financials.Expense;

namespace CondoSphere.Application.Services.Financials
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseDto?> CreateExpenseAsync(CreateExpenseDto dto, int companyId)
        {
            var condo = await _unitOfWork.Condominiums.GetByIdAsync(dto.CondominiumId, companyId);
            if (condo == null)
            {
                return null;
            }

            var newExpense = _mapper.Map<CoreExpense>(dto);
            newExpense.CompanyId = companyId;

            await _unitOfWork.Expenses.AddAsync(newExpense);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ExpenseDto>(newExpense);
        }

        public async Task<IEnumerable<ExpenseDto>> GetExpensesForOccurrenceAsync(int occurrenceId)
        {
            var expenses = await _unitOfWork.Expenses.GetByOccurrenceIdAsync(occurrenceId);
            return _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }
    }
}