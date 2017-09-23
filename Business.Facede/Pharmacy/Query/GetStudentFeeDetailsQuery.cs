using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Pharmacy.Query
{
    public class GetStudentFeeDetailsQuery : IQueryFor<int,IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(int input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.PHARMACYFEES.All()            
              .Select(
                  db.PHARMACYFEES.YEAR.As("Year"),
                  db.PHARMACYFEES.TUTION_FEE.As("CourseFee"),
                  db.PHARMACYFEES.LAB_FEE.As("LabFee"),
                  db.PHARMACYFEES.LIBRARY_FEE.As("LibraryFee"),
                  db.PHARMACYFEES.OTHER_FEE.As("OtherFee"),
                  db.PHARMACYFEES.ADMISSION_FEE.As("AdmissionFee"),

                  db.PHARMACYFEES.HOME_EXAM_FEE.As("HomeExamFee"),
                  db.PHARMACYFEES.MEDICAL_FEE.As("MedicalFee"),
                  db.PHARMACYFEES.IDENTITY_CARD_FEE.As("IdentityCardFee"),
                  db.PHARMACYFEES.MIS_FEE.As("MisFee"),
                  db.PHARMACYFEES.MAGAZINE_FEE.As("MagazineFee"),
                  db.PHARMACYFEES.JOURNAL_FEE.As("JournalFee"),
                  db.PHARMACYFEES.SPORTS_FEE.As("SportsFee"),
                  db.PHARMACYFEES.STUDENT_AID_FUND_FEE.As("StudentAidFundFee"),
                  db.PHARMACYFEES.CAUTION_FEE.As("CautionDepositFee"),
                  db.PHARMACYFEES.FEE_PAID.As("PaidFee"),
                  db.PHARMACYFEES.DUE_FEE.As("DueFee"),
                  db.PHARMACYFEES.DUE_DATE.As("DueDate"),
                  db.PHARMACYFEES.STATUS.As("Status"),
                  db.PHARMACYFEES.TOTAL_FEE.As("TotalFee"),
                  db.PHARMACYFEES.DATE_OF_ADMISSION.As("DateOfAdmission")
              ).Where(db.PHARMACYFEES.STUDENT_ID == input);

            students = query.ToList<Student>();
            return students;
        }
    }
}
