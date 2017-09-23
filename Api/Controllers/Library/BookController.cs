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

namespace Api.Controllers.Library
{
    public class BookController : ApiController
    {
        private readonly ICommandHandler<Book> addNewBookCommandHandler;

        public BookController()
        {
            this.addNewBookCommandHandler = new AddNewBookCommandHandler();
        }

        public HttpResponseMessage Post([FromBody] Book book)
        {
            this.addNewBookCommandHandler.Execute(book);
            return Request.CreateResponse(HttpStatusCode.Created, "New Book Added successfully.");
        }
    }
}
