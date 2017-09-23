using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Paramedical.Query
{
   public class GetYearsQuery : IQueryAll<IEnumerable<string>>
    {

        public IEnumerable<string> QueryAll()
        {
            var db = Database.Open();
            IEnumerable<SearchCriteria>  years = db.PARAMEDICALFEES.All()
                .Select(db.PARAMEDICALFEES.YEAR_OF_ADMISSION.Distinct().As("AdmissionYear"))
                .ToList<SearchCriteria>();
            return years.Select(p => p.AdmissionYear);
        }
    }
}
