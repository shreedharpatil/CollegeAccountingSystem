using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Query
{
   public class GetAuditDetailsQuery : IQueryFor<Student, IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(Student input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.DIPLOMASTUDENTS.All()
              .Join(db.DIPLOMAFEES, out fees)
              .On(db.DIPLOMASTUDENTS.ID == fees.STUDENT_ID)
              .Join(db.BRANCH, out branch)
              .On(db.DIPLOMASTUDENTS.BRANCH_ID == branch.ID)
              .Select(
                  db.DIPLOMASTUDENTS.ID.As("Id"),
                  db.DIPLOMASTUDENTS.NAME.As("Name"),
                  db.DIPLOMASTUDENTS.ADDRESS.As("Address"),
                  db.DIPLOMASTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.DIPLOMASTUDENTS.GENDER.As("Gender"),
                  db.DIPLOMASTUDENTS.QUOTA.As("Quota"),
                  db.DIPLOMASTUDENTS.BRANCH_ID.As("BranchId"),
                  db.DIPLOMASTUDENTS.IMAGE_URL.As("ImageUrl"),
                  fees.YEAR.As("Year"),
                  fees.TUTION_FEE.As("CourseFee"),
                  fees.ADMISSION_FORM_FEE.As("AdmissionFormFee"),
                  fees.LAB_FEE.As("LabFee"),
                  fees.LIBRARY_FEE.As("LibraryFee"),
                  fees.OTHER_FEE.As("OtherFee"),

                  fees.ADMISSION_FEE.As("AdmissionFee"),
                  fees.IDENTITY_CARD_FEE.As("IdentityCardFee"),
                  fees.STUDENT_ASSOCIATION_FEE.As("StudentAssociationFee"),
                  fees.READING_ROOM_FEE.As("ReadingRoomFee"),
                  fees.MAGAZINE_FEE.As("MagazineFee"),
                  fees.STUDENT_WELFARE_FUND_FEE.As("StudentWelfareFundFee"),
                  fees.TEACHER_BENEFIT_FUND_FEE.As("TeacherBenefitFundFee"),
                  fees.SPORTS_FEE.As("SportsFee"),
                  fees.FINE_FEE.As("FineFee"),
                  fees.ADMISSION_FINE_FEE.As("AdmissionFineFee"),

                  fees.FEE_PAID.As("PaidFee"),
                  fees.DUE_FEE.As("DueFee"),
                  fees.DUE_DATE.As("DueDate"),
                  fees.STATUS.As("Status"),
                  fees.TOTAL_FEE.As("TotalFee"),
                  branch.NAME.As("BranchName")
              ).Where(db.DIPLOMASTUDENTS.BRANCH_ID == input.BranchId && fees.YEAR_OF_ADMISSION == input.Year);

            students = query.ToList<Student>();

            return students;
        }
    }
}

