using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DBFirst_EntityDemo
{
    //Session
    //Application

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["TotalVisitor"] = 0;//100000
        }
        protected void Session_Start(object sender,EventArgs args)
        {
            Application.Lock();
            Application["TotalVisitor"] =Convert.ToInt32(Application["TotalVisitor"]) + 1;
            Session["UserName"] = null;//Registring Session key with current session
            Session["LoginTime"] = null;
            Application.UnLock();

        }
            /*         
             Application_End()
             Session_Start()
             Session_End()
             Application_Error()
             */


        }
}
