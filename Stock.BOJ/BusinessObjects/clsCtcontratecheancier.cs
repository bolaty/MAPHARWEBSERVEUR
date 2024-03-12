using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratecheancier
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private DateTime _EC_DATEECHEANCE = DateTime.Parse("01/01/1900");
		private double _EC_MONTANTECHEANCE = 0;

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

		public DateTime EC_DATEECHEANCE
		{
			get { return _EC_DATEECHEANCE; }
			set {  _EC_DATEECHEANCE = value; }
		}

		public double EC_MONTANTECHEANCE
		{
			get { return _EC_MONTANTECHEANCE; }
			set {  _EC_MONTANTECHEANCE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratecheancier(){}
		public clsCtcontratecheancier( string AG_CODEAGENCE,string EN_CODEENTREPOT,string CA_CODECONTRAT,DateTime EC_DATEECHEANCE,double EC_MONTANTECHEANCE)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
			this.CA_CODECONTRAT = CA_CODECONTRAT;
			this.EC_DATEECHEANCE = EC_DATEECHEANCE;
			this.EC_MONTANTECHEANCE = EC_MONTANTECHEANCE;
		}
		public clsCtcontratecheancier(clsCtcontratecheancier clsCtcontratecheancier)
		{
			this.AG_CODEAGENCE = clsCtcontratecheancier.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratecheancier.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratecheancier.CA_CODECONTRAT;
			this.EC_DATEECHEANCE = clsCtcontratecheancier.EC_DATEECHEANCE;
			this.EC_MONTANTECHEANCE = clsCtcontratecheancier.EC_MONTANTECHEANCE;
		}

		#endregion

	}
}
