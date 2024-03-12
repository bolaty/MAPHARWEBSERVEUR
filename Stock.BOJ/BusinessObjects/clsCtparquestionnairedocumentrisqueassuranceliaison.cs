using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparquestionnairedocumentrisqueassuranceliaison
	{
		#region VARIABLES LOCALES

		private string _DC_CODEDOCUMENT = "";
		private string _RQ_CODERISQUE = "";
		private int _GL_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string DC_CODEDOCUMENT
		{
			get { return _DC_CODEDOCUMENT; }
			set {  _DC_CODEDOCUMENT = value; }
		}

		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

		public int GL_NUMEROORDRE
		{
			get { return _GL_NUMEROORDRE; }
			set {  _GL_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparquestionnairedocumentrisqueassuranceliaison(){}
		public clsCtparquestionnairedocumentrisqueassuranceliaison( string DC_CODEDOCUMENT,string RQ_CODERISQUE,int GL_NUMEROORDRE)
		{
			this.DC_CODEDOCUMENT = DC_CODEDOCUMENT;
			this.RQ_CODERISQUE = RQ_CODERISQUE;
			this.GL_NUMEROORDRE = GL_NUMEROORDRE;
		}
		public clsCtparquestionnairedocumentrisqueassuranceliaison(clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison)
		{
			this.DC_CODEDOCUMENT = clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT;
			this.RQ_CODERISQUE = clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE;
			this.GL_NUMEROORDRE = clsCtparquestionnairedocumentrisqueassuranceliaison.GL_NUMEROORDRE;
		}

		#endregion

	}
}
