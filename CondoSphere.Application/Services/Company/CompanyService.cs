using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Application.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyProfileDto?> GetCompanyProfileAsync(int companyId)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(companyId);
            return _mapper.Map<CompanyProfileDto>(company);
        }

        public async Task<bool> UpdateCompanyProfileAsync(int companyId, CompanyProfileDto dto)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(companyId);
            if (company == null)
            {
                return false;
            }

            _mapper.Map(dto, company);
            _unitOfWork.Companies.Update(company);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}