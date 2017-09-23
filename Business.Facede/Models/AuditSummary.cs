using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class AuditSummary
    {
        public int NumberOfStudents { get; set; }

        public double TotalAdmissionFee { get; set; }

        public double TotalPaidFee { get; set; }

        public double TotalDueFee { get; set; }
    }
}
