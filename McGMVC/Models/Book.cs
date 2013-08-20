using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace McGMVC.Models
{
    public class Book
    {
        public ObjectId _id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string rating { get; set; }
    }
}