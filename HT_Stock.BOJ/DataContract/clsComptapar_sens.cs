using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsComptapar_sens : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _COMPTAPAR_SENS_CODE = "";
		private string _COMPTAPAR_SENS_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string COMPTAPAR_SENS_CODE
		{
			get { return _COMPTAPAR_SENS_CODE; }
			set {  _COMPTAPAR_SENS_CODE = value; }
		}

		public string COMPTAPAR_SENS_LIBELLE
		{
			get { return _COMPTAPAR_SENS_LIBELLE; }
			set {  _COMPTAPAR_SENS_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsComptapar_sens(){}
		public clsComptapar_sens(clsComptapar_sens clsComptapar_sens)
		{
			this.COMPTAPAR_SENS_CODE = clsComptapar_sens.COMPTAPAR_SENS_CODE;
			this.COMPTAPAR_SENS_LIBELLE = clsComptapar_sens.COMPTAPAR_SENS_LIBELLE;
		}

		#endregion

	}
}
