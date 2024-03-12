using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPlan_analytique
	{
		#region VARIABLES LOCALES

		private string _PLAN_ANALYTIQUE_CODE = "";
        private string _TYPE_PLAN_CODE = "";
		private string _PLAN_ANALYTIQUE_INTITULE = "";
		private string _PLAN_ANALYTIQUE_ABREGE = "";
		private string _PLAN_ANALYTIQUE_REPORT_A_NOUVEAU = "";
		private string _PLAN_ANALYTIQUE_MISE_EN_SOMMEIL = "";
        private string _PLAN_ANALYTIQUE_NUM_SECTION = "";
        private string _AF_CODE = "";
        private string _TS_CODE = "";
        private string _PLAN_ANALYTIQUE_NOMBRE_LIGNE = "";

		#endregion

		#region ACCESSEURS

		public string PLAN_ANALYTIQUE_CODE
		{
			get { return _PLAN_ANALYTIQUE_CODE; }
			set {  _PLAN_ANALYTIQUE_CODE = value; }
		}

        public string TYPE_PLAN_CODE
		{
            get { return _TYPE_PLAN_CODE; }
            set { _TYPE_PLAN_CODE = value; }
		}

		public string PLAN_ANALYTIQUE_INTITULE
		{
			get { return _PLAN_ANALYTIQUE_INTITULE; }
			set {  _PLAN_ANALYTIQUE_INTITULE = value; }
		}

		public string PLAN_ANALYTIQUE_ABREGE
		{
			get { return _PLAN_ANALYTIQUE_ABREGE; }
			set {  _PLAN_ANALYTIQUE_ABREGE = value; }
		}

		public string PLAN_ANALYTIQUE_REPORT_A_NOUVEAU
		{
			get { return _PLAN_ANALYTIQUE_REPORT_A_NOUVEAU; }
			set {  _PLAN_ANALYTIQUE_REPORT_A_NOUVEAU = value; }
		}

		public string PLAN_ANALYTIQUE_MISE_EN_SOMMEIL
		{
			get { return _PLAN_ANALYTIQUE_MISE_EN_SOMMEIL; }
			set {  _PLAN_ANALYTIQUE_MISE_EN_SOMMEIL = value; }
		}

        public string PLAN_ANALYTIQUE_NUM_SECTION
        {
            get { return _PLAN_ANALYTIQUE_NUM_SECTION; }
            set { _PLAN_ANALYTIQUE_NUM_SECTION = value; }
        }

        public string AF_CODE
        {
            get { return _AF_CODE; }
            set { _AF_CODE = value; }
        }

        public string TS_CODE
        {
            get { return _TS_CODE; }
            set { _TS_CODE = value; }
        }

        public string PLAN_ANALYTIQUE_NOMBRE_LIGNE
        {
            get { return _PLAN_ANALYTIQUE_NOMBRE_LIGNE; }
            set { _PLAN_ANALYTIQUE_NOMBRE_LIGNE = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsPlan_analytique(){}
		
		public clsPlan_analytique(clsPlan_analytique clsPlan_analytique)
		{
			this.PLAN_ANALYTIQUE_CODE = clsPlan_analytique.PLAN_ANALYTIQUE_CODE;
            this.TYPE_PLAN_CODE = clsPlan_analytique.TYPE_PLAN_CODE;
			this.PLAN_ANALYTIQUE_INTITULE = clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE;
			this.PLAN_ANALYTIQUE_ABREGE = clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE;
			this.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU = clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU;
			this.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL = clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL;
            this.PLAN_ANALYTIQUE_NUM_SECTION = clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION;
            this.AF_CODE = clsPlan_analytique.AF_CODE;
            this.TS_CODE = clsPlan_analytique.TS_CODE;
            this.PLAN_ANALYTIQUE_NOMBRE_LIGNE = clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE;

		}

		#endregion

	}
}
