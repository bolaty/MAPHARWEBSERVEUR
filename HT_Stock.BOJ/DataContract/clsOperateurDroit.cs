using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsOperateurdroit : clsEntitieBase
    {

        private string _OP_CODEOPERATEUR = "";
		private string _OB_CODEOBJET = "0";
		private string _OD_AUTORISER = "";
		private string _OD_AJOUTER = "";
		private string _OD_MODIFIER = "";
		private string _OD_SUPPRIMER = "";
		private string _OD_APERCU = "";
		private string _OD_IMPRIMER = "";
		private string _OD_IMPRIMERTOUT = "";
        private string _LO_CODELOGICIEL = "";
        private string _OB_RATTACHEA = "";
		private string _OD_NUMEROORDRE = "0";

        private string _AG_CODEAGENCE = "";
        private string _OB_NOMOBJET = "";
        private string _OT_CODETYPEOBJET = "";
        private string _OB_LIBELLE = "";





        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
		public string OB_CODEOBJET
		{
			get { return _OB_CODEOBJET; }
			set { _OB_CODEOBJET = value; }
		}
		public string OD_AUTORISER
		{
			get { return _OD_AUTORISER; }
			set { _OD_AUTORISER = value; }
		}
		public string OD_AJOUTER
		{
			get { return _OD_AJOUTER; }
			set { _OD_AJOUTER = value; }
		}
		public string OD_MODIFIER
		{
			get { return _OD_MODIFIER; }
			set { _OD_MODIFIER = value; }
		}
		public string OD_SUPPRIMER
		{
			get { return _OD_SUPPRIMER; }
			set { _OD_SUPPRIMER = value; }
		}
		public string OD_APERCU
		{
			get { return _OD_APERCU; }
			set { _OD_APERCU = value; }
		}
		public string OD_IMPRIMER
		{
			get { return _OD_IMPRIMER; }
			set { _OD_IMPRIMER = value; }
		}
		public string OD_IMPRIMERTOUT
		{
			get { return _OD_IMPRIMERTOUT; }
			set { _OD_IMPRIMERTOUT = value; }
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

		public string OD_NUMEROORDRE
		{
			get { return _OD_NUMEROORDRE; }
			set { _OD_NUMEROORDRE = value; }
		}
        public string OB_NOMOBJET
        {
        get { return _OB_NOMOBJET; }
        set { _OB_NOMOBJET = value; }
        }
        public string OT_CODETYPEOBJET
        {
        get { return _OT_CODETYPEOBJET; }
        set { _OT_CODETYPEOBJET = value; }
        }
        public string OB_LIBELLE
        {
        get { return _OB_LIBELLE; }
        set { _OB_LIBELLE = value; }
        }






        public clsOperateurdroit() {}

      

		public clsOperateurdroit(clsOperateurdroit clsOperateurdroit)
		{
			OP_CODEOPERATEUR = clsOperateurdroit.OP_CODEOPERATEUR;
			OB_CODEOBJET = clsOperateurdroit.OB_CODEOBJET;
			OD_AUTORISER = clsOperateurdroit.OD_AUTORISER;
			OD_AJOUTER = clsOperateurdroit.OD_AJOUTER;
			OD_MODIFIER = clsOperateurdroit.OD_MODIFIER;
			OD_SUPPRIMER = clsOperateurdroit.OD_SUPPRIMER;
			OD_APERCU = clsOperateurdroit.OD_APERCU;
			OD_IMPRIMER = clsOperateurdroit.OD_IMPRIMER;
			OD_IMPRIMERTOUT = clsOperateurdroit.OD_IMPRIMERTOUT;
            LO_CODELOGICIEL = clsOperateurdroit.LO_CODELOGICIEL;
            OB_RATTACHEA = clsOperateurdroit.OB_RATTACHEA;
			OD_NUMEROORDRE = clsOperateurdroit.OD_NUMEROORDRE;
            OB_NOMOBJET = clsOperateurdroit.OB_NOMOBJET;
            OT_CODETYPEOBJET = clsOperateurdroit.OT_CODETYPEOBJET;
            OB_LIBELLE = clsOperateurdroit.OB_LIBELLE;

            //clsOperateurdroit.OB_NOMOBJET = row["OB_NOMOBJET"].ToString();
            //clsOperateurdroit.OT_CODETYPEOBJET = row["OT_CODETYPEOBJET"].ToString();
            //clsOperateurdroit.OB_LIBELLE = row["OB_LIBELLE"].ToString();
        }
    }
}