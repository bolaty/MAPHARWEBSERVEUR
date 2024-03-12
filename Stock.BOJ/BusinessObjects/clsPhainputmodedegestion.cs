using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhainputmodedegestion
	{
		#region VARIABLES LOCALES

		private string _MG_CODEMODEGESTION = "";
		private string _IN_CODETYPEARTICLE = "";
		private string _IN_AFFICHER = "";

		#endregion

		#region ACCESSEURS

		public string MG_CODEMODEGESTION
		{
			get { return _MG_CODEMODEGESTION; }
			set {  _MG_CODEMODEGESTION = value; }
		}

		public string IN_CODETYPEARTICLE
		{
			get { return _IN_CODETYPEARTICLE; }
			set {  _IN_CODETYPEARTICLE = value; }
		}

		public string IN_AFFICHER
		{
			get { return _IN_AFFICHER; }
			set {  _IN_AFFICHER = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhainputmodedegestion(){}
		public clsPhainputmodedegestion( string MG_CODEMODEGESTION,string IN_CODETYPEARTICLE,string IN_AFFICHER)
		{
			this.MG_CODEMODEGESTION = MG_CODEMODEGESTION;
			this.IN_CODETYPEARTICLE = IN_CODETYPEARTICLE;
			this.IN_AFFICHER = IN_AFFICHER;
		}
		public clsPhainputmodedegestion(clsPhainputmodedegestion clsPhainputmodedegestion)
		{
			this.MG_CODEMODEGESTION = clsPhainputmodedegestion.MG_CODEMODEGESTION;
			this.IN_CODETYPEARTICLE = clsPhainputmodedegestion.IN_CODETYPEARTICLE;
			this.IN_AFFICHER = clsPhainputmodedegestion.IN_AFFICHER;
		}

		#endregion

	}
}
