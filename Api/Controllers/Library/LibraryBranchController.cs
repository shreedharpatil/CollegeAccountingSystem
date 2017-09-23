using Business.Facede;
using Business.Facede.Library.Command;
using Business.Facede.Models;
using Business.Facede.Library.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers.Library
{
    public class LibraryBranchController : ApiController
    {
        private readonly ICommandHandler<Student> addBranchCommandHandler;
        private readonly IQueryFor<string, IEnumerable<Branch>> getAllBranchesQuery;

        public LibraryBranchController()
        {
            getAllBranchesQuery = new GetAllBranchesQuery();
        }

        public HttpResponseMessage Get([FromUri] string application) {
            var branches = getAllBranchesQuery.ExecuteQueryWith(application);

            return Request.CreateResponse(HttpStatusCode.OK, branches);
        }
    }
}
