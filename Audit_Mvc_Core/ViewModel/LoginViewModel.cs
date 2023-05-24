using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;
using System.Security.Cryptography.X509Certificates;

namespace Audit_Mvc_Core.ViewModel
{
    public class LoginViewModel
    {
        public Admin admin { get; set; }
        public Customer customer { get; set; }  
        public Employee employee { get; set; }

        public string username { get; set; }
        public string password { get; set; }
    }
}
