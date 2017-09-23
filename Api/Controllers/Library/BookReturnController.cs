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
using Business.Facede.Library.Query;
using Business.Facede.Models;

namespace Api.Controllers.Library
{
    public class BookReturnController : ApiController
    {
        private readonly IQueryFor<int, IEnumerable<ReturnBook>> returnBookQuery;

        private readonly ICommandHandler<ReturnBook> updateBookReturnCommandHandler;
        public BookReturnController()
        {
            this.returnBookQuery = new ReturnBookQuery();
            this.updateBookReturnCommandHandler = new UpdateBookReturnCommandHandler();
        }

        public HttpResponseMessage Get([FromUri] int studentId)
        {
            var books = this.returnBookQuery.ExecuteQueryWith(studentId);
            foreach (var book in books)
            {
                if(DateTime.Today > book.BookDueDate)
                {
                    var d = DateTime.Today - book.BookDueDate;
                    book.FineAmount = d.Days;
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, books);
        }

        public HttpResponseMessage Put([FromBody] ReturnBook book)
        {
                this.updateBookReturnCommandHandler.Execute(book);
                return Request.CreateResponse(HttpStatusCode.OK, "Book returned successfully");
        }
    }
}
