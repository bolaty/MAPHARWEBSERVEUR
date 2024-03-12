using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparmodeinjection
	{
		#region VARIABLES LOCALES

		private string _IN_CODEMODEINJECTION = "";
		private string _IN_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string IN_CODEMODEINJECTION
		{
			get { return _IN_CODEMODEINJECTION; }
			set {  _IN_CODEMODEINJECTION = value; }
		}

		public string IN_LIBELLE
		{
			get { return _IN_LIBELLE; }
			set {  _IN_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparmodeinjection(){}
		public clsPhaparmodeinjection( string IN_CODEMODEINJECTION,string IN_LIBELLE)
		{
			this.IN_CODEMODEINJECTION = IN_CODEMODEINJECTION;
			this.IN_LIBELLE = IN_LIBELLE;
		}
		public clsPhaparmodeinjection(clsPhaparmodeinjection clsPhaparmodeinjection)
		{
			this.IN_CODEMODEINJECTION = clsPhaparmodeinjection.IN_CODEMODEINJECTION;
			this.IN_LIBELLE = clsPhaparmodeinjection.IN_LIBELLE;
		}

		#endregion

	}
}
