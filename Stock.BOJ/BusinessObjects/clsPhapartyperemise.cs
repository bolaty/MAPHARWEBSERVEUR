using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartyperemise
	{
		#region VARIABLES LOCALES

		private string _TR_CODETYPEQUANTITE = "";
		private string _TR_LIBELLE = "";
		private string _TR_DESCRIPTION = "";

		#endregion

		#region ACCESSEURS

		public string TR_CODETYPEQUANTITE
		{
			get { return _TR_CODETYPEQUANTITE; }
			set {  _TR_CODETYPEQUANTITE = value; }
		}

		public string TR_LIBELLE
		{
			get { return _TR_LIBELLE; }
			set {  _TR_LIBELLE = value; }
		}

		public string TR_DESCRIPTION
		{
			get { return _TR_DESCRIPTION; }
			set {  _TR_DESCRIPTION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartyperemise(){}
		public clsPhapartyperemise( string TR_CODETYPEQUANTITE,string TR_LIBELLE,string TR_DESCRIPTION)
		{
			this.TR_CODETYPEQUANTITE = TR_CODETYPEQUANTITE;
			this.TR_LIBELLE = TR_LIBELLE;
			this.TR_DESCRIPTION = TR_DESCRIPTION;
		}
		public clsPhapartyperemise(clsPhapartyperemise clsPhapartyperemise)
		{
			this.TR_CODETYPEQUANTITE = clsPhapartyperemise.TR_CODETYPEQUANTITE;
			this.TR_LIBELLE = clsPhapartyperemise.TR_LIBELLE;
			this.TR_DESCRIPTION = clsPhapartyperemise.TR_DESCRIPTION;
		}

		#endregion

	}
}
