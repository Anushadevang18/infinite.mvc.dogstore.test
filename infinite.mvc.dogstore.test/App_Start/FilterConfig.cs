using System.Web;
using System.Web.Mvc;

namespace infinite.mvc.dogstore.test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
