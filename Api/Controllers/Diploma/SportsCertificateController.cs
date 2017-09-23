using Business.Facede;
using Business.Facede.Models;
using Business.Facede.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Api.Controllers
{
    public class SportsCertificateController : ApiController
    {
        private readonly IQueryAll<IEnumerable<string>> getYearsQuery;

        public SportsCertificateController()
        {
            this.getYearsQuery = new GetYearsQuery();
        }

        public HttpResponseMessage Get() {
            GenerateSportsCertificate pdf = new GenerateSportsCertificate();
           
            var ms = pdf.ExecuteQueryWith(null);

            HttpResponse Response = HttpContext.Current.Response;
            Response.ContentType = "pdf/application";
            Response.AddHeader("content-disposition", "attachment;filename=FeeReceipt.pdf");
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);

            return Request.CreateResponse(HttpStatusCode.OK);
        }        
    }
}
