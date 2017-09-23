using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Query
{
    public class GetStudentFeeDetailsQuery : IQueryFor<int,IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(int input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.DIPLOMAFEES.All()            
              .Select(
                  db.DIPLOMAFEES.YEAR.As("Year"),
                  db.DIPLOMAFEES.TUTION_FEE.As("CourseFee"),
                  db.DIPLOMAFEES.ADMISSION_FORM_FEE.As("AdmissionFormFee"),
                  db.DIPLOMAFEES.LAB_FEE.As("LabFee"),
                  db.DIPLOMAFEES.LIBRARY_FEE.As("LibraryFee"),
                  db.DIPLOMAFEES.OTHER_FEE.As("OtherFee"),
                  db.DIPLOMAFEES.ADMISSION_FEE.As("AdmissionFee"),
                  db.DIPLOMAFEES.IDENTITY_CARD_FEE.As("IdentityCardFee"),
                  db.DIPLOMAFEES.STUDENT_ASSOCIATION_FEE.As("StudentAssociationFee"),
                  db.DIPLOMAFEES.READING_ROOM_FEE.As("ReadingRoomFee"),
                  db.DIPLOMAFEES.MAGAZINE_FEE.As("MagazineFee"),
                  db.DIPLOMAFEES.STUDENT_WELFARE_FUND_FEE.As("StudentWelfareFundFee"),
                  db.DIPLOMAFEES.TEACHER_BENEFIT_FUND_FEE.As("TeacherBenefitFundFee"),
                  db.DIPLOMAFEES.SPORTS_FEE.As("SportsFee"),
                  db.DIPLOMAFEES.ADMISSION_FINE_FEE.As("AdmissionFineFee"),
                  db.DIPLOMAFEES.FINE_FEE.As("FineFee"),
                  db.DIPLOMAFEES.FEE_PAID.As("PaidFee"),
                  db.DIPLOMAFEES.DUE_FEE.As("DueFee"),
                  db.DIPLOMAFEES.DUE_DATE.As("DueDate"),
                  db.DIPLOMAFEES.STATUS.As("Status"),
                  db.DIPLOMAFEES.TOTAL_FEE.As("TotalFee"),
                  db.DIPLOMAFEES.DATE_OF_ADMISSION.As("DateOfAdmission")
              ).Where(db.DIPLOMAFEES.STUDENT_ID == input);

            students = query.ToList<Student>();
            return students;
        }
    }
}
