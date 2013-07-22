using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McGMVC.Models;

namespace McGMVC.Controllers
{
    public class MongoController : Controller
    {
        //
        // GET: /Mongo/

        public ActionResult Index()
        {
            var model1 = new Book();
            model1._id = 08898933;
            model1.Title = "Node.JS in Action";
            model1.Author = "McGarrett, Brendan";
            var model2 = new Book();
            model2._id = 08523424;
            model2.Title = "SharePoint 2013";
            model2.Author = "Doe, John";
            var books = new List<Book>();
            books.Add(model1);
            books.Add(model2);
            return View(books);
        }

    }
}
