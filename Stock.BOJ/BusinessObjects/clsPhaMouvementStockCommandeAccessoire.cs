using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhamouvementStockcommandeaccessoire
	{
        private string _AG_CODEAGENCE = "";
        private double _CC_NUMSEQUENCE = 0;
		private string _MM_NUMSEQUENCE = "";
		private string _CC_CODEARTICLE1 = "";
		private string _CC_CODEARTICLE2 = "";
		private double _CC_UNITE = 0;
		private double _CC_QUANTITEENTREE = 0;
		private double _CC_QUANTITESORTIE = 0;
		private double _CC_PRIXUNITAIRE = 0;
        private string _OP_CODEOPERATEUR = "";

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public double CC_NUMSEQUENCE
		{
			get { return _CC_NUMSEQUENCE; }
			set { _CC_NUMSEQUENCE = value; }
		}

		public string MM_NUMSEQUENCE
		{
			get { return _MM_NUMSEQUENCE; }
			set { _MM_NUMSEQUENCE = value; }
		}
		public string CC_CODEARTICLE1
		{
			get { return _CC_CODEARTICLE1; }
			set { _CC_CODEARTICLE1 = value; }
		}
		public string CC_CODEARTICLE2
		{
			get { return _CC_CODEARTICLE2; }
			set { _CC_CODEARTICLE2 = value; }
		}
		public double CC_UNITE
		{
			get { return _CC_UNITE; }
			set { _CC_UNITE = value; }
		}
		public double CC_QUANTITEENTREE
		{
			get { return _CC_QUANTITEENTREE; }
			set { _CC_QUANTITEENTREE = value; }
		}
		public double CC_QUANTITESORTIE
		{
			get { return _CC_QUANTITESORTIE; }
			set { _CC_QUANTITESORTIE = value; }
		}
		public double CC_PRIXUNITAIRE
		{
			get { return _CC_PRIXUNITAIRE; }
			set { _CC_PRIXUNITAIRE = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public clsPhamouvementStockcommandeaccessoire() {} 


		public clsPhamouvementStockcommandeaccessoire(clsPhamouvementStockcommandeaccessoire clsPhamouvementStockcommandeaccessoire)
		{
            AG_CODEAGENCE = clsPhamouvementStockcommandeaccessoire.AG_CODEAGENCE;
            CC_NUMSEQUENCE = clsPhamouvementStockcommandeaccessoire.CC_NUMSEQUENCE;
			MM_NUMSEQUENCE = clsPhamouvementStockcommandeaccessoire.MM_NUMSEQUENCE;
			CC_CODEARTICLE1 = clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE1;
			CC_CODEARTICLE2 = clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE2;
			CC_UNITE = clsPhamouvementStockcommandeaccessoire.CC_UNITE;
			CC_QUANTITEENTREE = clsPhamouvementStockcommandeaccessoire.CC_QUANTITEENTREE;
			CC_QUANTITESORTIE = clsPhamouvementStockcommandeaccessoire.CC_QUANTITESORTIE;
			CC_PRIXUNITAIRE = clsPhamouvementStockcommandeaccessoire.CC_PRIXUNITAIRE;
            this.OP_CODEOPERATEUR = clsPhamouvementStockcommandeaccessoire.OP_CODEOPERATEUR;
		}
        }
}