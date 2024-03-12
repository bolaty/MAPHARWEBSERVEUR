using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpartypecontratsante
	{
		#region VARIABLES LOCALES

		private string _TA_CODETYPECONTRATSANTE = "";
		private string _TA_LIBELLETYPECONTRATSANTE = "";
		private string _TA_ACTIF = "";
		private int _TA_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string TA_CODETYPECONTRATSANTE
		{
			get { return _TA_CODETYPECONTRATSANTE; }
			set {  _TA_CODETYPECONTRATSANTE = value; }
		}

		public string TA_LIBELLETYPECONTRATSANTE
		{
			get { return _TA_LIBELLETYPECONTRATSANTE; }
			set {  _TA_LIBELLETYPECONTRATSANTE = value; }
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

		public clsCtpartypecontratsante(){}
		public clsCtpartypecontratsante( string TA_CODETYPECONTRATSANTE,string TA_LIBELLETYPECONTRATSANTE,string TA_ACTIF,int TA_NUMEROORDRE)
		{
			this.TA_CODETYPECONTRATSANTE = TA_CODETYPECONTRATSANTE;
			this.TA_LIBELLETYPECONTRATSANTE = TA_LIBELLETYPECONTRATSANTE;
			this.TA_ACTIF = TA_ACTIF;
			this.TA_NUMEROORDRE = TA_NUMEROORDRE;
		}
		public clsCtpartypecontratsante(clsCtpartypecontratsante clsCtpartypecontratsante)
		{
			this.TA_CODETYPECONTRATSANTE = clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE;
			this.TA_LIBELLETYPECONTRATSANTE = clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE;
			this.TA_ACTIF = clsCtpartypecontratsante.TA_ACTIF;
			this.TA_NUMEROORDRE = clsCtpartypecontratsante.TA_NUMEROORDRE;
		}

		#endregion

	}
}
