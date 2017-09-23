using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Library.Query
{
    public class BookLimitQuery : IQueryFor<IssueBook, StudentBookBorrowStatus>
    {
        public StudentBookBorrowStatus ExecuteQueryWith(IssueBook input)
        {
            var db = Database.Open();
            var bookLimitQuery = db.BOOK_LIMIT.All().Select(db.BOOK_LIMIT.BOOK_LIMIT.As("BookBorrowLimit"));
            var response = new StudentBookBorrowStatus();
            List<StudentBookBorrowStatus> limit = bookLimitQuery.ToList<StudentBookBorrowStatus>();
            ////.FirstOrDefault();
            response.BookBorrowLimit = limit != null ? limit.FirstOrDefault().BookBorrowLimit : 3;

            var studentBooksBorrowedQuery = db.BOOK_BORROW.All()
                .Where(db.BOOK_BORROW.BOOK_STATUS_ID == 1 && db.BOOK_BORROW.STUDENT_ID == input.StudentId && db.BOOK_BORROW.APPLICATION == input.Application);

            List<ReturnBook> booksBorrowed = studentBooksBorrowedQuery.ToList<ReturnBook>();
            response.NumberOfBooksBorrowed = booksBorrowed != null ? booksBorrowed.Count() : 0;
            return response;
        }
    }
}
