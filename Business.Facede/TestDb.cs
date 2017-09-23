using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede
{
   public class TestDb
    {
       public static IEnumerable<Student> Get() {
           var db = Database.Open();
           return db.STUDENT.All().
               Select(
               db.STUDENT.ID.As("Id"),
               db.STUDENT.NAME.As("Name")
               )
               .ToList<Student>();
       }
    }
}
