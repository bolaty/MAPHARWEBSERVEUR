using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace Stock.WSTOOLS
{
    public class clsDeclaration
    {
        #region  declaration unique de la classe

        //declaration unique de la classe clsDeclaration pour tout le projet
        private readonly static clsDeclaration ClassesDeclaration = new clsDeclaration();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsDeclaration()
        {
        }
        //constructeur public de la classe fonction 

        public static clsDeclaration ClasseDeclaration
        {
            get { return ClassesDeclaration; }
        }

        #endregion

        #region REGIONS URL ROOT
        public static string URL_ROOT_ADRESSE_API_SMS =  ConfigurationManager.AppSettings["urlApiSms"];

        #endregion

        #region URL_WEB_SERVICE
        ////URL API SMS
        public static string URL_ADRESSE_API_SMS = URL_ROOT_ADRESSE_API_SMS + "Service/wsApisms.svc/SendMessage";
        #endregion


        #region CONSTANTE
        public const string LANG_FRENCH = "FR";
        public const string LANG_ENGLISH = "EN";
        public const string ZOOM = "100";
        public const int TIMEOUT = 90000;
        #endregion

        public string SL_MESSAGEOBJET = "";
        public string SMSTEXT = "";
        public string AG_EMAIL = "";
        public string AG_EMAILMOTDEPASSE = "";


    }
}
