using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsBusinessplanparamdocumentdetailfamille
	{
		#region VARIABLES LOCALES

		private string _PA_CODEDOCUMENTDETAILFAMILLE = "";
		private string _PA_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PA_CODEDOCUMENTDETAILFAMILLE
		{
			get { return _PA_CODEDOCUMENTDETAILFAMILLE; }
			set {  _PA_CODEDOCUMENTDETAILFAMILLE = value; }
		}

		public string PA_LIBELLE
		{
			get { return _PA_LIBELLE; }
			set {  _PA_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparamdocumentdetailfamille(){}
		public clsBusinessplanparamdocumentdetailfamille( string PA_CODEDOCUMENTDETAILFAMILLE,string PA_LIBELLE)
		{
			this.PA_CODEDOCUMENTDETAILFAMILLE = PA_CODEDOCUMENTDETAILFAMILLE;
			this.PA_LIBELLE = PA_LIBELLE;
		}
		public clsBusinessplanparamdocumentdetailfamille(clsBusinessplanparamdocumentdetailfamille clsBusinessplanparamdocumentdetailfamille)
		{
			this.PA_CODEDOCUMENTDETAILFAMILLE = clsBusinessplanparamdocumentdetailfamille.PA_CODEDOCUMENTDETAILFAMILLE;
			this.PA_LIBELLE = clsBusinessplanparamdocumentdetailfamille.PA_LIBELLE;
		}

		#endregion

	}
}
