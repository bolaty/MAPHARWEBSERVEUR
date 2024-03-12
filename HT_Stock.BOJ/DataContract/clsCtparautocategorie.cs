using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparautocategorie : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AU_CODECATEGORIE = "";
		private string _AU_LIBELLECATEGORIE = "";
		private string _AU_ACTIF = "";
		private int _AU_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string AU_CODECATEGORIE
		{
			get { return _AU_CODECATEGORIE; }
			set {  _AU_CODECATEGORIE = value; }
		}

		public string AU_LIBELLECATEGORIE
		{
			get { return _AU_LIBELLECATEGORIE; }
			set {  _AU_LIBELLECATEGORIE = value; }
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

		public clsCtparautocategorie(){}
		public clsCtparautocategorie( string AU_CODECATEGORIE,string AU_LIBELLECATEGORIE,string AU_ACTIF,int AU_NUMEROORDRE)
		{
			this.AU_CODECATEGORIE = AU_CODECATEGORIE;
			this.AU_LIBELLECATEGORIE = AU_LIBELLECATEGORIE;
			this.AU_ACTIF = AU_ACTIF;
			this.AU_NUMEROORDRE = AU_NUMEROORDRE;
		}
		public clsCtparautocategorie(clsCtparautocategorie clsCtparautocategorie)
		{
			this.AU_CODECATEGORIE = clsCtparautocategorie.AU_CODECATEGORIE;
			this.AU_LIBELLECATEGORIE = clsCtparautocategorie.AU_LIBELLECATEGORIE;
			this.AU_ACTIF = clsCtparautocategorie.AU_ACTIF;
			this.AU_NUMEROORDRE = clsCtparautocategorie.AU_NUMEROORDRE;
		}

		#endregion

	}
}
