using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhapartypefournisseur : clsEntitieBase
    {

        private string _TF_CODETYPEFOURNISSEUR = "";
		private string _TF_LIBELLE = "";
		private string _TF_DESCRIPTION = "";
        private string _TF_NUMEROORDRE = "";


        public string TF_CODETYPEFOURNISSEUR
		{
			get { return _TF_CODETYPEFOURNISSEUR; }
			set { _TF_CODETYPEFOURNISSEUR = value; }
		}
		public string TF_LIBELLE
		{
			get { return _TF_LIBELLE; }
			set { _TF_LIBELLE = value; }
		}
		public string TF_DESCRIPTION
		{
			get { return _TF_DESCRIPTION; }
			set { _TF_DESCRIPTION = value; }
		}
        public string TF_NUMEROORDRE
		{
            get { return _TF_NUMEROORDRE; }
            set { _TF_NUMEROORDRE = value; }
		}


        public clsPhapartypefournisseur() {}

        public clsPhapartypefournisseur(string TF_CODETYPEFOURNISSEUR, string TF_LIBELLE, string TF_DESCRIPTION, string TF_NUMEROORDRE)
		{
			this.TF_CODETYPEFOURNISSEUR = TF_CODETYPEFOURNISSEUR;
			this.TF_LIBELLE = TF_LIBELLE;
			this.TF_DESCRIPTION = TF_DESCRIPTION;
            this.TF_NUMEROORDRE = TF_NUMEROORDRE;
		}

		public clsPhapartypefournisseur(clsPhapartypefournisseur clsPhapartypefournisseur)
		{
			TF_CODETYPEFOURNISSEUR = clsPhapartypefournisseur.TF_CODETYPEFOURNISSEUR;
			TF_LIBELLE = clsPhapartypefournisseur.TF_LIBELLE;
			TF_DESCRIPTION = clsPhapartypefournisseur.TF_DESCRIPTION;
            TF_NUMEROORDRE = clsPhapartypefournisseur.TF_NUMEROORDRE;
		}
        }
}