using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace dotnet_webform_site
{
    public class global : System.Web.HttpApplication
    {
        public const string bar = "hello world.";

        protected void Application_Start(object sender, EventArgs e)
        {
            String resources = "/resources/";
            String styles = resources + "styles/";
            String js = resources + "js/";
            String lib = js + "lib/";
            String bootstrap = lib + "bootstrap/";
            String jquery = lib + "jquery/";

            Application["styles"] = styles;
            Application["js"] = js;
            Application["lib"] = lib;
            Application["bootstrap"] = bootstrap;
            Application["jquery"] = jquery;
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
            string missing = System.Configuration.ConfigurationManager.AppSettings["404"].ToString();
            var serverError = Server.GetLastError() as HttpException;
            int errorCode = serverError.GetHttpCode();

            if(errorCode == 404)
            {
                Server.ClearError();
                Server.Transfer(missing, true);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}