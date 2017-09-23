using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Degree.Query
{
    public class GetStudentFeeDetailsQuery : IQueryFor<int,IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(int input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.DEGREEFEES.All()            
              .Select(
                  db.DEGREEFEES.YEAR.As("Year"),
                  db.DEGREEFEES.TUTION_FEE.As("CourseFee"),
                  db.DEGREEFEES.LAB_FEE.As("LabFee"),
                  db.DEGREEFEES.LIBRARY_FEE.As("LibraryFee"),
                   db.DEGREEFEES.IDENTITY_CARD_FEE.As("IdentityCardFee"),
                  db.DEGREEFEES.READING_ROOM_FEE.As("ReadingRoomFee"),
                  db.DEGREEFEES.MAGAZINE_FEE.As("MagazineFee"),
                  db.DEGREEFEES.ANNUAL_DAY_FEE.As("AnnualDayFee"),
                  db.DEGREEFEES.STUDENT_WELFARE_FUND_FEE.As("StudentWelfareFundFee"),
                  db.DEGREEFEES.TEACHER_BENEFIT_FUND_FEE.As("TeacherBenefitFundFee"),
                  db.DEGREEFEES.COLLEGE_SPORTS_FEE.As("CollegeSportsFee"),
                  db.DEGREEFEES.APPLICATION_FEE.As("ApplicationFee"),
                  db.DEGREEFEES.HOUSE_EXAM_FEE.As("HomeExamFee"),
                  db.DEGREEFEES.MEDICAL_EXAM_FEE.As("MedicalExamFee"),
                  db.DEGREEFEES.UNION_FEE.As("UnionFee"),
                  db.DEGREEFEES.STUDENT_AID_FUND_FEE.As("StudentAidFundFee"),
                  db.DEGREEFEES.SCIENCE_DEVELOPMENT_FEE.As("ScienceDevelopmentFee"),
                  db.DEGREEFEES.UNIVERSITY_REGISTRATION_FEE.As("UniversityRegistrationFee"),
                  db.DEGREEFEES.ELIGIBILITY_APPLICATION_FEE.As("EligibilityApplicationFee"),
                  db.DEGREEFEES.ELIGIBILITY_FEE.As("EligibilityFee"),
                  db.DEGREEFEES.UNIVERSITY_SPORTS_FEE.As("UniversitySportsFee"),
                  db.DEGREEFEES.UNIVERSITY_WELFARE_FEE.As("UniversityWelfareFee"),
                  db.DEGREEFEES.CARRIER_GUIDENCE_FUND_FEE.As("CarrierGuidenceFundFee"),
                  db.DEGREEFEES.CORPUS_FUND_FEE.As("CorpusFundFee"),
                  db.DEGREEFEES.ARREAR_FEE.As("ArrearFee"),
                  db.DEGREEFEES.NSS_FEE.As("NssFee"),
                  db.DEGREEFEES.COLLEGE_DEVELOPMENT_FEE.As("CollegeDevelopmentFee"),
                  db.DEGREEFEES.UNIVERSITY_SILVER_JUBILEE_FEE.As("UniversitysilverJubileeFee"),
                  db.DEGREEFEES.MISCELLANEOUS_FEE.As("MiscellaneousFee"),
                  db.DEGREEFEES.FEE_PAID.As("PaidFee"),
                  db.DEGREEFEES.DUE_FEE.As("DueFee"),
                  db.DEGREEFEES.DUE_DATE.As("DueDate"),
                  db.DEGREEFEES.STATUS.As("Status"),
                  db.DEGREEFEES.TOTAL_FEE.As("TotalFee"),
                  db.DEGREEFEES.MIS_FEE.As("MisFee"),
                  db.DEGREEFEES.DATE_OF_ADMISSION.As("DateOfAdmission")
              ).Where(db.DEGREEFEES.STUDENT_ID == input);

            students = query.ToList<Student>();
            return students;
        }
    }
}
