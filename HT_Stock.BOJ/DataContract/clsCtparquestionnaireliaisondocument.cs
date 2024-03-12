using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparquestionnaireliaisondocument : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _DC_CODEDOCUMENT = "";
		private string _DC_LIBELLEDOCUMENT = "";
		private string _QE_CODEQUESTIONNAIRE = "";
		private string _QE_LIBELLEQUESTIONNAIRE = "";
		private string _CQ_VALEUR1 = "N";
		private string _CQ_VALEUR2 = "";

		#endregion

		#region ACCESSEURS

		public string DC_CODEDOCUMENT
		{
			get { return _DC_CODEDOCUMENT; }
			set {  _DC_CODEDOCUMENT = value; }
		}
        public string DC_LIBELLEDOCUMENT
        {
	        get { return _DC_LIBELLEDOCUMENT; }
	        set { _DC_LIBELLEDOCUMENT = value; }
        }
		public string QE_CODEQUESTIONNAIRE
		{
			get { return _QE_CODEQUESTIONNAIRE; }
			set {  _QE_CODEQUESTIONNAIRE = value; }
		}
        public string QE_LIBELLEQUESTIONNAIRE
        {
	        get { return _QE_LIBELLEQUESTIONNAIRE; }
	        set { _QE_LIBELLEQUESTIONNAIRE = value; }
        }
        public string CQ_VALEUR1
        {
	        get { return _CQ_VALEUR1; }
	        set { _CQ_VALEUR1 = value; }
        }
        public string CQ_VALEUR2
        {
	        get { return _CQ_VALEUR2; }
	        set { _CQ_VALEUR2 = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsCtparquestionnaireliaisondocument(){}
		
		public clsCtparquestionnaireliaisondocument(clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument)
		{
			this.DC_CODEDOCUMENT = clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT;
			this.DC_LIBELLEDOCUMENT = clsCtparquestionnaireliaisondocument.DC_LIBELLEDOCUMENT;
			this.QE_CODEQUESTIONNAIRE = clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE;
			this.QE_LIBELLEQUESTIONNAIRE = clsCtparquestionnaireliaisondocument.QE_LIBELLEQUESTIONNAIRE;
			this.CQ_VALEUR1 = clsCtparquestionnaireliaisondocument.CQ_VALEUR1;
			this.CQ_VALEUR2 = clsCtparquestionnaireliaisondocument.CQ_VALEUR2;
		}

		#endregion

	}
}
