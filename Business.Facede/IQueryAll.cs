using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede
{
   public interface IQueryAll<out T1>
    {
       T1 QueryAll();
    }
}
