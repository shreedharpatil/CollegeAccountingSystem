using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Facede.Models;
using Simple.Data;

namespace Business.Facede.Library.Query
{
    public class StudentSearchQuery : IQueryFor<BookSearchCriteria, IEnumerable<Student>>
    {
       public IEnumerable<Student> ExecuteQueryWith(BookSearchCriteria input)
       {
           var db = Database.Open();
           SimpleQuery query = null;
           if (input.Application.Equals("Diploma", StringComparison.CurrentCultureIgnoreCase))
           {
               query = db.DIPLOMASTUDENTS.All().Where(db.DIPLOMASTUDENTS.BRANCH_ID == input.BranchId);
           }
           else if (input.Application.Equals("Paramedical", StringComparison.CurrentCultureIgnoreCase))
           {
               query = db.PARAMEDICALSTUDENTS.All().Where(db.PARAMEDICALSTUDENTS.BRANCH_ID == input.BranchId);
           }
           else if (input.Application.Equals("Degree", StringComparison.CurrentCultureIgnoreCase))
           {
               query = db.DEGREESTUDENTS.All().Where(db.DEGREESTUDENTS.BRANCH_ID == input.BranchId);
           }
           else if (input.Application.Equals("Pharmacy", StringComparison.CurrentCultureIgnoreCase))
           {
               query = db.PHARMACYSTUDENTS.All().Where(db.PHARMACYSTUDENTS.BRANCH_ID == input.BranchId);
           }
           else if (input.Application.Equals("Nursing", StringComparison.CurrentCultureIgnoreCase))
           {
               query = db.NURSINGSTUDENTS.All().Where(db.NURSINGSTUDENTS.BRANCH_ID == input.BranchId);
           }

           return query.ToList<Student>();
       }
    }
}
