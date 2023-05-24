using Audit_Mvc_Core.Models;

namespace Audit_Mvc_Core.Repository
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompanies();
        Task<Company> CompanyRegistration(Company cmp);
    }
}
