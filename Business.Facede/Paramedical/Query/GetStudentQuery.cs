using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Paramedical.Query
{
    public class GetStudentQuery : IQueryFor<string , Student>
    {
        public Student ExecuteQueryWith(string input)
        {
            var db = Database.Open();
            dynamic branch;

            IEnumerable<Student> students = db.PARAMEDICALSTUDENTS.All()
                .Join(db.BRANCH, out branch)
              .On(db.PARAMEDICALSTUDENTS.BRANCH_ID == branch.ID)
                .Select(
                    db.PARAMEDICALSTUDENTS.ID.As("Id"),
                    db.PARAMEDICALSTUDENTS.FATHERNAME.As("FatherName"),
                  db.PARAMEDICALSTUDENTS.NAME.As("Name"),
                  db.PARAMEDICALSTUDENTS.ADDRESS.As("Address"),
                  db.PARAMEDICALSTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.PARAMEDICALSTUDENTS.GENDER.As("Gender"),
                  db.PARAMEDICALSTUDENTS.QUOTA.As("Quota"),
                  db.PARAMEDICALSTUDENTS.BRANCH_ID.As("BranchId"),
                  db.PARAMEDICALSTUDENTS.IMAGE_URL.As("ImageUrl"),
                  branch.NAME.As("BranchName")
                )
                .Where(db.PARAMEDICALSTUDENTS.ID == input)
                .ToList<Student>();

            return students.FirstOrDefault();
        }
    }
}
