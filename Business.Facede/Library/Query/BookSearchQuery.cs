using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Facede.Models;
using Simple.Data;

namespace Business.Facede.Library.Query
{
    public class BookSearchQuery : IQueryFor<BookSearchCriteria, IEnumerable<Book>>
    {
        public IEnumerable<Book> ExecuteQueryWith(BookSearchCriteria input)
        {
            var db = Database.Open();
            dynamic branches, categories;

            SimpleQuery query = db.BOOKS.All()
                .Join(db.BRANCH, out branches)
                .On(branches.ID == db.BOOKS.BRANCH_ID)
                .Join(db.BOOK_CATEGORY, out categories)
                .On(categories.BOOK_ID == db.BOOKS.CATEGORY_ID)
                .Select(
                db.BOOKS.BOOK_ID.As("BookId"),
                db.BOOKS.ISBN.As("ISBN"),
                db.BOOKS.TITLE.As("Title"),
                db.BOOKS.AUTHORS.As("Authors"),
                db.BOOKS.PUBLISHER.As("Publishers"),
                db.BOOKS.EDITION.As("Edition"),
                db.BOOKS.BRANCH_ID.As("BranchId"),
                branches.NAME.As("BranchName"),
                db.BOOKS.SEMISTER.As("Semister"),
                db.BOOKS.PRICE.As("Price"),
                db.BOOKS.QUANTITY.As("Quantity"),
                db.BOOKS.BOOK_LANGUAGE.As("Language"),
                db.BOOKS.CATEGORY_ID.As("CategoryId"),
                categories.DESCRIPTION.As("CategoryName"),
                db.BOOKS.DESCRIPTION.As("Description")
                );
            query = query.Where(db.BOOKS.BRANCH_ID == input.BranchId && db.BOOKS.CATEGORY_ID == input.CategoryId);

            return query.ToList<Book>();
        }
    }
}
