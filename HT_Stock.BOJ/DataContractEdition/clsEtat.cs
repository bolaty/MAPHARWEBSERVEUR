using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEtat : clsEntitieBase
    {

  //      private string _ET_INDEX = "";
		//private string _ET_LIBELLEETAT = "";
		//private string _ET_NOMGROUPE = "";
		//private string _ET_DOSSIER = "";
		//private string _ET_NOMETAT = "";
        private string _ET_NOMETAT1 = "";
        private string _ET_NOMETAT2 = "";
		private string _ET_AFFICHER = "";
        private int _ET_NUMEROORDRE = 0;
        private int _ET_CODEDOCUMENT = 0;
        private string _ET_COCHER = "";
        private string _ET_IMPRIMER = "";
        private string _TS_CODETYPESCHEMACOMPTABLE = "";
        private string _ET_TYPEETAT = "";
        private string _ET_AFFICHERCOLNOMETATPORTRAIRE = "";
        private string _TC_CODETYPETIERS = "";
        private string _OP_CODEOPERATEUR = "";
        private string _OD_APERCU = "";


  //      public string ET_INDEX
		//{
		//	get { return _ET_INDEX; }
		//	set { _ET_INDEX = value; }
		//}
		//public string ET_NOMGROUPE
		//{
		//	get { return _ET_NOMGROUPE; }
		//	set { _ET_NOMGROUPE = value; }
		//}
		//public string ET_DOSSIER
		//{
		//	get { return _ET_DOSSIER; }
		//	set { _ET_DOSSIER = value; }
		//}
		//public string ET_NOMETAT
		//{
		//	get { return _ET_NOMETAT; }
		//	set { _ET_NOMETAT = value; }
		//}

        public string ET_NOMETAT1
        {
            get { return _ET_NOMETAT1; }
            set { _ET_NOMETAT1 = value; }
        }

        public string ET_NOMETAT2
        {
            get { return _ET_NOMETAT2; }
            set { _ET_NOMETAT2 = value; }
        }

		//public string ET_LIBELLEETAT
		//{
		//	get { return _ET_LIBELLEETAT; }
		//	set { _ET_LIBELLEETAT = value; }
		//}
		public string ET_AFFICHER
		{
			get { return _ET_AFFICHER; }
			set { _ET_AFFICHER = value; }
		}
		public int ET_NUMEROORDRE
		{
			get { return _ET_NUMEROORDRE; }
			set { _ET_NUMEROORDRE = value; }
		}
        public int ET_CODEDOCUMENT
		{
            get { return _ET_CODEDOCUMENT; }
            set { _ET_CODEDOCUMENT = value; }
		}

        public string ET_COCHER
		{
            get { return _ET_COCHER; }
            set { _ET_COCHER = value; }
		}

        public string ET_IMPRIMER
        {
            get { return _ET_IMPRIMER; }
            set { _ET_IMPRIMER = value; }
        }

        
        public string TS_CODETYPESCHEMACOMPTABLE
        {
            get { return _TS_CODETYPESCHEMACOMPTABLE; }
            set { _TS_CODETYPESCHEMACOMPTABLE = value; }
        }

        public string ET_TYPEETAT
        {
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
        }

        public string TC_CODETYPETIERS
        {
            get { return _TC_CODETYPETIERS; }
            set { _TC_CODETYPETIERS = value; }
        }

        public string ET_AFFICHERCOLNOMETATPORTRAIRE
        {
            get { return _ET_AFFICHERCOLNOMETATPORTRAIRE; }
            set { _ET_AFFICHERCOLNOMETATPORTRAIRE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public string OD_APERCU
        {
            get { return _OD_APERCU; }
            set { _OD_APERCU = value; }
        }

        public clsEtat() {}

      

		public clsEtat(clsEtat clsEtat)
		{
			//ET_INDEX = clsEtat.ET_INDEX;
			//ET_NOMGROUPE = clsEtat.ET_NOMGROUPE;
			//ET_DOSSIER = clsEtat.ET_DOSSIER;
			//ET_NOMETAT = clsEtat.ET_NOMETAT;
            ET_NOMETAT1 = clsEtat.ET_NOMETAT1;
            ET_NOMETAT2 = clsEtat.ET_NOMETAT2;
			//ET_LIBELLEETAT = clsEtat.ET_LIBELLEETAT;
			ET_AFFICHER = clsEtat.ET_AFFICHER;
			ET_NUMEROORDRE = clsEtat.ET_NUMEROORDRE;
            ET_CODEDOCUMENT = clsEtat.ET_CODEDOCUMENT; 
            ET_COCHER = clsEtat.ET_COCHER;
            ET_IMPRIMER = clsEtat.ET_IMPRIMER; 
            TS_CODETYPESCHEMACOMPTABLE = clsEtat.TS_CODETYPESCHEMACOMPTABLE;
            ET_TYPEETAT = clsEtat.ET_TYPEETAT;
            TC_CODETYPETIERS = clsEtat.TC_CODETYPETIERS;
            ET_AFFICHERCOLNOMETATPORTRAIRE = clsEtat.ET_AFFICHERCOLNOMETATPORTRAIRE;
            OP_CODEOPERATEUR = clsEtat.OP_CODEOPERATEUR;
            OD_APERCU = clsEtat.OD_APERCU;
		}
        }
}