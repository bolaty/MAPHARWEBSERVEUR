using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsMiccomptewebmotpasseoublie : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _PV_CODEPOINTVENTE = "";
		private string _RP_DATE = "";
		private string _RP_NUMSEQUENCE = "";
		private string _TI_IDTIERS = "";
		private string _MB_IDTIERS = "";
		private string _OP_CODEOPERATEUR = "";
		private string _RP_CODEVALIDATION = "";
        private string _RP_HEURE = "";
		private string _RP_EMAIL = "";
		private string _RP_DATECLOTURE = "";
		private string _DATEJOURNEE = "";
		private string _CL_CONTACT = "";
		private string _CL_CODECLIENT = "";
        private string _SL_VERSIONAPK = "";
        private string _LG_CODELANGUE = "";
        private string _OS_MACADRESSE = "";
        private string _TYPEOPERATION = "";
        private string _SL_MESSAGEOBJET = "";
		private string _AG_EMAIL = "";
		private string _AG_EMAILMOTDEPASSE = "";
		private string _SL_MESSAGECLIENT = "";
		private string _OB_NOMOBJET = "";
		private string _SL_RESULTATAPI = "";
		private string _SL_MESSAGEAPI = "";
		private string _SL_MOTPASSEOLD = "";
		private string _SL_LOGINOLD = "";
		private string _SL_MOTPASSENEW = "";
		private string _SL_LOGINNEW = "";

        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}
        public string PV_CODEPOINTVENTE
        {
			get { return _PV_CODEPOINTVENTE; }
			set { _PV_CODEPOINTVENTE = value; }
		}
		public string RP_DATE
		{
			get { return _RP_DATE; }
			set {  _RP_DATE = value; }
		}

		public string RP_NUMSEQUENCE
		{
			get { return _RP_NUMSEQUENCE; }
			set {  _RP_NUMSEQUENCE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string MB_IDTIERS
		{
			get { return _MB_IDTIERS; }
			set {  _MB_IDTIERS = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string RP_CODEVALIDATION
		{
			get { return _RP_CODEVALIDATION; }
			set {  _RP_CODEVALIDATION = value; }
		}

        public string RP_HEURE
		{
			get { return _RP_HEURE; }
			set {  _RP_HEURE = value; }
		}

		public string RP_EMAIL
		{
			get { return _RP_EMAIL; }
			set {  _RP_EMAIL = value; }
		}

		public string RP_DATECLOTURE
		{
			get { return _RP_DATECLOTURE; }
			set {  _RP_DATECLOTURE = value; }
		}
		public string DATEJOURNEE
        {
			get { return _DATEJOURNEE; }
			set { _DATEJOURNEE = value; }
		}
		public string CL_CONTACT
        {
			get { return _CL_CONTACT; }
			set { _CL_CONTACT = value; }
		}
		public string CL_CODECLIENT
        {
			get { return _CL_CODECLIENT; }
			set { _CL_CODECLIENT = value; }
		}
		public string OS_MACADRESSE
        {
			get { return _OS_MACADRESSE; }
			set { _OS_MACADRESSE = value; }
		}
		public string SL_MESSAGEOBJET
        {
			get { return _SL_MESSAGEOBJET; }
			set { _SL_MESSAGEOBJET = value; }
		}
		public string AG_EMAIL
        {
			get { return _AG_EMAIL; }
			set { _AG_EMAIL = value; }
		}
		public string AG_EMAILMOTDEPASSE
        {
			get { return _AG_EMAILMOTDEPASSE; }
			set { _AG_EMAILMOTDEPASSE = value; }
		}
		public string SL_MESSAGECLIENT
        {
			get { return _SL_MESSAGECLIENT; }
			set { _SL_MESSAGECLIENT = value; }
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
		public string SL_MOTPASSEOLD
        {
			get { return _SL_MOTPASSEOLD; }
			set { _SL_MOTPASSEOLD = value; }
		}
		public string SL_LOGINOLD
        {
			get { return _SL_LOGINOLD; }
			set { _SL_LOGINOLD = value; }
		}
		public string SL_MOTPASSENEW
        {
			get { return _SL_MOTPASSENEW; }
			set { _SL_MOTPASSENEW = value; }
		}
		public string SL_LOGINNEW
        {
			get { return _SL_LOGINNEW; }
			set { _SL_LOGINNEW = value; }
		}



        #endregion

        #region INSTANCIATEURS

        public clsMiccomptewebmotpasseoublie(){}
		
		public clsMiccomptewebmotpasseoublie(clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie)
		{
			this.AG_CODEAGENCE = clsMiccomptewebmotpasseoublie.AG_CODEAGENCE;
			this.PV_CODEPOINTVENTE = clsMiccomptewebmotpasseoublie.PV_CODEPOINTVENTE;
			this.RP_DATE = clsMiccomptewebmotpasseoublie.RP_DATE;
			this.RP_NUMSEQUENCE = clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE;
			this.TI_IDTIERS = clsMiccomptewebmotpasseoublie.TI_IDTIERS;
			this.MB_IDTIERS = clsMiccomptewebmotpasseoublie.MB_IDTIERS;
			this.OP_CODEOPERATEUR = clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR;
			this.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION;
			this.RP_HEURE = clsMiccomptewebmotpasseoublie.RP_HEURE;
			this.RP_EMAIL = clsMiccomptewebmotpasseoublie.RP_EMAIL;
			this.RP_DATECLOTURE = clsMiccomptewebmotpasseoublie.RP_DATECLOTURE;
			this.DATEJOURNEE = clsMiccomptewebmotpasseoublie.DATEJOURNEE;
			this.CL_CONTACT = clsMiccomptewebmotpasseoublie.CL_CONTACT;
			this.CL_CODECLIENT = clsMiccomptewebmotpasseoublie.CL_CODECLIENT;
			this.OS_MACADRESSE = clsMiccomptewebmotpasseoublie.OS_MACADRESSE;
			this.SL_MESSAGEOBJET = clsMiccomptewebmotpasseoublie.SL_MESSAGEOBJET;
			this.AG_EMAIL = clsMiccomptewebmotpasseoublie.AG_EMAIL;
			this.AG_EMAILMOTDEPASSE = clsMiccomptewebmotpasseoublie.AG_EMAILMOTDEPASSE;
			this.SL_MESSAGECLIENT = clsMiccomptewebmotpasseoublie.SL_MESSAGECLIENT;
			this.OB_NOMOBJET = clsMiccomptewebmotpasseoublie.OB_NOMOBJET;
			this.SL_RESULTATAPI = clsMiccomptewebmotpasseoublie.SL_RESULTATAPI;
			this.SL_MESSAGEAPI = clsMiccomptewebmotpasseoublie.SL_MESSAGEAPI;
			this.LG_CODELANGUE = clsMiccomptewebmotpasseoublie.LG_CODELANGUE;
			this.SL_MOTPASSEOLD = clsMiccomptewebmotpasseoublie.SL_MOTPASSEOLD;
			this.SL_LOGINOLD = clsMiccomptewebmotpasseoublie.SL_LOGINOLD;
			this.SL_MOTPASSENEW = clsMiccomptewebmotpasseoublie.SL_MOTPASSENEW;
			this.SL_LOGINNEW = clsMiccomptewebmotpasseoublie.SL_LOGINNEW;
            //  string LG_CODELANGUE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW


            //(string DATEJOURNEE, string CL_CONTACT, string CL_CODECLIENT, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string TYPEOPERATION)



        }

        #endregion

    }
}
