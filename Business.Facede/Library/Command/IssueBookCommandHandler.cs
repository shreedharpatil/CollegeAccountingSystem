using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Facede.Models;
using Simple.Data;

namespace Business.Facede.Library.Command
{
    public class IssueBookCommandHandler : ICommandHandler<IssueBook>
    {
        public void Execute(IssueBook command)
        {
            var db = Database.Open();

            db.BOOK_BORROW.Insert(
                STUDENT_ID : command.StudentId,
                STUDENT_BRANCH_ID : command.BranchId,
                BOOK_ID : command.BookId,
                ISBN : command.ISBN,
                BOOK_ISSUE_DATE : command.BookIssueDate,
                BOOK_DUE_DATE : command.BookDueDate,
                BOOK_RETURN_DATE : command.BookReturnDate,
                FINE_AMOUNT : command.FineAmount,
                BOOK_STATUS_ID : command.BookStatusId,
                REMARKS : command.Remarks
                );
        }
    }
}
