using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparretenue
	{
		#region VARIABLES LOCALES

		private string _RE_CODERETENUE = "";
		private string _RE_LIBELLE = "";
		private string _RE_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public string RE_CODERETENUE
		{
			get { return _RE_CODERETENUE; }
			set {  _RE_CODERETENUE = value; }
		}

		public string RE_LIBELLE
		{
			get { return _RE_LIBELLE; }
			set {  _RE_LIBELLE = value; }
		}

		public string RE_ACTIF
		{
			get { return _RE_ACTIF; }
			set {  _RE_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparretenue(){}
		public clsPhaparretenue( string RE_CODERETENUE,string RE_LIBELLE,string RE_ACTIF)
		{
			this.RE_CODERETENUE = RE_CODERETENUE;
			this.RE_LIBELLE = RE_LIBELLE;
			this.RE_ACTIF = RE_ACTIF;
		}
		public clsPhaparretenue(clsPhaparretenue clsPhaparretenue)
		{
			this.RE_CODERETENUE = clsPhaparretenue.RE_CODERETENUE;
			this.RE_LIBELLE = clsPhaparretenue.RE_LIBELLE;
			this.RE_ACTIF = clsPhaparretenue.RE_ACTIF;
		}

		#endregion

	}
}
