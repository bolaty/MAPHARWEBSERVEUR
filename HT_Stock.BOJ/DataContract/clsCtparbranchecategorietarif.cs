using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparbranchecategorietarif : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _CB_IDBRANCHE = "0";
		private string _AU_CODECATEGORIE = "0";
		private string _TA_CODETARIF = "0";
		private string _BC_NUMEROORDRE = "0";
		private string _CB_LIBELLEBRANCHE = "";
		private string _AU_LIBELLECATEGORIE = "";
		private string _TA_LIBELLETARIF = "";

		#endregion

		#region ACCESSEURS

		public string CB_IDBRANCHE
		{
			get { return _CB_IDBRANCHE; }
			set {  _CB_IDBRANCHE = value; }
		}

		public string AU_CODECATEGORIE
		{
			get { return _AU_CODECATEGORIE; }
			set {  _AU_CODECATEGORIE = value; }
		}

		public string TA_CODETARIF
		{
			get { return _TA_CODETARIF; }
			set {  _TA_CODETARIF = value; }
		}

		public string BC_NUMEROORDRE
		{
			get { return _BC_NUMEROORDRE; }
			set {  _BC_NUMEROORDRE = value; }
		}
        public string CB_LIBELLEBRANCHE
        {
	        get { return _CB_LIBELLEBRANCHE; }
	        set { _CB_LIBELLEBRANCHE = value; }
        }
        public string AU_LIBELLECATEGORIE
        {
	        get { return _AU_LIBELLECATEGORIE; }
	        set { _AU_LIBELLECATEGORIE = value; }
        }
        public string TA_LIBELLETARIF
        {
	        get { return _TA_LIBELLETARIF; }
	        set { _TA_LIBELLETARIF = value; }
        }        


        #endregion

        #region INSTANCIATEURS

        public clsCtparbranchecategorietarif(){}

		public clsCtparbranchecategorietarif(clsCtparbranchecategorietarif clsCtparbranchecategorietarif)
		{
			this.CB_IDBRANCHE = clsCtparbranchecategorietarif.CB_IDBRANCHE;
			this.AU_CODECATEGORIE = clsCtparbranchecategorietarif.AU_CODECATEGORIE;
			this.TA_CODETARIF = clsCtparbranchecategorietarif.TA_CODETARIF;
			this.BC_NUMEROORDRE = clsCtparbranchecategorietarif.BC_NUMEROORDRE;
			this.CB_LIBELLEBRANCHE = clsCtparbranchecategorietarif.CB_LIBELLEBRANCHE;
			this.AU_LIBELLECATEGORIE = clsCtparbranchecategorietarif.AU_LIBELLECATEGORIE;
			this.TA_LIBELLETARIF = clsCtparbranchecategorietarif.TA_LIBELLETARIF;
            //private string _CB_LIBELLEBRANCHE = "";
            //private string _AU_LIBELLECATEGORIE = "";
        }

        #endregion

    }
}
