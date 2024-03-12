using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhapartypequantite
	{
		#region VARIABLES LOCALES

		private string _TQ_CODETYPEQUANTITE = "";
		private string _TQ_LIBELLE = "";
		private string _TQ_DESCRIPTION = "";

		#endregion

		#region ACCESSEURS

		public string TQ_CODETYPEQUANTITE
		{
			get { return _TQ_CODETYPEQUANTITE; }
			set {  _TQ_CODETYPEQUANTITE = value; }
		}

		public string TQ_LIBELLE
		{
			get { return _TQ_LIBELLE; }
			set {  _TQ_LIBELLE = value; }
		}

		public string TQ_DESCRIPTION
		{
			get { return _TQ_DESCRIPTION; }
			set {  _TQ_DESCRIPTION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypequantite(){}
		public clsPhapartypequantite( string TQ_CODETYPEQUANTITE,string TQ_LIBELLE,string TQ_DESCRIPTION)
		{
			this.TQ_CODETYPEQUANTITE = TQ_CODETYPEQUANTITE;
			this.TQ_LIBELLE = TQ_LIBELLE;
			this.TQ_DESCRIPTION = TQ_DESCRIPTION;
		}
		public clsPhapartypequantite(clsPhapartypequantite clsPhapartypequantite)
		{
			this.TQ_CODETYPEQUANTITE = clsPhapartypequantite.TQ_CODETYPEQUANTITE;
			this.TQ_LIBELLE = clsPhapartypequantite.TQ_LIBELLE;
			this.TQ_DESCRIPTION = clsPhapartypequantite.TQ_DESCRIPTION;
		}

		#endregion

	}
}
