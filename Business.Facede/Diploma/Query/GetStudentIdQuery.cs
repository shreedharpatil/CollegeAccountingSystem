using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Query
{
    public class GetStudentIdQuery : IQueryAll<string>
    {
        public string QueryAll()
        {
            var db = Database.Open();
            var x = db.DiplomaStudents.All().Select(db.DiplomaStudents.Id.Max()).ToScalar();
            return x +  "";
        }
    }
}
