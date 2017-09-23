using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Pharmacy.Command
{
    public class AddFeeDetailsCommandHandler : ICommandHandler<Student>
    {
        public void Execute(Student command)
        {
            var db = Database.Open();
            db.PHARMACYFEES.INSERT(
                    STUDENT_ID : command.Id,
                    YEAR : command.Year,
                    TUTION_FEE : command.CourseFee,
                    LAB_FEE : command.LabFee,
                    LIBRARY_FEE : command.LibraryFee,
                    OTHER_FEE : command.OtherFee,
                    ADMISSION_FEE: command.AdmissionFee,
                    HOME_EXAM_FEE: command.HomeExamFee,
                    MEDICAL_FEE: command.MedicalFee,
                    IDENTITY_CARD_FEE: command.IdentityCardFee,
                    MIS_FEE: command.MisFee,
                    LAB_DEPOSIT_FEE: command.LabDepositFee,
                    STUDENT_AID_FUND_FEE: command.StudentAidFundFee,
                    SPORTS_FEE: command.SportsFee,
                    MAGAZINE_FEE: command.MagazineFee,
                    JOURNAL_FEE: command.JournalFee,
                    CAUTION_FEE: command.CautionDepositFee,
                    FEE_PAID : command.PaidFee,
                    DUE_FEE: (command.TotalFee - command.PaidFee),
                    TOTAL_FEE : command.TotalFee,
                    DUE_DATE : command.DueDate,
                    STATUS: (command.TotalFee - command.PaidFee) != 0 ? "Unpaid" : "Paid",
                    YEAR_OF_ADMISSION : DateTime.Now.Year,
                    DATE_OF_ADMISSION : DateTime.Today
                );
        }
    }
}
