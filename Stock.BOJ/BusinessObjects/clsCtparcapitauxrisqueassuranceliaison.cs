using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparcapitauxrisqueassuranceliaison
	{
		#region VARIABLES LOCALES

		private string _CP_CODECAPITAUX = "";
		private string _RQ_CODERISQUE = "";
		private int _CL_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string CP_CODECAPITAUX
		{
			get { return _CP_CODECAPITAUX; }
			set {  _CP_CODECAPITAUX = value; }
		}

		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

		public int CL_NUMEROORDRE
		{
			get { return _CL_NUMEROORDRE; }
			set {  _CL_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparcapitauxrisqueassuranceliaison(){}
		public clsCtparcapitauxrisqueassuranceliaison( string CP_CODECAPITAUX,string RQ_CODERISQUE,int CL_NUMEROORDRE)
		{
			this.CP_CODECAPITAUX = CP_CODECAPITAUX;
			this.RQ_CODERISQUE = RQ_CODERISQUE;
			this.CL_NUMEROORDRE = CL_NUMEROORDRE;
		}
		public clsCtparcapitauxrisqueassuranceliaison(clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison)
		{
			this.CP_CODECAPITAUX = clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX;
			this.RQ_CODERISQUE = clsCtparcapitauxrisqueassuranceliaison.RQ_CODERISQUE;
			this.CL_NUMEROORDRE = clsCtparcapitauxrisqueassuranceliaison.CL_NUMEROORDRE;
		}

		#endregion

	}
}
