using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Nursing.Query
{
    public class CheckSeatsAvailableQuery : IQueryFor<Student,bool>
    {
        public bool ExecuteQueryWith(Student input)
        {
            var db = Database.Open();
            var seatsAvailable = db.QUOTA.All()
                .Select(db.QUOTA.NUMBER_OF_SEATS)
                .Where(db.QUOTA.QUOTA_TYPE == input.Quota && db.QUOTA.BRANCH_ID == input.BranchId)
                .ToScalar();
            dynamic fees;
            IEnumerable<Student> seatsRegistered = db.NURSINGSTUDENTS.All()
                .Join(db.NURSINGFEES, out fees)
                .On(db.NURSINGSTUDENTS.ID == fees.STUDENT_ID)
                .Select(
                db.NURSINGSTUDENTS.ID.As("Id")
                )
                .Where(db.NURSINGSTUDENTS.BRANCH_ID == input.BranchId && db.NURSINGSTUDENTS.QUOTA == input.Quota && fees.YEAR == "1" && fees.YEAR_OF_ADMISSION == DateTime.Now.Year)
                .ToList<Student>();

            return seatsRegistered.Count() < seatsAvailable;
        }
    }
}
