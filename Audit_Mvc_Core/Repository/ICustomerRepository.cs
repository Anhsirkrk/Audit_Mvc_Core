using Audit_Mvc_Core.Models;

namespace Audit_Mvc_Core.Repository

{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> CustomerRegistration(Customer cust);
        Task<CustTaskCreation> CustomerTaskCreation(CustTaskCreation CTC); 

        
    }
}
