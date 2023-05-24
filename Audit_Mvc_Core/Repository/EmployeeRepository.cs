using Microsoft.EntityFrameworkCore;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;

namespace Audit_Mvc_Core.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly AuditContext _Context;
        
        public EmployeeRepository(AuditContext context)
        {
            _Context = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            if (_Context != null)
            {
                return await _Context.Employees.ToListAsync();  
            }
            return null;
        }
        
        public async Task<Employee> EmployeeRegistration(Employee Emp)
        {
            if (_Context != null)
            {
                var reg=await _Context.Employees.AddAsync(Emp);
                await _Context.SaveChangesAsync();
                return reg.Entity;
            }
            return null;
        }

    }
}
