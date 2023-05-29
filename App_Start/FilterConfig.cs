using System.Web;
using System.Web.Mvc;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
