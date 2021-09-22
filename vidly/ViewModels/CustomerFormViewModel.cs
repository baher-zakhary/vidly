using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        // We use IEnumerable (interface) to make our code loosely coupled instead of using concrete implementations
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
        public string Title {
            get
            {
                if (Customer == null || Customer.Id == 0)
                    return "Add Customer";
                else
                    return "Edit Customer";
            }
        }
    }
}