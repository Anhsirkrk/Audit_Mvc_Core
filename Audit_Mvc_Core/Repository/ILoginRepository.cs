using Audit_Mvc_Core.Models;
using Microsoft.EntityFrameworkCore;
using Audit_Mvc_Core.Controllers;
namespace Audit_Mvc_Core.Repository
{
    public interface ILoginRepository
    {
        //Task<List<Admin>> GetAdmin();
        //Task<List<Customer>> GetCustomers();
        //Task<List<Employee>> GetEmployees();


        Task<Admin> AuthenticateAdminLog(string username, string password);
        
        Task<Customer> AuthenticateCustomerLog(string username, string password);

        Task<Employee> AuthenticateEmployeeLog(string username, string password);
    }
}
