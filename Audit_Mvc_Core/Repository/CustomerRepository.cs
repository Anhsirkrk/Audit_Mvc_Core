using Microsoft.EntityFrameworkCore;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;

namespace Audit_Mvc_Core.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AuditContext _context;

        public CustomerRepository(AuditContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            if (_context != null)
            {
                return await _context.Customers.ToListAsync();
            }
            return null;
        }
        public async Task<Customer> CustomerRegistration(Customer cust)
        {
            if(_context != null)
            {
                var reg=await _context.AddAsync(cust);
                await _context.SaveChangesAsync();
                return reg.Entity;
            }
            return null;
        }
        public async Task<CustTaskCreation> CustomerTaskCreation(CustTaskCreation CTC)
        {
            if (_context != null)
            {
                var reg=await _context.AddAsync(CTC);
                await _context.SaveChangesAsync();
                return reg.Entity;
            }
            return null;
        }
    }
}
