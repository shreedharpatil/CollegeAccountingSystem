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
    public class StudentSearchController : ApiController
    {
        private readonly IQueryFor<BookSearchCriteria, IEnumerable<Student>> studentSearchQuery;

        public StudentSearchController()
        {
            this.studentSearchQuery = new StudentSearchQuery(); 
        }

        public HttpResponseMessage Get([FromUri] BookSearchCriteria searchCriteria)
        {
            var students = this.studentSearchQuery.ExecuteQueryWith(searchCriteria);
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }
    }
}
