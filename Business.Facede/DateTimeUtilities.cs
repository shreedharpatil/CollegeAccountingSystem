using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede
{
    public static class DateTimeUtilities
    {
        public static string  FormatDate(this DateTime datetime,string format=null){
            if (format != null)
            {
                format = "dd-MMM-yyyy";
            }
            else {
                format = "dd/MMM/yyyy";
            }
            return datetime.ToString(format);
        }
    }
}
