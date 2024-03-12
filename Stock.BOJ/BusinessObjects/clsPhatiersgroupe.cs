using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhatiersgroupe
	{
		#region VARIABLES LOCALES

		private string _GP_CODEGROUPE = "";
		private string _GP_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string GP_CODEGROUPE
		{
			get { return _GP_CODEGROUPE; }
			set {  _GP_CODEGROUPE = value; }
		}

		public string GP_LIBELLE
		{
			get { return _GP_LIBELLE; }
			set {  _GP_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhatiersgroupe(){}
		public clsPhatiersgroupe( string GP_CODEGROUPE,string GP_LIBELLE)
		{
			this.GP_CODEGROUPE = GP_CODEGROUPE;
			this.GP_LIBELLE = GP_LIBELLE;
		}
		public clsPhatiersgroupe(clsPhatiersgroupe clsPhatiersgroupe)
		{
			this.GP_CODEGROUPE = clsPhatiersgroupe.GP_CODEGROUPE;
			this.GP_LIBELLE = clsPhatiersgroupe.GP_LIBELLE;
		}

		#endregion

	}
}
