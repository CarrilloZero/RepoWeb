using System.Web;
using System.Web.Mvc;

namespace TesisWenAdmin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
        }
    }
}
