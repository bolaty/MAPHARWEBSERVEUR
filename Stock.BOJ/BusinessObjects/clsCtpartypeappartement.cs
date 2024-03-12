using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpartypeappartement
	{
		#region VARIABLES LOCALES

		private string _AP_CODETYPEAPPARTEMENT = "";
		private string _AP_LIBLLETYPEAPPARTEMENT = "";
		private string _AP_ACTIF = "";
		private int _AP_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string AP_CODETYPEAPPARTEMENT
		{
			get { return _AP_CODETYPEAPPARTEMENT; }
			set {  _AP_CODETYPEAPPARTEMENT = value; }
		}

		public string AP_LIBLLETYPEAPPARTEMENT
		{
			get { return _AP_LIBLLETYPEAPPARTEMENT; }
			set {  _AP_LIBLLETYPEAPPARTEMENT = value; }
		}

		public string AP_ACTIF
		{
			get { return _AP_ACTIF; }
			set {  _AP_ACTIF = value; }
		}

		public int AP_NUMEROORDRE
		{
			get { return _AP_NUMEROORDRE; }
			set {  _AP_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartypeappartement(){}
		public clsCtpartypeappartement( string AP_CODETYPEAPPARTEMENT,string AP_LIBLLETYPEAPPARTEMENT,string AP_ACTIF,int AP_NUMEROORDRE)
		{
			this.AP_CODETYPEAPPARTEMENT = AP_CODETYPEAPPARTEMENT;
			this.AP_LIBLLETYPEAPPARTEMENT = AP_LIBLLETYPEAPPARTEMENT;
			this.AP_ACTIF = AP_ACTIF;
			this.AP_NUMEROORDRE = AP_NUMEROORDRE;
		}
		public clsCtpartypeappartement(clsCtpartypeappartement clsCtpartypeappartement)
		{
			this.AP_CODETYPEAPPARTEMENT = clsCtpartypeappartement.AP_CODETYPEAPPARTEMENT;
			this.AP_LIBLLETYPEAPPARTEMENT = clsCtpartypeappartement.AP_LIBLLETYPEAPPARTEMENT;
			this.AP_ACTIF = clsCtpartypeappartement.AP_ACTIF;
			this.AP_NUMEROORDRE = clsCtpartypeappartement.AP_NUMEROORDRE;
		}

		#endregion

	}
}
