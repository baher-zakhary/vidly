using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public List<int> MovieIds { get; set; }

        public int CustomerId { get; set; }
    }
}