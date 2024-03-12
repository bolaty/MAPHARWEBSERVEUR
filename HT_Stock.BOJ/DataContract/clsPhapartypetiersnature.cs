using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhapartypetiersnature
	{
		#region VARIABLES LOCALES

		private string _NT_CODENATURETYPETIERS = "";
		private string _NT_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string NT_CODENATURETYPETIERS
		{
			get { return _NT_CODENATURETYPETIERS; }
			set {  _NT_CODENATURETYPETIERS = value; }
		}

		public string NT_LIBELLE
		{
			get { return _NT_LIBELLE; }
			set {  _NT_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypetiersnature(){}
		public clsPhapartypetiersnature( string NT_CODENATURETYPETIERS,string NT_LIBELLE)
		{
			this.NT_CODENATURETYPETIERS = NT_CODENATURETYPETIERS;
			this.NT_LIBELLE = NT_LIBELLE;
		}
		public clsPhapartypetiersnature(clsPhapartypetiersnature clsPhapartypetiersnature)
		{
			this.NT_CODENATURETYPETIERS = clsPhapartypetiersnature.NT_CODENATURETYPETIERS;
			this.NT_LIBELLE = clsPhapartypetiersnature.NT_LIBELLE;
		}

		#endregion

	}
}
