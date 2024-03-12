using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratgarantie
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _GA_CODEGARANTIE = "";
		private double _CG_CAPITAUXASSURES = 0;
		private double _CG_PRIMES = 0;
		private double _CG_APRESREDUCTION = 0;
		private double _CG_PRORATA = 0;
		private string _CG_FRANCHISES = "";
		private float _CG_TAUX = 0;
		private double _CG_MONTANT = 0;
		private string _CG_LIBELLE = "";
		private string _CG_GARANTIE = "";
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

		public string GA_CODEGARANTIE
		{
			get { return _GA_CODEGARANTIE; }
			set {  _GA_CODEGARANTIE = value; }
		}

		public double CG_CAPITAUXASSURES
		{
			get { return _CG_CAPITAUXASSURES; }
			set {  _CG_CAPITAUXASSURES = value; }
		}

		public double CG_PRIMES
		{
			get { return _CG_PRIMES; }
			set {  _CG_PRIMES = value; }
		}

		public double CG_APRESREDUCTION
		{
			get { return _CG_APRESREDUCTION; }
			set {  _CG_APRESREDUCTION = value; }
		}

		public double CG_PRORATA
		{
			get { return _CG_PRORATA; }
			set {  _CG_PRORATA = value; }
		}

		public string CG_FRANCHISES
		{
			get { return _CG_FRANCHISES; }
			set {  _CG_FRANCHISES = value; }
		}

		public float CG_TAUX
		{
			get { return _CG_TAUX; }
			set {  _CG_TAUX = value; }
		}

		public double CG_MONTANT
		{
			get { return _CG_MONTANT; }
			set {  _CG_MONTANT = value; }
		}

		public string CG_LIBELLE
		{
			get { return _CG_LIBELLE; }
			set {  _CG_LIBELLE = value; }
		}
		public string CG_GARANTIE
        {
			get { return _CG_GARANTIE; }
			set { _CG_GARANTIE = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsCtcontratgarantie(){}

		public clsCtcontratgarantie(clsCtcontratgarantie clsCtcontratgarantie)
		{
			this.AG_CODEAGENCE = clsCtcontratgarantie.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratgarantie.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratgarantie.CA_CODECONTRAT;
			this.GA_CODEGARANTIE = clsCtcontratgarantie.GA_CODEGARANTIE;
			this.CG_CAPITAUXASSURES = clsCtcontratgarantie.CG_CAPITAUXASSURES;
			this.CG_PRIMES = clsCtcontratgarantie.CG_PRIMES;
			this.CG_APRESREDUCTION = clsCtcontratgarantie.CG_APRESREDUCTION;
			this.CG_PRORATA = clsCtcontratgarantie.CG_PRORATA;
			this.CG_FRANCHISES = clsCtcontratgarantie.CG_FRANCHISES;
			this.CG_TAUX = clsCtcontratgarantie.CG_TAUX;
			this.CG_MONTANT = clsCtcontratgarantie.CG_MONTANT;
			this.CG_LIBELLE = clsCtcontratgarantie.CG_LIBELLE;
			this.CG_GARANTIE = clsCtcontratgarantie.CG_GARANTIE;
		}

		#endregion

	}
}
