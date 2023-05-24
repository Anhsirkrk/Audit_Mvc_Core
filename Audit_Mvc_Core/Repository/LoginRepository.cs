using Audit_Mvc_Core.Models;
using Microsoft.EntityFrameworkCore;
namespace Audit_Mvc_Core.Repository
{
    public class LoginRepository:ILoginRepository
    {
        AuditContext _context;

        public LoginRepository(AuditContext context)
        {
            _context = context;
        }
        //public async Task<Admin> GetAdmin()
        //{
        //    if (_context != null)
        //    {
        //        return await _context.Admins.ToListAsync();
        //    }
        //    return null;
        //}

        public async Task<Admin> AuthenticateAdminLog(string username,string password)
        {
            var Result=await _context.Admins.SingleOrDefaultAsync(x=>x.AdminUsername == username && x.AdminPassword == password);
            return Result;
        }
        public async Task<Customer> AuthenticateCustomerLog(string username,string password)
        {
            var result = await _context.Customers.SingleOrDefaultAsync(x => x.CustUsername == username && x.CustPassword == password);
            return result;
        }
        public async Task<Employee> AuthenticateEmployeeLog(string username,string password)
        {
            var result = await _context.Employees.SingleOrDefaultAsync(x => x.EmpUsername == username && x.EmpPassword == password);
            return result;
        }
    }

}
