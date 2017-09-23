using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Pharmacy.Query
{
    public class GetStudentQuery : IQueryFor<string , Student>
    {
        public Student ExecuteQueryWith(string input)
        {
            var db = Database.Open();
            dynamic branch;

            IEnumerable<Student> students = db.PHARMACYSTUDENTS.All()
                .Join(db.BRANCH, out branch)
              .On(db.PHARMACYSTUDENTS.BRANCH_ID == branch.ID)
                .Select(
                    db.PHARMACYSTUDENTS.ID.As("Id"),
                    db.PHARMACYSTUDENTS.FATHERNAME.As("FatherName"),
                  db.PHARMACYSTUDENTS.NAME.As("Name"),
                  db.PHARMACYSTUDENTS.ADDRESS.As("Address"),
                  db.PHARMACYSTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.PHARMACYSTUDENTS.GENDER.As("Gender"),
                  db.PHARMACYSTUDENTS.QUOTA.As("Quota"),
                  db.PHARMACYSTUDENTS.BRANCH_ID.As("BranchId"),
                  db.PHARMACYSTUDENTS.IMAGE_URL.As("ImageUrl"),
                  branch.NAME.As("BranchName")
                )
                .Where(db.PHARMACYSTUDENTS.ID == input)
                .ToList<Student>();

            return students.FirstOrDefault();
        }
    }
}
