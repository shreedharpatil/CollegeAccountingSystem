using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede
{
    public interface IQueryFor<in T1, out T2>
    {
        T2 ExecuteQueryWith(T1 input);
    }
}
