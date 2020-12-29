using chat.IoC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace chat.Pool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();

            //SqlDependency.Start(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 400;
        }

        //protected void Application_End()
        //{
        //    SqlDependency.Stop(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);
        //}
    }
}
