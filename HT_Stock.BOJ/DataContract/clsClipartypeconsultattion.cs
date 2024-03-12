using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsClipartypeconsultattion : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TY_CODETYPECONSULTATION = "";
		private string _TY_LIBELLETYPECONSULTATION = "";

		#endregion

		#region ACCESSEURS

		public string TY_CODETYPECONSULTATION
		{
			get { return _TY_CODETYPECONSULTATION; }
			set {  _TY_CODETYPECONSULTATION = value; }
		}

		public string TY_LIBELLETYPECONSULTATION
		{
			get { return _TY_LIBELLETYPECONSULTATION; }
			set {  _TY_LIBELLETYPECONSULTATION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsClipartypeconsultattion(){}
		public clsClipartypeconsultattion( string TY_CODETYPECONSULTATION,string TY_LIBELLETYPECONSULTATION)
		{
			this.TY_CODETYPECONSULTATION = TY_CODETYPECONSULTATION;
			this.TY_LIBELLETYPECONSULTATION = TY_LIBELLETYPECONSULTATION;
		}
		public clsClipartypeconsultattion(clsClipartypeconsultattion clsClipartypeconsultattion)
		{
			this.TY_CODETYPECONSULTATION = clsClipartypeconsultattion.TY_CODETYPECONSULTATION;
			this.TY_LIBELLETYPECONSULTATION = clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION;
		}

		#endregion

	}
}
