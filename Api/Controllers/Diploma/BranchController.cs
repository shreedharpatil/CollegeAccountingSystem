using Business.Facede;
using Business.Facede.Command;
using Business.Facede.Models;
using Business.Facede.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class BranchController : ApiController
    {
        private readonly ICommandHandler<Student> addBranchCommandHandler;
        private readonly IQueryAll<IEnumerable<Branch>> getAllBranchesQuery;

        public BranchController()
        {
            addBranchCommandHandler = new AddBranchCommandHandler();
            getAllBranchesQuery = new GetAllBranchesQuery();
        }

        public HttpResponseMessage Get() {
            var branches = getAllBranchesQuery.QueryAll();

            return Request.CreateResponse(HttpStatusCode.OK, branches);
        }

        public HttpResponseMessage Post([FromBody] Student student)
        {
            addBranchCommandHandler.Execute(student);
            return Request.CreateResponse(HttpStatusCode.Created, "New branch has been added successfully.");
        }
    }
}
