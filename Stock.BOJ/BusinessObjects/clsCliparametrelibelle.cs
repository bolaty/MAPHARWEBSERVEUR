using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparametrelibelle
	{
		#region VARIABLES LOCALES

		private string _PL_CODEPARAMETRELIBELLE = "";
		private string _PL_LIBELLE = "";
		private string _PL_LIBELLEORIGINE = "";

		#endregion

		#region ACCESSEURS

		public string PL_CODEPARAMETRELIBELLE
		{
			get { return _PL_CODEPARAMETRELIBELLE; }
			set {  _PL_CODEPARAMETRELIBELLE = value; }
		}

		public string PL_LIBELLE
		{
			get { return _PL_LIBELLE; }
			set {  _PL_LIBELLE = value; }
		}

		public string PL_LIBELLEORIGINE
		{
			get { return _PL_LIBELLEORIGINE; }
			set {  _PL_LIBELLEORIGINE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparametrelibelle(){}
		public clsCliparametrelibelle( string PL_CODEPARAMETRELIBELLE,string PL_LIBELLE,string PL_LIBELLEORIGINE)
		{
			this.PL_CODEPARAMETRELIBELLE = PL_CODEPARAMETRELIBELLE;
			this.PL_LIBELLE = PL_LIBELLE;
			this.PL_LIBELLEORIGINE = PL_LIBELLEORIGINE;
		}
		public clsCliparametrelibelle(clsCliparametrelibelle clsCliparametrelibelle)
		{
			this.PL_CODEPARAMETRELIBELLE = clsCliparametrelibelle.PL_CODEPARAMETRELIBELLE;
			this.PL_LIBELLE = clsCliparametrelibelle.PL_LIBELLE;
			this.PL_LIBELLEORIGINE = clsCliparametrelibelle.PL_LIBELLEORIGINE;
		}

		#endregion

	}
}
