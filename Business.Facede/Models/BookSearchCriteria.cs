using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class BookSearchCriteria
    {
        public int BranchId { get;set; }

        public int CategoryId { get; set; }

        public string Application { get; set; }
    }
}
