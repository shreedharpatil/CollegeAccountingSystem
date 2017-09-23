using Business.Facede;
using Business.Facede.Command;
using Business.Facede.Models;
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
    public class QuotaController : ApiController
    {
        private readonly ICommandHandler<Quota> addQuotaCommandHandler;

        public QuotaController()
        {
            addQuotaCommandHandler = new AddQuotaCommandHandler();
        }

        public HttpResponseMessage Post([FromBody]Quota quota)
        {
            addQuotaCommandHandler.Execute(quota);
            return Request.CreateResponse(HttpStatusCode.Created, "Details has been saved successfully.");
        }
    }
}
