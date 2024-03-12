using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace HT_Stock.BOJ
{
	public class clsCtparstatutcontrat : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _CT_CODESTAUT = "";
		private string _CT_LIBELLESTATUT = "";
		private string _CT_NUMEROORDRE = "0";

		#endregion

		#region ACCESSEURS

		public string CT_CODESTAUT
		{
			get { return _CT_CODESTAUT; }
			set {  _CT_CODESTAUT = value; }
		}

		public string CT_LIBELLESTATUT
		{
			get { return _CT_LIBELLESTATUT; }
			set {  _CT_LIBELLESTATUT = value; }
		}

		public string CT_NUMEROORDRE
		{
			get { return _CT_NUMEROORDRE; }
			set {  _CT_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparstatutcontrat(){}
		public clsCtparstatutcontrat( string CT_CODESTAUT,string CT_LIBELLESTATUT,string CT_NUMEROORDRE)
		{
			this.CT_CODESTAUT = CT_CODESTAUT;
			this.CT_LIBELLESTATUT = CT_LIBELLESTATUT;
			this.CT_NUMEROORDRE = CT_NUMEROORDRE;
		}
		public clsCtparstatutcontrat(clsCtparstatutcontrat clsCtparstatutcontrat)
		{
			this.CT_CODESTAUT = clsCtparstatutcontrat.CT_CODESTAUT;
			this.CT_LIBELLESTATUT = clsCtparstatutcontrat.CT_LIBELLESTATUT;
			this.CT_NUMEROORDRE = clsCtparstatutcontrat.CT_NUMEROORDRE;
		}

		#endregion

	}
}
