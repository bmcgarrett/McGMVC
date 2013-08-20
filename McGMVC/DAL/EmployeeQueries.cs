using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using McGMVC.DAL;
using McGMVC.Models;

namespace McGMVC.DAL
{
    public class EmployeeQueries
    {
        public IList<Employee> NamesWithB(EmployeeContext context)
        {
            using (context)
            {
                var namesWithB = from n in context.Employees
                                 where n.FirstName.StartsWith("B")
                                 select n;
                return namesWithB.ToList();
            }
        }
    }
}