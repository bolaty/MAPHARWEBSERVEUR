using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtpartarif : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TA_CODETARIF = "";
		private string _TA_LIBELLETARIF = "";
		private string _TA_ACTIF = "";
		private int _TA_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string TA_CODETARIF
		{
			get { return _TA_CODETARIF; }
			set {  _TA_CODETARIF = value; }
		}

		public string TA_LIBELLETARIF
		{
			get { return _TA_LIBELLETARIF; }
			set {  _TA_LIBELLETARIF = value; }
		}

		public string TA_ACTIF
		{
			get { return _TA_ACTIF; }
			set {  _TA_ACTIF = value; }
		}

		public int TA_NUMEROORDRE
		{
			get { return _TA_NUMEROORDRE; }
			set {  _TA_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartarif(){}
		public clsCtpartarif( string TA_CODETARIF,string TA_LIBELLETARIF,string TA_ACTIF,int TA_NUMEROORDRE)
		{
			this.TA_CODETARIF = TA_CODETARIF;
			this.TA_LIBELLETARIF = TA_LIBELLETARIF;
			this.TA_ACTIF = TA_ACTIF;
			this.TA_NUMEROORDRE = TA_NUMEROORDRE;
		}
		public clsCtpartarif(clsCtpartarif clsCtpartarif)
		{
			this.TA_CODETARIF = clsCtpartarif.TA_CODETARIF;
			this.TA_LIBELLETARIF = clsCtpartarif.TA_LIBELLETARIF;
			this.TA_ACTIF = clsCtpartarif.TA_ACTIF;
			this.TA_NUMEROORDRE = clsCtpartarif.TA_NUMEROORDRE;
		}

		#endregion

	}
}
