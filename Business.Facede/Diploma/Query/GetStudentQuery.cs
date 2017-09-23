using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Query
{
    public class GetStudentQuery : IQueryFor<string , Student>
    {
        public Student ExecuteQueryWith(string input)
        {
            var db = Database.Open();
            dynamic branch;

            IEnumerable<Student> students = db.DIPLOMASTUDENTS.All()
                .Join(db.BRANCH, out branch)
              .On(db.DIPLOMASTUDENTS.BRANCH_ID == branch.ID)
                .Select(
                    db.DIPLOMASTUDENTS.ID.As("Id"),
                    db.DIPLOMASTUDENTS.FATHERNAME.As("FatherName"),
                  db.DIPLOMASTUDENTS.NAME.As("Name"),
                  db.DIPLOMASTUDENTS.ADDRESS.As("Address"),
                  db.DIPLOMASTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.DIPLOMASTUDENTS.GENDER.As("Gender"),
                  db.DIPLOMASTUDENTS.QUOTA.As("Quota"),
                  db.DIPLOMASTUDENTS.BRANCH_ID.As("BranchId"),
                  db.DIPLOMASTUDENTS.IMAGE_URL.As("ImageUrl"),
                  branch.NAME.As("BranchName")
                )
                .Where(db.DIPLOMASTUDENTS.ID == input)
                .ToList<Student>();

            return students.FirstOrDefault();
        }
    }
}
