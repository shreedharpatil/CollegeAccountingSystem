using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Facede;
using Business.Facede.Library.Query;
using Business.Facede.Models;

namespace Api.Controllers.Library
{
    public class SearchBookController : ApiController
    {
        private readonly IQueryFor<BookSearchCriteria, IEnumerable<Book>> bookSearchQuery;

        public SearchBookController()
        {
                this.bookSearchQuery = new BookSearchQuery();
        }

        public HttpResponseMessage Get([FromUri] BookSearchCriteria searchCriteria)
        {
            var books = this.bookSearchQuery.ExecuteQueryWith(searchCriteria);

            return Request.CreateResponse(HttpStatusCode.OK, books);
        }
    }
}
