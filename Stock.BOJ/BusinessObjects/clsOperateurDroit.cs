using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsOperateurdroit
	{

        private string _OP_CODEOPERATEUR = "";
		private int _OB_CODEOBJET = 0;
		private string _OD_AUTORISER = "";
		private string _OD_AJOUTER = "";
		private string _OD_MODIFIER = "";
		private string _OD_SUPPRIMER = "";
		private string _OD_APERCU = "";
		private string _OD_IMPRIMER = "";
		private string _OD_IMPRIMERTOUT = "";
        private string _LO_CODELOGICIEL = "";
        private string _OB_RATTACHEA = "";
		private int _OD_NUMEROORDRE = 0;

        private string _AG_CODEAGENCE = "";

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
		public int OB_CODEOBJET
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

		public int OD_NUMEROORDRE
		{
			get { return _OD_NUMEROORDRE; }
			set { _OD_NUMEROORDRE = value; }
		}



        public clsOperateurdroit() {}

        public clsOperateurdroit(string OP_CODEOPERATEUR, int OB_CODEOBJET, string OD_AUTORISER, string OD_AJOUTER, string OD_MODIFIER, string OD_SUPPRIMER, string OD_APERCU, string OD_IMPRIMER, string OD_IMPRIMERTOUT, string LO_CODELOGICIEL, string OB_RATTACHEA, int OD_NUMEROORDRE)
		{
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.OB_CODEOBJET = OB_CODEOBJET;
			this.OD_AUTORISER = OD_AUTORISER;
			this.OD_AJOUTER = OD_AJOUTER;
			this.OD_MODIFIER = OD_MODIFIER;
			this.OD_SUPPRIMER = OD_SUPPRIMER;
			this.OD_APERCU = OD_APERCU;
			this.OD_IMPRIMER = OD_IMPRIMER;
			this.OD_IMPRIMERTOUT = OD_IMPRIMERTOUT;
            this.LO_CODELOGICIEL = LO_CODELOGICIEL;
            this.OB_RATTACHEA = OB_RATTACHEA;
			this.OD_NUMEROORDRE = OD_NUMEROORDRE;
		}

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
		}
        }
}