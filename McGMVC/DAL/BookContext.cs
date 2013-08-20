using McGMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace McGMVC.DAL
{
    public class BookContext :DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}