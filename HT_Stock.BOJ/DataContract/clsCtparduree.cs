using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparduree : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _DU_CODEDUREE = "";
		private string _DU_LIBELLEDUREE = "";
		private string _DU_ACTIF = "";
		private int _DU_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string DU_CODEDUREE
		{
			get { return _DU_CODEDUREE; }
			set {  _DU_CODEDUREE = value; }
		}

		public string DU_LIBELLEDUREE
		{
			get { return _DU_LIBELLEDUREE; }
			set {  _DU_LIBELLEDUREE = value; }
		}

		public string DU_ACTIF
		{
			get { return _DU_ACTIF; }
			set {  _DU_ACTIF = value; }
		}

		public int DU_NUMEROORDRE
		{
			get { return _DU_NUMEROORDRE; }
			set {  _DU_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparduree(){}
		public clsCtparduree( string DU_CODEDUREE,string DU_LIBELLEDUREE,string DU_ACTIF,int DU_NUMEROORDRE)
		{
			this.DU_CODEDUREE = DU_CODEDUREE;
			this.DU_LIBELLEDUREE = DU_LIBELLEDUREE;
			this.DU_ACTIF = DU_ACTIF;
			this.DU_NUMEROORDRE = DU_NUMEROORDRE;
		}
		public clsCtparduree(clsCtparduree clsCtparduree)
		{
			this.DU_CODEDUREE = clsCtparduree.DU_CODEDUREE;
			this.DU_LIBELLEDUREE = clsCtparduree.DU_LIBELLEDUREE;
			this.DU_ACTIF = clsCtparduree.DU_ACTIF;
			this.DU_NUMEROORDRE = clsCtparduree.DU_NUMEROORDRE;
		}

		#endregion

	}
}
