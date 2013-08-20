using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McGMVC.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int idNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}