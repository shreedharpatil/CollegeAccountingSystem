using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Nursing.Query
{
   public class GetAuditDetailsQuery : IQueryFor<Student, IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(Student input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.NURSINGSTUDENTS.All()
              .Join(db.NURSINGFEES, out fees)
              .On(db.NURSINGSTUDENTS.ID == fees.STUDENT_ID)
              .Join(db.BRANCH, out branch)
              .On(db.NURSINGSTUDENTS.BRANCH_ID == branch.ID)
              .Select(
                  db.NURSINGSTUDENTS.ID.As("Id"),
                  db.NURSINGSTUDENTS.NAME.As("Name"),
                  db.NURSINGSTUDENTS.ADDRESS.As("Address"),
                  db.NURSINGSTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.NURSINGSTUDENTS.GENDER.As("Gender"),
                  db.NURSINGSTUDENTS.QUOTA.As("Quota"),
                  db.NURSINGSTUDENTS.BRANCH_ID.As("BranchId"),
                  db.NURSINGSTUDENTS.IMAGE_URL.As("ImageUrl"),
                  fees.YEAR.As("Year"),
                  fees.TUTION_FEE.As("CourseFee"),
                  fees.LAB_FEE.As("LabFee"),
                  fees.LIBRARY_FEE.As("LibraryFee"),
                  fees.OTHER_FEE.As("OtherFee"),

                  fees.ADMISSION_FEE.As("AdmissionFee"),

                  fees.PHYCHIATRIC_FEE.As("PhyciatricFee"),
                  fees.MEDICAL_FEE.As("MedicalFee"),
                  fees.TRANSPORTATION_FEE.As("TransportationFee"),
                  fees.EXAMINATION_FEE.As("ExaminationFee"),
                  fees.HOSTEL_FEE.As("HostelFee"),
                  fees.MESS_FEE.As("MessFee"),
                  fees.SPORTS_FEE.As("SportsFee"),
                  fees.BOOKS_FEE.As("BooksFee"),
                  fees.UNIFORM_FEE.As("UniformFee"),
                  fees.CAUTION_DEPOSIT_FEE.As("CautionDepositFee"),

                  fees.FEE_PAID.As("PaidFee"),
                  fees.DUE_FEE.As("DueFee"),
                  fees.DUE_DATE.As("DueDate"),
                  fees.STATUS.As("Status"),
                  fees.TOTAL_FEE.As("TotalFee"),
                  branch.NAME.As("BranchName")
              ).Where(db.NURSINGSTUDENTS.BRANCH_ID == input.BranchId && fees.YEAR_OF_ADMISSION == input.Year);

            students = query.ToList<Student>();

            return students;
        }
    }
}

