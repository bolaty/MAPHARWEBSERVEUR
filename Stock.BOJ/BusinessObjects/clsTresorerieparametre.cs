using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTresorerieparametre
	{
		#region VARIABLES LOCALES

		private string _TP_CODETRESORERIPARAMETRE = "";
		private string _TP_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TP_CODETRESORERIPARAMETRE
		{
			get { return _TP_CODETRESORERIPARAMETRE; }
			set {  _TP_CODETRESORERIPARAMETRE = value; }
		}

		public string TP_LIBELLE
		{
			get { return _TP_LIBELLE; }
			set {  _TP_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieparametre(){}
		public clsTresorerieparametre( string TP_CODETRESORERIPARAMETRE,string TP_LIBELLE)
		{
			this.TP_CODETRESORERIPARAMETRE = TP_CODETRESORERIPARAMETRE;
			this.TP_LIBELLE = TP_LIBELLE;
		}
		public clsTresorerieparametre(clsTresorerieparametre clsTresorerieparametre)
		{
			this.TP_CODETRESORERIPARAMETRE = clsTresorerieparametre.TP_CODETRESORERIPARAMETRE;
			this.TP_LIBELLE = clsTresorerieparametre.TP_LIBELLE;
		}

		#endregion

	}
}
