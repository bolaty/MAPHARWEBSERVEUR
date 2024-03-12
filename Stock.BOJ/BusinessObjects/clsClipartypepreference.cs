using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsClipartypepreference
	{
		#region VARIABLES LOCALES

		private string _TP_CODETYPEPREFERENCE = "";
		private string _TP_LIBELLETYPEPREFERENCE = "";

		#endregion

		#region ACCESSEURS

		public string TP_CODETYPEPREFERENCE
		{
			get { return _TP_CODETYPEPREFERENCE; }
			set {  _TP_CODETYPEPREFERENCE = value; }
		}

		public string TP_LIBELLETYPEPREFERENCE
		{
			get { return _TP_LIBELLETYPEPREFERENCE; }
			set {  _TP_LIBELLETYPEPREFERENCE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsClipartypepreference(){}
		public clsClipartypepreference( string TP_CODETYPEPREFERENCE,string TP_LIBELLETYPEPREFERENCE)
		{
			this.TP_CODETYPEPREFERENCE = TP_CODETYPEPREFERENCE;
			this.TP_LIBELLETYPEPREFERENCE = TP_LIBELLETYPEPREFERENCE;
		}
		public clsClipartypepreference(clsClipartypepreference clsClipartypepreference)
		{
			this.TP_CODETYPEPREFERENCE = clsClipartypepreference.TP_CODETYPEPREFERENCE;
			this.TP_LIBELLETYPEPREFERENCE = clsClipartypepreference.TP_LIBELLETYPEPREFERENCE;
		}

		#endregion

	}
}
