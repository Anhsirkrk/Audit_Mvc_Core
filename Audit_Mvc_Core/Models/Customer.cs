using System;
using System.Collections.Generic;

namespace Audit_Mvc_Core.Models
{
    public partial class Customer
    {
        public Customer()
        {
            AdminTaskAssigns = new HashSet<AdminTaskAssign>();
            Companies = new HashSet<Company>();
            CustTaskCreations = new HashSet<CustTaskCreation>();
        }

        public int CustomerId { get; set; }
        public string? CustFirstname { get; set; }
        public string? CustLastname { get; set; }
        public string? CustUsername { get; set; }
        public string? CustPassword { get; set; }
        public string? CustGender { get; set; }
        public string? CustState { get; set; }
        public string? CustCity { get; set; }
        public string? CustAddress { get; set; }
        public string? CustZipCode { get; set; }
        public string? CustCompanyName { get; set; }
        public string? CustDeisgnation { get; set; }
        public string? CustReferenceId { get; set; }
        public long? CustMobileNo { get; set; }
        public string? CustEmailid { get; set; }
        public string? CustProfilepic { get; set; }
        public DateTime? CustDob { get; set; }

        public virtual ICollection<AdminTaskAssign> AdminTaskAssigns { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<CustTaskCreation> CustTaskCreations { get; set; }
    }
}
