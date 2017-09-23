using Business.Facede;
using Business.Facede.Models;
using Business.Facede.Nursing.Command;
using Business.Facede.Nursing.Query;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Api.Controllers
{
    public class NursingBranchController : ApiController
    {
        private readonly ICommandHandler<Student> addBranchCommandHandler;
        private readonly IQueryAll<IEnumerable<Branch>> getAllBranchesQuery;

        public NursingBranchController()
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
