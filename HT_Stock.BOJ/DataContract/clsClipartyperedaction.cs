using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsClipartyperedaction
	{
		#region VARIABLES LOCALES

		private string _TL_CODETYPEREDACTION = "";
		private string _TL_LIBELLETYPEREDACTION = "";

		#endregion

		#region ACCESSEURS

		public string TL_CODETYPEREDACTION
		{
			get { return _TL_CODETYPEREDACTION; }
			set {  _TL_CODETYPEREDACTION = value; }
		}

		public string TL_LIBELLETYPEREDACTION
		{
			get { return _TL_LIBELLETYPEREDACTION; }
			set {  _TL_LIBELLETYPEREDACTION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsClipartyperedaction(){}
		public clsClipartyperedaction( string TL_CODETYPEREDACTION,string TL_LIBELLETYPEREDACTION)
		{
			this.TL_CODETYPEREDACTION = TL_CODETYPEREDACTION;
			this.TL_LIBELLETYPEREDACTION = TL_LIBELLETYPEREDACTION;
		}
		public clsClipartyperedaction(clsClipartyperedaction clsClipartyperedaction)
		{
			this.TL_CODETYPEREDACTION = clsClipartyperedaction.TL_CODETYPEREDACTION;
			this.TL_LIBELLETYPEREDACTION = clsClipartyperedaction.TL_LIBELLETYPEREDACTION;
		}

		#endregion

	}
}
