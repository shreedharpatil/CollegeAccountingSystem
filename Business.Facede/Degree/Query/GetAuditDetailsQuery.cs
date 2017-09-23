using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Degree.Query
{
   public class GetAuditDetailsQuery : IQueryFor<Student, IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(Student input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.DEGREESTUDENTS.All()
              .Join(db.DEGREEFEES, out fees)
              .On(db.DEGREESTUDENTS.ID == fees.STUDENT_ID)
              .Join(db.BRANCH, out branch)
              .On(db.DEGREESTUDENTS.BRANCH_ID == branch.ID)
              .Select(
                  db.DEGREESTUDENTS.ID.As("Id"),
                  db.DEGREESTUDENTS.NAME.As("Name"),
                  db.DEGREESTUDENTS.ADDRESS.As("Address"),
                  db.DEGREESTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.DEGREESTUDENTS.GENDER.As("Gender"),
                  db.DEGREESTUDENTS.QUOTA.As("Quota"),
                  db.DEGREESTUDENTS.BRANCH_ID.As("BranchId"),
                  db.DEGREESTUDENTS.IMAGE_URL.As("ImageUrl"),
                  fees.YEAR.As("Year"),
                  fees.TUTION_FEE.As("CourseFee"),
                  fees.LAB_FEE.As("LabFee"),
                  fees.LIBRARY_FEE.As("LibraryFee"),
                  fees.READING_ROOM_FEE.As("ReadingRoomFee"),
                  fees.MAGAZINE_FEE.As("MagazineFee"),
                  fees.ANNUAL_DAY_FEE.As("AnnualDayFee"),
                  fees.IDENTITY_CARD_FEE.As("IdentityCardFee"),
                  fees.STUDENT_WELFARE_FUND_FEE.As("StudentWelfareFundFee"),
                  fees.TEACHER_BENEFIT_FUND_FEE.As("TeacherBenefitFundFee"),
                  fees.COLLEGE_SPORTS_FEE.As("CollegeSportsFee"),
                  fees.APPLICATION_FEE.As("ApplicationFee"),
                  fees.HOUSE_EXAM_FEE.As("HomeExamFee"),
                  fees.MEDICAL_EXAM_FEE.As("MedicalExamFee"),
                  fees.UNION_FEE.As("UnionFee"),
                  fees.STUDENT_AID_FUND_FEE.As("StudentAidFundFee"),
                  fees.SCIENCE_DEVELOPMENT_FEE.As("ScienceDevelopmentFee"),
                  fees.UNIVERSITY_REGISTRATION_FEE.As("UniversityRegistrationFee"),
                  fees.ELIGIBILITY_APPLICATION_FEE.As("EligibilityApplicationFee"),
                  fees.ELIGIBILITY_FEE.As("EligibilityFee"),
                  fees.UNIVERSITY_SPORTS_FEE.As("UniversitySportsFee"),
                  fees.UNIVERSITY_WELFARE_FEE.As("UniversityWelfareFee"),
                  fees.CARRIER_GUIDENCE_FUND_FEE.As("CarrierGuidenceFundFee"),
                  fees.CORPUS_FUND_FEE.As("CorpusFundFee"),
                  fees.ARREAR_FEE.As("ArrearFee"),
                  fees.NSS_FEE.As("NssFee"),
                  fees.COLLEGE_DEVELOPMENT_FEE.As("CollegeDevelopmentFee"),
                  fees.UNIVERSITY_SILVER_JUBILEE_FEE.As("UniversitysilverJubileeFee"),
                  fees.MISCELLANEOUS_FEE.As("MiscellaneousFee"),
                  fees.MIS_FEE.As("MisFee"),
                  fees.FEE_PAID.As("PaidFee"),
                  fees.DUE_FEE.As("DueFee"),
                  fees.DUE_DATE.As("DueDate"),
                  fees.STATUS.As("Status"),
                  fees.TOTAL_FEE.As("TotalFee"),
                  branch.NAME.As("BranchName")
              ).Where(db.DEGREESTUDENTS.BRANCH_ID == input.BranchId && fees.YEAR_OF_ADMISSION == input.Year);

            students = query.ToList<Student>();

            return students;
        }
    }
}

