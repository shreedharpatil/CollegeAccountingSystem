using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Command
{
    public class UpdateFeeDetailsCommandHandler : ICommandHandler<Student>
    {
        public void Execute(Student command)
        {
            var db = Database.Open();
            command.PaidFee = command.PaidFee + command.DueFee;
            var status = (command.TotalFee - command.PaidFee) != 0 ? "Unpaid" : "Paid";
            db.DIPLOMAFEES.UpdateByYEARAndSTUDENT_ID(
                FEE_PAID: command.PaidFee,
                    DUE_FEE: command.TotalFee - command.PaidFee,
                    DUE_DATE: command.DueDate,
                    STATUS: status,
                    YEAR: command.Year,
                    STUDENT_ID: command.Id
                    );
                //).Where(db.FEES.YEAR == command.Year && db.FEES.STUDENT_ID == command.Id);
        }
    }
}
