using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhamouvementStockdetail
	{

        private string _AG_CODEAGENCE = "";
		private string _AR_CODEARTICLE = "";
        private string _AR_CODEARTICLE1 = "";
		private string _MS_NUMPIECE = "";
        private string _MD_NUMSEQUENCE = "";
		private double _MD_PRIXUNITAIREACHAT = 0;
		private double _MD_PRIXUNITAIREVENTE = 0;
		private string _MD_STATUTACCESSOIRE = "";
		private double _MD_TAUXCOMMISSION = 0;
		private double _MD_MONTANTCOMMISSION = 0;
		private double _MD_TAUXREMISE = 0;
		private double _MD_MONTANTREMISE = 0;
        private double _MD_ASDI = 0;
        private double _MD_TVA = 0;
		private double _MD_QUANTITESORTIE = 0;
		private double _MD_QUANTITEENTREE = 0;
        private double _MD_QUANTITEPERDUE = 0;
        private double _MD_QUANTITEPERTEFICTIF = 0;
        private double _MD_QUANTITEGAGNEE = 0;
        private double _MD_NOMBRESAC = 0;
        private double _MD_POIDSNET = 0;
        private double _MD_NOMBRESACTRANSMIS = 0;
        private double _MD_NOMBRESACACCEPTE = 0;
        private double _MD_REFACTION = 0;

		private DateTime _MD_DATEPEREMPTION = DateTime.Parse("01/01/1900");
		private string _MD_ANNULATIONPIECE = "";
        private string _MD_DESCRIPTION = "";
        private string _MD_NUMEROPIECE = "";
        private double _MD_MONTANTVERSE = 0;
        private DateTime _MD_DATERETRAIT = DateTime.Parse("01/01/1900");
        private string _MD_REMETTANT = "";
        private int _TYPEOPERATION = 0;
        private string _NO_CODENATUREOPERATION = "";
        private string _EN_CODEENTREPOT = "";
         private string _MF_IDFILTRAGEDESTOCK = ""; 
         private string _ME_IDFILTRAGEDESTOCKEXPIRATION = "";          
         private string _MF_IDFILTRAGEDESTOCKM1 = "";            
         private string _MF_IDFILTRAGEDESTOCKM2 = "";           
   
            private string _TI_IDTIERSPHARMACIE = "";      
               
         private Double _MD_MONTANTASSUREUR = 0;
        private Double _MD_MONTANTESCOMPTE = 0;
        private Double _MD_TAUXESCOMPTE = 0;
        private Double _MD_MONTANTREMISEUNITAIRE = 0;
        private Double _MD_MONTANTESCOMPTEUNITAIRE = 0;

        private Double _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = 0;
        private Double _MD_TAUXREMBOURSEMENT = 0;
        private string _JF_CODETYPEJOURFACTURATION = "";
        private string _LF_CODELIEUFACTURATION = "";

        //private string _CH_IDCHAUFFEUR = "";


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
        public string AR_CODEARTICLE1
        {
            get { return _AR_CODEARTICLE1; }
            set { _AR_CODEARTICLE1 = value; }
        }

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set { _MS_NUMPIECE = value; }
		}
        public string MD_NUMSEQUENCE
		{
			get { return _MD_NUMSEQUENCE; }
			set { _MD_NUMSEQUENCE = value; }
		}
		public double MD_PRIXUNITAIREACHAT
		{
			get { return _MD_PRIXUNITAIREACHAT; }
			set { _MD_PRIXUNITAIREACHAT = value; }
		}
		public double MD_PRIXUNITAIREVENTE
		{
			get { return _MD_PRIXUNITAIREVENTE; }
			set { _MD_PRIXUNITAIREVENTE = value; }
		}

        public double MD_QUANTITEPERTEFICTIF
		{
            get { return _MD_QUANTITEPERTEFICTIF; }
            set { _MD_QUANTITEPERTEFICTIF = value; }
		}
		public string MD_STATUTACCESSOIRE
		{
			get { return _MD_STATUTACCESSOIRE; }
			set { _MD_STATUTACCESSOIRE = value; }
		}
		public double MD_TAUXCOMMISSION
		{
			get { return _MD_TAUXCOMMISSION; }
			set { _MD_TAUXCOMMISSION = value; }
		}
		public double MD_MONTANTCOMMISSION
		{
			get { return _MD_MONTANTCOMMISSION; }
			set { _MD_MONTANTCOMMISSION = value; }
		}
		public double MD_TAUXREMISE
		{
			get { return _MD_TAUXREMISE; }
			set { _MD_TAUXREMISE = value; }
		}
		public double MD_MONTANTREMISE
		{
			get { return _MD_MONTANTREMISE; }
			set { _MD_MONTANTREMISE = value; }
		}
        public double MD_ASDI
		{
			get { return _MD_ASDI; }
			set { _MD_ASDI = value; }
		}
        public double MD_TVA
		{
			get { return _MD_TVA; }
			set { _MD_TVA = value; }
		}
		public double MD_QUANTITESORTIE
		{
			get { return _MD_QUANTITESORTIE; }
			set { _MD_QUANTITESORTIE = value; }
		}
		public double MD_QUANTITEENTREE
		{
			get { return _MD_QUANTITEENTREE; }
			set { _MD_QUANTITEENTREE = value; }
		}

        public double MD_QUANTITEPERDUE
        {
            get { return _MD_QUANTITEPERDUE; }
            set { _MD_QUANTITEPERDUE = value; }
        }
        public double MD_QUANTITEGAGNEE
        {
            get { return _MD_QUANTITEGAGNEE; }
            set { _MD_QUANTITEGAGNEE = value; }
        }


        public double MD_NOMBRESAC
        {
            get { return _MD_NOMBRESAC; }
            set { _MD_NOMBRESAC = value; }
        }


        public double MD_POIDSNET
        {
            get { return _MD_POIDSNET; }
            set { _MD_POIDSNET = value; }
        }

        public double MD_NOMBRESACTRANSMIS
        {
            get { return _MD_NOMBRESACTRANSMIS; }
            set { _MD_NOMBRESACTRANSMIS = value; }
        }

        public double MD_NOMBRESACACCEPTE
        {
            get { return _MD_NOMBRESACACCEPTE; }
            set { _MD_NOMBRESACACCEPTE = value; }
        }

        public double MD_REFACTION
        {
            get { return _MD_REFACTION; }
            set { _MD_REFACTION = value; }
        }
       

		public DateTime MD_DATEPEREMPTION
		{
			get { return _MD_DATEPEREMPTION; }
			set { _MD_DATEPEREMPTION = value; }
		}
		public string MD_ANNULATIONPIECE
		{
			get { return _MD_ANNULATIONPIECE; }
			set { _MD_ANNULATIONPIECE = value; }
		}
        public string MD_DESCRIPTION
		{
            get { return _MD_DESCRIPTION; }
            set { _MD_DESCRIPTION = value; }
		}
        public string MD_NUMEROPIECE
		{
            get { return _MD_NUMEROPIECE; }
            set { _MD_NUMEROPIECE = value; }
		}



        public double MD_MONTANTVERSE
        {
            get { return _MD_MONTANTVERSE; }
            set { _MD_MONTANTVERSE = value; }
        }
        public DateTime MD_DATERETRAIT
        {
            get { return _MD_DATERETRAIT; }
            set { _MD_DATERETRAIT = value; }
        }
        public string MD_REMETTANT
        {
            get { return _MD_REMETTANT; }
            set { _MD_REMETTANT = value; }
        }

        public int TYPEOPERATION
		{
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
		}


        public string NO_CODENATUREOPERATION
        {
            get { return _NO_CODENATUREOPERATION; }
            set { _NO_CODENATUREOPERATION = value; }
        }

        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }
        double _MD_MONTANTTVA = 0;
        public double MD_MONTANTTVA
        {
            get { return _MD_MONTANTTVA; }
            set { _MD_MONTANTTVA = value; }
        }

        double _MD_MONTANTASDI = 0;
        public double MD_MONTANTASDI
        {
            get { return _MD_MONTANTASDI; }
            set { _MD_MONTANTASDI = value; }
        }
        public string MF_IDFILTRAGEDESTOCK
        {
            get { return _MF_IDFILTRAGEDESTOCK; }
            set { _MF_IDFILTRAGEDESTOCK = value; }
        }
        public string ME_IDFILTRAGEDESTOCKEXPIRATION
        {
            get { return _ME_IDFILTRAGEDESTOCKEXPIRATION; }
            set { _ME_IDFILTRAGEDESTOCKEXPIRATION = value; }
        }      
        public string MF_IDFILTRAGEDESTOCKM1
        {
            get { return _MF_IDFILTRAGEDESTOCKM1; }
            set { _MF_IDFILTRAGEDESTOCKM1 = value; }
        }  

        public string MF_IDFILTRAGEDESTOCKM2
        {
            get { return _MF_IDFILTRAGEDESTOCKM2; }
            set { _MF_IDFILTRAGEDESTOCKM2 = value; }
        }

        public string TI_IDTIERSPHARMACIE
        {
            get { return _TI_IDTIERSPHARMACIE; }
            set { _TI_IDTIERSPHARMACIE = value; }
        }
        public Double MD_MONTANTASSUREUR
        {
            get { return _MD_MONTANTASSUREUR; }
            set { _MD_MONTANTASSUREUR = value; }
        }

        public Double MD_MONTANTESCOMPTE
        {
            get { return _MD_MONTANTESCOMPTE; }
            set { _MD_MONTANTESCOMPTE = value; }
        }

        public Double MD_TAUXESCOMPTE
        {
            get { return _MD_TAUXESCOMPTE; }
            set { _MD_TAUXESCOMPTE = value; }
        }

        public Double MD_TAUXREMBOURSEMENT
        {
            get { return _MD_TAUXREMBOURSEMENT; }
            set { _MD_TAUXREMBOURSEMENT = value; }
        }

        public Double MD_MONTANTREMISEUNITAIRE
        {
            get { return _MD_MONTANTREMISEUNITAIRE; }
            set { _MD_MONTANTREMISEUNITAIRE = value; }
        }

        public Double MD_MONTANTESCOMPTEUNITAIRE
        {
            get { return _MD_MONTANTESCOMPTEUNITAIRE; }
            set { _MD_MONTANTESCOMPTEUNITAIRE = value; }
        }
        
        public Double MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE
        {
            get { return _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE; }
            set { _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = value; }
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


        //public string CH_IDCHAUFFEUR
        //{
        //    get { return _CH_IDCHAUFFEUR; }
        //    set { _CH_IDCHAUFFEUR = value; }
        //}


        public clsPhamouvementStockdetail() {}


		public clsPhamouvementStockdetail(clsPhamouvementStockdetail clsPhamouvementStockdetail)
		{
			AG_CODEAGENCE = clsPhamouvementStockdetail.AG_CODEAGENCE;

			AR_CODEARTICLE = clsPhamouvementStockdetail.AR_CODEARTICLE;
            AR_CODEARTICLE1 = clsPhamouvementStockdetail.AR_CODEARTICLE1;

			MS_NUMPIECE = clsPhamouvementStockdetail.MS_NUMPIECE;
			MD_NUMSEQUENCE = clsPhamouvementStockdetail.MD_NUMSEQUENCE;
			MD_PRIXUNITAIREACHAT = clsPhamouvementStockdetail.MD_PRIXUNITAIREACHAT;
			MD_PRIXUNITAIREVENTE = clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTE;
			MD_STATUTACCESSOIRE = clsPhamouvementStockdetail.MD_STATUTACCESSOIRE;
			MD_TAUXCOMMISSION = clsPhamouvementStockdetail.MD_TAUXCOMMISSION;
			MD_MONTANTCOMMISSION = clsPhamouvementStockdetail.MD_MONTANTCOMMISSION;
			MD_TAUXREMISE = clsPhamouvementStockdetail.MD_TAUXREMISE;
			MD_MONTANTREMISE = clsPhamouvementStockdetail.MD_MONTANTREMISE;
			MD_ASDI = clsPhamouvementStockdetail.MD_ASDI;
			MD_TVA = clsPhamouvementStockdetail.MD_TVA;
			MD_QUANTITESORTIE = clsPhamouvementStockdetail.MD_QUANTITESORTIE;
			MD_QUANTITEENTREE = clsPhamouvementStockdetail.MD_QUANTITEENTREE;
            MD_QUANTITEPERDUE = clsPhamouvementStockdetail.MD_QUANTITEPERDUE;
            MD_QUANTITEPERTEFICTIF = clsPhamouvementStockdetail.MD_QUANTITEPERTEFICTIF;
            MD_QUANTITEGAGNEE = clsPhamouvementStockdetail.MD_QUANTITEGAGNEE;

            MD_NOMBRESAC = clsPhamouvementStockdetail.MD_NOMBRESAC;
            MD_POIDSNET = clsPhamouvementStockdetail.MD_POIDSNET;
            MD_NOMBRESACTRANSMIS = clsPhamouvementStockdetail.MD_NOMBRESACTRANSMIS;
            MD_NOMBRESACACCEPTE = clsPhamouvementStockdetail.MD_NOMBRESACACCEPTE;
            MD_REFACTION = clsPhamouvementStockdetail.MD_REFACTION;

			MD_DATEPEREMPTION = clsPhamouvementStockdetail.MD_DATEPEREMPTION;
			MD_ANNULATIONPIECE = clsPhamouvementStockdetail.MD_ANNULATIONPIECE;
            MD_DESCRIPTION = clsPhamouvementStockdetail.MD_DESCRIPTION;
            MD_NUMEROPIECE = clsPhamouvementStockdetail.MD_NUMEROPIECE;


            MD_MONTANTVERSE = clsPhamouvementStockdetail.MD_MONTANTVERSE;
            MD_DATERETRAIT = clsPhamouvementStockdetail.MD_DATERETRAIT;
            MD_REMETTANT = clsPhamouvementStockdetail.MD_REMETTANT;
            TYPEOPERATION = clsPhamouvementStockdetail._TYPEOPERATION;
            NO_CODENATUREOPERATION = clsPhamouvementStockdetail.NO_CODENATUREOPERATION;
            EN_CODEENTREPOT = clsPhamouvementStockdetail.EN_CODEENTREPOT;
            MD_MONTANTTVA = clsPhamouvementStockdetail.MD_MONTANTTVA;
            MD_MONTANTASDI = clsPhamouvementStockdetail.MD_MONTANTASDI;
            MF_IDFILTRAGEDESTOCK = clsPhamouvementStockdetail.MF_IDFILTRAGEDESTOCK;
            ME_IDFILTRAGEDESTOCKEXPIRATION = clsPhamouvementStockdetail.ME_IDFILTRAGEDESTOCKEXPIRATION;
            MF_IDFILTRAGEDESTOCKM1 = clsPhamouvementStockdetail.MF_IDFILTRAGEDESTOCKM1;
            MF_IDFILTRAGEDESTOCKM2 = clsPhamouvementStockdetail.MF_IDFILTRAGEDESTOCKM2;
            TI_IDTIERSPHARMACIE = clsPhamouvementStockdetail.TI_IDTIERSPHARMACIE;
            MD_MONTANTASSUREUR = clsPhamouvementStockdetail.MD_MONTANTASSUREUR;
            MD_MONTANTESCOMPTE = clsPhamouvementStockdetail.MD_MONTANTESCOMPTE;
            MD_TAUXESCOMPTE = clsPhamouvementStockdetail.MD_TAUXESCOMPTE;
            MD_TAUXREMBOURSEMENT = clsPhamouvementStockdetail.MD_TAUXREMBOURSEMENT;
            MD_MONTANTREMISEUNITAIRE = clsPhamouvementStockdetail.MD_MONTANTREMISEUNITAIRE;
            MD_MONTANTESCOMPTEUNITAIRE = clsPhamouvementStockdetail.MD_MONTANTESCOMPTEUNITAIRE;
            MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE;

            JF_CODETYPEJOURFACTURATION = clsPhamouvementStockdetail.JF_CODETYPEJOURFACTURATION;
            LF_CODELIEUFACTURATION = clsPhamouvementStockdetail.LF_CODELIEUFACTURATION;

            //private Double _MD_MONTANTESCOMPTE = 0;
            //private Double _MD_TAUXESCOMPTE = 0;
            //CH_IDCHAUFFEUR = clsPhamouvementStockdetail.CH_IDCHAUFFEUR;
        }


    }
}