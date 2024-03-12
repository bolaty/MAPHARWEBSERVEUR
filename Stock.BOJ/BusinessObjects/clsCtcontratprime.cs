using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratprime
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _RE_CODERESUME = "";
		private double _CP_VALEUR = 0;
		private DateTime _CM_DATEPIECE =DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";

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
		public DateTime CM_DATEPIECE
        {
			get { return _CM_DATEPIECE; }
			set { _CM_DATEPIECE = value; }
		}
		public string OP_CODEOPERATEUR
        {
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
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
			this.CM_DATEPIECE = clsCtcontratprime.CM_DATEPIECE;
			this.OP_CODEOPERATEUR = clsCtcontratprime.OP_CODEOPERATEUR;

		}

		#endregion

	}
}
