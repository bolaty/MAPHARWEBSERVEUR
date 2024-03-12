using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCliparmodesortie : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _MS_CODEMODESORTIE = "";
		private string _MS_LIBELLEMODESORTIE = "";

		#endregion

		#region ACCESSEURS

		public string MS_CODEMODESORTIE
		{
			get { return _MS_CODEMODESORTIE; }
			set {  _MS_CODEMODESORTIE = value; }
		}

		public string MS_LIBELLEMODESORTIE
		{
			get { return _MS_LIBELLEMODESORTIE; }
			set {  _MS_LIBELLEMODESORTIE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparmodesortie(){}
		public clsCliparmodesortie( string MS_CODEMODESORTIE,string MS_LIBELLEMODESORTIE)
		{
			this.MS_CODEMODESORTIE = MS_CODEMODESORTIE;
			this.MS_LIBELLEMODESORTIE = MS_LIBELLEMODESORTIE;
		}
		public clsCliparmodesortie(clsCliparmodesortie clsCliparmodesortie)
		{
			this.MS_CODEMODESORTIE = clsCliparmodesortie.MS_CODEMODESORTIE;
			this.MS_LIBELLEMODESORTIE = clsCliparmodesortie.MS_LIBELLEMODESORTIE;
		}

		#endregion

	}
}
