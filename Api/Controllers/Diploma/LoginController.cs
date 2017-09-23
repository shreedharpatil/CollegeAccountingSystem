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
using System.Web.Http;

namespace Api.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IQueryFor<Login, Login> loginQuery;

        public LoginController()
        {
            loginQuery = new LoginQuery();
        }

       public HttpResponseMessage Post([FromBody] Login login) {
            var login11 = loginQuery.ExecuteQueryWith(login);
            var response = new Login()
            {
                Status = login11 != null,
                Path = "/admin/index.html"
            };
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
    }
}
