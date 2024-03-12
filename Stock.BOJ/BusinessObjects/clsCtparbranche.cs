using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparbranche
	{
		#region VARIABLES LOCALES

		private string _CB_IDBRANCHE = "";
		private string _CB_CODEBRANCHE = "";
		private string _CB_LIBELLEBRANCHE = "";
		private string _CB_ACTIF = "";
		private int _CB_NUMEROORDRE = 0;

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


		#endregion

		#region INSTANCIATEURS

		public clsCtparbranche(){}
		public clsCtparbranche( string CB_IDBRANCHE,string CB_CODEBRANCHE,string CB_LIBELLEBRANCHE,string CB_ACTIF,int CB_NUMEROORDRE)
		{
			this.CB_IDBRANCHE = CB_IDBRANCHE;
			this.CB_CODEBRANCHE = CB_CODEBRANCHE;
			this.CB_LIBELLEBRANCHE = CB_LIBELLEBRANCHE;
			this.CB_ACTIF = CB_ACTIF;
			this.CB_NUMEROORDRE = CB_NUMEROORDRE;
		}
		public clsCtparbranche(clsCtparbranche clsCtparbranche)
		{
			this.CB_IDBRANCHE = clsCtparbranche.CB_IDBRANCHE;
			this.CB_CODEBRANCHE = clsCtparbranche.CB_CODEBRANCHE;
			this.CB_LIBELLEBRANCHE = clsCtparbranche.CB_LIBELLEBRANCHE;
			this.CB_ACTIF = clsCtparbranche.CB_ACTIF;
			this.CB_NUMEROORDRE = clsCtparbranche.CB_NUMEROORDRE;
		}

		#endregion

	}
}
