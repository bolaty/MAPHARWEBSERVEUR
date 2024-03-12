using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparlocale
	{
		#region VARIABLES LOCALES

		private string _LO_CODELOCALE = "";
		private string _LO_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string LO_CODELOCALE
		{
			get { return _LO_CODELOCALE; }
			set {  _LO_CODELOCALE = value; }
		}

		public string LO_LIBELLE
		{
			get { return _LO_LIBELLE; }
			set {  _LO_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparlocale(){}
		public clsPhaparlocale( string LO_CODELOCALE,string LO_LIBELLE)
		{
			this.LO_CODELOCALE = LO_CODELOCALE;
			this.LO_LIBELLE = LO_LIBELLE;
		}
		public clsPhaparlocale(clsPhaparlocale clsPhaparlocale)
		{
			this.LO_CODELOCALE = clsPhaparlocale.LO_CODELOCALE;
			this.LO_LIBELLE = clsPhaparlocale.LO_LIBELLE;
		}

		#endregion

	}
}
