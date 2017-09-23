using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Facede;
using Business.Facede.Library.Command;
using Business.Facede.Models;
using Business.Facede.Library.Query;

namespace Api.Controllers.Library
{
    public class IssueBookController : ApiController
    {
        private readonly ICommandHandler<IssueBook> issueBookCommandHandler;

        private readonly IQueryFor<IssueBook, StudentBookBorrowStatus> bookLimitQuery;

        public IssueBookController()
        {
                this.issueBookCommandHandler = new IssueBookCommandHandler();
                this.bookLimitQuery = new BookLimitQuery();
        }

        public HttpResponseMessage Post([FromBody] IssueBook book)
        {
            var bookLimit = this.bookLimitQuery.ExecuteQueryWith(book);

            if (bookLimit.NumberOfBooksBorrowed > bookLimit.BookBorrowLimit) {
                return Request.CreateResponse(HttpStatusCode.OK, "This student has already borrowed " + bookLimit.NumberOfBooksBorrowed + " books and crossed the book limit. Cannot issue book right now.");
            }
            book.BookStatusId = 1;
            book.BookIssueDate = DateTime.Today;
            this.issueBookCommandHandler.Execute(book);
            return Request.CreateResponse(HttpStatusCode.Created, "Book issued successfully");
        }
    }
}
