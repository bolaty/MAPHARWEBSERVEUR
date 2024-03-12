using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparprimerisqueassuranceliaison
	{
		#region VARIABLES LOCALES

		private string _RE_CODERESUME = "";
		private string _RQ_CODERISQUE = "";
		private int _RL_NUMEROORDRE = 0;

        private string _RE_LIBELLERESUME = "";
        private string _RQ_LIBELLERISQUE = "";
        private string _CG_CAPITAUXASSURES = "0";
        private string _CG_PRIMES = "0";
        private string _CG_APRESREDUCTION = "0";
        private string _CG_PRORATA = "0";
        private string _CG_FRANCHISES = "0";
        private string _CG_TAUX = "0";

        #endregion

        #region ACCESSEURS

        public string RE_CODERESUME
		{
			get { return _RE_CODERESUME; }
			set {  _RE_CODERESUME = value; }
		}

		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

		public int RL_NUMEROORDRE
		{
			get { return _RL_NUMEROORDRE; }
			set {  _RL_NUMEROORDRE = value; }
		}

        public string RE_LIBELLERESUME
        {
            get { return _RE_LIBELLERESUME; }
            set { _RE_LIBELLERESUME = value; }
        }
        public string RQ_LIBELLERISQUE
        {
            get { return _RQ_LIBELLERISQUE; }
            set { _RQ_LIBELLERISQUE = value; }
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


        #endregion

        #region INSTANCIATEURS

        public clsCtparprimerisqueassuranceliaison(){}
		public clsCtparprimerisqueassuranceliaison( string RE_CODERESUME,string RQ_CODERISQUE,int RL_NUMEROORDRE)
		{
			this.RE_CODERESUME = RE_CODERESUME;
			this.RQ_CODERISQUE = RQ_CODERISQUE;
			this.RL_NUMEROORDRE = RL_NUMEROORDRE;
		}
		public clsCtparprimerisqueassuranceliaison(clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison)
		{
			this.RE_CODERESUME = clsCtparprimerisqueassuranceliaison.RE_CODERESUME;
			this.RQ_CODERISQUE = clsCtparprimerisqueassuranceliaison.RQ_CODERISQUE;
			this.RL_NUMEROORDRE = clsCtparprimerisqueassuranceliaison.RL_NUMEROORDRE;
            this.RE_LIBELLERESUME = clsCtparprimerisqueassuranceliaison.RE_LIBELLERESUME;
            this.RQ_LIBELLERISQUE = clsCtparprimerisqueassuranceliaison.RQ_LIBELLERISQUE;
            this.CG_CAPITAUXASSURES = clsCtparprimerisqueassuranceliaison.CG_CAPITAUXASSURES;
            this.CG_PRIMES = clsCtparprimerisqueassuranceliaison.CG_PRIMES;
            this.CG_APRESREDUCTION = clsCtparprimerisqueassuranceliaison.CG_APRESREDUCTION;
            this.CG_PRORATA = clsCtparprimerisqueassuranceliaison.CG_PRORATA;
            this.CG_FRANCHISES = clsCtparprimerisqueassuranceliaison.CG_FRANCHISES;
            this.CG_TAUX = clsCtparprimerisqueassuranceliaison.CG_TAUX;
        }

		#endregion

	}
}
