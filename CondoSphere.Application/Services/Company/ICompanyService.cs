using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Application.Services.Company
{
    public interface ICompanyService
    {
        Task<CompanyProfileDto?> GetCompanyProfileAsync(int companyId);
        Task<bool> UpdateCompanyProfileAsync(int companyId, CompanyProfileDto dto);
        
    }
}