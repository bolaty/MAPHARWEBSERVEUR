using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhapartypetierscompterattacheadditionnel : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TC_CODECOMPTETYPETIERS = "";
		private string _TP_CODETYPETIERS = "";
		private string _PL_CODENUMCOMPTE = "";
		private string _TC_LIBELLE = "";
		private int _TC_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string TC_CODECOMPTETYPETIERS
		{
			get { return _TC_CODECOMPTETYPETIERS; }
			set {  _TC_CODECOMPTETYPETIERS = value; }
		}

		public string TP_CODETYPETIERS
		{
			get { return _TP_CODETYPETIERS; }
			set {  _TP_CODETYPETIERS = value; }
		}

		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}

		public string TC_LIBELLE
		{
			get { return _TC_LIBELLE; }
			set {  _TC_LIBELLE = value; }
		}

		public int TC_NUMEROORDRE
		{
			get { return _TC_NUMEROORDRE; }
			set {  _TC_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypetierscompterattacheadditionnel(){}
		public clsPhapartypetierscompterattacheadditionnel( string TC_CODECOMPTETYPETIERS,string TP_CODETYPETIERS,string PL_CODENUMCOMPTE,string TC_LIBELLE,int TC_NUMEROORDRE)
		{
			this.TC_CODECOMPTETYPETIERS = TC_CODECOMPTETYPETIERS;
			this.TP_CODETYPETIERS = TP_CODETYPETIERS;
			this.PL_CODENUMCOMPTE = PL_CODENUMCOMPTE;
			this.TC_LIBELLE = TC_LIBELLE;
			this.TC_NUMEROORDRE = TC_NUMEROORDRE;
		}
		public clsPhapartypetierscompterattacheadditionnel(clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel)
		{
			this.TC_CODECOMPTETYPETIERS = clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS;
			this.TP_CODETYPETIERS = clsPhapartypetierscompterattacheadditionnel.TP_CODETYPETIERS;
			this.PL_CODENUMCOMPTE = clsPhapartypetierscompterattacheadditionnel.PL_CODENUMCOMPTE;
			this.TC_LIBELLE = clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE;
			this.TC_NUMEROORDRE = clsPhapartypetierscompterattacheadditionnel.TC_NUMEROORDRE;
		}

		#endregion

	}
}
