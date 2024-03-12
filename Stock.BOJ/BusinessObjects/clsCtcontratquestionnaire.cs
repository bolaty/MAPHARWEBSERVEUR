using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratquestionnaire
	{
		#region VARIABLES LOCALES

		private string _CA_CODECONTRAT = "";
		private string _QE_CODEQUESTIONNAIRE = "";
		private string _DC_CODEDOCUMENT = "";
		private string _CQ_VALEUR1 = "";
		private string _CQ_VALEUR2 = "";

		#endregion

		#region ACCESSEURS

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string QE_CODEQUESTIONNAIRE
		{
			get { return _QE_CODEQUESTIONNAIRE; }
			set {  _QE_CODEQUESTIONNAIRE = value; }
		}
		public string DC_CODEDOCUMENT
        {
			get { return _DC_CODEDOCUMENT; }
			set { _DC_CODEDOCUMENT = value; }
		}


		public string CQ_VALEUR1
		{
			get { return _CQ_VALEUR1; }
			set {  _CQ_VALEUR1 = value; }
		}

		public string CQ_VALEUR2
		{
			get { return _CQ_VALEUR2; }
			set {  _CQ_VALEUR2 = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratquestionnaire(){}
		
		public clsCtcontratquestionnaire(clsCtcontratquestionnaire clsCtcontratquestionnaire)
		{
			this.CA_CODECONTRAT = clsCtcontratquestionnaire.CA_CODECONTRAT;
			this.QE_CODEQUESTIONNAIRE = clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE;
			this.DC_CODEDOCUMENT = clsCtcontratquestionnaire.DC_CODEDOCUMENT;
			this.CQ_VALEUR1 = clsCtcontratquestionnaire.CQ_VALEUR1;
			this.CQ_VALEUR2 = clsCtcontratquestionnaire.CQ_VALEUR2;
		}

		#endregion

	}
}
