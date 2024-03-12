using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsProfildroit
	{
		#region VARIABLES LOCALES

		private string _PO_CODEPROFIL = "";
		private int _OB_CODEOBJET = 0;
		private string _PD_AUTORISER = "";
		private string _PD_AJOUTER = "";
		private string _PD_MODIFIER = "";
		private string _PD_SUPPRIMER = "";
		private string _PD_APERCU = "";
		private string _PD_IMPRIMER = "";
		private string _PD_IMPRIMERTOUT = "";
		private int _PD_NUMEROORDRE = 0;

        private string _LO_CODELOGICIEL = "";
        private string _OB_RATTACHEA = "";

		#endregion

		#region ACCESSEURS

		public string PO_CODEPROFIL
		{
			get { return _PO_CODEPROFIL; }
			set {  _PO_CODEPROFIL = value; }
		}

		public int OB_CODEOBJET
		{
			get { return _OB_CODEOBJET; }
			set {  _OB_CODEOBJET = value; }
		}

		public string PD_AUTORISER
		{
			get { return _PD_AUTORISER; }
			set {  _PD_AUTORISER = value; }
		}

		public string PD_AJOUTER
		{
			get { return _PD_AJOUTER; }
			set {  _PD_AJOUTER = value; }
		}

		public string PD_MODIFIER
		{
			get { return _PD_MODIFIER; }
			set {  _PD_MODIFIER = value; }
		}

		public string PD_SUPPRIMER
		{
			get { return _PD_SUPPRIMER; }
			set {  _PD_SUPPRIMER = value; }
		}

		public string PD_APERCU
		{
			get { return _PD_APERCU; }
			set {  _PD_APERCU = value; }
		}

		public string PD_IMPRIMER
		{
			get { return _PD_IMPRIMER; }
			set {  _PD_IMPRIMER = value; }
		}

		public string PD_IMPRIMERTOUT
		{
			get { return _PD_IMPRIMERTOUT; }
			set {  _PD_IMPRIMERTOUT = value; }
		}

		public int PD_NUMEROORDRE
		{
			get { return _PD_NUMEROORDRE; }
			set {  _PD_NUMEROORDRE = value; }
		}

        public string LO_CODELOGICIEL
        {
            get { return _LO_CODELOGICIEL; }
            set { _LO_CODELOGICIEL = value; }
        }

        public string OB_RATTACHEA
        {
            get { return _OB_RATTACHEA; }
            set { _OB_RATTACHEA = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsProfildroit(){}
        public clsProfildroit(string PO_CODEPROFIL, int OB_CODEOBJET, string PD_AUTORISER, string PD_AJOUTER, string PD_MODIFIER, string PD_SUPPRIMER, string PD_APERCU, string PD_IMPRIMER, string PD_IMPRIMERTOUT, string LO_CODELOGICIEL, string OB_RATTACHEA, int PD_NUMEROORDRE)
		{
			this.PO_CODEPROFIL = PO_CODEPROFIL;
			this.OB_CODEOBJET = OB_CODEOBJET;
			this.PD_AUTORISER = PD_AUTORISER;
			this.PD_AJOUTER = PD_AJOUTER;
			this.PD_MODIFIER = PD_MODIFIER;
			this.PD_SUPPRIMER = PD_SUPPRIMER;
			this.PD_APERCU = PD_APERCU;
			this.PD_IMPRIMER = PD_IMPRIMER;
			this.PD_IMPRIMERTOUT = PD_IMPRIMERTOUT;
            this.LO_CODELOGICIEL = LO_CODELOGICIEL;
            this.OB_RATTACHEA = OB_RATTACHEA;
			this.PD_NUMEROORDRE = PD_NUMEROORDRE;
		}
		public clsProfildroit(clsProfildroit clsProfildroit)
		{
			this.PO_CODEPROFIL = clsProfildroit.PO_CODEPROFIL;
			this.OB_CODEOBJET = clsProfildroit.OB_CODEOBJET;
			this.PD_AUTORISER = clsProfildroit.PD_AUTORISER;
			this.PD_AJOUTER = clsProfildroit.PD_AJOUTER;
			this.PD_MODIFIER = clsProfildroit.PD_MODIFIER;
			this.PD_SUPPRIMER = clsProfildroit.PD_SUPPRIMER;
			this.PD_APERCU = clsProfildroit.PD_APERCU;
			this.PD_IMPRIMER = clsProfildroit.PD_IMPRIMER;
			this.PD_IMPRIMERTOUT = clsProfildroit.PD_IMPRIMERTOUT;
            this.LO_CODELOGICIEL = clsProfildroit.LO_CODELOGICIEL;
            this.OB_RATTACHEA = clsProfildroit.OB_RATTACHEA;
			this.PD_NUMEROORDRE = clsProfildroit.PD_NUMEROORDRE;
		}

		#endregion

	}
}
