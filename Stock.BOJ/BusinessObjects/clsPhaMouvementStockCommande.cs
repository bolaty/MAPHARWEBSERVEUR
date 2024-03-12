using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhamouvementStockcommande
	{

        private string _AG_CODEAGENCE = "";
		private string _MK_NUMPIECE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CH_IDCHAUFFEUR = "";
		private DateTime _MK_DATEPIECE = DateTime.Parse("01/01/1900");
		private double _MK_NUMSEQUENCE = 0;
        //private string _FR_CODEFOURNISSEUR = "";
        //private string _FR_MATRICULE = "";
        private string _TI_IDTIERS = "";
        private string _PR_IDTIERS = "";
        //private string _CL_NUMCLIENT = "";
        private string _TI_NUMTIERS = "";
        private string _CO_IDCOMMERCIAL = "";
        private string _CO_NUMCOMMERCIAL = "";
		private string _MK_REFPIECE = "";
		private string _MK_LIBOPERA = "";
		private string _NO_CODENATUREOPERATION = "";
		private double _MK_TAUXREMISE = 0;
		private double _MK_MONTANTTOTALREMISE = 0;
		private double _MK_MONTANTTRANSPORT = 0;
        private double _MK_MONTANTVERSE = 0;
		private int _MK_DELAILIVRAISON = 0;
		private DateTime _MK_DATELIVRAISON = DateTime.Parse("01/01/1900");
		private string _MK_ANNULATIONPIECE = "N";
		private string _OP_CODEOPERATEUR = "";
		private DateTime _MK_DATESAISIE = DateTime.Parse("01/01/1900");
		private double _MK_MONTANTECHEANCE = 0;
		private int _MK_DUREEPRET = 0;
		private DateTime _MK_DATEDEBUTREGLEMENT = DateTime.Parse("01/01/1900");
		private string _MK_DUREEVALIDITE = "";
		private string _MK_CONDITIONREGLEMENT = "";
		private string _MK_SITUATIONFACTURE = "N";
        private double _MK_TAUXTVA = 0;
        private double _MK_TAUXASDI = 0;
		private int _TYPEOPERATION = 0;
		private string _MK_VOSREFERENCES ="";
		private string _MK_CONDITIONDEREGLEMENT = "";
		private string _MK_REMETTANT = "";
		private string _MR_CODEMODEREGLEMENT = "";
		private string _OP_CODEOPERATEURRESPONSABLECMD = "";
		private string _MK_MOTIFCMD = "";
		private string _MK_LIEULIVRAISON = "";
		private string _MK_PERSONNEACONTACTER = "";
		private string _MK_CONTACTPERSONNEACONTACTER = "";
		private string _MK_NOTERBIEN = ""; 
	 


        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string MK_NUMPIECE
		{
			get { return _MK_NUMPIECE; }
			set { _MK_NUMPIECE = value; }
		}
		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set { _EN_CODEENTREPOT = value; }
		}
		public string CH_IDCHAUFFEUR
		{
			get { return _CH_IDCHAUFFEUR; }
			set { _CH_IDCHAUFFEUR = value; }
		}
		public DateTime MK_DATEPIECE
		{
			get { return _MK_DATEPIECE; }
			set { _MK_DATEPIECE = value; }
		}
		public double MK_NUMSEQUENCE
		{
			get { return _MK_NUMSEQUENCE; }
			set { _MK_NUMSEQUENCE = value; }
		}
        //public string FR_CODEFOURNISSEUR
        //{
        //    get { return _FR_CODEFOURNISSEUR; }
        //    set { _FR_CODEFOURNISSEUR = value; }
        //}
        //public string FR_MATRICULE
        //{
        //    get { return _FR_MATRICULE; }
        //    set { _FR_MATRICULE = value; }
        //}
        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }
        public string PR_IDTIERS
        {
            get { return _PR_IDTIERS; }
            set { _PR_IDTIERS = value; }
        }


        //public string CL_NUMCLIENT
        //{
        //    get { return _CL_NUMCLIENT; }
        //    set { _CL_NUMCLIENT = value; }
        //}
        public string TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }
		public string  CO_IDCOMMERCIAL
		{
			get { return _CO_IDCOMMERCIAL; }
			set { _CO_IDCOMMERCIAL = value; }
		}
        public string CO_NUMCOMMERCIAL
		{
            get { return _CO_NUMCOMMERCIAL; }
            set { _CO_NUMCOMMERCIAL = value; }
		}

		public string MK_REFPIECE
		{
			get { return _MK_REFPIECE; }
			set { _MK_REFPIECE = value; }
		}
		public string MK_LIBOPERA
		{
			get { return _MK_LIBOPERA; }
			set { _MK_LIBOPERA = value; }
		}
		public string NO_CODENATUREOPERATION
		{
			get { return _NO_CODENATUREOPERATION; }
			set { _NO_CODENATUREOPERATION = value; }
		}
		public double MK_TAUXREMISE
		{
			get { return _MK_TAUXREMISE; }
			set { _MK_TAUXREMISE = value; }
		}
		public double MK_MONTANTTOTALREMISE
		{
			get { return _MK_MONTANTTOTALREMISE; }
			set { _MK_MONTANTTOTALREMISE = value; }
		}
		public double MK_MONTANTTRANSPORT
		{
			get { return _MK_MONTANTTRANSPORT; }
			set { _MK_MONTANTTRANSPORT = value; }
		}
        public double MK_MONTANTVERSE
        {
            get { return _MK_MONTANTVERSE; }
            set { _MK_MONTANTVERSE = value; }
        }

		public int MK_DELAILIVRAISON
		{
			get { return _MK_DELAILIVRAISON; }
			set { _MK_DELAILIVRAISON = value; }
		}
		public DateTime MK_DATELIVRAISON
		{
			get { return _MK_DATELIVRAISON; }
			set { _MK_DATELIVRAISON = value; }
		}
		public string MK_ANNULATIONPIECE
		{
			get { return _MK_ANNULATIONPIECE; }
			set { _MK_ANNULATIONPIECE = value; }
		}
		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
		public DateTime MK_DATESAISIE
		{
			get { return _MK_DATESAISIE; }
			set { _MK_DATESAISIE = value; }
		}
		public double MK_MONTANTECHEANCE
		{
			get { return _MK_MONTANTECHEANCE; }
			set { _MK_MONTANTECHEANCE = value; }
		}
		public int MK_DUREEPRET
		{
			get { return _MK_DUREEPRET; }
			set { _MK_DUREEPRET = value; }
		}
		public DateTime MK_DATEDEBUTREGLEMENT
		{
			get { return _MK_DATEDEBUTREGLEMENT; }
			set { _MK_DATEDEBUTREGLEMENT = value; }
		}
		public string MK_DUREEVALIDITE
		{
			get { return _MK_DUREEVALIDITE; }
			set { _MK_DUREEVALIDITE = value; }
		}
		public string MK_CONDITIONREGLEMENT
		{
			get { return _MK_CONDITIONREGLEMENT; }
			set { _MK_CONDITIONREGLEMENT = value; }
		}
		public string MK_SITUATIONFACTURE
		{
			get { return _MK_SITUATIONFACTURE; }
			set { _MK_SITUATIONFACTURE = value; }
		}

        public double MK_TAUXTVA
        {
            get { return _MK_TAUXTVA; }
            set { _MK_TAUXTVA = value; }
        }
        public double MK_TAUXASDI
        {
            get { return _MK_TAUXASDI; }
            set { _MK_TAUXASDI = value; }
        }

        public int TYPEOPERATION
		{
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
		}
        public string MK_VOSREFERENCES
        {
            get { return _MK_VOSREFERENCES; }
            set { _MK_VOSREFERENCES = value; }
		}
        public string MK_CONDITIONDEREGLEMENT
        {
            get { return _MK_CONDITIONDEREGLEMENT; }
            set { _MK_CONDITIONDEREGLEMENT = value; }
        }

        public string MK_REMETTANT
        {
            get { return _MK_REMETTANT; }
            set { _MK_REMETTANT = value; }
        }

        public string MR_CODEMODEREGLEMENT
        {
            get { return _MR_CODEMODEREGLEMENT; }
            set { _MR_CODEMODEREGLEMENT = value; }
        }
        public string OP_CODEOPERATEURRESPONSABLECMD
        {
            get { return _OP_CODEOPERATEURRESPONSABLECMD; }
            set { _OP_CODEOPERATEURRESPONSABLECMD = value; }
        }

        public string MK_MOTIFCMD
        {
            get { return _MK_MOTIFCMD; }
            set { _MK_MOTIFCMD = value; }
        }
        public string MK_LIEULIVRAISON
        {
            get { return _MK_LIEULIVRAISON; }
            set { _MK_LIEULIVRAISON = value; }
        }
        public string MK_PERSONNEACONTACTER
        {
            get { return _MK_PERSONNEACONTACTER; }
            set { _MK_PERSONNEACONTACTER = value; }
        }

        public string MK_CONTACTPERSONNEACONTACTER
        {
            get { return _MK_CONTACTPERSONNEACONTACTER; }
            set { _MK_CONTACTPERSONNEACONTACTER = value; }
        }

        public string MK_NOTERBIEN
        {
            get { return _MK_NOTERBIEN; }
            set { _MK_NOTERBIEN = value; }
        }
       









        public clsPhamouvementStockcommande() {}


		public clsPhamouvementStockcommande(clsPhamouvementStockcommande clsPhamouvementStockcommande) 
		{
			AG_CODEAGENCE = clsPhamouvementStockcommande.AG_CODEAGENCE;
			MK_NUMPIECE = clsPhamouvementStockcommande.MK_NUMPIECE;
			EN_CODEENTREPOT = clsPhamouvementStockcommande.EN_CODEENTREPOT;
			CH_IDCHAUFFEUR = clsPhamouvementStockcommande.CH_IDCHAUFFEUR;
			MK_DATEPIECE = clsPhamouvementStockcommande.MK_DATEPIECE;
			MK_NUMSEQUENCE = clsPhamouvementStockcommande.MK_NUMSEQUENCE;
            //FR_CODEFOURNISSEUR = clsPhamouvementStockcommande.FR_CODEFOURNISSEUR;
            //FR_MATRICULE = clsPhamouvementStockcommande.FR_MATRICULE;
            TI_IDTIERS = clsPhamouvementStockcommande.TI_IDTIERS;
            PR_IDTIERS = clsPhamouvementStockcommande.PR_IDTIERS;
            //CL_NUMCLIENT = clsPhamouvementStockcommande.CL_NUMCLIENT;
            TI_NUMTIERS = clsPhamouvementStockcommande.TI_NUMTIERS;
			CO_IDCOMMERCIAL = clsPhamouvementStockcommande.CO_IDCOMMERCIAL;
            CO_NUMCOMMERCIAL = clsPhamouvementStockcommande.CO_NUMCOMMERCIAL;
			MK_REFPIECE = clsPhamouvementStockcommande.MK_REFPIECE;
			MK_LIBOPERA = clsPhamouvementStockcommande.MK_LIBOPERA;
			NO_CODENATUREOPERATION = clsPhamouvementStockcommande.NO_CODENATUREOPERATION;
			MK_TAUXREMISE = clsPhamouvementStockcommande.MK_TAUXREMISE;
			MK_MONTANTTOTALREMISE = clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE;
			MK_MONTANTTRANSPORT = clsPhamouvementStockcommande.MK_MONTANTTRANSPORT;
            MK_MONTANTVERSE = clsPhamouvementStockcommande.MK_MONTANTVERSE;
			MK_DELAILIVRAISON = clsPhamouvementStockcommande.MK_DELAILIVRAISON;
			MK_DATELIVRAISON = clsPhamouvementStockcommande.MK_DATELIVRAISON;
			MK_ANNULATIONPIECE = clsPhamouvementStockcommande.MK_ANNULATIONPIECE;
			OP_CODEOPERATEUR = clsPhamouvementStockcommande.OP_CODEOPERATEUR;
			MK_DATESAISIE = clsPhamouvementStockcommande.MK_DATESAISIE;
			MK_MONTANTECHEANCE = clsPhamouvementStockcommande.MK_MONTANTECHEANCE;
			MK_DUREEPRET = clsPhamouvementStockcommande.MK_DUREEPRET;
			MK_DATEDEBUTREGLEMENT = clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT;
			MK_DUREEVALIDITE = clsPhamouvementStockcommande.MK_DUREEVALIDITE;
			MK_CONDITIONREGLEMENT = clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT;
			MK_SITUATIONFACTURE = clsPhamouvementStockcommande.MK_SITUATIONFACTURE;
            MK_TAUXTVA = clsPhamouvementStockcommande.MK_TAUXTVA;
            MK_TAUXASDI = clsPhamouvementStockcommande.MK_TAUXASDI;
            TYPEOPERATION = clsPhamouvementStockcommande.TYPEOPERATION;
            MK_VOSREFERENCES = clsPhamouvementStockcommande.MK_VOSREFERENCES;
            MK_CONDITIONDEREGLEMENT = clsPhamouvementStockcommande.MK_CONDITIONDEREGLEMENT;
            MK_REMETTANT = clsPhamouvementStockcommande.MK_REMETTANT;
            MR_CODEMODEREGLEMENT = clsPhamouvementStockcommande.MR_CODEMODEREGLEMENT;
            OP_CODEOPERATEURRESPONSABLECMD = clsPhamouvementStockcommande.OP_CODEOPERATEURRESPONSABLECMD;
            MK_MOTIFCMD = clsPhamouvementStockcommande.MK_MOTIFCMD;
            MK_LIEULIVRAISON = clsPhamouvementStockcommande.MK_LIEULIVRAISON;
            MK_PERSONNEACONTACTER = clsPhamouvementStockcommande.MK_PERSONNEACONTACTER;
            MK_CONTACTPERSONNEACONTACTER = clsPhamouvementStockcommande.MK_CONTACTPERSONNEACONTACTER;
            MK_NOTERBIEN = clsPhamouvementStockcommande.MK_NOTERBIEN;            



        }
    }
}