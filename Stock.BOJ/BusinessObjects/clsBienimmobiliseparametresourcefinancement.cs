using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsBienimmobiliseparametresourcefinancement
	{
		#region VARIABLES LOCALES

		private string _SF_CODESOURCEFINANCEMENT = "";
		private string _SF_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string SF_CODESOURCEFINANCEMENT
		{
			get { return _SF_CODESOURCEFINANCEMENT; }
			set {  _SF_CODESOURCEFINANCEMENT = value; }
		}

		public string SF_LIBELLE
		{
			get { return _SF_LIBELLE; }
			set {  _SF_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBienimmobiliseparametresourcefinancement(){}
		public clsBienimmobiliseparametresourcefinancement( string SF_CODESOURCEFINANCEMENT,string SF_LIBELLE)
		{
			this.SF_CODESOURCEFINANCEMENT = SF_CODESOURCEFINANCEMENT;
			this.SF_LIBELLE = SF_LIBELLE;
		}
		public clsBienimmobiliseparametresourcefinancement(clsBienimmobiliseparametresourcefinancement clsBienimmobiliseparametresourcefinancement)
		{
			this.SF_CODESOURCEFINANCEMENT = clsBienimmobiliseparametresourcefinancement.SF_CODESOURCEFINANCEMENT;
			this.SF_LIBELLE = clsBienimmobiliseparametresourcefinancement.SF_LIBELLE;
		}

		#endregion

	}
}
