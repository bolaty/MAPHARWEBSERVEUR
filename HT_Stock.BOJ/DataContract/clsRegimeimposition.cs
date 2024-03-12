using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsRegimeimposition : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _RE_CODEREGIMEIMPOSITION = "";
		private string _RE_LIBELLEREGIMEIMPOSITION = "";
		private int _RE_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string RE_CODEREGIMEIMPOSITION
		{
			get { return _RE_CODEREGIMEIMPOSITION; }
			set {  _RE_CODEREGIMEIMPOSITION = value; }
		}

		public string RE_LIBELLEREGIMEIMPOSITION
		{
			get { return _RE_LIBELLEREGIMEIMPOSITION; }
			set {  _RE_LIBELLEREGIMEIMPOSITION = value; }
		}

		public int RE_NUMEROORDRE
		{
			get { return _RE_NUMEROORDRE; }
			set {  _RE_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsRegimeimposition(){}
		public clsRegimeimposition( string RE_CODEREGIMEIMPOSITION,string RE_LIBELLEREGIMEIMPOSITION,int RE_NUMEROORDRE)
		{
			this.RE_CODEREGIMEIMPOSITION = RE_CODEREGIMEIMPOSITION;
			this.RE_LIBELLEREGIMEIMPOSITION = RE_LIBELLEREGIMEIMPOSITION;
			this.RE_NUMEROORDRE = RE_NUMEROORDRE;
		}
		public clsRegimeimposition(clsRegimeimposition clsRegimeimposition)
		{
			this.RE_CODEREGIMEIMPOSITION = clsRegimeimposition.RE_CODEREGIMEIMPOSITION;
			this.RE_LIBELLEREGIMEIMPOSITION = clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION;
			this.RE_NUMEROORDRE = clsRegimeimposition.RE_NUMEROORDRE;
		}

		#endregion

	}
}
