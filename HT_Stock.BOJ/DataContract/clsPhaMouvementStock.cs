using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhamouvementStock : clsEntitieBase
    {

        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _MS_NUMPIECE = "";
        private string _MS_NUMPIECE1 = "";
		private string _MK_NUMPIECE = "";
		
        private string _MS_NUMFACTURE = "";
		
		private string _MS_DATEPIECE = "01/01/1900";
        private string _MS_DATEFACTURE = "01/01/1900";
        private string _CA_DATESAISIE = "01/01/1900";
		private string _MS_NUMSEQUENCE = "0";
		private string _FR_CODEFOURNISSEUR = "";
        private string _FR_MATRICULE = "";
        private string _TI_IDTIERS = "";
        private string _TI_NUMTIERS = "";

        private string _TI_IDTIERSNEW = "";
        private string _TI_NUMTIERSNEW = "";
        private string _TI_DENOMINATIONNEW = "";
        private string _TI_TELEPHONENEW = "";
        private string _TI_ADRESSEGEOGRAPHIQUENEW = "";

		private string _CL_IDCLIENT = "";
        private string _CL_NUMCLIENT = "";
		private string _CO_IDCOMMERCIAL = "";
		private string _MS_REFPIECE = "";
		private string _MS_LIBOPERA = "";
		private string _NO_CODENATUREOPERATION = "";
		private string _MS_TAUXREMISE = "0";
		private string _MS_MONTANTTOTALREMISE = "0";
		private string _MS_MONTANTTRANSPORT = "0";
		private string _MS_DELAILIVRAISON = "0";
		private string _MS_DATELIVRAISON = "01/01/1900";
		private string _MS_ANNULATIONPIECE = "N";
		private string _OP_CODEOPERATEUR = "";
		private string _MS_DATESAISIE ="01/01/1900";
		private string _MS_MONTANTECHEANCE = "0";
		private string _MS_DUREEPRET = "0";
		private string _MS_DATEDEBUTREGLEMENT = "01/01/1900";
		private string _MS_DUREEVALIDITE = "";
		private string _MS_CONDITIONREGLEMENT = "";
        private string _MR_CODEMODEREGLEMENT = "";
		private string _MS_SITUATIONFACTURE = "";
        private string _MS_MONTANTVERSE = "0";
        private string _MS_TAUXTVA = "0";
        private string _MS_TAUXASDI = "0";

        private string _SOLDE = "0";
        private string _MONTANTFACTUREINITIAL = "0";
        private string _MONTANTFACTUREINITIALAVECREMISE = "0";
        private string _MONTANTFACTUREINITIALTTC = "0";
        private string _MONTANTFACTUREINITIALTTCPLUSAIRSI = "0";
        private string _MONTANTTVA = "0";
        private string _MONTANTAIRSI = "0";
        private string _MONTANTTRANSPORT = "0";

        private string _MS_MONTANTREMISE1 = "0";
        private string _MS_MONTANTREMISE2 = "0";



        private String _FB_IDFOURNISSEUR = "";
        private string _MS_MONTANTFOURNISSEURBON = "0";
        private String _MS_NUMBON = "";
        //private string _TYPEOPERATION = "0";

        private string _MS_DATEDEBUTFABRICATION ="01/01/1900";
        private string _MS_HEUREDEBUTFABRICATION = "01/01/1900";
        private string _MS_DATEFINFABRICATION ="01/01/1900";
        private string _MS_HEUREFINFABRICATION ="01/01/1900";

        private string _MS_DATEDEPART ="01/01/1900";
        private string _MS_HEUREDEBUT ="01/01/1900";
        private string _MS_HEUREFIN ="01/01/1900";
        private string _EM_CODEEMBALLAGE = "";
        private string _MS_TAUXHUMIDITE = "0";
        private string _MS_REMARQUE = "";
        private string _TR_IDTRANSPORTEUR = "";
        private string _CH_IDCHAUFFEUR = "";
        private string _SC_CODESECTION = "";
        private string _VH_CODEVEHICULE = "";
        private string _RM_CODEREMORQUE= "";
        private string _MV_NOMTIERS = "";
        private string _CA_CODECAMPAGNE = "";

        private string _MS_MONTANTTIMBRE = "0";
        //private string _MS_MONTANTASDI = 0;
        private string _CO_CODECONSULTATION = "";
        private string _COCHER = "";
        private string _MS_VOSREFERENCES = "";
        private string _MS_NUMPIECECALCULAVOIR = "";
        private string _MS_CONDITIONDEREGLEMENT = "";
        private string _MS_DATERENDEZVOUS ="01/01/1900";
        private string _TI_DENOMINATION = "";
        private string _TP_CODETYPETIERS = "";
        private string _NT_CODENATURETYPEARTICLE = "";
        private string _CO_NUMCOMMERCIAL = "";
        private string _CO_NOMPRENOM = "";
        private string _NT_CODENATURETIERS = "";
        private string _AR_CODEARTICLE1 = "";
        private string _GP_CODEGROUPE = "";
        private string _TYPELISTE = "";
        private string _MS_DATECLOTURE = "";
        private string _TI_TELEPHONE = "";
        private string _TI_ADRESSEGEOGRAPHIQUE = "";
        private string _MS_MONTANTVERSE1 = "0";
        private string _PL_NUMCOMPTE = "";
        private string _TI_PLAFONDCREDIT = "";
        private string _TI_ASDI = "";
        private string _TI_TVA = "";
        private string _MS_NUMERIMMATRICULATION = "";
        private string _MS_RESTAMONTANTVERSE = "0";
        private string _MS_TAUXASSURANCE = "0";
        private string _MS_MONTANTASSURANCE = "0";
        private string _SR_MONTANTCREDIT = "0";
        private string _NUMEROBORDEREAU = "0";
        private string _MONTANTTTCPLUSAIRSI = "0";
        private string _CA_CODECONTRAT = "";


        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}

        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }
		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set { _MS_NUMPIECE = value; }
		}

        public string MS_NUMPIECE1
        {
            get { return _MS_NUMPIECE1; }
            set { _MS_NUMPIECE1 = value; }
        }
		public string MK_NUMPIECE
		{
			get { return _MK_NUMPIECE; }
			set { _MK_NUMPIECE = value; }
		}
        
		
		public string MS_DATEPIECE
		{
			get { return _MS_DATEPIECE; }
			set { _MS_DATEPIECE = value; }
		}
        public string MS_DATEFACTURE
		{
            get { return _MS_DATEFACTURE; }
            set { _MS_DATEFACTURE = value; }
		}
        public string CA_DATESAISIE
        {
            get { return _CA_DATESAISIE; }
            set { _CA_DATESAISIE = value; }
		}

        public string MS_NUMFACTURE
		{
            get { return _MS_NUMFACTURE; }
            set { _MS_NUMFACTURE = value; }
		}
		public string MS_NUMSEQUENCE
		{
			get { return _MS_NUMSEQUENCE; }
			set { _MS_NUMSEQUENCE = value; }
		}
		public string FR_CODEFOURNISSEUR
		{
			get { return _FR_CODEFOURNISSEUR; }
			set { _FR_CODEFOURNISSEUR = value; }
		}
        public string FR_MATRICULE
		{
            get { return _FR_MATRICULE; }
            set { _FR_MATRICULE = value; }
		}


        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }


        public string TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }
        public string TI_IDTIERSNEW
        {
            get { return _TI_IDTIERSNEW; }
            set { _TI_IDTIERSNEW = value; }
        }


        public string TI_NUMTIERSNEW
        {
            get { return _TI_NUMTIERSNEW; }
            set { _TI_NUMTIERSNEW = value; }
        }

        public string TI_DENOMINATIONNEW
        {
            get { return _TI_DENOMINATIONNEW; }
            set { _TI_DENOMINATIONNEW = value; }
        }

        public string TI_TELEPHONENEW
        {
            get { return _TI_TELEPHONENEW; }
            set { _TI_TELEPHONENEW = value; }
        }
        public string TI_ADRESSEGEOGRAPHIQUENEW
        {
            get { return _TI_ADRESSEGEOGRAPHIQUENEW; }
            set { _TI_ADRESSEGEOGRAPHIQUENEW = value; }
        }

        public string MS_MONTANTTIMBRE
        {
            get { return _MS_MONTANTTIMBRE; }
            set { _MS_MONTANTTIMBRE = value; }
        }

        

        //private string _TI_IDTIERSNEW = "";
        //private string _TI_NUMTIERSNEW = "";
        //private string _TI_DENOMINATIONNEW = "";
        //private string _TI_TELEPHONENEW = "";



		public string CL_IDCLIENT
		{
			get { return _CL_IDCLIENT; }
			set { _CL_IDCLIENT = value; }
		}

        public string CL_NUMCLIENT
		{
            get { return _CL_NUMCLIENT; }
            set { _CL_NUMCLIENT = value; }
		}

		public string CO_IDCOMMERCIAL
		{
			get { return _CO_IDCOMMERCIAL; }
			set { _CO_IDCOMMERCIAL = value; }
		}
		public string MS_REFPIECE
		{
			get { return _MS_REFPIECE; }
			set { _MS_REFPIECE = value; }
		}
		public string MS_LIBOPERA
		{
			get { return _MS_LIBOPERA; }
			set { _MS_LIBOPERA = value; }
		}
		public string NO_CODENATUREOPERATION
		{
			get { return _NO_CODENATUREOPERATION; }
			set { _NO_CODENATUREOPERATION = value; }
		}
		public string MS_TAUXREMISE
		{
			get { return _MS_TAUXREMISE; }
			set { _MS_TAUXREMISE = value; }
		}
		public string MS_MONTANTTOTALREMISE
		{
			get { return _MS_MONTANTTOTALREMISE; }
			set { _MS_MONTANTTOTALREMISE = value; }
		}



		public string MS_MONTANTTRANSPORT
		{
			get { return _MS_MONTANTTRANSPORT; }
			set { _MS_MONTANTTRANSPORT = value; }
		}

        public string MS_MONTANTREMISE1
        {
            get { return _MS_MONTANTREMISE1; }
            set { _MS_MONTANTREMISE1 = value; }
        }

        public string MS_MONTANTREMISE2
        {
            get { return _MS_MONTANTREMISE2; }
            set { _MS_MONTANTREMISE2= value; }
        }


		public string MS_DELAILIVRAISON
		{
			get { return _MS_DELAILIVRAISON; }
			set { _MS_DELAILIVRAISON = value; }
		}
		public string MS_DATELIVRAISON
		{
			get { return _MS_DATELIVRAISON; }
			set { _MS_DATELIVRAISON = value; }
		}
		public string MS_ANNULATIONPIECE
		{
			get { return _MS_ANNULATIONPIECE; }
			set { _MS_ANNULATIONPIECE = value; }
		}
		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
		public string MS_DATESAISIE
		{
			get { return _MS_DATESAISIE; }
			set { _MS_DATESAISIE = value; }
		}
		public string MS_MONTANTECHEANCE
		{
			get { return _MS_MONTANTECHEANCE; }
			set { _MS_MONTANTECHEANCE = value; }
		}
		public string MS_DUREEPRET
		{
			get { return _MS_DUREEPRET; }
			set { _MS_DUREEPRET = value; }
		}
		public string MS_DATEDEBUTREGLEMENT
		{
			get { return _MS_DATEDEBUTREGLEMENT; }
			set { _MS_DATEDEBUTREGLEMENT = value; }
		}
		public string MS_DUREEVALIDITE
		{
			get { return _MS_DUREEVALIDITE; }
			set { _MS_DUREEVALIDITE = value; }
		}
		public string MS_CONDITIONREGLEMENT
		{
			get { return _MS_CONDITIONREGLEMENT; }
			set { _MS_CONDITIONREGLEMENT = value; }
		}
		public string MS_SITUATIONFACTURE
		{
			get { return _MS_SITUATIONFACTURE; }
			set { _MS_SITUATIONFACTURE = value; }
		}

        public string MR_CODEMODEREGLEMENT
		{
            get { return _MR_CODEMODEREGLEMENT; }
            set { _MR_CODEMODEREGLEMENT = value; }
		}

        public string MS_MONTANTVERSE
        {
            get { return _MS_MONTANTVERSE; }
            set { _MS_MONTANTVERSE = value; }
        }
       
        
        public string MS_TAUXTVA
        {
            get { return _MS_TAUXTVA; }
            set { _MS_TAUXTVA = value; }
        }



        public string MS_TAUXASDI
        {
            get { return _MS_TAUXASDI; }
            set { _MS_TAUXASDI = value; }
        }

        public string SOLDE
        {
            get { return _SOLDE; }
            set { _SOLDE = value; }
        }



        public string MONTANTFACTUREINITIAL
        {
            get { return _MONTANTFACTUREINITIAL; }
            set { _MONTANTFACTUREINITIAL = value; }
        }
        public string MONTANTFACTUREINITIALTTC
        {
            get { return _MONTANTFACTUREINITIALTTC; }
            set { _MONTANTFACTUREINITIALTTC = value; }
        }

        public string MONTANTFACTUREINITIALTTCPLUSAIRSI
        {
            get { return _MONTANTFACTUREINITIALTTCPLUSAIRSI; }
            set { _MONTANTFACTUREINITIALTTCPLUSAIRSI = value; }
        }



        //public string TYPEOPERATION
        //{
        //    get { return _TYPEOPERATION; }
        //    set { _TYPEOPERATION = value; }
        //}

        public string MS_DATERENDEZVOUS
		{
            get { return _MS_DATERENDEZVOUS; }
            set { _MS_DATERENDEZVOUS = value; }
		}
        public string MONTANTTVA
		{
            get { return _MONTANTTVA; }
            set { _MONTANTTVA = value; }
		}

        public string MONTANTAIRSI
        {
            get { return _MONTANTAIRSI; }
            set { _MONTANTAIRSI = value; }
        }
        public string MONTANTTRANSPORT
        {
            get { return _MONTANTTRANSPORT; }
            set { _MONTANTTRANSPORT = value; }
        }

        public string MONTANTFACTUREINITIALAVECREMISE
        {
            get { return _MONTANTFACTUREINITIALAVECREMISE; }
            set { _MONTANTFACTUREINITIALAVECREMISE = value; }
        }


        public string FB_IDFOURNISSEUR
        {
            get { return _FB_IDFOURNISSEUR; }
            set { _FB_IDFOURNISSEUR = value; }
        }
        public string MS_MONTANTFOURNISSEURBON
        {
            get { return _MS_MONTANTFOURNISSEURBON; }
            set { _MS_MONTANTFOURNISSEURBON = value; }
        }

        public string MS_NUMBON
        {
            get { return _MS_NUMBON; }
            set { _MS_NUMBON = value; }
        }

        public string MS_DATEDEBUTFABRICATION
        {
            get { return _MS_DATEDEBUTFABRICATION; }
            set { _MS_DATEDEBUTFABRICATION = value; }
        }
        public string MS_HEUREDEBUTFABRICATION
        {
            get { return _MS_HEUREDEBUTFABRICATION; }
            set { _MS_HEUREDEBUTFABRICATION = value; }
        }
        public string MS_DATEFINFABRICATION
        {
            get { return _MS_DATEFINFABRICATION; }
            set { _MS_DATEFINFABRICATION = value; }
        }
        public string MS_HEUREFINFABRICATION
        {
            get { return _MS_HEUREFINFABRICATION; }
            set { _MS_HEUREFINFABRICATION = value; }
        }


        public string MS_DATEDEPART
        {
            get { return _MS_DATEDEPART; }
            set { _MS_DATEDEPART = value; }
        }
        public string MS_HEUREDEBUT
        {
            get { return _MS_HEUREDEBUT; }
            set { _MS_HEUREDEBUT = value; }
        }
        public string MS_HEUREFIN
        {
            get { return _MS_HEUREFIN; }
            set { _MS_HEUREFIN = value; }
        }

        public string EM_CODEEMBALLAGE
        {
            get { return _EM_CODEEMBALLAGE; }
            set { _EM_CODEEMBALLAGE = value; }
        }

        public string MS_TAUXHUMIDITE
        {
            get { return _MS_TAUXHUMIDITE; }
            set { _MS_TAUXHUMIDITE = value; }
        }

        public string MS_REMARQUE
        {
            get { return _MS_REMARQUE; }
            set { _MS_REMARQUE = value; }
        }

        public string TR_IDTRANSPORTEUR
        {
            get { return _TR_IDTRANSPORTEUR; }
            set { _TR_IDTRANSPORTEUR = value; }
        }

        public string CH_IDCHAUFFEUR
        {
            get { return _CH_IDCHAUFFEUR; }
            set { _CH_IDCHAUFFEUR = value; }
        }
        public string SC_CODESECTION
        {
            get { return _SC_CODESECTION; }
            set { _SC_CODESECTION = value; }
        }
        public string VH_CODEVEHICULE
        {
            get { return _VH_CODEVEHICULE; }
            set { _VH_CODEVEHICULE = value; }
        }
        public string RM_CODEREMORQUE
        {
            get { return _RM_CODEREMORQUE; }
            set { _RM_CODEREMORQUE= value; }
        }

        public string MV_NOMTIERS
        {
            get { return _MV_NOMTIERS; }
            set { _MV_NOMTIERS = value; }
        }

        public string CA_CODECAMPAGNE
        {
            get { return _CA_CODECAMPAGNE; }
            set { _CA_CODECAMPAGNE = value; }
        }

        public string CO_CODECONSULTATION
        {
            get { return _CO_CODECONSULTATION; }
            set { _CO_CODECONSULTATION = value; }
        }

        public string COCHER
        {
            get { return _COCHER; }
            set { _COCHER = value; }
        }
        public string MS_VOSREFERENCES
        {
            get { return _MS_VOSREFERENCES; }
            set { _MS_VOSREFERENCES = value; }
        }

        public string MS_NUMPIECECALCULAVOIR
        {
            get { return _MS_NUMPIECECALCULAVOIR; }
            set { _MS_NUMPIECECALCULAVOIR = value; }
        }
        public string MS_CONDITIONDEREGLEMENT
        {
            get { return _MS_CONDITIONDEREGLEMENT; }
            set { _MS_CONDITIONDEREGLEMENT = value; }
        }
        public string TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }
        public string TP_CODETYPETIERS
        {
            get { return _TP_CODETYPETIERS; }
            set { _TP_CODETYPETIERS = value; }
        }
        public string NT_CODENATURETYPEARTICLE
        {
            get { return _NT_CODENATURETYPEARTICLE; }
            set { _NT_CODENATURETYPEARTICLE = value; }
        }
        public string CO_NUMCOMMERCIAL
        {
            get { return _CO_NUMCOMMERCIAL; }
            set { _CO_NUMCOMMERCIAL = value; }
        }
        public string CO_NOMPRENOM
        {
            get { return _CO_NOMPRENOM; }
            set { _CO_NOMPRENOM = value; }
        }
        public string NT_CODENATURETIERS
        {
            get { return _NT_CODENATURETIERS; }
            set { _NT_CODENATURETIERS = value; }
        }
        public string AR_CODEARTICLE1
        {
            get { return _AR_CODEARTICLE1; }
            set { _AR_CODEARTICLE1 = value; }
        }
        public string GP_CODEGROUPE
        {
            get { return _GP_CODEGROUPE; }
            set { _GP_CODEGROUPE = value; }
        }
        public string TYPELISTE
        {
            get { return _TYPELISTE; }
            set { _TYPELISTE = value; }
        }
        public string MS_DATECLOTURE
        {
            get { return _MS_DATECLOTURE; }
            set { _MS_DATECLOTURE = value; }
        }

        public string TI_TELEPHONE
        {
            get { return _TI_TELEPHONE; }
            set { _TI_TELEPHONE = value; }
        }
        public string TI_ADRESSEGEOGRAPHIQUE
        {
            get { return _TI_ADRESSEGEOGRAPHIQUE; }
            set { _TI_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string MS_MONTANTVERSE1
        {
            get { return _MS_MONTANTVERSE1; }
            set { _MS_MONTANTVERSE1 = value; }
        }
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }
        public string TI_PLAFONDCREDIT
        {
            get { return _TI_PLAFONDCREDIT; }
            set { _TI_PLAFONDCREDIT = value; }
        }
        public string TI_ASDI
        {
            get { return _TI_ASDI; }
            set { _TI_ASDI = value; }
        }
        public string TI_TVA
        {
            get { return _TI_TVA; }
            set { _TI_TVA = value; }
        }
        public string MS_NUMERIMMATRICULATION
        {
            get { return _MS_NUMERIMMATRICULATION; }
            set { _MS_NUMERIMMATRICULATION = value; }
        }
        public string MS_RESTAMONTANTVERSE
        {
            get { return _MS_RESTAMONTANTVERSE; }
            set { _MS_RESTAMONTANTVERSE = value; }
        }
        public string MS_TAUXASSURANCE
        {
            get { return _MS_TAUXASSURANCE; }
            set { _MS_TAUXASSURANCE = value; }
        }
        public string MS_MONTANTASSURANCE
        {
            get { return _MS_MONTANTASSURANCE; }
            set { _MS_MONTANTASSURANCE = value; }
        }
        public string SR_MONTANTCREDIT
        {
            get { return _SR_MONTANTCREDIT; }
            set { _SR_MONTANTCREDIT = value; }
        }
        public string NUMEROBORDEREAU
        {
            get { return _NUMEROBORDEREAU; }
            set { _NUMEROBORDEREAU = value; }
        }
        public string MONTANTTTCPLUSAIRSI
        {
            get { return _MONTANTTTCPLUSAIRSI; }
            set { _MONTANTTTCPLUSAIRSI = value; }
        }
        public string CA_CODECONTRAT
        {
            get { return _CA_CODECONTRAT; }
            set { _CA_CODECONTRAT = value; }
        }



        //public string MS_MONTANTTVA
        //{
        //    get { return _MS_MONTANTTVA; }
        //    set { _MS_MONTANTTVA = value; }
        //}

        //public string MS_MONTANTASDI
        //{
        //    get { return _MS_MONTANTASDI; }
        //    set { _MS_MONTANTASDI = value; }
        //}
        public clsPhamouvementStock() {}

       

		public clsPhamouvementStock(clsPhamouvementStock clsPhamouvementStock)
		{
			AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsPhamouvementStock.EN_CODEENTREPOT;
			MS_NUMPIECE = clsPhamouvementStock.MS_NUMPIECE;
            MS_NUMPIECE1 = clsPhamouvementStock.MS_NUMPIECE1;
			MK_NUMPIECE = clsPhamouvementStock.MK_NUMPIECE;
			
			MS_DATEPIECE = clsPhamouvementStock.MS_DATEPIECE;
			MS_NUMSEQUENCE = clsPhamouvementStock.MS_NUMSEQUENCE;
			FR_CODEFOURNISSEUR = clsPhamouvementStock.FR_CODEFOURNISSEUR;
            FR_MATRICULE = clsPhamouvementStock.FR_MATRICULE;
            TI_IDTIERS = clsPhamouvementStock.TI_IDTIERS;
            TI_NUMTIERS = clsPhamouvementStock.TI_NUMTIERS;
			CL_IDCLIENT = clsPhamouvementStock.CL_IDCLIENT;
            CL_NUMCLIENT = clsPhamouvementStock.CL_NUMCLIENT;
			CO_IDCOMMERCIAL = clsPhamouvementStock.CO_IDCOMMERCIAL;
			MS_REFPIECE = clsPhamouvementStock.MS_REFPIECE;
			MS_LIBOPERA = clsPhamouvementStock.MS_LIBOPERA;
			NO_CODENATUREOPERATION = clsPhamouvementStock.NO_CODENATUREOPERATION;
			MS_TAUXREMISE = clsPhamouvementStock.MS_TAUXREMISE;
			MS_MONTANTTOTALREMISE = clsPhamouvementStock.MS_MONTANTTOTALREMISE;
			MS_MONTANTTRANSPORT = clsPhamouvementStock.MS_MONTANTTRANSPORT;
			MS_DELAILIVRAISON = clsPhamouvementStock.MS_DELAILIVRAISON;
			MS_DATELIVRAISON = clsPhamouvementStock.MS_DATELIVRAISON;
			MS_ANNULATIONPIECE = clsPhamouvementStock.MS_ANNULATIONPIECE;
			OP_CODEOPERATEUR = clsPhamouvementStock.OP_CODEOPERATEUR;
			MS_DATESAISIE = clsPhamouvementStock.MS_DATESAISIE;
			MS_MONTANTECHEANCE = clsPhamouvementStock.MS_MONTANTECHEANCE;
			MS_DUREEPRET = clsPhamouvementStock.MS_DUREEPRET;
			MS_DATEDEBUTREGLEMENT = clsPhamouvementStock.MS_DATEDEBUTREGLEMENT;
			MS_DUREEVALIDITE = clsPhamouvementStock.MS_DUREEVALIDITE;
			MS_CONDITIONREGLEMENT = clsPhamouvementStock.MS_CONDITIONREGLEMENT;
			MS_SITUATIONFACTURE = clsPhamouvementStock.MS_SITUATIONFACTURE;
            MS_NUMFACTURE = clsPhamouvementStock.MS_NUMFACTURE ;
            MS_DATEFACTURE = clsPhamouvementStock.MS_DATEFACTURE ;
            CA_DATESAISIE = clsPhamouvementStock.CA_DATESAISIE;           
            MS_TAUXTVA = clsPhamouvementStock.MS_TAUXTVA;
            MS_TAUXASDI  = clsPhamouvementStock.MS_TAUXASDI;

            SOLDE = clsPhamouvementStock.SOLDE;
            MONTANTFACTUREINITIAL = clsPhamouvementStock.MONTANTFACTUREINITIAL;
            MONTANTFACTUREINITIALAVECREMISE = clsPhamouvementStock.MONTANTFACTUREINITIALAVECREMISE;
            MONTANTFACTUREINITIALTTCPLUSAIRSI = clsPhamouvementStock._MONTANTFACTUREINITIALTTCPLUSAIRSI;
            MS_DATERENDEZVOUS = clsPhamouvementStock.MS_DATERENDEZVOUS;


            FB_IDFOURNISSEUR = clsPhamouvementStock.FB_IDFOURNISSEUR;
            MS_MONTANTFOURNISSEURBON = clsPhamouvementStock.MS_MONTANTFOURNISSEURBON;
            MS_NUMBON = clsPhamouvementStock.MS_NUMBON;
            MS_DATEDEBUTFABRICATION = clsPhamouvementStock.MS_DATEDEBUTFABRICATION;
            MS_HEUREDEBUTFABRICATION = clsPhamouvementStock.MS_HEUREDEBUTFABRICATION;
            MS_DATEFINFABRICATION = clsPhamouvementStock.MS_DATEFINFABRICATION;
            MS_HEUREFINFABRICATION = clsPhamouvementStock.MS_HEUREFINFABRICATION;

            MS_DATEDEPART = clsPhamouvementStock.MS_DATEDEPART;
            MS_HEUREDEBUT = clsPhamouvementStock.MS_HEUREDEBUT;
            MS_HEUREFIN = clsPhamouvementStock.MS_HEUREFIN;
            EM_CODEEMBALLAGE = clsPhamouvementStock.EM_CODEEMBALLAGE;
            MS_TAUXHUMIDITE = clsPhamouvementStock.MS_TAUXHUMIDITE;
            MS_REMARQUE = clsPhamouvementStock.MS_REMARQUE;

            TR_IDTRANSPORTEUR = clsPhamouvementStock.TR_IDTRANSPORTEUR;
            CH_IDCHAUFFEUR = clsPhamouvementStock.CH_IDCHAUFFEUR;
            SC_CODESECTION = clsPhamouvementStock.SC_CODESECTION;
            VH_CODEVEHICULE = clsPhamouvementStock.VH_CODEVEHICULE;
            RM_CODEREMORQUE= clsPhamouvementStock.RM_CODEREMORQUE;
            MV_NOMTIERS = clsPhamouvementStock.MV_NOMTIERS;

            TI_IDTIERSNEW = clsPhamouvementStock.TI_IDTIERSNEW;
            TI_NUMTIERSNEW = clsPhamouvementStock.TI_NUMTIERSNEW;
            TI_DENOMINATIONNEW = clsPhamouvementStock.TI_DENOMINATIONNEW;
            TI_TELEPHONENEW = clsPhamouvementStock.TI_TELEPHONENEW;
            TI_ADRESSEGEOGRAPHIQUENEW = clsPhamouvementStock.TI_ADRESSEGEOGRAPHIQUENEW;
            CA_CODECAMPAGNE = clsPhamouvementStock.CA_CODECAMPAGNE;

            MS_MONTANTTIMBRE = clsPhamouvementStock.MS_MONTANTTIMBRE;
            CO_CODECONSULTATION = clsPhamouvementStock.CO_CODECONSULTATION;
            COCHER = clsPhamouvementStock.COCHER;
            MS_VOSREFERENCES = clsPhamouvementStock.MS_VOSREFERENCES;
            MS_NUMPIECECALCULAVOIR = clsPhamouvementStock.MS_NUMPIECECALCULAVOIR;
            MS_CONDITIONDEREGLEMENT = clsPhamouvementStock.MS_CONDITIONDEREGLEMENT;
            TI_DENOMINATION = clsPhamouvementStock.TI_DENOMINATION;
            TP_CODETYPETIERS = clsPhamouvementStock.TP_CODETYPETIERS;
            NT_CODENATURETYPEARTICLE = clsPhamouvementStock.NT_CODENATURETYPEARTICLE;
            CO_NUMCOMMERCIAL = clsPhamouvementStock.CO_NUMCOMMERCIAL;
            CO_NOMPRENOM = clsPhamouvementStock.CO_NOMPRENOM;
            NT_CODENATURETIERS = clsPhamouvementStock.NT_CODENATURETIERS;
            AR_CODEARTICLE1 = clsPhamouvementStock.AR_CODEARTICLE1;
            GP_CODEGROUPE = clsPhamouvementStock.GP_CODEGROUPE;
            TYPELISTE = clsPhamouvementStock.TYPELISTE;
            MS_DATECLOTURE = clsPhamouvementStock.MS_DATECLOTURE;
            TI_TELEPHONE = clsPhamouvementStock.TI_TELEPHONE;
            TI_ADRESSEGEOGRAPHIQUE = clsPhamouvementStock.TI_ADRESSEGEOGRAPHIQUE;
            MS_MONTANTVERSE1 = clsPhamouvementStock.MS_MONTANTVERSE1;
            PL_NUMCOMPTE = clsPhamouvementStock.PL_NUMCOMPTE;
            TI_PLAFONDCREDIT = clsPhamouvementStock.TI_PLAFONDCREDIT;
            TI_ASDI = clsPhamouvementStock.TI_ASDI;
            TI_TVA = clsPhamouvementStock.TI_TVA;
            MS_NUMERIMMATRICULATION = clsPhamouvementStock.MS_NUMERIMMATRICULATION;
            MS_RESTAMONTANTVERSE = clsPhamouvementStock.MS_RESTAMONTANTVERSE;
            MS_TAUXASSURANCE = clsPhamouvementStock.MS_TAUXASSURANCE;
            MS_MONTANTASSURANCE = clsPhamouvementStock.MS_MONTANTASSURANCE;
            SR_MONTANTCREDIT = clsPhamouvementStock.SR_MONTANTCREDIT;
            NUMEROBORDEREAU = clsPhamouvementStock.NUMEROBORDEREAU;
            MONTANTTTCPLUSAIRSI = clsPhamouvementStock.MONTANTTTCPLUSAIRSI;
            CA_CODECONTRAT = clsPhamouvementStock.CA_CODECONTRAT;

		}

        }
}