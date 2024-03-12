using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsProfilwebdroit : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _PO_CODEPROFILWEB = "";
		private string _OB_CODEOBJET = "0";
		private string _PD_AUTORISER = "";
		private string _PD_AJOUTER = "";
		private string _PD_MODIFIER = "";
		private string _PD_SUPPRIMER = "";
		private string _PD_APERCU = "";
		private string _PD_IMPRIMER = "";
		private string _PD_IMPRIMERTOUT = "";
		private string _PD_NUMEROORDRE = "0";
        private string _OT_CODETYPEOBJET = "";
        private string _LO_CODELOGICIEL = "";
        private string _OB_RATTACHEA = "";

		#endregion

		#region ACCESSEURS

		public string PO_CODEPROFILWEB
		{
			get { return _PO_CODEPROFILWEB; }
			set {  _PO_CODEPROFILWEB = value; }
		}

		public string OB_CODEOBJET
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

		public string PD_NUMEROORDRE
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
        public string OT_CODETYPEOBJET
        {
            get { return _OT_CODETYPEOBJET; }
            set { _OT_CODETYPEOBJET = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsProfilwebdroit(){}
        public clsProfilwebdroit(string PO_CODEPROFILWEB, string OB_CODEOBJET, string PD_AUTORISER, string PD_AJOUTER, string PD_MODIFIER, string PD_SUPPRIMER, string PD_APERCU, string PD_IMPRIMER, string PD_IMPRIMERTOUT, string LO_CODELOGICIEL, string OB_RATTACHEA, string PD_NUMEROORDRE, string OT_CODETYPEOBJET)
		{
			this.PO_CODEPROFILWEB = PO_CODEPROFILWEB;
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
            this.OT_CODETYPEOBJET = OT_CODETYPEOBJET;
        }
		public clsProfilwebdroit(clsProfilwebdroit clsProfilwebdroit)
		{
			this.PO_CODEPROFILWEB = clsProfilwebdroit.PO_CODEPROFILWEB;
			this.OB_CODEOBJET = clsProfilwebdroit.OB_CODEOBJET;
			this.PD_AUTORISER = clsProfilwebdroit.PD_AUTORISER;
			this.PD_AJOUTER = clsProfilwebdroit.PD_AJOUTER;
			this.PD_MODIFIER = clsProfilwebdroit.PD_MODIFIER;
			this.PD_SUPPRIMER = clsProfilwebdroit.PD_SUPPRIMER;
			this.PD_APERCU = clsProfilwebdroit.PD_APERCU;
			this.PD_IMPRIMER = clsProfilwebdroit.PD_IMPRIMER;
			this.PD_IMPRIMERTOUT = clsProfilwebdroit.PD_IMPRIMERTOUT;
            this.LO_CODELOGICIEL = clsProfilwebdroit.LO_CODELOGICIEL;
            this.OB_RATTACHEA = clsProfilwebdroit.OB_RATTACHEA;
			this.PD_NUMEROORDRE = clsProfilwebdroit.PD_NUMEROORDRE;
            this.OT_CODETYPEOBJET = clsProfilwebdroit.OT_CODETYPEOBJET;
        }

		#endregion

	}
}
