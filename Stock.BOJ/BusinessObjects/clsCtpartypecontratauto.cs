using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpartypecontratauto
	{
		#region VARIABLES LOCALES

		private string _AU_CODETYPECONTRATAUTO = "";
		private string _AU_LIBELLETYPECONTRATAUTO = "";
		private string _AU_ACTIF = "";
		private int _AU_NUMEROORDRE = 0;

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

		public int AU_NUMEROORDRE
		{
			get { return _AU_NUMEROORDRE; }
			set {  _AU_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartypecontratauto(){}
		public clsCtpartypecontratauto( string AU_CODETYPECONTRATAUTO,string AU_LIBELLETYPECONTRATAUTO,string AU_ACTIF,int AU_NUMEROORDRE)
		{
			this.AU_CODETYPECONTRATAUTO = AU_CODETYPECONTRATAUTO;
			this.AU_LIBELLETYPECONTRATAUTO = AU_LIBELLETYPECONTRATAUTO;
			this.AU_ACTIF = AU_ACTIF;
			this.AU_NUMEROORDRE = AU_NUMEROORDRE;
		}
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
