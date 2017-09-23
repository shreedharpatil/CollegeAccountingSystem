using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }

        public string Publishers { get; set; }

        public string Edition { get; set; }

        public int BranchId { get; set; }

        public string BranchName { get; set; }

        public string Semister { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Language { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
