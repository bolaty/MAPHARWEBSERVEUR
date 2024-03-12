using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TontineMobile.WCF.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public void EcrireDansFichierLog(string vlpOrigine, string vlpMessage)
        {
            string path = TontineMobile.WSTOOLS.clsDeclaration.PATHLOGGER;
            //try { path = Server.MapPath("~/Loggers/"); } catch { }
           
            Logger loggerHT;
            //--Envoi de sms Appel url notification
            loggerHT = new Logger();
            loggerHT.Log(path, vlpOrigine, vlpMessage);
        }
    }
}