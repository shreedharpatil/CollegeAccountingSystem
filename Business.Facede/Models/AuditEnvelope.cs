using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class AuditEnvelope
    {
        public AuditSummary MainAuditSummary { get; set; }

        public Audit GovernmentQuota { get; set; }

        public Audit ManagementQuota { get; set; }

        public Audit YearOne { get; set; }

        public Audit YearTwo { get; set; }

        public Audit YearThree { get; set; }

        public Audit YearFour { get; set; }

        public Audit YearFive { get; set; }

        public Audit YearSix { get; set; }

        public Audit Male { get; set; }

        public Audit Female { get; set; }
    }
}
