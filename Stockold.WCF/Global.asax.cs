using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TontineMobile.WCF
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            TontineMobile.WSTOOLS.clsDeclaration.PATHLOGGER =  Server.MapPath("~/Loggers/");

            Controllers.LogController Logger = new Controllers.LogController();

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string vlpMessage = "";
                Logger.EcrireDansFichierLog("pvgUserLogin", "======================================== current Timestamp" + HttpContext.Current.Timestamp);
                vlpMessage = "Request URL" + HttpContext.Current.Request.Url + "\n-" + "-current Timestamp" + HttpContext.Current.Timestamp+ "\n-Object in Application level " + HttpContext.Current.Application.Count+ "\n-Is Debug Enable in current Mode?" + HttpContext.Current.IsDebuggingEnabled;
                Logger.EcrireDansFichierLog("pvgUserLogin", vlpMessage);
            }


            //Response.Write("Request URL" + HttpContext.Current.Request.Url);
            //    Response.Write("Number of Session variable" + HttpContext.Current.Session.Count);
            //    Response.Write("current Timestamp" + HttpContext.Current.Timestamp);
            //    Response.Write("Object in Application level " + HttpContext.Current.Application.Count);
            //    Response.Write("Is Debug Enable in current Mode?" + HttpContext.Current.IsDebuggingEnabled);



            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");//http://localhost:8100
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "*");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE,OPTIONS");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }

        

        }
    }
}
