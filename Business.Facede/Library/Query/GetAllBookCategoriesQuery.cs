using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Library.Query
{
    public class GetAllBookCategoriesQuery : IQueryAll<IEnumerable<BookCategory>>
    {

        public IEnumerable<BookCategory> QueryAll()
        {
            var db = Database.Open();
            IEnumerable<BookCategory> branches = db.BOOK_CATEGORY.All()
                .Select(
                db.BOOK_CATEGORY.BOOK_ID.As("CategoryId"),
                db.BOOK_CATEGORY.DESCRIPTION.As("Description")
                )
                .ToList<BookCategory>();
            return branches;
        }
    }
}
