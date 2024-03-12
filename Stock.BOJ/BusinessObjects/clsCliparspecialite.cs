using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparspecialite
	{
		#region VARIABLES LOCALES

		private string _SP_CODESPECIALITE = "";
		private string _SP_LIBELLESPECIALITE = "";

		#endregion

		#region ACCESSEURS

		public string SP_CODESPECIALITE
		{
			get { return _SP_CODESPECIALITE; }
			set {  _SP_CODESPECIALITE = value; }
		}

		public string SP_LIBELLESPECIALITE
		{
			get { return _SP_LIBELLESPECIALITE; }
			set {  _SP_LIBELLESPECIALITE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparspecialite(){}
		public clsCliparspecialite( string SP_CODESPECIALITE,string SP_LIBELLESPECIALITE)
		{
			this.SP_CODESPECIALITE = SP_CODESPECIALITE;
			this.SP_LIBELLESPECIALITE = SP_LIBELLESPECIALITE;
		}
		public clsCliparspecialite(clsCliparspecialite clsCliparspecialite)
		{
			this.SP_CODESPECIALITE = clsCliparspecialite.SP_CODESPECIALITE;
			this.SP_LIBELLESPECIALITE = clsCliparspecialite.SP_LIBELLESPECIALITE;
		}

		#endregion

	}
}
