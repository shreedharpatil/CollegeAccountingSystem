using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class Audit
    {
        public AuditSummary AuditSummary { get; set; }

        public IEnumerable<Student> AuditDetails { get; set; }
    }
}
