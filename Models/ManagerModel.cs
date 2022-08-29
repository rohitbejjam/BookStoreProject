using BookStoreEntity;
using BookStoreInterfaces;
using BookStoreManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ManagerModel
    {
        public int AddBook(BookModelEntity bookModelEntity)
        {
            BookEntity bookEntity = new BookEntity();
            bookEntity.Title = bookModelEntity.Title;
            bookEntity.Author = bookModelEntity.Author;
            bookEntity.Category = bookModelEntity.Category;
            bookEntity.Location = bookModelEntity.Location;
            bookEntity.Pages = bookModelEntity.Pages;
            bookEntity.Tags = bookModelEntity.Tags;
            Imanager imanager = new Manager();
            int count = imanager.AddBook(bookEntity);
            return count;
        }
        public BookModelEntity ShowBooks(BookModelEntity bookModelEntity1)
        {
            List<BookModelEntity> list = new List<BookModelEntity>();
            List<BookModelEntity> flist = new List<BookModelEntity>();
            BookEntity bookEntity = new BookEntity();
            Imanager imanager = new Manager();
            bookEntity = imanager.ShowBooks(bookEntity);
            foreach (BookEntity entity in bookEntity.BookList)
            {
                BookModelEntity bookModelEntity = new BookModelEntity();
                bookModelEntity.Title = entity.Title;
                bookModelEntity.Author = entity.Author;
                bookModelEntity.Category = entity.Category;
                bookModelEntity.Location = entity.Location;
                bookModelEntity.Pages = entity.Pages;
                bookModelEntity.Tags = entity.Tags;
                list.Add(bookModelEntity);
            }
            bookModelEntity1.BookList = list;
            foreach (BookEntity entity in bookEntity.List)
            {
                BookModelEntity bookModelEntity = new BookModelEntity();
                bookModelEntity.Title = entity.Title;
                bookModelEntity.Author = entity.Author;

                flist.Add(bookModelEntity);
            }
            bookModelEntity1.List = flist;
            return bookModelEntity1;
        }
        public void AddFav(string title, string author)
        {
            Imanager imanager = new Manager();
            imanager.AddFav(title, author);
        }
    }
}

