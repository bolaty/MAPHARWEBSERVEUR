using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsComptapar_taux
	{
		#region VARIABLES LOCALES

		private string _COMPTAPAR_TAUX_CODE = "";
		private string _COMPTAPAR_TAUX_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string COMPTAPAR_TAUX_CODE
		{
			get { return _COMPTAPAR_TAUX_CODE; }
			set {  _COMPTAPAR_TAUX_CODE = value; }
		}

		public string COMPTAPAR_TAUX_LIBELLE
		{
			get { return _COMPTAPAR_TAUX_LIBELLE; }
			set {  _COMPTAPAR_TAUX_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsComptapar_taux(){}
		public clsComptapar_taux(clsComptapar_taux clsComptapar_taux)
		{
			this.COMPTAPAR_TAUX_CODE = clsComptapar_taux.COMPTAPAR_TAUX_CODE;
			this.COMPTAPAR_TAUX_LIBELLE = clsComptapar_taux.COMPTAPAR_TAUX_LIBELLE;
		}

		#endregion

	}
}
