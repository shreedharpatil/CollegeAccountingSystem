using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Command
{
    public class AddQuotaCommandHandler : ICommandHandler<Quota>
    {
        public void Execute(Quota command)
        {
            var db = Database.Open();
            db.QUOTA.Insert(
                QUOTA_TYPE: command.Quota_Type,
                BRANCH_ID : command.BranchId,
                NUMBER_OF_SEATS : command.NumberOfSeats
                );
        }
    }
}
