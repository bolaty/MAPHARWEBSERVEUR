using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtpartauxauto : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TX_CODETAUX = "0";
		private string _TX_DUREEMINIMUM = "0";
		private string _TX_DUREEMAXIMUM = "0";
		private string _TX_TAUX = "0";

		#endregion

		#region ACCESSEURS

		public string TX_CODETAUX
		{
			get { return _TX_CODETAUX; }
			set {  _TX_CODETAUX = value; }
		}

		public string TX_DUREEMINIMUM
		{
			get { return _TX_DUREEMINIMUM; }
			set {  _TX_DUREEMINIMUM = value; }
		}

		public string TX_DUREEMAXIMUM
		{
			get { return _TX_DUREEMAXIMUM; }
			set {  _TX_DUREEMAXIMUM = value; }
		}

		public string TX_TAUX
		{
			get { return _TX_TAUX; }
			set {  _TX_TAUX = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartauxauto(){}

		public clsCtpartauxauto(clsCtpartauxauto clsCtpartauxauto)
		{
			this.TX_CODETAUX = clsCtpartauxauto.TX_CODETAUX;
			this.TX_DUREEMINIMUM = clsCtpartauxauto.TX_DUREEMINIMUM;
			this.TX_DUREEMAXIMUM = clsCtpartauxauto.TX_DUREEMAXIMUM;
			this.TX_TAUX = clsCtpartauxauto.TX_TAUX;
		}

		#endregion

	}
}
