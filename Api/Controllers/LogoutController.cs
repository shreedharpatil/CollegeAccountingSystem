using Business.Facede;
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
    public class LogoutController : ApiController
    {
        public HttpResponseMessage Get([FromUri] string application) {
            TakeDatabaseBackupCommand backupCommand = new TakeDatabaseBackupCommand();
            bool isSuccess = backupCommand.TakeBackup(application);
            return Request.CreateResponse(HttpStatusCode.OK,isSuccess);
        }
    }
}
