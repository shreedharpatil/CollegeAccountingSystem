using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string Path { get; set; }
    }
}
