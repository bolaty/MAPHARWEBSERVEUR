using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPharparpresentationproduit
	{
		#region VARIABLES LOCALES

		private string _PR_CODEPRESENTATION = "";
		private string _PR_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PR_CODEPRESENTATION
		{
			get { return _PR_CODEPRESENTATION; }
			set {  _PR_CODEPRESENTATION = value; }
		}

		public string PR_LIBELLE
		{
			get { return _PR_LIBELLE; }
			set {  _PR_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPharparpresentationproduit(){}
		public clsPharparpresentationproduit( string PR_CODEPRESENTATION,string PR_LIBELLE)
		{
			this.PR_CODEPRESENTATION = PR_CODEPRESENTATION;
			this.PR_LIBELLE = PR_LIBELLE;
		}
		public clsPharparpresentationproduit(clsPharparpresentationproduit clsPharparpresentationproduit)
		{
			this.PR_CODEPRESENTATION = clsPharparpresentationproduit.PR_CODEPRESENTATION;
			this.PR_LIBELLE = clsPharparpresentationproduit.PR_LIBELLE;
		}

		#endregion

	}
}
