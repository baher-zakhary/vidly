using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.DTOs
{
    public class RentalDto
    {
        public int Id { get; set; }

        public List<int> MovieIds { get; set; }

        public int CustomerId { get; set; }
    }
}