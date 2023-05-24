using System;
using System.Collections.Generic;

namespace Audit_Mvc_Core.Models
{
    public partial class Admin
    {
        public Admin()
        {
            AdminTaskAssigns = new HashSet<AdminTaskAssign>();
        }

        public int AdminId { get; set; }
        public string? AdminFirstname { get; set; }
        public string? AdminLastname { get; set; }
        public string? AdminGender { get; set; }
        public string? AdminUsername { get; set; }
        public string? AdminPassword { get; set; }
        public decimal? AdminMobileNo { get; set; }
        public string? AdminEmailid { get; set; }
        public string? AdminLicenceNo { get; set; }
        public byte[]? AdminProfilepic { get; set; }
        public string? AdminBankName { get; set; }
        public string? AdminBankAccno { get; set; }
        public string? AdminIfscCode { get; set; }
        public string? AdminPanNo { get; set; }
        public string? AdminState { get; set; }
        public string? AdminCity { get; set; }
        public DateTime? AdminDob { get; set; }

        public virtual ICollection<AdminTaskAssign> AdminTaskAssigns { get; set; }
    }
}
