using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace McGMVC.Models
{
    public class Book
    {
        public int _id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

}