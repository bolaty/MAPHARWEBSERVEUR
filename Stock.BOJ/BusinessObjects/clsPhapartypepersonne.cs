using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartypepersonne
	{
		#region VARIABLES LOCALES

		private string _TP_CODETYPEPERSONNE = "";
		private string _TP_LIBELLETYPEPERSONNE = "";

		#endregion

		#region ACCESSEURS

		public string TP_CODETYPEPERSONNE
		{
			get { return _TP_CODETYPEPERSONNE; }
			set {  _TP_CODETYPEPERSONNE = value; }
		}

		public string TP_LIBELLETYPEPERSONNE
		{
			get { return _TP_LIBELLETYPEPERSONNE; }
			set {  _TP_LIBELLETYPEPERSONNE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypepersonne(){}
		public clsPhapartypepersonne( string TP_CODETYPEPERSONNE,string TP_LIBELLETYPEPERSONNE)
		{
			this.TP_CODETYPEPERSONNE = TP_CODETYPEPERSONNE;
			this.TP_LIBELLETYPEPERSONNE = TP_LIBELLETYPEPERSONNE;
		}
		public clsPhapartypepersonne(clsPhapartypepersonne clsPhapartypepersonne)
		{
			this.TP_CODETYPEPERSONNE = clsPhapartypepersonne.TP_CODETYPEPERSONNE;
			this.TP_LIBELLETYPEPERSONNE = clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE;
		}

		#endregion

	}
}
