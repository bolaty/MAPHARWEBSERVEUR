using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhapartaxe
	{
		#region VARIABLES LOCALES

		private string _TA_CODETAXE = "";
		private string _TA_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TA_CODETAXE
		{
			get { return _TA_CODETAXE; }
			set {  _TA_CODETAXE = value; }
		}

		public string TA_LIBELLE
		{
			get { return _TA_LIBELLE; }
			set {  _TA_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartaxe(){}
		public clsPhapartaxe( string TA_CODETAXE,string TA_LIBELLE)
		{
			this.TA_CODETAXE = TA_CODETAXE;
			this.TA_LIBELLE = TA_LIBELLE;
		}
		public clsPhapartaxe(clsPhapartaxe clsPhapartaxe)
		{
			this.TA_CODETAXE = clsPhapartaxe.TA_CODETAXE;
			this.TA_LIBELLE = clsPhapartaxe.TA_LIBELLE;
		}

		#endregion

	}
}
