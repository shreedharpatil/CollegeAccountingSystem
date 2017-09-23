using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Facede.Models;
using Simple.Data;

namespace Business.Facede.Library.Command
{
    public class AddNewBookCategoryCommandHandler : ICommandHandler<BookCategory>
    {
        public void Execute(BookCategory command)
        {
            var db = Database.Open();
            db.BOOK_CATEGORY.Insert(
                DESCRIPTION : command.Description
                );
        }
    }
}
