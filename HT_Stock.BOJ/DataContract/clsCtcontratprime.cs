using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratprime : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _RE_CODERESUME = "";
		private double _CP_VALEUR = 0;
		private double _CG_PRIMES = 0;
		private string _RE_LIBELLERESUME = "";
		private string _CG_TAUX = "0";
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string RE_CODERESUME
		{
			get { return _RE_CODERESUME; }
			set {  _RE_CODERESUME = value; }
		}

		public double CP_VALEUR
		{
			get { return _CP_VALEUR; }
			set {  _CP_VALEUR = value; }
		}
		public double CG_PRIMES
        {
			get { return _CG_PRIMES; }
			set { _CG_PRIMES = value; }
		}
		public string RE_LIBELLERESUME
        {
			get { return _RE_LIBELLERESUME; }
			set { _RE_LIBELLERESUME = value; }
		}
		public string CG_TAUX
        {
			get { return _CG_TAUX; }
			set { _CG_TAUX = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratprime(){}
		
		public clsCtcontratprime(clsCtcontratprime clsCtcontratprime)
		{
			this.AG_CODEAGENCE = clsCtcontratprime.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratprime.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratprime.CA_CODECONTRAT;
			this.RE_CODERESUME = clsCtcontratprime.RE_CODERESUME;
			this.CP_VALEUR = clsCtcontratprime.CP_VALEUR;
			this.CG_PRIMES = clsCtcontratprime.CG_PRIMES;
			this.CG_TAUX = clsCtcontratprime.CG_TAUX;
			this.RE_LIBELLERESUME = clsCtcontratprime.RE_LIBELLERESUME;

		}

		#endregion

	}
}
