using System;
using System.Collections.Generic;

namespace Audit_Mvc_Core.Models
{
    public partial class AdminTaskAssign
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public int? CompanyId { get; set; }
        public int? Points { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string? Priority { get; set; }
        public int? AssignedBy { get; set; }
        public int? AssignedTo { get; set; }
        public int? CustomerId { get; set; }
        public string? Comments { get; set; }
        public string? Remarks { get; set; }
        /// <summary>
        /// 1=Completed, 0=Rejected, 2=Pending,3=Cancelled
        /// </summary>
        public int? TaskStatus { get; set; }

        public virtual Admin? AssignedByNavigation { get; set; }
        public virtual Employee? AssignedToNavigation { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual CustTaskCreation? Task { get; set; }
    }
}
