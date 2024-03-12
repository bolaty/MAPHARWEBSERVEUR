using System;
using Stock.Common;

namespace HT_Stock.BOJ
{

	public partial class clsUtilisateursapis : clsEntitieBase
	{
		#region VARIABLES LOCALES
		private string _UT_IDUTILISATEUR = "";
		private string _UT_LOGIN = "";
		private string _UT_MOTDEPASSE = "";
		private string _UT_TOKEN = "";
		private string _UT_STATUT = "";
		private string _UT_DATESAISIE = "";
		private string _UT_UTILISATEURSAPIS1 = "";
		private string _UT_UTILISATEURSAPIS2 = "";
		#endregion

		#region ACCESSEURS
		public string UT_IDUTILISATEUR
		{
			get { return _UT_IDUTILISATEUR; }
			set {  _UT_IDUTILISATEUR = value; }
		}

		public string UT_LOGIN
		{
			get { return _UT_LOGIN; }
			set {  _UT_LOGIN = value; }
		}

		public string UT_MOTDEPASSE
		{
			get { return _UT_MOTDEPASSE; }
			set {  _UT_MOTDEPASSE = value; }
		}

		public string UT_TOKEN
		{
			get { return _UT_TOKEN; }
			set {  _UT_TOKEN = value; }
		}

		public string UT_STATUT
		{
			get { return _UT_STATUT; }
			set {  _UT_STATUT = value; }
		}

		public string UT_DATESAISIE
		{
			get { return _UT_DATESAISIE; }
			set {  _UT_DATESAISIE = value; }
		}

		public string UT_UTILISATEURSAPIS1
		{
			get { return _UT_UTILISATEURSAPIS1; }
			set { _UT_UTILISATEURSAPIS1 = value; }
		}
		public string UT_UTILISATEURSAPIS2
		{
			get { return _UT_UTILISATEURSAPIS2; }
			set { _UT_UTILISATEURSAPIS2 = value; }
		}

		#endregion
		#region INSTANCIATEURS
		public clsUtilisateursapis(){}

		public clsUtilisateursapis(clsUtilisateursapis clsUtilisateursapis)
		{
			this.UT_IDUTILISATEUR = clsUtilisateursapis.UT_IDUTILISATEUR;
			this.UT_LOGIN = clsUtilisateursapis.UT_LOGIN;
			this.UT_MOTDEPASSE = clsUtilisateursapis.UT_MOTDEPASSE;
			this.UT_TOKEN = clsUtilisateursapis.UT_TOKEN;
			this.UT_STATUT = clsUtilisateursapis.UT_STATUT;
			this.UT_DATESAISIE = clsUtilisateursapis.UT_DATESAISIE;

			this.UT_UTILISATEURSAPIS1 = clsUtilisateursapis.UT_UTILISATEURSAPIS1;
			this.UT_UTILISATEURSAPIS2 = clsUtilisateursapis.UT_UTILISATEURSAPIS2;
		}
		#endregion
	}
}
