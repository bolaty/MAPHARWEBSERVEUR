using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratgarantie : clsEntitieBase
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
		private string _CG_FRANCHISES ="";
		private string _CG_TAUX = "0";
		private double _CG_MONTANT = 0;
		private string _CG_LIBELLE = "";
		private string _GA_LIBELLEGARANTIE = "";
		private string _SC_CODESOUSCATEGORIE = "";
		private string _SC_LIBELLESOUSCATEGORIE = "";
		private string _CT_LIBELLECATEGORIE = "";
		private string _TG_LIBELLETYPEGARANTIE = "";
		private string _CG_GARANTIE = "N";
        


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

		public string CG_TAUX
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
        public string GA_LIBELLEGARANTIE
        {
	        get { return _GA_LIBELLEGARANTIE; }
	        set { _GA_LIBELLEGARANTIE = value; }
        }

        public string SC_CODESOUSCATEGORIE
        {
	        get { return _SC_CODESOUSCATEGORIE; }
	        set { _SC_CODESOUSCATEGORIE = value; }
        }
        public string SC_LIBELLESOUSCATEGORIE
        {
	        get { return _SC_LIBELLESOUSCATEGORIE; }
	        set { _SC_LIBELLESOUSCATEGORIE = value; }
        }
        public string CT_LIBELLECATEGORIE
        {
	        get { return _CT_LIBELLECATEGORIE; }
	        set { _CT_LIBELLECATEGORIE = value; }
        }
        public string TG_LIBELLETYPEGARANTIE
        {
	        get { return _TG_LIBELLETYPEGARANTIE; }
	        set { _TG_LIBELLETYPEGARANTIE = value; }
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
			this.GA_LIBELLEGARANTIE = clsCtcontratgarantie.GA_LIBELLEGARANTIE;
			this.SC_CODESOUSCATEGORIE = clsCtcontratgarantie.SC_CODESOUSCATEGORIE;
			this.SC_LIBELLESOUSCATEGORIE = clsCtcontratgarantie.SC_LIBELLESOUSCATEGORIE;
			this.CT_LIBELLECATEGORIE = clsCtcontratgarantie.CT_LIBELLECATEGORIE;
			this.TG_LIBELLETYPEGARANTIE = clsCtcontratgarantie.TG_LIBELLETYPEGARANTIE;
			this.CG_GARANTIE = clsCtcontratgarantie.CG_GARANTIE;
            //clsCtcontratgarantieDTO.GA_LIBELLEGARANTIE = rowCtcontratgarantie["GA_LIBELLEGARANTIE"].ToString();
            //clsCtcontratgarantieDTO.SC_CODESOUSCATEGORIE = rowCtcontratgarantie["SC_CODESOUSCATEGORIE"].ToString();
            //clsCtcontratgarantieDTO.SC_LIBELLESOUSCATEGORIE = rowCtcontratgarantie["SC_LIBELLESOUSCATEGORIE"].ToString();
            //clsCtcontratgarantieDTO.CT_LIBELLECATEGORIE = rowCtcontratgarantie["CT_LIBELLECATEGORIE"].ToString();
            //clsCtcontratgarantieDTO.TG_LIBELLETYPEGARANTIE = rowCtcontratgarantie["TG_LIBELLETYPEGARANTIE"].ToString();
        }

        #endregion

    }
}
