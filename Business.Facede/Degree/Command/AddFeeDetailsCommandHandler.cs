using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Degree.Command
{
    public class AddFeeDetailsCommandHandler : ICommandHandler<Student>
    {
        public void Execute(Student command)
        {
            var db = Database.Open();
            db.DEGREEFEES.INSERT(
                    STUDENT_ID : command.Id,
                    YEAR : command.Year,
                    TUTION_FEE : command.CourseFee,
                    LAB_FEE : command.LabFee,
                    LIBRARY_FEE : command.LibraryFee,

                    IDENTITY_CARD_FEE: command.IdentityCardFee,
                    READING_ROOM_FEE: command.ReadingRoomFee,
                    MAGAZINE_FEE: command.MagazineFee,
                    ANNUAL_DAY_FEE: command.AnnualDayFee,
                    STUDENT_WELFARE_FUND_FEE: command.StudentWelfareFundFee,
                    TEACHER_BENEFIT_FUND_FEE: command.TeacherBenefitFundFee,
                    COLLEGE_SPORTS_FEE: command.CollegeSportsFee,
                    APPLICATION_FEE: command.ApplicationFee,
                    HOUSE_EXAM_FEE: command.HomeExamFee,
                    MEDICAL_EXAM_FEE: command.MedicalExamFee,
                    UNION_FEE: command.UnionFee,
                    STUDENT_AID_FUND_FEE: command.StudentAidFundFee,
                    SCIENCE_DEVELOPMENT_FEE: command.ScienceDevelopmentFee,
                    UNIVERSITY_REGISTRATION_FEE: command.UniversityRegistrationFee,
                    ELIGIBILITY_APPLICATION_FEE: command.EligibilityApplicationFee,
                    ELIGIBILITY_FEE: command.EligibilityFee,
                    UNIVERSITY_SPORTS_FEE: command.UniversitySportsFee,
                    UNIVERSITY_WELFARE_FEE: command.UniversityWelfareFee,
                    CARRIER_GUIDENCE_FUND_FEE: command.CarrierGuidenceFundFee,
                    CORPUS_FUND_FEE: command.CorpusFundFee,
                    ARREAR_FEE: command.ArrearFee,
                    NSS_FEE: command.NssFee,
                    COLLEGE_DEVELOPMENT_FEE: command.CollegeDevelopmentFee,
                    UNIVERSITY_SILVER_JUBILEE_FEE: command.UniversitysilverJubileeFee,
                    MISCELLANEOUS_FEE: command.MiscellaneousFee, 
                    MIS_FEE : command.MisFee,
                    FEE_PAID : command.PaidFee,
                    DUE_FEE: (command.TotalFee - command.PaidFee),
                    TOTAL_FEE : command.TotalFee,
                    DUE_DATE : command.DueDate,
                    STATUS : (command.TotalFee - command.PaidFee) != 0 ? "Unpaid" : "Paid",
                    YEAR_OF_ADMISSION : DateTime.Now.Year,
                    DATE_OF_ADMISSION : DateTime.Today
                );
        }
    }
}
