using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsComptapar_typesaut
	{
		#region VARIABLES LOCALES

		private string _TS_CODE = "";
		private string _TS_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TS_CODE
		{
			get { return _TS_CODE; }
			set {  _TS_CODE = value; }
		}

		public string TS_LIBELLE
		{
			get { return _TS_LIBELLE; }
			set {  _TS_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsComptapar_typesaut(){}
		public clsComptapar_typesaut( string TS_CODE,string TS_LIBELLE)
		{
			this.TS_CODE = TS_CODE;
			this.TS_LIBELLE = TS_LIBELLE;
		}
		public clsComptapar_typesaut(clsComptapar_typesaut clsComptapar_typesaut)
		{
			this.TS_CODE = clsComptapar_typesaut.TS_CODE;
			this.TS_LIBELLE = clsComptapar_typesaut.TS_LIBELLE;
		}

		#endregion

	}
}
