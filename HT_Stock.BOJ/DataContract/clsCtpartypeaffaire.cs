using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtpartypeaffaire : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TA_CODETYPEAFFAIRES = "";
		private string _TA_LIBLLETYPEAFFAIRES = "";
		private string _TA_NUMEROORDRE = "0";

		#endregion

		#region ACCESSEURS

		public string TA_CODETYPEAFFAIRES
		{
			get { return _TA_CODETYPEAFFAIRES; }
			set {  _TA_CODETYPEAFFAIRES = value; }
		}

		public string TA_LIBLLETYPEAFFAIRES
		{
			get { return _TA_LIBLLETYPEAFFAIRES; }
			set {  _TA_LIBLLETYPEAFFAIRES = value; }
		}

		public string TA_NUMEROORDRE
		{
			get { return _TA_NUMEROORDRE; }
			set {  _TA_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartypeaffaire(){}

		public clsCtpartypeaffaire(clsCtpartypeaffaire clsCtpartypeaffaire)
		{
			this.TA_CODETYPEAFFAIRES = clsCtpartypeaffaire.TA_CODETYPEAFFAIRES;
			this.TA_LIBLLETYPEAFFAIRES = clsCtpartypeaffaire.TA_LIBLLETYPEAFFAIRES;
			this.TA_NUMEROORDRE = clsCtpartypeaffaire.TA_NUMEROORDRE;
		}

		#endregion

	}
}
