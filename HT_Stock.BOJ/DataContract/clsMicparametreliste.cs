using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsMicparametreliste
	{
		#region VARIABLES LOCALES

		private string _LG_CODEPARAMETRELIBELLEGROUPE = "";
		private string _LP_CODEPARAMETRELIBELLE = "";
		private string _PL_CODEPARAMETRELISTE = "";
		private string _PL_TYPECHAMP = "";
		private string _CP_CHAMPOBLIGATOIRE = "";
		private string _PL_AFFICHER = "";
		private int _CP_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string LG_CODEPARAMETRELIBELLEGROUPE
		{
			get { return _LG_CODEPARAMETRELIBELLEGROUPE; }
			set {  _LG_CODEPARAMETRELIBELLEGROUPE = value; }
		}

		public string LP_CODEPARAMETRELIBELLE
		{
			get { return _LP_CODEPARAMETRELIBELLE; }
			set {  _LP_CODEPARAMETRELIBELLE = value; }
		}

		public string PL_CODEPARAMETRELISTE
		{
			get { return _PL_CODEPARAMETRELISTE; }
			set {  _PL_CODEPARAMETRELISTE = value; }
		}

		public string PL_TYPECHAMP
		{
			get { return _PL_TYPECHAMP; }
			set {  _PL_TYPECHAMP = value; }
		}

		public string PL_CHAMPOBLIGATOIRE
		{
			get { return _CP_CHAMPOBLIGATOIRE; }
			set {  _CP_CHAMPOBLIGATOIRE = value; }
		}

		public string PL_AFFICHER
		{
			get { return _PL_AFFICHER; }
			set {  _PL_AFFICHER = value; }
		}

		public int CP_NUMEROORDRE
		{
			get { return _CP_NUMEROORDRE; }
			set {  _CP_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsMicparametreliste(){}
		public clsMicparametreliste( string LG_CODEPARAMETRELIBELLEGROUPE,string LP_CODEPARAMETRELIBELLE,string PL_CODEPARAMETRELISTE,string PL_TYPECHAMP,string PL_CHAMPOBLIGATOIRE,string PL_AFFICHER,int CP_NUMEROORDRE)
		{
			this.LG_CODEPARAMETRELIBELLEGROUPE = LG_CODEPARAMETRELIBELLEGROUPE;
			this.LP_CODEPARAMETRELIBELLE = LP_CODEPARAMETRELIBELLE;
			this.PL_CODEPARAMETRELISTE = PL_CODEPARAMETRELISTE;
			this.PL_TYPECHAMP = PL_TYPECHAMP;
			this.PL_CHAMPOBLIGATOIRE = PL_CHAMPOBLIGATOIRE;
			this.PL_AFFICHER = PL_AFFICHER;
			this.CP_NUMEROORDRE = CP_NUMEROORDRE;
		}
		public clsMicparametreliste(clsMicparametreliste clsMicparametreliste)
		{
			this.LG_CODEPARAMETRELIBELLEGROUPE = clsMicparametreliste.LG_CODEPARAMETRELIBELLEGROUPE;
			this.LP_CODEPARAMETRELIBELLE = clsMicparametreliste.LP_CODEPARAMETRELIBELLE;
			this.PL_CODEPARAMETRELISTE = clsMicparametreliste.PL_CODEPARAMETRELISTE;
			this.PL_TYPECHAMP = clsMicparametreliste.PL_TYPECHAMP;
			this.PL_CHAMPOBLIGATOIRE = clsMicparametreliste.PL_CHAMPOBLIGATOIRE;
			this.PL_AFFICHER = clsMicparametreliste.PL_AFFICHER;
			this.CP_NUMEROORDRE = clsMicparametreliste.CP_NUMEROORDRE;
		}

		#endregion

	}
}
