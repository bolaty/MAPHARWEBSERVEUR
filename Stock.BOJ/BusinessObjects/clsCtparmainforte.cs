using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparmainforte
	{
		#region VARIABLES LOCALES

		private string _MF_CODEMAINFORTE = "";
		private string _MF_LIBLLEMAINFORTE = "";
		private int _MF_NUMEROORDRE = 0;

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

		public int MF_NUMEROORDRE
		{
			get { return _MF_NUMEROORDRE; }
			set {  _MF_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparmainforte(){}
		public clsCtparmainforte( string MF_CODEMAINFORTE,string MF_LIBLLEMAINFORTE,int MF_NUMEROORDRE)
		{
			this.MF_CODEMAINFORTE = MF_CODEMAINFORTE;
			this.MF_LIBLLEMAINFORTE = MF_LIBLLEMAINFORTE;
			this.MF_NUMEROORDRE = MF_NUMEROORDRE;
		}
		public clsCtparmainforte(clsCtparmainforte clsCtparmainforte)
		{
			this.MF_CODEMAINFORTE = clsCtparmainforte.MF_CODEMAINFORTE;
			this.MF_LIBLLEMAINFORTE = clsCtparmainforte.MF_LIBLLEMAINFORTE;
			this.MF_NUMEROORDRE = clsCtparmainforte.MF_NUMEROORDRE;
		}

		#endregion

	}
}
