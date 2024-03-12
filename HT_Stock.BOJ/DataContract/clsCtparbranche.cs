using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparbranche : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _CB_IDBRANCHE = "";
		private string _CB_CODEBRANCHE = "";
		private string _CB_LIBELLEBRANCHE = "";
		private string _CB_ACTIF = "";
		private int _CB_NUMEROORDRE = 0;
		private string _RQ_CODERISQUE = "";

		#endregion

		#region ACCESSEURS

		public string CB_IDBRANCHE
		{
			get { return _CB_IDBRANCHE; }
			set {  _CB_IDBRANCHE = value; }
		}

		public string CB_CODEBRANCHE
		{
			get { return _CB_CODEBRANCHE; }
			set {  _CB_CODEBRANCHE = value; }
		}

		public string CB_LIBELLEBRANCHE
		{
			get { return _CB_LIBELLEBRANCHE; }
			set {  _CB_LIBELLEBRANCHE = value; }
		}

		public string CB_ACTIF
		{
			get { return _CB_ACTIF; }
			set {  _CB_ACTIF = value; }
		}

		public int CB_NUMEROORDRE
		{
			get { return _CB_NUMEROORDRE; }
			set {  _CB_NUMEROORDRE = value; }
		}

        public string RQ_CODERISQUE
        {
	        get { return _RQ_CODERISQUE; }
	        set { _RQ_CODERISQUE = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsCtparbranche(){}

		public clsCtparbranche(clsCtparbranche clsCtparbranche)
		{
			this.CB_IDBRANCHE = clsCtparbranche.CB_IDBRANCHE;
			this.CB_CODEBRANCHE = clsCtparbranche.CB_CODEBRANCHE;
			this.CB_LIBELLEBRANCHE = clsCtparbranche.CB_LIBELLEBRANCHE;
			this.CB_ACTIF = clsCtparbranche.CB_ACTIF;
			this.CB_NUMEROORDRE = clsCtparbranche.CB_NUMEROORDRE;
			this.RQ_CODERISQUE = clsCtparbranche.RQ_CODERISQUE;

		}

		#endregion

	}
}
