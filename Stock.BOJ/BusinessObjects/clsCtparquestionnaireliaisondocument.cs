using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparquestionnaireliaisondocument
	{
		#region VARIABLES LOCALES

		private string _DC_CODEDOCUMENT = "";
		private int _QE_CODEQUESTIONNAIRE = 0;

		#endregion

		#region ACCESSEURS

		public string DC_CODEDOCUMENT
		{
			get { return _DC_CODEDOCUMENT; }
			set {  _DC_CODEDOCUMENT = value; }
		}

		public int QE_CODEQUESTIONNAIRE
		{
			get { return _QE_CODEQUESTIONNAIRE; }
			set {  _QE_CODEQUESTIONNAIRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparquestionnaireliaisondocument(){}
		public clsCtparquestionnaireliaisondocument( string DC_CODEDOCUMENT,int QE_CODEQUESTIONNAIRE)
		{
			this.DC_CODEDOCUMENT = DC_CODEDOCUMENT;
			this.QE_CODEQUESTIONNAIRE = QE_CODEQUESTIONNAIRE;
		}
		public clsCtparquestionnaireliaisondocument(clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument)
		{
			this.DC_CODEDOCUMENT = clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT;
			this.QE_CODEQUESTIONNAIRE = clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE;
		}

		#endregion

	}
}
