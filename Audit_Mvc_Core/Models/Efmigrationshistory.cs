using System;
using System.Collections.Generic;

namespace Audit_Mvc_Core.Models
{
    public partial class Efmigrationshistory
    {
        public string MigrationId { get; set; } = null!;
        public string ProductVersion { get; set; } = null!;
    }
}
