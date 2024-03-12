using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtpartypecontratauto : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AU_CODETYPECONTRATAUTO = "";
		private string _AU_LIBELLETYPECONTRATAUTO = "";
		private string _AU_ACTIF = "";
		private string _AU_NUMEROORDRE = "0";

		#endregion

		#region ACCESSEURS

		public string AU_CODETYPECONTRATAUTO
		{
			get { return _AU_CODETYPECONTRATAUTO; }
			set {  _AU_CODETYPECONTRATAUTO = value; }
		}

		public string AU_LIBELLETYPECONTRATAUTO
		{
			get { return _AU_LIBELLETYPECONTRATAUTO; }
			set {  _AU_LIBELLETYPECONTRATAUTO = value; }
		}

		public string AU_ACTIF
		{
			get { return _AU_ACTIF; }
			set {  _AU_ACTIF = value; }
		}

		public string AU_NUMEROORDRE
		{
			get { return _AU_NUMEROORDRE; }
			set {  _AU_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartypecontratauto(){}

		public clsCtpartypecontratauto(clsCtpartypecontratauto clsCtpartypecontratauto)
		{
			this.AU_CODETYPECONTRATAUTO = clsCtpartypecontratauto.AU_CODETYPECONTRATAUTO;
			this.AU_LIBELLETYPECONTRATAUTO = clsCtpartypecontratauto.AU_LIBELLETYPECONTRATAUTO;
			this.AU_ACTIF = clsCtpartypecontratauto.AU_ACTIF;
			this.AU_NUMEROORDRE = clsCtpartypecontratauto.AU_NUMEROORDRE;
		}

		#endregion

	}
}
