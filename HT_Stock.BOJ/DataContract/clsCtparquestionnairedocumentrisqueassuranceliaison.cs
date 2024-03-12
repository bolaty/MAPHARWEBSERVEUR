using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparquestionnairedocumentrisqueassuranceliaison : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _DC_CODEDOCUMENT = "";
		private string _DC_LIBELLEDOCUMENT = "";
		private string _RQ_CODERISQUE = "";
		private string _GL_NUMEROORDRE = "0";

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
		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

		public string GL_NUMEROORDRE
		{
			get { return _GL_NUMEROORDRE; }
			set {  _GL_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparquestionnairedocumentrisqueassuranceliaison(){}
	
		public clsCtparquestionnairedocumentrisqueassuranceliaison(clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison)
		{
			this.DC_CODEDOCUMENT = clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT;
			this.DC_LIBELLEDOCUMENT = clsCtparquestionnairedocumentrisqueassuranceliaison.DC_LIBELLEDOCUMENT;
			this.RQ_CODERISQUE = clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE;
			this.GL_NUMEROORDRE = clsCtparquestionnairedocumentrisqueassuranceliaison.GL_NUMEROORDRE;
		}

		#endregion

	}
}
