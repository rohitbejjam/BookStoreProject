using BookStoreEntity;
using BookStoreInterfaces;
using BookStoreRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManager
{
    public class Manager : Imanager
    {
        IRepository repository = new Repository();
        public int AddBook(BookEntity bookEntity)
        {
            int count = 0;

            if (bookEntity.Title != null && bookEntity.Author != null && bookEntity.Category != null && bookEntity.Location != null && bookEntity.Tags != null && bookEntity.Pages != 0)
            {
                count = repository.AddBook(bookEntity);
                return count;
            }
            else
            { count = -1; return count; }
        }
        public BookEntity ShowBooks(BookEntity bookEntity)
        {
            bookEntity = repository.ShowBooks(bookEntity);
            return bookEntity;
        }
        public void AddFav(string title, string author)
        {
            repository.AddFav(title, author);

        }
    }
}