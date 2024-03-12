using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpupopmenumenuprincipalmodedegestion
	{
		#region VARIABLES LOCALES

		private string _MG_CODEMODEGESTION = "";
		private int _MP_CODEMENU = 0;
		private string _OG_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public string MG_CODEMODEGESTION
		{
			get { return _MG_CODEMODEGESTION; }
			set {  _MG_CODEMODEGESTION = value; }
		}

		public int MP_CODEMENU
		{
			get { return _MP_CODEMENU; }
			set {  _MP_CODEMENU = value; }
		}

		public string OG_ACTIF
		{
			get { return _OG_ACTIF; }
			set {  _OG_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenumenuprincipalmodedegestion(){}
		public clsPhaparpupopmenumenuprincipalmodedegestion( string MG_CODEMODEGESTION,int MP_CODEMENU,string OG_ACTIF)
		{
			this.MG_CODEMODEGESTION = MG_CODEMODEGESTION;
			this.MP_CODEMENU = MP_CODEMENU;
			this.OG_ACTIF = OG_ACTIF;
		}
		public clsPhaparpupopmenumenuprincipalmodedegestion(clsPhaparpupopmenumenuprincipalmodedegestion clsPhaparpupopmenumenuprincipalmodedegestion)
		{
			this.MG_CODEMODEGESTION = clsPhaparpupopmenumenuprincipalmodedegestion.MG_CODEMODEGESTION;
			this.MP_CODEMENU = clsPhaparpupopmenumenuprincipalmodedegestion.MP_CODEMENU;
			this.OG_ACTIF = clsPhaparpupopmenumenuprincipalmodedegestion.OG_ACTIF;
		}

		#endregion

	}
}
