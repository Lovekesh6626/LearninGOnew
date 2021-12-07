using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LearninGO
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
        void Application_BeginRequest(object sender, EventArgs e)
{

//if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("http:/localhost:44321/"))
//{
//HttpContext.Current.Response.Clear();
//HttpContext.Current.Response.Status = "301 Moved Permanently";
//HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("http:/localhost:44321/", "http://localhost:44321/"));
//}

}
    }
}
