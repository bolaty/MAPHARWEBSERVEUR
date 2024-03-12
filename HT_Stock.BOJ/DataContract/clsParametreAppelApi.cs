using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsParametreAppelApi
	{

        private string _SL_RESULTATAPI = "";
		private string _AG_CODEAGENCE = "";
		private string _SL_MESSAGEAPI = "";
        private string _ET_CODEETABLISSEMENT = "";
		private string _OB_NOMOBJET = "";
        private string _OP_CODEOPERATEUR = "";
        private string _RP_DATE = "";
		private string _SL_MESSAGECLIENT = "";
		private string _SL_LIBELLE1 = "";
		private string _SL_LIBELLE2 = "";
        private string _CO_CODECOMPTE = "";
        private string _SL_MESSAGE = "";
        private string _CL_CONTACT = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_RESULTAT = "";
        public string SL_RESULTATAPI
		{
			get { return _SL_RESULTATAPI; }
			set { _SL_RESULTATAPI = value; }
		}
		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string SL_MESSAGEAPI
		{
			get { return _SL_MESSAGEAPI; }
			set { _SL_MESSAGEAPI = value; }
		}
        public string ET_CODEETABLISSEMENT
        {
            get { return _ET_CODEETABLISSEMENT; }
            set { _ET_CODEETABLISSEMENT = value; }
        }
		public string OB_NOMOBJET
		{
			get { return _OB_NOMOBJET; }
			set { _OB_NOMOBJET = value; }
		}
       
		public string RP_DATE
		{
			get { return _RP_DATE; }
			set { _RP_DATE = value; }
		}
		public string SL_MESSAGECLIENT
		{
			get { return _SL_MESSAGECLIENT; }
			set { _SL_MESSAGECLIENT = value; }
		}
		public string SL_LIBELLE1
		{
			get { return _SL_LIBELLE1; }
			set { _SL_LIBELLE1 = value; }
		}
		public string SL_LIBELLE2
		{
			get { return _SL_LIBELLE2; }
			set { _SL_LIBELLE2 = value; }
		}
        public string CO_CODECOMPTE
        {
            get { return _CO_CODECOMPTE; }
            set { _CO_CODECOMPTE = value; }
        }

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }
        public string CL_CONTACT
        {
            get { return _CL_CONTACT; }
            set { _CL_CONTACT = value; }
        }

        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }

        public clsParametreAppelApi() {}

        public clsParametreAppelApi(string SL_RESULTATAPI, string AG_CODEAGENCE, string SL_MESSAGEAPI, string _ET_CODEETABLISSEMENT, string OB_NOMOBJET, string ZN_CODEZONE, string RP_DATE, string SL_MESSAGECLIENT, string SL_LIBELLE1, string SL_LIBELLE2, string CO_CODECOMPTE, string OP_CODEOPERATEUR, string SL_MESSAGE, string CL_CONTACT, string SL_CODEMESSAGE, string SL_RESULTAT)
		{
			this.SL_RESULTATAPI = SL_RESULTATAPI;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.SL_MESSAGEAPI = SL_MESSAGEAPI;
            this._ET_CODEETABLISSEMENT = _ET_CODEETABLISSEMENT;
			this.OB_NOMOBJET = OB_NOMOBJET;
			this.RP_DATE = RP_DATE;
			this.SL_MESSAGECLIENT = SL_MESSAGECLIENT;
			this.SL_LIBELLE1 = SL_LIBELLE1;
			this.SL_LIBELLE2 = SL_LIBELLE2;
            this.CO_CODECOMPTE = CO_CODECOMPTE;
            this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
            this.SL_MESSAGE = SL_MESSAGE;
            this.CL_CONTACT = CL_CONTACT;
            this.SL_CODEMESSAGE = SL_CODEMESSAGE;
            this.SL_RESULTAT = SL_RESULTAT;
        }

		public clsParametreAppelApi(clsParametreAppelApi clsParametreAppelApi)
		{
			SL_RESULTATAPI = clsParametreAppelApi.SL_RESULTATAPI;
			AG_CODEAGENCE = clsParametreAppelApi.AG_CODEAGENCE;
			SL_MESSAGEAPI = clsParametreAppelApi.SL_MESSAGEAPI;
            _ET_CODEETABLISSEMENT = clsParametreAppelApi._ET_CODEETABLISSEMENT;
			OB_NOMOBJET = clsParametreAppelApi.OB_NOMOBJET;
			RP_DATE = clsParametreAppelApi.RP_DATE;
			SL_MESSAGECLIENT = clsParametreAppelApi.SL_MESSAGECLIENT;
			SL_LIBELLE1 = clsParametreAppelApi.SL_LIBELLE1;
			SL_LIBELLE2 = clsParametreAppelApi.SL_LIBELLE2;
            CO_CODECOMPTE = clsParametreAppelApi.CO_CODECOMPTE;
            OP_CODEOPERATEUR = clsParametreAppelApi.OP_CODEOPERATEUR;
            SL_MESSAGE = clsParametreAppelApi.SL_MESSAGE;
            CL_CONTACT = clsParametreAppelApi.CL_CONTACT;
            SL_CODEMESSAGE = clsParametreAppelApi.SL_CODEMESSAGE;
        }
        }
}