using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Paramedical.Command
{
    public class AddFeeDetailsCommandHandler : ICommandHandler<Student>
    {
        public void Execute(Student command)
        {
            var db = Database.Open();
            db.PARAMEDICALFEES.INSERT(
                    STUDENT_ID : command.Id,
                    YEAR : command.Year,
                    TUTION_FEE : command.CourseFee,
                    ADMISSION_FORM_FEE : command.AdmissionFormFee,
                    LAB_FEE : command.LabFee,
                    LIBRARY_FEE : command.LibraryFee,
                    OTHER_FEE : command.OtherFee,
                    ADMISSION_FEE: command.AdmissionFee,
                    IDENTITYCARD_FEE: command.IdentityCardFee,
                    STUDENT_ASSOCIATION_FEE: command.StudentAssociationFee,
                    READING_ROOM_FEE: command.ReadingRoomFee,
                    MAGAZINE_FEE: command.MagazineFee,
                    STUDENT_WELFARE_FUND_FEE: command.StudentWelfareFundFee,
                    TEACHER_BENEFIT_FUND_FEE: command.TeacherBenefitFundFee,
                    SPORTS_FEE: command.SportsFee,
                    FINE_FEE: command.FineFee,
                    ADMISSION_FINE_FEE: command.AdmissionFineFee,
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
