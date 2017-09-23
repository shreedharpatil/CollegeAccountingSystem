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
    public class BookCategoryController : ApiController
    {
        private readonly ICommandHandler<BookCategory> addNewBookCategoryCommandHandler;

        private readonly IQueryAll<IEnumerable<BookCategory>> getAllBookCategoriesQuery;

        public BookCategoryController()
        {
            this.getAllBookCategoriesQuery = new GetAllBookCategoriesQuery();
            this.addNewBookCategoryCommandHandler = new AddNewBookCategoryCommandHandler();
        }

        public HttpResponseMessage Get()
        {
            var categories = this.getAllBookCategoriesQuery.QueryAll();
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        public HttpResponseMessage Post([FromBody] BookCategory bookCategory)
        {
            this.addNewBookCategoryCommandHandler.Execute(bookCategory);
            return Request.CreateResponse(HttpStatusCode.Created, "New Book category added successfully.");
        }
    }
}
