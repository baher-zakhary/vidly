using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vidly.Controllers
{
    // Use Allow Anonymous on controller to exclude controller from global AuthorizationAttribute setup in App_Start/FilterConfig.cs
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}