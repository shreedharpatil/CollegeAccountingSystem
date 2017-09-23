using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Nursing.Query
{
    public class GetStudentQuery : IQueryFor<string , Student>
    {
        public Student ExecuteQueryWith(string input)
        {
            var db = Database.Open();
            dynamic branch;

            IEnumerable<Student> students = db.NURSINGSTUDENTS.All()
                .Join(db.BRANCH, out branch)
              .On(db.NURSINGSTUDENTS.BRANCH_ID == branch.ID)
                .Select(
                    db.NURSINGSTUDENTS.ID.As("Id"),
                    db.NURSINGSTUDENTS.FATHERNAME.As("FatherName"),
                  db.NURSINGSTUDENTS.NAME.As("Name"),
                  db.NURSINGSTUDENTS.ADDRESS.As("Address"),
                  db.NURSINGSTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.NURSINGSTUDENTS.GENDER.As("Gender"),
                  db.NURSINGSTUDENTS.QUOTA.As("Quota"),
                  db.NURSINGSTUDENTS.BRANCH_ID.As("BranchId"),
                  db.NURSINGSTUDENTS.IMAGE_URL.As("ImageUrl"),
                  branch.NAME.As("BranchName")
                )
                .Where(db.NURSINGSTUDENTS.ID == input)
                .ToList<Student>();

            return students.FirstOrDefault();
        }
    }
}
