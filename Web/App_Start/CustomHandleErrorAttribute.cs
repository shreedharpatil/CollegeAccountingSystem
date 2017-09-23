using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Filters;

namespace Web.App_Start
{
    public class CustomHandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            LogEntry entry = new LogEntry();
            entry.Message = context.Exception.ToString();
            entry.Categories.Add("Error");
            Logger.Write(entry);
            context.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.InternalServerError);//, "An Error has occurred. please try again later.");
        }
    }
}