using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhapartypeboite
	{
		#region VARIABLES LOCALES

		private string _BO_CODETYPEBOITE = "";
		private string _BO_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string BO_CODETYPEBOITE
		{
			get { return _BO_CODETYPEBOITE; }
			set {  _BO_CODETYPEBOITE = value; }
		}

		public string BO_LIBELLE
		{
			get { return _BO_LIBELLE; }
			set {  _BO_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypeboite(){}
		
		public clsPhapartypeboite(clsPhapartypeboite clsPhapartypeboite)
		{
			this.BO_CODETYPEBOITE = clsPhapartypeboite.BO_CODETYPEBOITE;
			this.BO_LIBELLE = clsPhapartypeboite.BO_LIBELLE;
		}

		#endregion

	}
}
