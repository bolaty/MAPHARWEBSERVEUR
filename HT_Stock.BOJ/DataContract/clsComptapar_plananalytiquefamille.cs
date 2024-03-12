using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsComptapar_plananalytiquefamille
	{
		#region VARIABLES LOCALES

		private string _AF_CODE = "";
		private string _AF_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string AF_CODE
		{
			get { return _AF_CODE; }
			set {  _AF_CODE = value; }
		}

		public string AF_LIBELLE
		{
			get { return _AF_LIBELLE; }
			set {  _AF_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsComptapar_plananalytiquefamille(){}
		public clsComptapar_plananalytiquefamille( string AF_CODE,string AF_LIBELLE)
		{
			this.AF_CODE = AF_CODE;
			this.AF_LIBELLE = AF_LIBELLE;
		}
		public clsComptapar_plananalytiquefamille(clsComptapar_plananalytiquefamille clsComptapar_plananalytiquefamille)
		{
			this.AF_CODE = clsComptapar_plananalytiquefamille.AF_CODE;
			this.AF_LIBELLE = clsComptapar_plananalytiquefamille.AF_LIBELLE;
		}

		#endregion

	}
}
