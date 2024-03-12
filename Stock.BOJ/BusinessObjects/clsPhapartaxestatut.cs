using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartaxestatut
	{
		#region VARIABLES LOCALES

		private string _TA_CODETAXE = "";
		private string _ST_STATUT = "";
		private string _ST_LIBELLE = "";
		private int _ST_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string TA_CODETAXE
		{
			get { return _TA_CODETAXE; }
			set {  _TA_CODETAXE = value; }
		}

		public string ST_STATUT
		{
			get { return _ST_STATUT; }
			set {  _ST_STATUT = value; }
		}

		public string ST_LIBELLE
		{
			get { return _ST_LIBELLE; }
			set {  _ST_LIBELLE = value; }
		}

		public int ST_NUMEROORDRE
		{
			get { return _ST_NUMEROORDRE; }
			set {  _ST_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartaxestatut(){}
		public clsPhapartaxestatut( string TA_CODETAXE,string ST_STATUT,string ST_LIBELLE,int ST_NUMEROORDRE)
		{
			this.TA_CODETAXE = TA_CODETAXE;
			this.ST_STATUT = ST_STATUT;
			this.ST_LIBELLE = ST_LIBELLE;
			this.ST_NUMEROORDRE = ST_NUMEROORDRE;
		}
		public clsPhapartaxestatut(clsPhapartaxestatut clsPhapartaxestatut)
		{
			this.TA_CODETAXE = clsPhapartaxestatut.TA_CODETAXE;
			this.ST_STATUT = clsPhapartaxestatut.ST_STATUT;
			this.ST_LIBELLE = clsPhapartaxestatut.ST_LIBELLE;
			this.ST_NUMEROORDRE = clsPhapartaxestatut.ST_NUMEROORDRE;
		}

		#endregion

	}
}
