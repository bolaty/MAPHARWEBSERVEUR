using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratecheancier : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _EC_DATEECHEANCE ="";
		private string _EC_MONTANTECHEANCE = "0";
		private string _EC_MONTANTECHEANCENF = "0";
		private string _EC_MONTANTSOLDE = "0";
		private string _EC_MONTANTTOTAL = "0";
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

		public string EC_DATEECHEANCE
		{
			get { return _EC_DATEECHEANCE; }
			set {  _EC_DATEECHEANCE = value; }
		}

		public string EC_MONTANTECHEANCE
		{
			get { return _EC_MONTANTECHEANCE; }
			set {  _EC_MONTANTECHEANCE = value; }
		}
        public string EC_MONTANTECHEANCENF
        {
	        get { return _EC_MONTANTECHEANCENF; }
	        set { _EC_MONTANTECHEANCENF = value; }
        }
        public string EC_MONTANTSOLDE
        {
	        get { return _EC_MONTANTSOLDE; }
	        set { _EC_MONTANTSOLDE = value; }
        }
        public string EC_MONTANTTOTAL
        {
	        get { return _EC_MONTANTTOTAL; }
	        set { _EC_MONTANTTOTAL = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCtcontratecheancier(){}
		
		public clsCtcontratecheancier(clsCtcontratecheancier clsCtcontratecheancier)
		{
			this.AG_CODEAGENCE = clsCtcontratecheancier.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratecheancier.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratecheancier.CA_CODECONTRAT;
			this.EC_DATEECHEANCE = clsCtcontratecheancier.EC_DATEECHEANCE;
			this.EC_MONTANTECHEANCE = clsCtcontratecheancier.EC_MONTANTECHEANCE;
			this.EC_MONTANTECHEANCENF = clsCtcontratecheancier.EC_MONTANTECHEANCENF;
			this.EC_MONTANTSOLDE = clsCtcontratecheancier.EC_MONTANTSOLDE;
			this.EC_MONTANTTOTAL = clsCtcontratecheancier.EC_MONTANTTOTAL;

        }

		#endregion

	}
}
