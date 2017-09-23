using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Facede.Models;
using Simple.Data;

namespace Business.Facede.Library.Query
{
    public class ReturnBookQuery : IQueryFor<int, IEnumerable<ReturnBook>>
    {
        public IEnumerable<ReturnBook> ExecuteQueryWith(int input)
        {
            var db = Database.Open();
            dynamic books, bookstatus,branch;
            var query = 
            db.BOOK_BORROW.All()
                .Join(db.BOOKS, out books)
                .On(books.BOOK_ID == db.BOOK_BORROW.BOOK_ID)
                .Join(db.BOOK_STATUS, out bookstatus)
                .On(bookstatus.BOOK_STATUS_ID == db.BOOK_BORROW.BOOK_STATUS_ID)
                .Join(db.BRANCH, out branch)
                .On(branch.ID == db.BOOK_BORROW.STUDENT_BRANCH_ID)
                .Select(
                    db.BOOK_BORROW.TRANSACTION_ID.As("TransactionId"),
                    db.BOOK_BORROW.STUDENT_ID.As("StudentId"),
                    db.BOOK_BORROW.STUDENT_BRANCH_ID.As("BranchId"),
                    db.BOOK_BORROW.BOOK_ID.As("BookId"),
                    db.BOOK_BORROW.ISBN.As("ISBN"),
                    db.BOOK_BORROW.BOOK_ISSUE_DATE.As("BookIssueDate"),
                    db.BOOK_BORROW.BOOK_DUE_DATE.As("BookDueDate"),
                    db.BOOK_BORROW.BOOK_RETURN_DATE.As("BookReturnDate"),
                    db.BOOK_BORROW.FINE_AMOUNT.As("FineAmount"),
                    db.BOOK_BORROW.BOOK_STATUS_ID.As("BookStatusId"),
                    db.BOOK_BORROW.REMARKS.As("Remarks"),
                    bookstatus.DESCRIPTION.As("BookStatus"),
                    books.TITLE.As("Title"),
                    books.AUTHORS.As("Authors"),
                    books.PUBLISHER.As("Publishers"),
                    books.EDITION.As("Edition"),
                    books.SEMISTER.As("Semister"),
                    books.PRICE.As("Price"),
                    books.QUANTITY.As("Quantity"),
                    books.BOOK_LANGUAGE.As("Language"),
                    books.DESCRIPTION.As("Description"),
                    branch.NAME.As("BranchName")
                )
                .Where(db.BOOK_BORROW.STUDENT_ID == input && db.BOOK_BORROW.BOOK_STATUS_ID == 1);

            return query.ToList<ReturnBook>();
        }
    }
}
