using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparreduction : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _RD_CODEREDUCTION = "";
		private string _RD_LIBELLEREDUCTION = "";
		private string _RD_ACTIF = "";
		private string _RD_NUMEROORDRE = "0";
        private string _RD_MONTANT = "0";
        private string _RD_TAUX="0";

        #endregion

        #region ACCESSEURS

        public string RD_CODEREDUCTION
		{
			get { return _RD_CODEREDUCTION; }
			set {  _RD_CODEREDUCTION = value; }
		}

		public string RD_LIBELLEREDUCTION
		{
			get { return _RD_LIBELLEREDUCTION; }
			set {  _RD_LIBELLEREDUCTION = value; }
		}

		public string RD_ACTIF
		{
			get { return _RD_ACTIF; }
			set {  _RD_ACTIF = value; }
		}

		public string RD_NUMEROORDRE
		{
			get { return _RD_NUMEROORDRE; }
			set {  _RD_NUMEROORDRE = value; }
		}
        public string RD_MONTANT
        {
	        get { return _RD_MONTANT; }
	        set { _RD_MONTANT = value; }
        }
        public string RD_TAUX
        {
	        get { return _RD_TAUX; }
	        set { _RD_TAUX = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsCtparreduction(){}

		public clsCtparreduction(clsCtparreduction clsCtparreduction)
		{
			this.RD_CODEREDUCTION = clsCtparreduction.RD_CODEREDUCTION;
			this.RD_LIBELLEREDUCTION = clsCtparreduction.RD_LIBELLEREDUCTION;
			this.RD_ACTIF = clsCtparreduction.RD_ACTIF;
			this.RD_NUMEROORDRE = clsCtparreduction.RD_NUMEROORDRE;
			this.RD_MONTANT = clsCtparreduction.RD_MONTANT;
			this.RD_TAUX = clsCtparreduction.RD_TAUX;

        }

        #endregion

    }
}
