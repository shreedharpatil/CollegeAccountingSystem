using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Query
{
   public class GetYearsQuery : IQueryAll<IEnumerable<string>>
    {

        public IEnumerable<string> QueryAll()
        {
            var db = Database.Open();
            IEnumerable<SearchCriteria>  years = db.DIPLOMAFEES.All()
                .Select(db.DIPLOMAFEES.YEAR_OF_ADMISSION.Distinct().As("AdmissionYear"))
                .ToList<SearchCriteria>();
            return years.Select(p => p.AdmissionYear);
        }
    }
}
