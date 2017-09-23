using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Nursing.Command
{
    public class AddFeeDetailsCommandHandler : ICommandHandler<Student>
    {
        public void Execute(Student command)
        {
            var db = Database.Open();
            db.NURSINGFEES.INSERT(
                    STUDENT_ID : command.Id,
                    YEAR : command.Year,
                    TUTION_FEE : command.CourseFee,
                    LAB_FEE : command.LabFee,
                    LIBRARY_FEE : command.LibraryFee,
                    OTHER_FEE : command.OtherFee,
                    ADMISSION_FEE: command.AdmissionFee,
                    PHYCHIATRIC_FEE: command.PhyciatricFee,
                    MEDICAL_FEE: command.MedicalFee,
                    TRANSPORTATION_FEE: command.TransportationFee,
                    EXAMINATION_FEE: command.ExaminationFee,
                    HOSTEL_FEE: command.HostelFee,
                    MESS_FEE: command.MessFee,
                    SPORTS_FEE: command.SportsFee,
                    BOOK_FEE: command.BooksFee,
                    UNIFORM_FEE: command.UniformFee,
                    CAUTION_DEPOSIT_FEE: command.CautionDepositFee,
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
