using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparcoeficient
	{
		#region VARIABLES LOCALES

		private string _CF_CODECOEFICIENT = "";
		private string _CF_LETTRECOEFICIENT = "";
		private string _CF_LIBELLECOEFICIENT = "";
		private string _CF_ACTIF = "";
		private int _CF_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string CF_CODECOEFICIENT
		{
			get { return _CF_CODECOEFICIENT; }
			set {  _CF_CODECOEFICIENT = value; }
		}

		public string CF_LETTRECOEFICIENT
		{
			get { return _CF_LETTRECOEFICIENT; }
			set {  _CF_LETTRECOEFICIENT = value; }
		}

		public string CF_LIBELLECOEFICIENT
		{
			get { return _CF_LIBELLECOEFICIENT; }
			set {  _CF_LIBELLECOEFICIENT = value; }
		}

		public string CF_ACTIF
		{
			get { return _CF_ACTIF; }
			set {  _CF_ACTIF = value; }
		}

		public int CF_NUMEROORDRE
		{
			get { return _CF_NUMEROORDRE; }
			set {  _CF_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparcoeficient(){}
		public clsCliparcoeficient( string CF_CODECOEFICIENT,string CF_LETTRECOEFICIENT,string CF_LIBELLECOEFICIENT,string CF_ACTIF,int CF_NUMEROORDRE)
		{
			this.CF_CODECOEFICIENT = CF_CODECOEFICIENT;
			this.CF_LETTRECOEFICIENT = CF_LETTRECOEFICIENT;
			this.CF_LIBELLECOEFICIENT = CF_LIBELLECOEFICIENT;
			this.CF_ACTIF = CF_ACTIF;
			this.CF_NUMEROORDRE = CF_NUMEROORDRE;
		}
		public clsCliparcoeficient(clsCliparcoeficient clsCliparcoeficient)
		{
			this.CF_CODECOEFICIENT = clsCliparcoeficient.CF_CODECOEFICIENT;
			this.CF_LETTRECOEFICIENT = clsCliparcoeficient.CF_LETTRECOEFICIENT;
			this.CF_LIBELLECOEFICIENT = clsCliparcoeficient.CF_LIBELLECOEFICIENT;
			this.CF_ACTIF = clsCliparcoeficient.CF_ACTIF;
			this.CF_NUMEROORDRE = clsCliparcoeficient.CF_NUMEROORDRE;
		}

		#endregion

	}
}
