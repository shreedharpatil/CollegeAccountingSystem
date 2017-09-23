using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Library.Query
{
    public class GetAllBranchesQuery : IQueryFor<string, IEnumerable<Branch>>
    {

        public IEnumerable<Branch> ExecuteQueryWith(string input)
        {
            var db = Database.Open();
            var query = db.BRANCH.All();
            if (input != null)
            {
                query = query.Where(db.BRANCH.APPLICATION == input);
            }

            IEnumerable<Branch> branches = query.ToList<Branch>();
            return branches;
        }
    }
}
