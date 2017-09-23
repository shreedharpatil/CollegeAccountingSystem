using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Nursing.Query
{
   public class GetYearsQuery : IQueryAll<IEnumerable<string>>
    {

        public IEnumerable<string> QueryAll()
        {
            var db = Database.Open();
            IEnumerable<SearchCriteria>  years = db.NURSINGFEES.All()
                .Select(db.NURSINGFEES.YEAR_OF_ADMISSION.Distinct().As("AdmissionYear"))
                .ToList<SearchCriteria>();
            return years.Select(p => p.AdmissionYear);
        }
    }
}
