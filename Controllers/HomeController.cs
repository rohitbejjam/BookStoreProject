using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BookStore.Controllers
{
    public class MainController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult Search()
        {
            BookModelEntity bookModelEntity = new BookModelEntity();
            ManagerModel managerModel = new ManagerModel();
            bookModelEntity = managerModel.ShowBooks(bookModelEntity);
            //bookModelEntity.BookList = bookList;
            return View(bookModelEntity);
        }
        public ActionResult AddBook(BookModelEntity bookModelEntity)
        {
            ManagerModel managerModel = new ManagerModel();
            int count = managerModel.AddBook(bookModelEntity);
            if (count == 0)
            {

                return RedirectToAction("Added");
            }
            else
            {

                return RedirectToAction("Error");
            }
        }
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Main");
        }
        public ActionResult AddFav(string title, string author)
        {
            ManagerModel managerModel = new ManagerModel();
            managerModel.AddFav(title, author);
            return RedirectToAction("Added");
        }
        public ActionResult Added()
        {

            return RedirectToAction("Index", "Main");
        }

    }
}
