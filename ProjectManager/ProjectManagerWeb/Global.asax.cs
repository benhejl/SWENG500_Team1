using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectManagerWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {

        //void Application_Start(object sender, EventArgs e)
        //{
        //    // Code that runs on application startup

        //}

        //public class FilterConfig
        //{
        //    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //    {
        //        filters.Add(new HandleErrorAttribute());
        //    }
        //}

        //public class RouteConfig
        //{
        //    public static void RegisterRoutes(RouteCollection routes)
        //    {
        //        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


        //        routes.MapRoute(
        //            "Issue",
        //            "Issue/{id}/",
        //            new { controller = "Issue", action = "Index", id = "" }
        //            );


        //        routes.MapRoute(
        //            name: "Default",
        //            url: "{controller}/{action}/{id}",
        //            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //        );
        //    }
        //}

        //public static class WebApiConfig
        //{
        //    public static void Register(HttpConfiguration config)
        //    {
        //        config.Routes.MapHttpRoute(
        //            name: "DefaultApi",
        //            routeTemplate: "api/{controller}/{id}",
        //            defaults: new { id = RouteParameter.Optional }
        //        );
        //    }
        //}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        //void Application_End(object sender, EventArgs e)
        //{
        //    //  Code that runs on application shutdown

        //}

        //void Application_Error(object sender, EventArgs e)
        //{
        //    // Code that runs when an unhandled error occurs

        //}

        //void Session_Start(object sender, EventArgs e)
        //{
        //    // Code that runs when a new session is started

        //}

        //void Session_End(object sender, EventArgs e)
        //{
        //    // Code that runs when a session ends. 
        //    // Note: The Session_End event is raised only when the sessionstate mode
        //    // is set to InProc in the Web.config file. If session mode is set to StateServer 
        //    // or SQLServer, the event is not raised.

        //}

    }
}
