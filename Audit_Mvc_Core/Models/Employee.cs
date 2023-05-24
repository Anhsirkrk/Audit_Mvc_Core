using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audit_Mvc_Core.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AdminTaskAssigns = new HashSet<AdminTaskAssign>();
        }

        public int EmpId { get; set; }
        public string? EmpFirstname { get; set; }
        public string? EmpLastname { get; set; }
        public string? EmpUsername { get; set; }
        public string? EmpPassword { get; set; }
        public string? EmpGender { get; set; }
        public string? EmpState { get; set; }
        public string? EmpCity { get; set; }
        public string? EmpAddress { get; set; }
        public string? EmpZipCode { get; set; }
        public string? EmpDepartment { get; set; }
        public string? EmpDesignation { get; set; }
        public decimal? EmpSalary { get; set; }
        public decimal? EmpMobileNo { get; set; }
        public string? EmpEmailid { get; set; }
        public byte[]? EmpProfilepic { get; set; }
        public string? EmpBankName { get; set; }
        public string? EmpBankBranch { get; set; }
        public string? EmpBankAccno { get; set; }
        public string? EmpIfscCode { get; set; }
        public string? EmpPanNo { get; set; }
        public DateTime? EmpDob { get; set; }
        public DateTime? EmpDoj { get; set; }
        public byte[]? EmpQualificationDoc { get; set; }

        [NotMapped]
        public IFormFile Profilepic { get; set; } 

        public virtual ICollection<AdminTaskAssign> AdminTaskAssigns { get; set; }
    }
}
