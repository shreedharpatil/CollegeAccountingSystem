using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Paramedical.Query
{
    public class GetStudentFeeDetailsQuery : IQueryFor<int,IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(int input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.PARAMEDICALFEES.All()            
              .Select(
                  db.PARAMEDICALFEES.YEAR.As("Year"),
                  db.PARAMEDICALFEES.TUTION_FEE.As("CourseFee"),
                  db.PARAMEDICALFEES.ADMISSION_FORM_FEE.As("AdmissionFormFee"),
                  db.PARAMEDICALFEES.LAB_FEE.As("LabFee"),
                  db.PARAMEDICALFEES.LIBRARY_FEE.As("LibraryFee"),
                  db.PARAMEDICALFEES.OTHER_FEE.As("OtherFee"),
                  db.PARAMEDICALFEES.ADMISSION_FEE.As("AdmissionFee"),
                  db.PARAMEDICALFEES.IDENTITY_CARD_FEE.As("IdentityCardFee"),
                  db.PARAMEDICALFEES.STUDENT_ASSOCIATION_FEE.As("StudentAssociationFee"),
                  db.PARAMEDICALFEES.READING_ROOM_FEE.As("ReadingRoomFee"),
                  db.PARAMEDICALFEES.MAGAZINE_FEE.As("MagazineFee"),
                  db.PARAMEDICALFEES.STUDENT_WELFARE_FUND_FEE.As("StudentWelfareFundFee"),
                  db.PARAMEDICALFEES.TEACHER_BENEFIT_FUND_FEE.As("TeacherBenefitFundFee"),
                  db.PARAMEDICALFEES.SPORTS_FEE.As("SportsFee"),
                  db.PARAMEDICALFEES.ADMISSION_FINE_FEE.As("AdmissionFineFee"),
                  db.PARAMEDICALFEES.FINE_FEE.As("FineFee"),
                  db.PARAMEDICALFEES.FEE_PAID.As("PaidFee"),
                  db.PARAMEDICALFEES.DUE_FEE.As("DueFee"),
                  db.PARAMEDICALFEES.DUE_DATE.As("DueDate"),
                  db.PARAMEDICALFEES.STATUS.As("Status"),
                  db.PARAMEDICALFEES.TOTAL_FEE.As("TotalFee"),
                  db.PARAMEDICALFEES.DATE_OF_ADMISSION.As("DateOfAdmission")
              ).Where(db.PARAMEDICALFEES.STUDENT_ID == input);

            students = query.ToList<Student>();
            return students;
        }
    }
}
