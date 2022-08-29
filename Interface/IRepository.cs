using BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreInterfaces
{
    public interface IRepository
    {
        int AddBook(BookEntity bookEntity);
        BookEntity ShowBooks(BookEntity bookEntity);
        void AddFav(string title, string author);
    }
}