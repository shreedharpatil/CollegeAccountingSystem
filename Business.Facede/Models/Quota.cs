using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
   public  class Quota
    {
       public int BranchId { get; set; }
       public string Quota_Type { get; set; }
       public int NumberOfSeats { get; set; }
    }
}
