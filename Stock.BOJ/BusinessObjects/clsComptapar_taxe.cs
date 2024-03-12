using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsComptapar_taxe
	{
		#region VARIABLES LOCALES

		private string _COMPTAPAR_TAXE_CODE = "";
		private string _COMPTAPAR_SENS_CODE = "";
		private string _COMPTAPAR_TAUX_CODE = "";
		private double _PL_CODENUMCOMPTE = 0;
		private string _COMPTAPAR_TAXE_INTITULE = "";
		private string _COMPTAPAR_TAXE_TYPE = "";

		#endregion

		#region ACCESSEURS

		public string COMPTAPAR_TAXE_CODE
		{
			get { return _COMPTAPAR_TAXE_CODE; }
			set {  _COMPTAPAR_TAXE_CODE = value; }
		}

		public string COMPTAPAR_SENS_CODE
		{
			get { return _COMPTAPAR_SENS_CODE; }
			set {  _COMPTAPAR_SENS_CODE = value; }
		}

		public string COMPTAPAR_TAUX_CODE
		{
			get { return _COMPTAPAR_TAUX_CODE; }
			set {  _COMPTAPAR_TAUX_CODE = value; }
		}

		public double PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}

		public string COMPTAPAR_TAXE_INTITULE
		{
			get { return _COMPTAPAR_TAXE_INTITULE; }
			set {  _COMPTAPAR_TAXE_INTITULE = value; }
		}

		public string COMPTAPAR_TAXE_TYPE
		{
			get { return _COMPTAPAR_TAXE_TYPE; }
			set {  _COMPTAPAR_TAXE_TYPE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsComptapar_taxe(){}
		public clsComptapar_taxe(clsComptapar_taxe clsComptapar_taxe)
		{
			this.COMPTAPAR_TAXE_CODE = clsComptapar_taxe.COMPTAPAR_TAXE_CODE;
			this.COMPTAPAR_SENS_CODE = clsComptapar_taxe.COMPTAPAR_SENS_CODE;
			this.COMPTAPAR_TAUX_CODE = clsComptapar_taxe.COMPTAPAR_TAUX_CODE;
			this.PL_CODENUMCOMPTE = clsComptapar_taxe.PL_CODENUMCOMPTE;
			this.COMPTAPAR_TAXE_INTITULE = clsComptapar_taxe.COMPTAPAR_TAXE_INTITULE;
			this.COMPTAPAR_TAXE_TYPE = clsComptapar_taxe.COMPTAPAR_TAXE_TYPE;
		}

		#endregion

	}
}
