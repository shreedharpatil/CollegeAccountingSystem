using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class StudentBookBorrowStatus
    {
        public int BookBorrowLimit { get; set; }

        public int NumberOfBooksBorrowed { get; set; }
    }
}
