using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPlan_rerporting : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _PLAN_REPORTING_CODE = "";
        private string _TYPE_PLAN_CODE = "";
		private string _PLAN_RERPORTING_INTITULE = "";
		private string _PLAN_RERPORTING_ABREGE = "";
        private string _TS_CODE = "";
		private string _PLAN_RERPORTING_NOMBRE_LIGNE = "";
        private string _PLAN_REPORTING_NUMERO = "";

		#endregion

		#region ACCESSEURS

		public string PLAN_REPORTING_CODE
		{
			get { return _PLAN_REPORTING_CODE; }
			set {  _PLAN_REPORTING_NUMERO = value; }
		}

        public string TYPE_PLAN_CODE
		{
            get { return _TYPE_PLAN_CODE; }
            set { _TYPE_PLAN_CODE = value; }
		}

		public string PLAN_RERPORTING_INTITULE
		{
			get { return _PLAN_RERPORTING_INTITULE; }
			set {  _PLAN_RERPORTING_INTITULE = value; }
		}

		public string PLAN_RERPORTING_ABREGE
		{
			get { return _PLAN_RERPORTING_ABREGE; }
			set {  _PLAN_RERPORTING_ABREGE = value; }
		}

        public string TS_CODE
		{
            get { return _TS_CODE; }
            set { _TS_CODE = value; }
		}

		public string PLAN_RERPORTING_NOMBRE_LIGNE
		{
			get { return _PLAN_RERPORTING_NOMBRE_LIGNE; }
			set {  _PLAN_RERPORTING_NOMBRE_LIGNE = value; }
		}

        public string PLAN_REPORTING_NUMERO
        {
            get { return _PLAN_REPORTING_NUMERO; }
            set { _PLAN_REPORTING_NUMERO = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsPlan_rerporting(){}
		
		public clsPlan_rerporting(clsPlan_rerporting clsPlan_rerporting)
		{
            PLAN_REPORTING_CODE = clsPlan_rerporting.PLAN_REPORTING_CODE;
            TYPE_PLAN_CODE = clsPlan_rerporting.TYPE_PLAN_CODE;
			PLAN_RERPORTING_INTITULE = clsPlan_rerporting.PLAN_RERPORTING_INTITULE;
			PLAN_RERPORTING_ABREGE = clsPlan_rerporting.PLAN_RERPORTING_ABREGE;
            TS_CODE = clsPlan_rerporting.TS_CODE;
			PLAN_RERPORTING_NOMBRE_LIGNE = clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE;
            PLAN_REPORTING_NUMERO = clsPlan_rerporting.PLAN_REPORTING_NUMERO;
		}

		#endregion

	}
}
