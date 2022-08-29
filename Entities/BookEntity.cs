using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreEntity
{
    public class BookEntity
    {
        string _title;
        string _author;
        string _location;
        string _category;
        int _pages;
        string _tags;
        List<BookEntity> _bookList;
        List<BookEntity> _list;
        [Required]
        public string Title { get { return _title; } set { _title = value; } }
        public string Author { get { return _author; } set { _author = value; } }
        [Required]
        public string Location { get { return _location; } set { _location = value; } }
        public string Category { get { return _category; } set { _category = value; } }
        public int Pages { get { return _pages; } set { _pages = value; } }
        public string Tags { get { return _tags; } set { _tags = value; } }

        public List<BookEntity> BookList { get { return _bookList; } set { _bookList = value; } }
        public List<BookEntity> List { get { return _list; } set { _list = value; } }
    }
}