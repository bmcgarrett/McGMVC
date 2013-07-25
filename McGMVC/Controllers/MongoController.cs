using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McGMVC.DAL;
using McGMVC.Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace McGMVC.Controllers
{
    public class MongoController : Controller, IDisposable
    {
        private mongoBooks.Dal dal = new mongoBooks.Dal();
        private bool disposed = false;
        //
        // GET: /Mongo/

        public ActionResult Index()
        {
            return View(dal.GetAllBooks());
        }

        [HttpGet]
        public ActionResult Add(Book book)
        {
            try
            {
                dal.CreateBook(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dal.GetAllBooks());
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            try
            { 
                var myBookID = new ObjectId(id);
                dal.DeleteBook(myBookID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dal.GetAllBooks());
            }
        }

        [HttpGet]
        public ActionResult Edit(Book book, string id)
        {
            try
            {
                var myBookID = new ObjectId(id);
                dal.EditBook(myBookID,book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dal.GetAllBooks());
            }
        }

        #region IDisposable
        new protected void Dispose()
        {
        this.Dispose(true);
        GC.SuppressFinalize(this);
        }


        new protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dal.Dispose();
                }
            }
            this.disposed = true;
        }


        #endregion
    }
}
