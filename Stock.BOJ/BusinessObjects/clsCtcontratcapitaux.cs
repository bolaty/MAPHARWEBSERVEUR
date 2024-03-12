using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratcapitaux
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _CP_CODECAPITAUX = "";
		private double _CC_CAPITAUX = 0;
		private double _CC_PRIMES = 0;
		private float _CC_TAUX = 0;
		private string _CC_LIBELLE = "";

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

		public string CP_CODECAPITAUX
		{
			get { return _CP_CODECAPITAUX; }
			set {  _CP_CODECAPITAUX = value; }
		}

		public double CC_CAPITAUX
		{
			get { return _CC_CAPITAUX; }
			set {  _CC_CAPITAUX = value; }
		}

		public double CC_PRIMES
		{
			get { return _CC_PRIMES; }
			set {  _CC_PRIMES = value; }
		}

		public float CC_TAUX
		{
			get { return _CC_TAUX; }
			set {  _CC_TAUX = value; }
		}

		public string CC_LIBELLE
		{
			get { return _CC_LIBELLE; }
			set {  _CC_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratcapitaux(){}
		public clsCtcontratcapitaux( string AG_CODEAGENCE,string EN_CODEENTREPOT,string CA_CODECONTRAT,string CP_CODECAPITAUX,double CC_CAPITAUX,double CC_PRIMES,float CC_TAUX,string CC_LIBELLE)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
			this.CA_CODECONTRAT = CA_CODECONTRAT;
			this.CP_CODECAPITAUX = CP_CODECAPITAUX;
			this.CC_CAPITAUX = CC_CAPITAUX;
			this.CC_PRIMES = CC_PRIMES;
			this.CC_TAUX = CC_TAUX;
			this.CC_LIBELLE = CC_LIBELLE;
		}
		public clsCtcontratcapitaux(clsCtcontratcapitaux clsCtcontratcapitaux)
		{
			this.AG_CODEAGENCE = clsCtcontratcapitaux.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratcapitaux.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratcapitaux.CA_CODECONTRAT;
			this.CP_CODECAPITAUX = clsCtcontratcapitaux.CP_CODECAPITAUX;
			this.CC_CAPITAUX = clsCtcontratcapitaux.CC_CAPITAUX;
			this.CC_PRIMES = clsCtcontratcapitaux.CC_PRIMES;
			this.CC_TAUX = clsCtcontratcapitaux.CC_TAUX;
			this.CC_LIBELLE = clsCtcontratcapitaux.CC_LIBELLE;
		}

		#endregion

	}
}
