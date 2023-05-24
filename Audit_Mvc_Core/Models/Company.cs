using System;
using System.Collections.Generic;

namespace Audit_Mvc_Core.Models
{
    public partial class Company
    {
        public Company()
        {
            AdminTaskAssigns = new HashSet<AdminTaskAssign>();
            CustTaskCreations = new HashSet<CustTaskCreation>();
        }

        public int CmpId { get; set; }
        public string? CmpName { get; set; }
        public string? CmpType { get; set; }
        public string? CmpGstNo { get; set; }
        public string? CmpPanNo { get; set; }
        public string? CmpLicenceNo { get; set; }
        public string? CmpPropreitorFirstName { get; set; }
        public string? CmpPropreitorLastName { get; set; }
        public string? CmpGstAddress { get; set; }
        public string? CmpGstState { get; set; }
        public string? CmpGstCity { get; set; }
        public int? CmpZip { get; set; }
        public string? CmpCompanyAddress { get; set; }
        public string? CmpCompanyState { get; set; }
        public string? CmpCompanyCity { get; set; }
        public int? CmpZipCode { get; set; }
        public string? CmpBankName { get; set; }
        public string? CmpBankBranch { get; set; }
        public string? CmpBankAccno { get; set; }
        public string? CmpIfscCode { get; set; }
        public byte[]? CmpBankChequePhoto { get; set; }
        public decimal? CmpLandline { get; set; }
        public byte[]? CmpDoc { get; set; }
        public int? CmpRegisteredBy { get; set; }

        public virtual Customer? CmpRegisteredByNavigation { get; set; }
        public virtual ICollection<AdminTaskAssign> AdminTaskAssigns { get; set; }
        public virtual ICollection<CustTaskCreation> CustTaskCreations { get; set; }
    }
}
