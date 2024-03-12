using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsMouvementcomptableanalytique
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private DateTime _MC_DATEPIECE = DateTime.Parse("01/01/1900");
		private string _MC_NUMPIECE = "";
		private string _MC_NUMSEQUENCE = "";
		private string _AF_CODE = "";
        private string _PLAN_ANALYTIQUE_CODE = "";
		private double _MA_MONTANT = 0;

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public DateTime MC_DATEPIECE
		{
			get { return _MC_DATEPIECE; }
			set {  _MC_DATEPIECE = value; }
		}

		public string MC_NUMPIECE
		{
			get { return _MC_NUMPIECE; }
			set {  _MC_NUMPIECE = value; }
		}

		public string MC_NUMSEQUENCE
		{
			get { return _MC_NUMSEQUENCE; }
			set {  _MC_NUMSEQUENCE = value; }
		}

		public string AF_CODE
		{
			get { return _AF_CODE; }
			set {  _AF_CODE = value; }
		}

        public string PLAN_ANALYTIQUE_CODE
		{
			get { return _PLAN_ANALYTIQUE_CODE; }
			set {  _PLAN_ANALYTIQUE_CODE = value; }
		}

		public double MA_MONTANT
		{
			get { return _MA_MONTANT; }
			set {  _MA_MONTANT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsMouvementcomptableanalytique(){}

		public clsMouvementcomptableanalytique(clsMouvementcomptableanalytique clsMouvementcomptableanalytique)
		{
			this.AG_CODEAGENCE = clsMouvementcomptableanalytique.AG_CODEAGENCE;
			this.MC_DATEPIECE = clsMouvementcomptableanalytique.MC_DATEPIECE;
			this.MC_NUMPIECE = clsMouvementcomptableanalytique.MC_NUMPIECE;
			this.MC_NUMSEQUENCE = clsMouvementcomptableanalytique.MC_NUMSEQUENCE;
			this.AF_CODE = clsMouvementcomptableanalytique.AF_CODE;
			this.PLAN_ANALYTIQUE_CODE = clsMouvementcomptableanalytique.PLAN_ANALYTIQUE_CODE;
			this.MA_MONTANT = clsMouvementcomptableanalytique.MA_MONTANT;
		}

		#endregion

	}
}
