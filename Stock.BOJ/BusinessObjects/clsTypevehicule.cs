using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTypevehicule
	{
		#region VARIABLES LOCALES

		private string _TVH_CODETYPE = "";
		private string _TVH_LIBELE = "";

		#endregion

		#region ACCESSEURS

		public string TVH_CODETYPE
		{
			get { return _TVH_CODETYPE; }
			set {  _TVH_CODETYPE = value; }
		}

		public string TVH_LIBELE
		{
			get { return _TVH_LIBELE; }
			set {  _TVH_LIBELE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTypevehicule(){}
		public clsTypevehicule( string TVH_CODETYPE,string TVH_LIBELE)
		{
			this.TVH_CODETYPE = TVH_CODETYPE;
			this.TVH_LIBELE = TVH_LIBELE;
		}
		public clsTypevehicule(clsTypevehicule clsTypevehicule)
		{
			this.TVH_CODETYPE = clsTypevehicule.TVH_CODETYPE;
			this.TVH_LIBELE = clsTypevehicule.TVH_LIBELE;
		}

		#endregion

	}
}
