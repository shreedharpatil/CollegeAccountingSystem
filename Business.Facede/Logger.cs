using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede
{
    public class Logger : ILogger
    {
        public void Log(Exception exception)
        {
            LogEntry logEntry = new LogEntry();
            logEntry.Categories.Add("Error");
            logEntry.Message = exception.ToString();
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logEntry);
        }
    }
}
