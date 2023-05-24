using Audit_Mvc_Core.Models;

namespace Audit_Mvc_Core.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> EmployeeRegistration(Employee Emp);
    }
}
