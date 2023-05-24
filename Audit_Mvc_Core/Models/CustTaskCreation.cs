using System;
using System.Collections.Generic;

namespace Audit_Mvc_Core.Models
{
    public partial class CustTaskCreation
    {
        public CustTaskCreation()
        {
            AdminTaskAssigns = new HashSet<AdminTaskAssign>();
        }

        public int TaskNo { get; set; }
        public int? CompanyId { get; set; }
        public string? TaskType { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public DateTime? TaskCreationDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte[]? Documents { get; set; }
        public int? CustomerId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<AdminTaskAssign> AdminTaskAssigns { get; set; }
    }
}
