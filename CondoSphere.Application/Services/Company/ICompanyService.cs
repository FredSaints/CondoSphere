using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Application.Services.Company
{
    /// <summary>
    /// I Company Service.
    /// </summary>
    public interface ICompanyService
    {
        Task<CompanyProfileDto?> GetCompanyProfileAsync(int companyId);
        Task<bool> UpdateCompanyProfileAsync(int companyId, CompanyProfileDto dto);
        
    }
}