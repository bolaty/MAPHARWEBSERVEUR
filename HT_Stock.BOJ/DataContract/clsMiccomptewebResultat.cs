using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsMiccomptewebResultat : clsEntitieBase
    {

        #region VARIABLES LOCALES

        private string _SL_TELEPHONE = "";
        private string _SL_INDICATIF = "";
        private string _SL_MONTANTOPERATION = "";
        private string _SL_URLNOTIFICATION = "";

        private string _PV_CODEPOINTVENTE = "";
        private string _CO_CODECOMPTE = "";
        private string _OB_NOMOBJET = "";
        //clsMiccomptewebResultat.PV_CODEPOINTVENTE, clsMiccomptewebResultat.CO_CODECOMPTE, clsResultatOperationListe[0].OB_NOMOBJET, clsMiccomptewebResultat.CL_TELEPHONE

        private string _SL_CODEMESSAGE = "";
        private string _SL_MESSAGE = "";
        private string _SL_RESULTAT = "";
        private string _SL_NUMEROTRANSACTION = "";
        private string _SL_RESULTATAPI = "";
        private string _SL_MESSAGEAPI = "";
        private string _SL_MESSAGECLIENT = "";
        private string _CL_IDCLIENT = "";
        private string _TK_TOKEN = "";
        private List<clsReedition> _clsReeditions = null;
        #endregion

        #region ACCESSEURS




        public string SL_TELEPHONE
        {
            get { return _SL_TELEPHONE; }
            set { _SL_TELEPHONE = value; }
        }

        public string SL_INDICATIF
        {
            get { return _SL_INDICATIF; }
            set { _SL_INDICATIF = value; }
        }
        public string SL_MONTANTOPERATION
        {
            get { return _SL_MONTANTOPERATION; }
            set { _SL_MONTANTOPERATION = value; }
        }
        public string SL_URLNOTIFICATION
        {
            get { return _SL_URLNOTIFICATION; }
            set { _SL_URLNOTIFICATION = value; }
        }




        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }


        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }


        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }
        public string SL_NUMEROTRANSACTION
        {
            get { return _SL_NUMEROTRANSACTION; }
            set { _SL_NUMEROTRANSACTION = value; }
        }

        public string PV_CODEPOINTVENTE
        {
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
        }
        public string CO_CODECOMPTE
        {
            get { return _CO_CODECOMPTE; }
            set { _CO_CODECOMPTE = value; }
        }
        public string OB_NOMOBJET
        {
            get { return _OB_NOMOBJET; }
            set { _OB_NOMOBJET = value; }
        }

        public string SL_RESULTATAPI
        {
            get { return _SL_RESULTATAPI; }
            set { _SL_RESULTATAPI = value; }
        }

        public string SL_MESSAGEAPI
        {
            get { return _SL_MESSAGEAPI; }
            set { _SL_MESSAGEAPI = value; }
        }
        public string SL_MESSAGECLIENT
        {
            get { return _SL_MESSAGECLIENT; }
            set { _SL_MESSAGECLIENT = value; }
        }
        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }

        public List<clsReedition> clsReeditions
        {
            get { return _clsReeditions; }
            set { _clsReeditions = value; }
        }
        public string TK_TOKEN
        {
            get { return _TK_TOKEN; }
            set { _TK_TOKEN = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsMiccomptewebResultat() { }

        public clsMiccomptewebResultat(clsMiccomptewebResultat clsMiccomptewebResultat)
        {

            

            this.SL_TELEPHONE = clsMiccomptewebResultat.SL_TELEPHONE;
            this.SL_INDICATIF = clsMiccomptewebResultat.SL_INDICATIF;
            this.SL_MONTANTOPERATION = clsMiccomptewebResultat.SL_MONTANTOPERATION;
            this.SL_URLNOTIFICATION = clsMiccomptewebResultat.SL_URLNOTIFICATION;

            this.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
            this.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
            this.SL_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
            this.PV_CODEPOINTVENTE = clsMiccomptewebResultat.PV_CODEPOINTVENTE;
            this.CO_CODECOMPTE = clsMiccomptewebResultat.CO_CODECOMPTE;
            this.OB_NOMOBJET = clsMiccomptewebResultat.OB_NOMOBJET;
            this.SL_RESULTATAPI = clsMiccomptewebResultat.SL_RESULTATAPI;
            this.SL_MESSAGEAPI = clsMiccomptewebResultat.SL_MESSAGEAPI;
            this.SL_MESSAGECLIENT = clsMiccomptewebResultat.SL_MESSAGECLIENT;
            this.CL_IDCLIENT = clsMiccomptewebResultat.CL_IDCLIENT;
            this.clsReeditions = clsMiccomptewebResultat.clsReeditions;
            this.TK_TOKEN = clsMiccomptewebResultat.TK_TOKEN;
            //private string _PV_CODEPOINTVENTE = "";
            //private string _CO_CODECOMPTE = "";
            //private string _OB_NOMOBJET = "";
        }

        #endregion


    }
}