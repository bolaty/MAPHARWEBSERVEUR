using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparpupopmenumenuprincipallibelleparametre
	{
		#region VARIABLES LOCALES

		private string _MG_CODEMODEGESTION = "";
		private string _LP_CODELIBELLE = "";
        private string _LP_LIBELLE = "";
		private int _MP_CODEMENU = 0;
        private string _MP_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string MG_CODEMODEGESTION
		{
			get { return _MG_CODEMODEGESTION; }
			set {  _MG_CODEMODEGESTION = value; }
		}

		public string LP_CODELIBELLE
		{
			get { return _LP_CODELIBELLE; }
			set {  _LP_CODELIBELLE = value; }
		}
        public string LP_LIBELLE
        {
            get { return _LP_LIBELLE; }
            set { _LP_LIBELLE = value; }
        }
		public int MP_CODEMENU
		{
			get { return _MP_CODEMENU; }
			set {  _MP_CODEMENU = value; }
		}
        public string MP_LIBELLE
        {
            get { return _MP_LIBELLE; }
            set { _MP_LIBELLE = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenumenuprincipallibelleparametre(){}
		
		public clsPhaparpupopmenumenuprincipallibelleparametre(clsPhaparpupopmenumenuprincipallibelleparametre clsPhaparpupopmenumenuprincipallibelleparametre)
		{
			this.MG_CODEMODEGESTION = clsPhaparpupopmenumenuprincipallibelleparametre.MG_CODEMODEGESTION;
			this.LP_CODELIBELLE = clsPhaparpupopmenumenuprincipallibelleparametre.LP_CODELIBELLE;
            this.LP_LIBELLE = clsPhaparpupopmenumenuprincipallibelleparametre.LP_LIBELLE;
			this.MP_CODEMENU = clsPhaparpupopmenumenuprincipallibelleparametre.MP_CODEMENU;
            this.MP_LIBELLE = clsPhaparpupopmenumenuprincipallibelleparametre.MP_LIBELLE;

		}

		#endregion

	}
}
