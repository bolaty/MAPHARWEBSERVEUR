using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtpargarantie : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _GA_CODEGARANTIE = "";
		private string _TG_CODETYPEGARANTIE = "";
		private string _SC_CODESOUSCATEGORIE = "";
		private string _GA_LIBELLEGARANTIE = "";
		private string _GA_ACTIF = "";
		private int _GA_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string GA_CODEGARANTIE
		{
			get { return _GA_CODEGARANTIE; }
			set {  _GA_CODEGARANTIE = value; }
		}

		public string TG_CODETYPEGARANTIE
		{
			get { return _TG_CODETYPEGARANTIE; }
			set {  _TG_CODETYPEGARANTIE = value; }
		}

		public string SC_CODESOUSCATEGORIE
		{
			get { return _SC_CODESOUSCATEGORIE; }
			set {  _SC_CODESOUSCATEGORIE = value; }
		}

		public string GA_LIBELLEGARANTIE
		{
			get { return _GA_LIBELLEGARANTIE; }
			set {  _GA_LIBELLEGARANTIE = value; }
		}

		public string GA_ACTIF
		{
			get { return _GA_ACTIF; }
			set {  _GA_ACTIF = value; }
		}

		public int GA_NUMEROORDRE
		{
			get { return _GA_NUMEROORDRE; }
			set {  _GA_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpargarantie(){}
		public clsCtpargarantie( string GA_CODEGARANTIE,string TG_CODETYPEGARANTIE,string SC_CODESOUSCATEGORIE,string GA_LIBELLEGARANTIE,string GA_ACTIF,int GA_NUMEROORDRE)
		{
			this.GA_CODEGARANTIE = GA_CODEGARANTIE;
			this.TG_CODETYPEGARANTIE = TG_CODETYPEGARANTIE;
			this.SC_CODESOUSCATEGORIE = SC_CODESOUSCATEGORIE;
			this.GA_LIBELLEGARANTIE = GA_LIBELLEGARANTIE;
			this.GA_ACTIF = GA_ACTIF;
			this.GA_NUMEROORDRE = GA_NUMEROORDRE;
		}
		public clsCtpargarantie(clsCtpargarantie clsCtpargarantie)
		{
			this.GA_CODEGARANTIE = clsCtpargarantie.GA_CODEGARANTIE;
			this.TG_CODETYPEGARANTIE = clsCtpargarantie.TG_CODETYPEGARANTIE;
			this.SC_CODESOUSCATEGORIE = clsCtpargarantie.SC_CODESOUSCATEGORIE;
			this.GA_LIBELLEGARANTIE = clsCtpargarantie.GA_LIBELLEGARANTIE;
			this.GA_ACTIF = clsCtpargarantie.GA_ACTIF;
			this.GA_NUMEROORDRE = clsCtpargarantie.GA_NUMEROORDRE;
		}

		#endregion

	}
}
