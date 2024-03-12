using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratreduction : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _RD_CODEREDUCTION = "";
		private string _RD_LIBELLEREDUCTION = "";
		private string _RD_TAUX = "0";
		private double _RD_MONTANT = 0;

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

		public string RD_CODEREDUCTION
		{
			get { return _RD_CODEREDUCTION; }
			set {  _RD_CODEREDUCTION = value; }
		}

		public string RD_LIBELLEREDUCTION
        {
			get { return _RD_LIBELLEREDUCTION; }
			set { _RD_LIBELLEREDUCTION = value; }
		}

		public string RD_TAUX
		{
			get { return _RD_TAUX; }
			set {  _RD_TAUX = value; }
		}

		public double RD_MONTANT
		{
			get { return _RD_MONTANT; }
			set {  _RD_MONTANT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratreduction(){}
		
		public clsCtcontratreduction(clsCtcontratreduction clsCtcontratreduction)
		{
			this.AG_CODEAGENCE = clsCtcontratreduction.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratreduction.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratreduction.CA_CODECONTRAT;
			this.RD_CODEREDUCTION = clsCtcontratreduction.RD_CODEREDUCTION;
			this.RD_LIBELLEREDUCTION = clsCtcontratreduction.RD_LIBELLEREDUCTION;
			this.RD_TAUX = clsCtcontratreduction.RD_TAUX;
			this.RD_MONTANT = clsCtcontratreduction.RD_MONTANT;
		}

		#endregion

	}
}
