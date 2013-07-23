using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using McGMVC.Models;
using MongoDB.Driver;

namespace McGMVC.DAL
{
    public class mongoBooks
    {
        public class Dal : IDisposable
        {
            private MongoServer mongoServer = null;
            private bool disposed = false;


            //private string connectionString = System.Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGO");

            private string connectionString = @"mongodb://brendan:admin@widmore.mongohq.com:10010/bmacusers";

            private string dbName = "bmacusers";
            private string collectionName = "learn";


            // Default constructor.        
            public Dal()
            {

            }


            public List<Book> GetAllBooks()
            {
                try
                {
                    MongoCollection<Book> collection = GetBooksCollection();
                    return collection.FindAll().ToList<Book>();
                }
                catch (MongoConnectionException)
                {
                    return new List<Book>();
                }
            }


            // Creates a Note and inserts it into the collection in MongoDB.
            public void CreateBook(Book book)
            {
                MongoCollection<Book> collection = getBooksCollectionForEdit();
                try
                {
                    collection.Insert(book, SafeMode.True);
                }
                catch (MongoCommandException ex)
                {
                    string msg = ex.Message;
                }
            }


            private MongoCollection<Book> GetBooksCollection()
            {
                MongoServer server = MongoServer.Create(connectionString);
                MongoDatabase database = server[dbName];
                MongoCollection<Book> bookCollection = database.GetCollection<Book>(collectionName);
                return bookCollection;
            }


            private MongoCollection<Book> getBooksCollectionForEdit()
            {
                MongoServer server = MongoServer.Create(connectionString);
                MongoDatabase database = server[dbName];
                MongoCollection<Book> bookCollection = database.GetCollection<Book>(collectionName);
                return bookCollection;
            }


            # region IDisposable


            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }


            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        if (mongoServer != null)
                        {
                            this.mongoServer.Disconnect();
                        }
                    }
                }


                this.disposed = true;
            }


            # endregion
        }


    }
}
   