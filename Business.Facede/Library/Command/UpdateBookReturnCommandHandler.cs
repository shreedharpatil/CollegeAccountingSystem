using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Facede.Models;
using Simple.Data;

namespace Business.Facede.Library.Command
{
    public class UpdateBookReturnCommandHandler : ICommandHandler<ReturnBook>
    {
        public void Execute(ReturnBook command)
        {
            var db = Database.Open();
            db.BOOK_BORROW.UpdateByTRANSACTION_ID(
                FINE_AMOUNT: command.FineAmount,
                REMARKS: command.Remarks,
                BOOK_STATUS_ID: 2,
                TRANSACTION_ID : command.TransactionId
                )
            ;
        }
    }
}
