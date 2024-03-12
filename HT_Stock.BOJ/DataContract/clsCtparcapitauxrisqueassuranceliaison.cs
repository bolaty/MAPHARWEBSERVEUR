using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparcapitauxrisqueassuranceliaison : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _CP_CODECAPITAUX = "";
		private string _RQ_CODERISQUE = "";
		private string _CL_NUMEROORDRE = "0";
		private string _CP_LIBELLECAPITAUX = "";
		private string _CC_LIBELLE = "";
		private string _CC_CAPITAUX = "0";
		private string _CC_PRIMES = "0";
		private string _CC_TAUX = "0";
		#endregion

		#region ACCESSEURS

		public string CP_CODECAPITAUX
		{
			get { return _CP_CODECAPITAUX; }
			set {  _CP_CODECAPITAUX = value; }
		}

		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

		public string CL_NUMEROORDRE
		{
			get { return _CL_NUMEROORDRE; }
			set {  _CL_NUMEROORDRE = value; }
		}
        public string CP_LIBELLECAPITAUX
        {
	        get { return _CP_LIBELLECAPITAUX; }
	        set { _CP_LIBELLECAPITAUX = value; }
        }
        public string CC_CAPITAUX
        {
	        get { return _CC_CAPITAUX; }
	        set { _CC_CAPITAUX = value; }
        }
        public string CC_PRIMES
        {
	        get { return _CC_PRIMES; }
	        set { _CC_PRIMES = value; }
        }
        public string CC_TAUX
        {
	        get { return _CC_TAUX; }
	        set { _CC_TAUX = value; }
        }
        public string CC_LIBELLE
        {
	        get { return _CC_LIBELLE; }
	        set { _CC_LIBELLE = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCtparcapitauxrisqueassuranceliaison(){}
		
		public clsCtparcapitauxrisqueassuranceliaison(clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison)
		{
			this.CP_CODECAPITAUX = clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX;
			this.RQ_CODERISQUE = clsCtparcapitauxrisqueassuranceliaison.RQ_CODERISQUE;
			this.CL_NUMEROORDRE = clsCtparcapitauxrisqueassuranceliaison.CL_NUMEROORDRE;
			this.CP_LIBELLECAPITAUX = clsCtparcapitauxrisqueassuranceliaison.CP_LIBELLECAPITAUX;
            this.CC_CAPITAUX = clsCtparcapitauxrisqueassuranceliaison.CC_CAPITAUX;
            this.CC_PRIMES = clsCtparcapitauxrisqueassuranceliaison.CC_PRIMES;
            this.CC_LIBELLE = clsCtparcapitauxrisqueassuranceliaison.CC_LIBELLE;

		}

		#endregion

	}
}
