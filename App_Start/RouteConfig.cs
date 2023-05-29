using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Employee",
                url: "Employee/{action}/{id}",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Farmer",
                url: "Farmer/{action}/{id}",
                defaults: new { controller = "Farmer", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddFarmer",
                url: "Employee/AddFarmer",
                defaults: new { controller = "Employee", action = "AddFarmer" }
            );

            routes.MapRoute(
                name: "EmployeeLogout",
                url: "Employee/Logout",
                defaults: new { controller = "Employee", action = "Logout" }
            );

            routes.MapRoute(
                name: "FarmerLogout",
                url: "Farmer/Logout",
                defaults: new { controller = "Farmer", action = "Logout" }
            );
        }
    }
}
