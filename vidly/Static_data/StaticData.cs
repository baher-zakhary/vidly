using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Static_data
{
    public class StaticData
    {
        public readonly static string AppTitle = "Vidly";

        public readonly static List<Customer> Customers = new List<Customer>
        {
            new Customer { Name = "John Smith" },
            new Customer { Name = "Mary Williams" }
        };
    }
}