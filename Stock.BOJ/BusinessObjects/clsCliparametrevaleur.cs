using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparametrevaleur
	{
		#region VARIABLES LOCALES

		private string _PT_CODEPRIME = "";
		private string _AP_CODEPRODUIT = "";
		private string _LP_CODEPARAMETRELIBELLE = "";
		private decimal _PT_BORNEMIN = 0;
		private decimal _PT_BORNEMAX = 0;
		private decimal _PT_MONTANTMINI = 0;
		private decimal _PT_MONTANTMAXI = 0;
		private decimal _PT_TAUX = 0;
		private decimal _PT_MONTANT = 0;

		#endregion

		#region ACCESSEURS

		public string PT_CODEPRIME
		{
			get { return _PT_CODEPRIME; }
			set {  _PT_CODEPRIME = value; }
		}

		public string AP_CODEPRODUIT
		{
			get { return _AP_CODEPRODUIT; }
			set {  _AP_CODEPRODUIT = value; }
		}

		public string LP_CODEPARAMETRELIBELLE
		{
			get { return _LP_CODEPARAMETRELIBELLE; }
			set {  _LP_CODEPARAMETRELIBELLE = value; }
		}

		public decimal PT_BORNEMIN
		{
			get { return _PT_BORNEMIN; }
			set {  _PT_BORNEMIN = value; }
		}

		public decimal PT_BORNEMAX
		{
			get { return _PT_BORNEMAX; }
			set {  _PT_BORNEMAX = value; }
		}

		public decimal PT_MONTANTMINI
		{
			get { return _PT_MONTANTMINI; }
			set {  _PT_MONTANTMINI = value; }
		}

		public decimal PT_MONTANTMAXI
		{
			get { return _PT_MONTANTMAXI; }
			set {  _PT_MONTANTMAXI = value; }
		}

		public decimal PT_TAUX
		{
			get { return _PT_TAUX; }
			set {  _PT_TAUX = value; }
		}

		public decimal PT_MONTANT
		{
			get { return _PT_MONTANT; }
			set {  _PT_MONTANT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparametrevaleur(){}
		public clsCliparametrevaleur( string PT_CODEPRIME,string AP_CODEPRODUIT,string LP_CODEPARAMETRELIBELLE,decimal PT_BORNEMIN,decimal PT_BORNEMAX,decimal PT_MONTANTMINI,decimal PT_MONTANTMAXI,decimal PT_TAUX,decimal PT_MONTANT)
		{
			this.PT_CODEPRIME = PT_CODEPRIME;
			this.AP_CODEPRODUIT = AP_CODEPRODUIT;
			this.LP_CODEPARAMETRELIBELLE = LP_CODEPARAMETRELIBELLE;
			this.PT_BORNEMIN = PT_BORNEMIN;
			this.PT_BORNEMAX = PT_BORNEMAX;
			this.PT_MONTANTMINI = PT_MONTANTMINI;
			this.PT_MONTANTMAXI = PT_MONTANTMAXI;
			this.PT_TAUX = PT_TAUX;
			this.PT_MONTANT = PT_MONTANT;
		}
		public clsCliparametrevaleur(clsCliparametrevaleur clsCliparametrevaleur)
		{
			this.PT_CODEPRIME = clsCliparametrevaleur.PT_CODEPRIME;
			this.AP_CODEPRODUIT = clsCliparametrevaleur.AP_CODEPRODUIT;
			this.LP_CODEPARAMETRELIBELLE = clsCliparametrevaleur.LP_CODEPARAMETRELIBELLE;
			this.PT_BORNEMIN = clsCliparametrevaleur.PT_BORNEMIN;
			this.PT_BORNEMAX = clsCliparametrevaleur.PT_BORNEMAX;
			this.PT_MONTANTMINI = clsCliparametrevaleur.PT_MONTANTMINI;
			this.PT_MONTANTMAXI = clsCliparametrevaleur.PT_MONTANTMAXI;
			this.PT_TAUX = clsCliparametrevaleur.PT_TAUX;
			this.PT_MONTANT = clsCliparametrevaleur.PT_MONTANT;
		}

		#endregion

	}
}
