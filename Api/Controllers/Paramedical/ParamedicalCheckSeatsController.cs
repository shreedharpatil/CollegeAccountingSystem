using Business.Facede;
using Business.Facede.Models;
using Business.Facede.Paramedical.Query;
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
   public  class ParamedicalCheckSeatsController : ApiController
    {
       private readonly IQueryFor<Student, bool> checkSeatsAvailableQuery;

       public ParamedicalCheckSeatsController()
       {
           this.checkSeatsAvailableQuery = new CheckSeatsAvailableQuery();
       }

       public HttpResponseMessage Get([FromUri]Student student) {
           var status = this.checkSeatsAvailableQuery.ExecuteQueryWith(student);
           return Request.CreateResponse(HttpStatusCode.OK,status);
       }
    }
}
