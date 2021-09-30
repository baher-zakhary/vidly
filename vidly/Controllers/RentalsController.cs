using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vidly.Controllers
{
    public class RentalsController : Controller
    {
        // GET: NewRental
        public ActionResult New()
        {
            return View();
        }
    }
}