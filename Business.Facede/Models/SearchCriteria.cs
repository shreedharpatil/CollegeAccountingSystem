using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class SearchCriteria
    {
        public string Criteria { get; set; }

        public string BranchId { get; set; }

        public string Quota { get; set; }

        public string Year { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public string AdmissionYear { get; set; }
    }
}
