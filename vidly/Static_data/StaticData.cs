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
            new Customer { Id = 1, Name = "John Smith" },
            new Customer { Id = 2, Name = "Mary Williams" }
        };

        public readonly static List<Movie> Movies = new List<Movie>
        {
            new Movie { Id = 1, Name = "Shrek" },
            new Movie { Id = 2, Name = "Wall-E"}
        };
    }
}