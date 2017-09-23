using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class IssueBook
    {
        public int StudentId { get; set; }

        public int BranchId { get; set; }

        public int BookId { get; set; }

        public string ISBN { get; set; }

        public DateTime BookIssueDate { get; set; }

        public DateTime BookDueDate { get; set; }

        public DateTime BookReturnDate { get; set; }

        public double FineAmount { get; set; }

        public int BookStatusId { get; set; }

        public string BookStatus { get; set; }

        public string Remarks { get; set; }

        public string Application { get; set; }
    }
}
