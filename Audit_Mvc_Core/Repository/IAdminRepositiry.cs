using Audit_Mvc_Core.Models;

namespace Audit_Mvc_Core.Repository
{
    public interface IAdminRepository
    {
        int CountofEmployees();

        int CountofCustomers();

        int CountofCompanies();

        Task<Admin> AdminRegistration(Admin ad);

        Task<AdminTaskAssign> AdminTaskAssign(AdminTaskAssign ATA);
    }
}
