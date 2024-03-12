using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsMiccomptewebmotpasseoublie
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private DateTime _RP_DATE = DateTime.Parse("01/01/1900");
		private string _RP_NUMSEQUENCE = "";
		private string _TI_IDTIERS = "";
		private string _MB_IDTIERS = "";
		private string _OP_CODEOPERATEUR = "";
		private string _RP_CODEVALIDATION = "";
		private DateTime _RP_HEURE = DateTime.Parse("01/01/1900");
		private string _RP_EMAIL = "";
		private DateTime _RP_DATECLOTURE = DateTime.Parse("01/01/1900");
		private string _SL_RESULTAT = "";
		private string _SL_MESSAGE = "";
		private string _SL_MESSAGEOBJET = "";
		private string _AG_EMAIL = "";
		private string _AG_EMAILMOTDEPASSE = "";
		private string _SL_MESSAGECLIENT = "";
		private string _OB_NOMOBJET = "";

		private string _PV_CODEPOINTVENTE = "";
		private string _CO_CODECOMPTE = "";
		private string _SL_MESSAGEAPI = "";
		private string _SL_LIBELLE1 = "";
		private string _SL_LIBELLE2 = "";
        //     this.AG_EMAIL = clsMiccomptewebmotpasseoublie.AG_EMAIL;
        //this.AG_EMAILMOTDEPASSE = clsMiccomptewebmotpasseoublie.AG_EMAILMOTDEPASSE;
        //this.SL_MESSAGECLIENT = clsMiccomptewebmotpasseoublie.SL_MESSAGECLIENT;
        //this.OB_NOMOBJET = clsMiccomptewebmotpasseoublie.OB_NOMOBJET;


        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public DateTime RP_DATE
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

		public DateTime RP_HEURE
		{
			get { return _RP_HEURE; }
			set {  _RP_HEURE = value; }
		}

		public string RP_EMAIL
		{
			get { return _RP_EMAIL; }
			set {  _RP_EMAIL = value; }
		}

		public string SL_RESULTAT
        {
			get { return _SL_RESULTAT; }
			set { _SL_RESULTAT = value; }
		}
		public string SL_MESSAGE
        {
			get { return _SL_MESSAGE; }
			set { _SL_MESSAGE = value; }
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







		public DateTime RP_DATECLOTURE
		{
			get { return _RP_DATECLOTURE; }
			set {  _RP_DATECLOTURE = value; }
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
        public string SL_MESSAGEAPI
        {
	        get { return _SL_MESSAGEAPI; }
	        set { _SL_MESSAGEAPI = value; }
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


		#endregion

		#region INSTANCIATEURS

		public clsMiccomptewebmotpasseoublie(){}

		public clsMiccomptewebmotpasseoublie(clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie)
		{
			this.AG_CODEAGENCE = clsMiccomptewebmotpasseoublie.AG_CODEAGENCE;
			this.RP_DATE = clsMiccomptewebmotpasseoublie.RP_DATE;
			this.RP_NUMSEQUENCE = clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE;
			this.TI_IDTIERS = clsMiccomptewebmotpasseoublie.TI_IDTIERS;
			this.MB_IDTIERS = clsMiccomptewebmotpasseoublie.MB_IDTIERS;
			this.OP_CODEOPERATEUR = clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR;
			this.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION;
			this.RP_HEURE = clsMiccomptewebmotpasseoublie.RP_HEURE;
			this.RP_EMAIL = clsMiccomptewebmotpasseoublie.RP_EMAIL;
			this.RP_DATECLOTURE = clsMiccomptewebmotpasseoublie.RP_DATECLOTURE;
			this.SL_RESULTAT = clsMiccomptewebmotpasseoublie.SL_RESULTAT;
			this.SL_MESSAGE = clsMiccomptewebmotpasseoublie.SL_MESSAGE;
			this.SL_MESSAGEOBJET = clsMiccomptewebmotpasseoublie.SL_MESSAGEOBJET;
			this.AG_EMAIL = clsMiccomptewebmotpasseoublie.AG_EMAIL;
			this.AG_EMAILMOTDEPASSE = clsMiccomptewebmotpasseoublie.AG_EMAILMOTDEPASSE;
			this.SL_MESSAGECLIENT = clsMiccomptewebmotpasseoublie.SL_MESSAGECLIENT;
			this.OB_NOMOBJET = clsMiccomptewebmotpasseoublie.OB_NOMOBJET;
			this.PV_CODEPOINTVENTE = clsMiccomptewebmotpasseoublie.PV_CODEPOINTVENTE;
			this.CO_CODECOMPTE = clsMiccomptewebmotpasseoublie.CO_CODECOMPTE;
			this.SL_MESSAGEAPI = clsMiccomptewebmotpasseoublie.SL_MESSAGEAPI;
			this.SL_LIBELLE1 = clsMiccomptewebmotpasseoublie.SL_LIBELLE1;
			this.SL_LIBELLE2 = clsMiccomptewebmotpasseoublie.SL_LIBELLE2;
		}

		#endregion

	}
}
