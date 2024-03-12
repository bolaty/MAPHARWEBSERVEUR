using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhamouvementStockdetailcommande
	{

        private string _AG_CODEAGENCE = "";
		private string _AR_CODEARTICLE = "";
		private string _MK_NUMPIECE = "";
		private string _MM_NUMSEQUENCE = "";
		private double _MM_PRIXUNITAIREACHAT = 0;
		private double _MM_PRIXUNITAIREVENTE = 0;
		private string _MM_STATUTACCESSOIRE = "V";
		private double _MM_TAUXCOMMISSION = 0;
		private double _MM_MONTANTCOMMISSION = 0;
		private double _MM_TAUXREMISE = 0;
		private double _MM_MONTANTREMISE = 0;
		private double _MM_ASDI = 0;
        private double _MM_TVA = 0;
		private double _MM_QUANTITESORTIE = 0;
		private double _MM_QUANTITEENTREE = 0;
		private DateTime _MM_DATEPEREMPTION = DateTime.Parse("01/01/1900");
		private string _MM_ANNULATIONPIECE = "N";
        private double _MM_MONTANTTVA = 0;
        private double _MM_MONTANTASDI = 0;

        private double _MM_MONTANTESCOMPTE = 0;
        private double _MM_TAUXESCOMPTE = 0;
        private double _MM_MONTANTREMISEUNITAIRE = 0;
        private double _MM_MONTANTESCOMPTEUNITAIRE = 0;
		private string _MM_DESCRIPTION = "";
		private Double _MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE =0;
        private string _JF_CODETYPEJOURFACTURATION = "";
        private string _LF_CODELIEUFACTURATION = "";
        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set { _AR_CODEARTICLE = value; }
		}
		public string MK_NUMPIECE
		{
			get { return _MK_NUMPIECE; }
			set { _MK_NUMPIECE = value; }
		}
		public string MM_NUMSEQUENCE
		{
			get { return _MM_NUMSEQUENCE; }
			set { _MM_NUMSEQUENCE = value; }
		}
		public double MM_PRIXUNITAIREACHAT
		{
			get { return _MM_PRIXUNITAIREACHAT; }
			set { _MM_PRIXUNITAIREACHAT = value; }
		}
		public double MM_PRIXUNITAIREVENTE
		{
			get { return _MM_PRIXUNITAIREVENTE; }
			set { _MM_PRIXUNITAIREVENTE = value; }
		}
		public string MM_STATUTACCESSOIRE
		{
			get { return _MM_STATUTACCESSOIRE; }
			set { _MM_STATUTACCESSOIRE = value; }
		}
		public double MM_TAUXCOMMISSION
		{
			get { return _MM_TAUXCOMMISSION; }
			set { _MM_TAUXCOMMISSION = value; }
		}
		public double MM_MONTANTCOMMISSION
		{
			get { return _MM_MONTANTCOMMISSION; }
			set { _MM_MONTANTCOMMISSION = value; }
		}
		public double MM_TAUXREMISE
		{
			get { return _MM_TAUXREMISE; }
			set { _MM_TAUXREMISE = value; }
		}
		public double MM_MONTANTREMISE
		{
			get { return _MM_MONTANTREMISE; }
			set { _MM_MONTANTREMISE = value; }
		}
		public double  MM_ASDI
		{
			get { return _MM_ASDI; }
			set { _MM_ASDI = value; }
		}
        public double MM_TVA
		{
			get { return _MM_TVA; }
			set { _MM_TVA = value; }
		}
		public double MM_QUANTITESORTIE
		{
			get { return _MM_QUANTITESORTIE; }
			set { _MM_QUANTITESORTIE = value; }
		}
		public double MM_QUANTITEENTREE
		{
			get { return _MM_QUANTITEENTREE; }
			set { _MM_QUANTITEENTREE = value; }
		}
		public DateTime MM_DATEPEREMPTION
		{
			get { return _MM_DATEPEREMPTION; }
			set { _MM_DATEPEREMPTION = value; }
		}
		public string MM_ANNULATIONPIECE
		{
			get { return _MM_ANNULATIONPIECE; }
			set { _MM_ANNULATIONPIECE = value; }
		}
        public double MM_MONTANTTVA
		{
            get { return _MM_MONTANTTVA; }
            set { _MM_MONTANTTVA = value; }
		}
        public double MM_MONTANTASDI
		{
            get { return _MM_MONTANTASDI; }
            set { _MM_MONTANTASDI = value; }
		}

        public double MM_MONTANTESCOMPTE
        {
            get { return _MM_MONTANTESCOMPTE; }
            set { _MM_MONTANTESCOMPTE = value; }
        }

        public double MM_TAUXESCOMPTE
        {
            get { return _MM_TAUXESCOMPTE; }
            set { _MM_TAUXESCOMPTE = value; }
        }

        public double MM_MONTANTREMISEUNITAIRE
        {
            get { return _MM_MONTANTREMISEUNITAIRE; }
            set { _MM_MONTANTREMISEUNITAIRE = value; }
        }

        public double MM_MONTANTESCOMPTEUNITAIRE
        {
            get { return _MM_MONTANTESCOMPTEUNITAIRE; }
            set { _MM_MONTANTESCOMPTEUNITAIRE = value; }
        }

        public string MM_DESCRIPTION
        {
            get { return _MM_DESCRIPTION; }
            set { _MM_DESCRIPTION = value; }
        }

        public Double MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE
        {
            get { return _MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE; }
            set { _MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = value; }
        }


        public string JF_CODETYPEJOURFACTURATION
        {
            get { return _JF_CODETYPEJOURFACTURATION; }
            set { _JF_CODETYPEJOURFACTURATION = value; }
        }

        public string LF_CODELIEUFACTURATION
        {
            get { return _LF_CODELIEUFACTURATION; }
            set { _LF_CODELIEUFACTURATION = value; }
        }

        //private double _MM_MONTANTESCOMPTE = 0;
        //private double _MM_TAUXESCOMPTE = 0;
        //private double _MM_MONTANTREMISEUNITAIRE = 0;
        //private double _MM_MONTANTESCOMPTEUNITAIRE = 0;



        public clsPhamouvementStockdetailcommande() {}

       

		public clsPhamouvementStockdetailcommande(clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande)
		{
			AG_CODEAGENCE = clsPhamouvementStockdetailcommande.AG_CODEAGENCE;
			AR_CODEARTICLE = clsPhamouvementStockdetailcommande.AR_CODEARTICLE;
			MK_NUMPIECE = clsPhamouvementStockdetailcommande.MK_NUMPIECE;
			MM_NUMSEQUENCE = clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE;
			MM_PRIXUNITAIREACHAT = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREACHAT;
			MM_PRIXUNITAIREVENTE = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTE;
			MM_STATUTACCESSOIRE = clsPhamouvementStockdetailcommande.MM_STATUTACCESSOIRE;
			MM_TAUXCOMMISSION = clsPhamouvementStockdetailcommande.MM_TAUXCOMMISSION;
			MM_MONTANTCOMMISSION = clsPhamouvementStockdetailcommande.MM_MONTANTCOMMISSION;
			MM_TAUXREMISE = clsPhamouvementStockdetailcommande.MM_TAUXREMISE;
			MM_MONTANTREMISE = clsPhamouvementStockdetailcommande.MM_MONTANTREMISE;
			MM_ASDI = clsPhamouvementStockdetailcommande.MM_ASDI;
			MM_TVA = clsPhamouvementStockdetailcommande.MM_TVA;
			MM_QUANTITESORTIE = clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE;
			MM_QUANTITEENTREE = clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE;
			MM_DATEPEREMPTION = clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION;
			MM_ANNULATIONPIECE = clsPhamouvementStockdetailcommande.MM_ANNULATIONPIECE;
            MM_MONTANTTVA = clsPhamouvementStockdetailcommande.MM_MONTANTTVA;
            MM_MONTANTASDI = clsPhamouvementStockdetailcommande.MM_MONTANTASDI;
            MM_MONTANTESCOMPTE = clsPhamouvementStockdetailcommande.MM_MONTANTESCOMPTE;
            MM_TAUXESCOMPTE = clsPhamouvementStockdetailcommande.MM_TAUXESCOMPTE;
            MM_MONTANTREMISEUNITAIRE = clsPhamouvementStockdetailcommande.MM_MONTANTREMISEUNITAIRE;
            MM_MONTANTESCOMPTEUNITAIRE = clsPhamouvementStockdetailcommande.MM_MONTANTESCOMPTEUNITAIRE;
            MM_DESCRIPTION = clsPhamouvementStockdetailcommande.MM_DESCRIPTION;
            MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE;
            JF_CODETYPEJOURFACTURATION = clsPhamouvementStockdetailcommande.JF_CODETYPEJOURFACTURATION;
            LF_CODELIEUFACTURATION = clsPhamouvementStockdetailcommande.LF_CODELIEUFACTURATION;


        }
        }
}