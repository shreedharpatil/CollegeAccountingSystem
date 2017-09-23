using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Nursing.Query
{
    public class GetStudentIdQuery : IQueryAll<string>
    {
        public string QueryAll()
        {
            var db = Database.Open();
            var x = db.NURSINGSTUDENTS.All().Select(db.NURSINGSTUDENTS.Id.Max()).ToScalar();
            return x +  "";
        }
    }
}
