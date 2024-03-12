using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparmainforte : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _MF_CODEMAINFORTE = "";
		private string _MF_LIBLLEMAINFORTE = "";
		private string _MF_NUMEROORDRE = "";

		#endregion

		#region ACCESSEURS

		public string MF_CODEMAINFORTE
		{
			get { return _MF_CODEMAINFORTE; }
			set {  _MF_CODEMAINFORTE = value; }
		}

		public string MF_LIBLLEMAINFORTE
		{
			get { return _MF_LIBLLEMAINFORTE; }
			set {  _MF_LIBLLEMAINFORTE = value; }
		}

		public string MF_NUMEROORDRE
		{
			get { return _MF_NUMEROORDRE; }
			set {  _MF_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparmainforte(){}
		
		public clsCtparmainforte(clsCtparmainforte clsCtparmainforte)
		{
			this.MF_CODEMAINFORTE = clsCtparmainforte.MF_CODEMAINFORTE;
			this.MF_LIBLLEMAINFORTE = clsCtparmainforte.MF_LIBLLEMAINFORTE;
			this.MF_NUMEROORDRE = clsCtparmainforte.MF_NUMEROORDRE;
		}

		#endregion

	}
}
