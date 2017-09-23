using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Business.Facede.Models;
using Simple.Data;

namespace Business.Facede.Library.Command
{
    public class AddNewBookCommandHandler : ICommandHandler<Book>
    {
        public void Execute(Book command)
        {
            var db = Database.Open();
            db.BOOKS.Insert(
                ISBN : command.ISBN,
                Title : command.Title,
                AUTHORS : command.Authors,
                PUBLISHER : command.Publishers,
                EDITION : command.Edition,
                BRANCH_ID : command.BranchId,
                SEMISTER : command.Semister,
                PRICE : command.Price,
                QUANTITY : command.Quantity,
                BOOK_LANGUAGE : command.Language,
                DESCRIPTION : command.Description,
                CATEGORY_ID : command.CategoryId
                );
        }
    }
}
