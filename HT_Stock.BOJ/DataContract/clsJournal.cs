using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsJournal : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _EN_CODEENTREPOT = "";
		private string _JO_CODEJOURNAL = "";
        private string _JO_JOURNALCODE = "";
		private string _JO_LIBELLE = "";
		private string _JO_C = "";
        private string _PL_CODENUMCOMPTE = "";
		private string _JO_NUMEROORDRE = "0";
        private string _TJ_CODETYPEJOURNAL = "";
        private string _PL_NUMCOMPTE = "";
        private string _JO_SAISIEANALYTIQUE = "";
        private string _JO_CONTREPARTIE = "";
        private string _EN_DENOMINATION = "";
        private string _TJ_LIBELLE = "";
        

        #endregion

        #region ACCESSEURS

        public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string JO_CODEJOURNAL
		{
			get { return _JO_CODEJOURNAL; }
			set {  _JO_CODEJOURNAL = value; }
		}
        public string JO_JOURNALCODE
		{
            get { return _JO_JOURNALCODE; }
            set { _JO_JOURNALCODE = value; }
		}


		public string JO_LIBELLE
		{
			get { return _JO_LIBELLE; }
			set {  _JO_LIBELLE = value; }
		}

		public string JO_C
		{
			get { return _JO_C; }
			set {  _JO_C = value; }
		}

        public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}

		public string JO_NUMEROORDRE
		{
			get { return _JO_NUMEROORDRE; }
			set {  _JO_NUMEROORDRE = value; }
		}
        public string TJ_CODETYPEJOURNAL
		{
            get { return _TJ_CODETYPEJOURNAL; }
            set { _TJ_CODETYPEJOURNAL = value; }
		}

        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }

        public string JO_SAISIEANALYTIQUE
        {
            get { return _JO_SAISIEANALYTIQUE; }
            set { _JO_SAISIEANALYTIQUE = value; } 
        }

         public string JO_CONTREPARTIE
        {
            get { return _JO_CONTREPARTIE; }
            set { _JO_CONTREPARTIE = value; } 
        }
         public string EN_DENOMINATION
        {
            get { return _EN_DENOMINATION; }
            set { _EN_DENOMINATION = value; } 
        }
         public string TJ_LIBELLE
        {
            get { return _TJ_LIBELLE; }
            set { _TJ_LIBELLE = value; } 
        }
       

        #endregion

        #region INSTANCIATEURS

        public clsJournal(){}
       
		public clsJournal(clsJournal clsJournal)
		{
			this.EN_CODEENTREPOT = clsJournal.EN_CODEENTREPOT;
			this.JO_CODEJOURNAL = clsJournal.JO_CODEJOURNAL;
            this.JO_JOURNALCODE = clsJournal.JO_JOURNALCODE;
			this.JO_LIBELLE = clsJournal.JO_LIBELLE;
			this.JO_C = clsJournal.JO_C;
			this.PL_CODENUMCOMPTE = clsJournal.PL_CODENUMCOMPTE;
			this.JO_NUMEROORDRE = clsJournal.JO_NUMEROORDRE;
            this.TJ_CODETYPEJOURNAL = clsJournal.TJ_CODETYPEJOURNAL;
            this.PL_NUMCOMPTE = clsJournal.PL_NUMCOMPTE;
            this.JO_SAISIEANALYTIQUE = clsJournal.JO_SAISIEANALYTIQUE;
            this.JO_CONTREPARTIE = clsJournal.JO_CONTREPARTIE;
            this.EN_DENOMINATION = clsJournal.EN_DENOMINATION;
            this.TJ_LIBELLE = clsJournal.TJ_LIBELLE;

    }

		#endregion

	}
}
