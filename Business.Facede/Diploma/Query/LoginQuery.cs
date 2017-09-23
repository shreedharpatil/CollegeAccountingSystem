using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Query
{
    public class LoginQuery : IQueryFor<Login,Login>
    {
        public Login ExecuteQueryWith(Login input)
        {
            var db = Database.Open();
            IEnumerable<Login> login = db.LOGIN.ALL()
                .Where(
                db.LOGIN.USERNAME == input.UserName && 
                db.LOGIN.PASSWORD == input.Password && 
                db.LOGIN.USER_TYPE == input.Type).ToList<Login>();
            return login.FirstOrDefault();
        }
    }
}
