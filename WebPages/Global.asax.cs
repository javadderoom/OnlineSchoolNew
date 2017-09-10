using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;
using System.Web.SessionState;

namespace WebPages
{
    public class Global : System.Web.HttpApplication
    {
        private void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapPageRoute("R1", "Dashborad", "~/Dashboard.aspx");
            routes.MapPageRoute("R2", "News", "~/News.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //Telerik.Reporting.Services.WebApi.ReportsControllerConfiguration.RegisterRoutes(System.Web.Http.GlobalConfiguration.Configuration);
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}