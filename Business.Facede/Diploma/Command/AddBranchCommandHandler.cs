using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Facede.Library.Command;

namespace Business.Facede.Command
{
    public class AddBranchCommandHandler : ICommandHandler<Student>
    {
        public void Execute(Student student)
        {
            var db = Database.Open();
            db.BRANCH.Insert(
                NAME:student.BranchName,
                APPLICATION:student.Application                
                );
        }
    }
}
