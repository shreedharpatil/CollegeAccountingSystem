using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Degree.Query
{
    public class GetStudentQuery : IQueryFor<string , Student>
    {
        public Student ExecuteQueryWith(string input)
        {
            var db = Database.Open();
            dynamic branch;

            IEnumerable<Student> students = db.DEGREESTUDENTS.All()
                .Join(db.BRANCH, out branch)
              .On(db.DEGREESTUDENTS.BRANCH_ID == branch.ID)
                .Select(
                    db.DEGREESTUDENTS.ID.As("Id"),
                    db.DEGREESTUDENTS.FATHERNAME.As("FatherName"),
                  db.DEGREESTUDENTS.NAME.As("Name"),
                  db.DEGREESTUDENTS.ADDRESS.As("Address"),
                  db.DEGREESTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.DEGREESTUDENTS.GENDER.As("Gender"),
                  db.DEGREESTUDENTS.QUOTA.As("Quota"),
                  db.DEGREESTUDENTS.BRANCH_ID.As("BranchId"),
                  db.DEGREESTUDENTS.IMAGE_URL.As("ImageUrl"),
                  branch.NAME.As("BranchName")
                )
                .Where(db.DEGREESTUDENTS.ID == input)
                .ToList<Student>();

            return students.FirstOrDefault();
        }
    }
}
