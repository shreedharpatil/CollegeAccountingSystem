using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class Fee
    {
        public decimal CourseFee { get; set; }
        public decimal DevelopmentFee { get; set; }
        public decimal LabFee { get; set; }
        public decimal LibraryFee { get; set; }
        public decimal OtherFee { get; set; }
        public decimal TotalFee { get; set; }
        public decimal DueFee { get; set; }
        public decimal PaidFee { get; set; }
        public DateTime DueDate { get; set; }
    }
}
