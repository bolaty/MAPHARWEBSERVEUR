using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhamouvementStockaccessoire
	{
        private string _AG_CODEAGENCE = "";
        private string _MD_NUMSEQUENCE = "";
        private string _AC_NUMSEQUENCE = "";
		private string _AC_CODEARTICLE1 = "";
		private string _AC_CODEARTICLE2 = "";
        private double _AC_UNITE = 0;
		private double _AC_QUANTITEENTREE = 0;
		private double _AC_QUANTITESORTIE = 0;
		private double _AC_PRIXUNITAIRE = 0;
        private string _OP_CODEOPERATEUR = "";

        public string AG_CODEAGENCE
		{
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
		}
        public string MD_NUMSEQUENCE
		{
			get { return _MD_NUMSEQUENCE; }
			set { _MD_NUMSEQUENCE = value; }
		}
        public string AC_NUMSEQUENCE
		{
			get { return _AC_NUMSEQUENCE; }
			set { _AC_NUMSEQUENCE = value; }
		}
		public string AC_CODEARTICLE1
		{
			get { return _AC_CODEARTICLE1; }
			set { _AC_CODEARTICLE1 = value; }
		}
		public string AC_CODEARTICLE2
		{
			get { return _AC_CODEARTICLE2; }
			set { _AC_CODEARTICLE2 = value; }
		}
        public double AC_UNITE
		{
            get { return _AC_UNITE; }
            set { _AC_UNITE = value; }
		}
		public double AC_QUANTITEENTREE
		{
			get { return _AC_QUANTITEENTREE; }
			set { _AC_QUANTITEENTREE = value; }
		}
        public double AC_QUANTITESORTIE
		{
            get { return _AC_QUANTITESORTIE; }
            set { _AC_QUANTITESORTIE = value; }
		}
		public double AC_PRIXUNITAIRE
		{
			get { return _AC_PRIXUNITAIRE; }
			set { _AC_PRIXUNITAIRE = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public clsPhamouvementStockaccessoire() {}

       

		public clsPhamouvementStockaccessoire(clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire)
		{
            AG_CODEAGENCE = clsPhamouvementStockaccessoire.AG_CODEAGENCE;
			MD_NUMSEQUENCE = clsPhamouvementStockaccessoire.MD_NUMSEQUENCE;
			AC_NUMSEQUENCE = clsPhamouvementStockaccessoire.AC_NUMSEQUENCE;
			AC_CODEARTICLE1 = clsPhamouvementStockaccessoire.AC_CODEARTICLE1;
			AC_CODEARTICLE2 = clsPhamouvementStockaccessoire.AC_CODEARTICLE2;
            AC_UNITE = clsPhamouvementStockaccessoire.AC_UNITE;
			AC_QUANTITEENTREE = clsPhamouvementStockaccessoire.AC_QUANTITEENTREE;
            AC_QUANTITESORTIE = clsPhamouvementStockaccessoire.AC_QUANTITESORTIE;
			AC_PRIXUNITAIRE = clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE;
            this.OP_CODEOPERATEUR = clsPhamouvementStockaccessoire.OP_CODEOPERATEUR;
		}
        }
}