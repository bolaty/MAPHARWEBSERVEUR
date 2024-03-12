using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtpargarantierisqueassuranceliaison : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _GA_CODEGARANTIE = "";
		private string _RQ_CODERISQUE = "";
		private string _GA_LIBELLEGARANTIE = "";
		private string _RQ_LIBELLERISQUE = "";
		private string _SC_CODESOUSCATEGORIE = "";
		private string _SC_LIBELLESOUSCATEGORIE = "";
		private string _CT_LIBELLECATEGORIE = "";
		private string _TG_LIBELLETYPEGARANTIE = "";
		private string _CG_CAPITAUXASSURES = "0";
		private string _CG_PRIMES = "0";
		private string _CG_APRESREDUCTION = "0";
		private string _CG_PRORATA = "0";
		private string _CG_FRANCHISES = "0";
		private string _CG_TAUX = "0";
		private string _CG_GARANTIE = "N";
		#endregion

		#region ACCESSEURS

		public string GA_CODEGARANTIE
		{
			get { return _GA_CODEGARANTIE; }
			set {  _GA_CODEGARANTIE = value; }
		}

		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}
        public string GA_LIBELLEGARANTIE
        {
	        get { return _GA_LIBELLEGARANTIE; }
	        set { _GA_LIBELLEGARANTIE = value; }
        }
        public string RQ_LIBELLERISQUE
        {
	        get { return _RQ_LIBELLERISQUE; }
	        set { _RQ_LIBELLERISQUE = value; }
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
        public string CG_CAPITAUXASSURES
        {
	        get { return _CG_CAPITAUXASSURES; }
	        set { _CG_CAPITAUXASSURES = value; }
        }
        public string CG_PRIMES
        {
	        get { return _CG_PRIMES; }
	        set { _CG_PRIMES = value; }
        }
        public string CG_APRESREDUCTION
        {
	        get { return _CG_APRESREDUCTION; }
	        set { _CG_APRESREDUCTION = value; }
        }
        public string CG_PRORATA
        {
	        get { return _CG_PRORATA; }
	        set { _CG_PRORATA = value; }
        }
        public string CG_FRANCHISES
        {
	        get { return _CG_FRANCHISES; }
	        set { _CG_FRANCHISES = value; }
        }
        public string CG_TAUX
        {
	        get { return _CG_TAUX; }
	        set { _CG_TAUX = value; }
        }
        public string CG_GARANTIE
        {
	        get { return _CG_GARANTIE; }
	        set { _CG_GARANTIE = value; }
        }
        


        #endregion

        #region INSTANCIATEURS

        public clsCtpargarantierisqueassuranceliaison(){}

		public clsCtpargarantierisqueassuranceliaison(clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison)
		{
			this.GA_CODEGARANTIE = clsCtpargarantierisqueassuranceliaison.GA_CODEGARANTIE;
			this.RQ_CODERISQUE = clsCtpargarantierisqueassuranceliaison.RQ_CODERISQUE;

            this.GA_LIBELLEGARANTIE = clsCtpargarantierisqueassuranceliaison.GA_LIBELLEGARANTIE;
            this.RQ_LIBELLERISQUE = clsCtpargarantierisqueassuranceliaison.RQ_LIBELLERISQUE;
            this.SC_CODESOUSCATEGORIE = clsCtpargarantierisqueassuranceliaison.SC_CODESOUSCATEGORIE;
            this.SC_LIBELLESOUSCATEGORIE = clsCtpargarantierisqueassuranceliaison.SC_LIBELLESOUSCATEGORIE;
            this.CT_LIBELLECATEGORIE = clsCtpargarantierisqueassuranceliaison.CT_LIBELLECATEGORIE;
            this.TG_LIBELLETYPEGARANTIE = clsCtpargarantierisqueassuranceliaison.TG_LIBELLETYPEGARANTIE;
            this.CG_CAPITAUXASSURES = clsCtpargarantierisqueassuranceliaison.CG_CAPITAUXASSURES ;
            this.CG_PRIMES = clsCtpargarantierisqueassuranceliaison.CG_PRIMES;
            this.CG_APRESREDUCTION = clsCtpargarantierisqueassuranceliaison.CG_APRESREDUCTION;
            this.CG_PRORATA = clsCtpargarantierisqueassuranceliaison.CG_PRORATA;
            this.CG_FRANCHISES = clsCtpargarantierisqueassuranceliaison.CG_FRANCHISES;
            this.CG_TAUX = clsCtpargarantierisqueassuranceliaison.CG_TAUX;
            this.CG_GARANTIE = clsCtpargarantierisqueassuranceliaison.CG_GARANTIE;

        }

        #endregion

    }
}
