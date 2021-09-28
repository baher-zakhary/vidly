using System.Web;
using System.Web.Mvc;

namespace vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Apply authorization on everything in our application
            filters.Add(new AuthorizeAttribute());

            // Require HTTPS to use our App - block non secure access to our App
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
