using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Paramedical.Query
{
    public class GetStudentIdQuery : IQueryAll<string>
    {
        public string QueryAll()
        {
            var db = Database.Open();
            var x = db.PARAMEDICALSTUDENTS.All().Select(db.PARAMEDICALSTUDENTS.Id.Max()).ToScalar();
            return x +  "";
        }
    }
}
