using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhapartypecontact
	{
		#region VARIABLES LOCALES

		private string _TC_CODETYPECONTACT = "";
		private string _TC_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TC_CODETYPECONTACT
		{
			get { return _TC_CODETYPECONTACT; }
			set {  _TC_CODETYPECONTACT = value; }
		}

		public string TC_LIBELLE
		{
			get { return _TC_LIBELLE; }
			set {  _TC_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypecontact(){}
		public clsPhapartypecontact( string TC_CODETYPECONTACT,string TC_LIBELLE)
		{
			this.TC_CODETYPECONTACT = TC_CODETYPECONTACT;
			this.TC_LIBELLE = TC_LIBELLE;
		}
		public clsPhapartypecontact(clsPhapartypecontact clsPhapartypecontact)
		{
			this.TC_CODETYPECONTACT = clsPhapartypecontact.TC_CODETYPECONTACT;
			this.TC_LIBELLE = clsPhapartypecontact.TC_LIBELLE;
		}

		#endregion

	}
}
