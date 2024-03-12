using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhazdecaisse
	{
		#region VARIABLES LOCALES

		private string _ZC_CODE = "";
		private string _ZC_LIBELLE = "";
		private string _ZC_ACTIF = "";
		private int _ZC_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string ZC_CODE
		{
			get { return _ZC_CODE; }
			set {  _ZC_CODE = value; }
		}

		public string ZC_LIBELLE
		{
			get { return _ZC_LIBELLE; }
			set {  _ZC_LIBELLE = value; }
		}

		public string ZC_ACTIF
		{
			get { return _ZC_ACTIF; }
			set {  _ZC_ACTIF = value; }
		}

		public int ZC_NUMEROORDRE
		{
			get { return _ZC_NUMEROORDRE; }
			set {  _ZC_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhazdecaisse(){}
		public clsPhazdecaisse( string ZC_CODE,string ZC_LIBELLE,string ZC_ACTIF,int ZC_NUMEROORDRE)
		{
			this.ZC_CODE = ZC_CODE;
			this.ZC_LIBELLE = ZC_LIBELLE;
			this.ZC_ACTIF = ZC_ACTIF;
			this.ZC_NUMEROORDRE = ZC_NUMEROORDRE;
		}
		public clsPhazdecaisse(clsPhazdecaisse clsPhazdecaisse)
		{
			this.ZC_CODE = clsPhazdecaisse.ZC_CODE;
			this.ZC_LIBELLE = clsPhazdecaisse.ZC_LIBELLE;
			this.ZC_ACTIF = clsPhazdecaisse.ZC_ACTIF;
			this.ZC_NUMEROORDRE = clsPhazdecaisse.ZC_NUMEROORDRE;
		}

		#endregion

	}
}
