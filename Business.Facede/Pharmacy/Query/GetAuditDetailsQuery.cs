using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Pharmacy.Query
{
   public class GetAuditDetailsQuery : IQueryFor<Student, IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(Student input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.PHARMACYSTUDENTS.All()
              .Join(db.PHARMACYFEES, out fees)
              .On(db.PHARMACYSTUDENTS.ID == fees.STUDENT_ID)
              .Join(db.BRANCH, out branch)
              .On(db.PHARMACYSTUDENTS.BRANCH_ID == branch.ID)
              .Select(
                  db.PHARMACYSTUDENTS.ID.As("Id"),
                  db.PHARMACYSTUDENTS.NAME.As("Name"),
                  db.PHARMACYSTUDENTS.ADDRESS.As("Address"),
                  db.PHARMACYSTUDENTS.CONTACT_NUMBER.As("ContactNumber"),
                  db.PHARMACYSTUDENTS.GENDER.As("Gender"),
                  db.PHARMACYSTUDENTS.QUOTA.As("Quota"),
                  db.PHARMACYSTUDENTS.BRANCH_ID.As("BranchId"),
                  db.PHARMACYSTUDENTS.IMAGE_URL.As("ImageUrl"),
                  fees.YEAR.As("Year"),
                  fees.TUTION_FEE.As("CourseFee"),
                  fees.LAB_FEE.As("LabFee"),
                  fees.LIBRARY_FEE.As("LibraryFee"),
                  fees.OTHER_FEE.As("OtherFee"),

                  fees.ADMISSION_FEE.As("AdmissionFee"),

                  fees.HOME_EXAM_FEE.As("HomeExamFee"),
                  fees.MEDICAL_FEE.As("MedicalFee"),
                  fees.IDENTITY_CARD_FEE.As("IdentityCardFee"),
                  fees.MIS_FEE.As("MisFee"),
                  fees.LAB_DEPOSIT_FEE.As("LabDepositFee"),
                  fees.STUDENT_AID_FUND_FEE.As("StudentAidFundFee"),
                  fees.SPORTS_FEE.As("SportsFee"),
                  fees.MAGAZINE_FEE.As("MagazineFee"),
                  fees.JOURNAL_FEE.As("JournalFee"),
                  fees.CAUTION_FEE.As("CautionDepositFee"),

                  fees.FEE_PAID.As("PaidFee"),
                  fees.DUE_FEE.As("DueFee"),
                  fees.DUE_DATE.As("DueDate"),
                  fees.STATUS.As("Status"),
                  fees.TOTAL_FEE.As("TotalFee"),
                  branch.NAME.As("BranchName")
              ).Where(db.PHARMACYSTUDENTS.BRANCH_ID == input.BranchId && fees.YEAR_OF_ADMISSION == input.Year);

            students = query.ToList<Student>();

            return students;
        }
    }
}

