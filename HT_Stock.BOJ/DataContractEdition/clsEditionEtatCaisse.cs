using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEditionEtatCaisse : clsEntitieBase
    {


    //    @AG_CODEAGENCE varchar(7000),	
    //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
    //@DATEDEBUT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _TP_CODETYPETIERS = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _OP_CODEOPERATEUR = "";
        private string _DATEDEBUT = "";
        private string _DATEFIN = "";
        private string _MR_CODEMODEREGLEMENT= "";
        private string _NO_CODENATUREOPERATION = "";
        private string _PL_NUMCOMPTE1 = "";
        private string _PL_NUMCOMPTE2 = "";
        private string _PL_NUMCOMPTETIERS = "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";
        private string _PL_OPTION = "";
        private string _JO_CODEJOURNAL = "";
        private string _MV_STATUTGLVRE = "";
        private string _GP_CODEGROUPE = "";
        private string _PY_CODEPAYS = "";
        private string _NT_CODENATURETIERS = "";
        private string _TI_IDTIERSMEDECIN = "";


        private string _AG_RAISONSOCIAL = "";
        private string _MV_NUMPIECE = "";
        private string _NO_CODENATUREOPERATION1 = "";
        private string _MS_NUMPIECE = "";
        private double _MV_MONTANTDEBIT = 0;
        private double _MV_MONTANTCREDIT = 0;
        private string _MV_DATEPIECE = "01/01/1900";

        private string _MV_ANNULATIONPIECE = "";
        private string _MV_REFERENCEPIECE = "";
        private string _MV_LIBELLEOPERATION = "";
        private string _MV_NOMTIERS = "";
        private string _NUMEROBORDEREAU = "";
        private double _MV_SOLDEPRECEDENT = 0;
        private string _MV_NUMSEQUENCE = "";
        private double _MV_SOLDE = 0;
        private string _NUMEROBORDEREAU1 = "";
        private double _MV_SOLDEFINAL = 0;
        private string _MS_NUMSEQUENCE = "";
        private string _PL_CODENUMCOMPTE = "";
        private double _MC_SOLDEPRECEDENT = 0;
        private string _TI_NUMTIERS = "";
        private string _TI_DENOMINATION = "";
        private string _OP_NOMPRENOM = "";
        private string _MR_LIBELLE = "";
        private double _TOTALCAISSE = 0;
        private double _TOTALBANQUE = 0;



        //private string _AG_CODEAGENCE = "";
        //private string _AG_RAISONSOCIAL = "";
        private string _AG_BOITEPOSTAL = "";
        private string _AG_TELEPHONE = "";
        //private string _EN_CODEENTREPOT = "";
        private string _EN_NUMENTREPOT = "";
        private string _EN_DENOMINATION = "";
        private string _PL_LIBELLE = "";
        //private string _MV_DATEPIECE = "";
        //private string _MV_NUMPIECE = "";
        private string _MV_NUMEROPIECE = "";
        //private string _MS_NUMPIECE = "";
        private string _MS_REFPIECE = "";
        //private string _MS_NUMSEQUENCE = "";
        private string _MS_DATEPIECE = "";
        //private string _JO_CODEJOURNAL = "";
        private string _JO_JOURNALCODE = "";
        private string _PL_NUMCOMPTE = "";
        //private string _MV_REFERENCEPIECE = "";
        //private string _MV_LIBELLEOPERATION = "";
        //private string _MV_NOMTIERS = "";
        //private string _MV_MONTANTDEBIT = "";
        //private string _MV_MONTANTCREDIT = "";
        //private string _OP_CODEOPERATEUR = "";
        private double _MC_SOLDE = 0;
        private string _JO_LIBELLE = "";
        //private string _MV_NUMSEQUENCE = "";
        //private string _MC_SOLDEPRECEDENT = "";
        private string _CO_CODECOMPTE = "";
        private string _CO_NUMEROSEQUENCE = "";
        private string _CL_CODECLIENT = "";
        private string _TI_IDTIERS = "";
        //private string _TI_NUMTIERS = "";
        //private string _TI_DENOMINATION = "";
        private string _PS_ABREVIATION = "";
        //private string _NUMEROBORDEREAU = "";
        private string _OP_LOGIN = "";
        //private string _NO_CODENATUREOPERATION = "";
        //private string _NO_CODENATUREOPERATION1 = "";
        //private string _PL_CODENUMCOMPTE = "";
        //private string _MV_SOLDE MONEY ="";
		private string _COCHER = "";
        private string _LT_CODELETTRAGE = "";
        private string _LT_LIBELLELETTRAGE = "";




        //private string _AG_CODEAGENCE = "";
        //private string _AG_RAISONSOCIAL = "";
        //private string _EN_CODEENTREPOT = "";
        //private string _EN_NUMENTREPOT = "";
        //private string _EN_DENOMINATION = "";
        private string _NC_CODENATURECOMPTE = "";
        private string _PL_COMPTECOLLECTIF = "";
        //private string _TI_IDTIERS = "";
        //private string _TI_NUMTIERS = "";
        //private string _TI_DENOMINATION = "";
        //private string _MV_DATEPIECE = "";
        //private string _PL_CODENUMCOMPTE = "";
        //private string _PL_NUMCOMPTE = "";
        //private string _PL_LIBELLE = "";
        private string _PL_TYPECOMPTE = "";
        //private string _MV_LIBELLEOPERATION = "";
        private double _PL_MONTANTPERIODEPRECEDENTDEBIT = 0;
        private double _PL_MONTANTPERIODEPRECEDENTCREDIT = 0;
        private double _PL_MONTANTPERIODEDEBITENCOURS = 0;
        private double _PL_MONTANTPERIODECREDITENCOURS = 0;
        private double _PL_MONTANTSOLDEFINALDEBIT = 0;
        private double _PL_MONTANTSOLDEFINALCREDIT = 0;
        private double _PL_MONTANTPERIODEPRECEDENTDEBITTOTAL = 0;
        private double _PL_MONTANTPERIODEPRECEDENTCREDITTOTAL = 0;
        private double _PL_MONTANTPERIODEDEBITENCOURSTOTAL = 0;
        private double _PL_MONTANTPERIODECREDITENCOURSTOTAL = 0;
        private double _PL_MONTANTSOLDEFINALDEBITTOTAL = 0;
        private double _PL_MONTANTSOLDEFINALCREDITTOTAL = 0;
        private double _PL_MONTANTPERIODEPRECEDENTCREDITGESTION = 0;
        private double _PL_MONTANTPERIODEDEBITENCOURSGESTION = 0;
        private double _PL_MONTANTPERIODECREDITENCOURSGESTION = 0;
        private double _PL_MONTANTSOLDEFINALDEBITGESTION = 0;
        private double _PL_MONTANTSOLDEFINALCREDITGESTION = 0;
        private double _PL_MONTANTPERIODEPRECEDENTDEBITBILAN = 0;
        private double _PL_MONTANTPERIODEPRECEDENTCREDITBILAN = 0;
        private double _PL_MONTANTPERIODEDEBITENCOURSBILAN = 0;
        private double _PL_MONTANTPERIODECREDITENCOURSBILAN = 0;
        private double _PL_MONTANTSOLDEFINALDEBITBILAN = 0;
        private double _PL_MONTANTSOLDEFINALCREDITBILAN = 0;
        private double _PL_TOTALCHARGEFINPERIODE = 0;
        private double _PL_TOTALPRODUITFINPERIODE = 0;
        private double _PL_RESULTATNETPROVISOIRE = 0;
        private double _PL_TOTALCOMPTEGESTION = 0;
        private double _PL_TOTALCOMPTEBILAN = 0;
        private double _PL_MONTANTPERIODEPRECEDENTDEBITGESTION = 0;
        private string _COMPTAPAR_SENS_CODE = "";



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

        public string TP_CODETYPETIERS
        {
            get { return _TP_CODETYPETIERS; }
            set { _TP_CODETYPETIERS = value; }
        }

		public string OP_CODEOPERATEUREDITION
		{
			get { return _OP_CODEOPERATEUREDITION; }
			set { _OP_CODEOPERATEUREDITION = value; }
		}

        public string OP_CODEOPERATEUR
		{
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
		}
  //      public string DATEDEBUT
		//{
  //          get { return _DATEDEBUT; }
  //          set { _DATEDEBUT = value; }
		//}
  //      public string DATEFIN
		//{
  //          get { return _DATEFIN; }
  //          set { _DATEFIN = value; }
		//}
        public string MR_CODEMODEREGLEMENT
		{
            get { return _MR_CODEMODEREGLEMENT; }
            set { _MR_CODEMODEREGLEMENT = value; }
		}
        public string NO_CODENATUREOPERATION
		{
            get { return _NO_CODENATUREOPERATION; }
            set { _NO_CODENATUREOPERATION = value; }
		}
        public string PL_NUMCOMPTE1
		{
            get { return _PL_NUMCOMPTE1; }
            set { _PL_NUMCOMPTE1 = value; }
		}
        public string PL_NUMCOMPTE2
		{
            get { return _PL_NUMCOMPTE2; }
            set { _PL_NUMCOMPTE2= value; }
		}

        public string PL_NUMCOMPTETIERS
        {
            get { return _PL_NUMCOMPTETIERS; }
            set { _PL_NUMCOMPTETIERS = value; }
        }
        public string ET_TYPEETAT
		{
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
		}
        public string ET_TYPERETOURS
		{
            get { return _ET_TYPERETOURS; }
            set { _ET_TYPERETOURS = value; }
		}

        public string PL_OPTION
        {
            get { return _PL_OPTION; }
            set { _PL_OPTION = value; }
        }

        public string JO_CODEJOURNAL
        {
            get { return _JO_CODEJOURNAL; }
            set { _JO_CODEJOURNAL = value; }
        }

        public string MV_STATUTGLVRE
        {
            get { return _MV_STATUTGLVRE; }
            set { _MV_STATUTGLVRE = value; }
        }


        public string GP_CODEGROUPE
        {
            get { return _GP_CODEGROUPE; }
            set { _GP_CODEGROUPE = value; }
        }

        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
        public string NT_CODENATURETIERS
        {
            get { return _NT_CODENATURETIERS; }
            set { _NT_CODENATURETIERS = value; }
        }
        public string TI_IDTIERSMEDECIN
        {
            get { return _TI_IDTIERSMEDECIN; }
            set { _TI_IDTIERSMEDECIN = value; }
        }

        public string AG_RAISONSOCIAL
        {
            get { return _TI_IDTIERSMEDECIN; }
            set { _TI_IDTIERSMEDECIN = value; }
        }

        public string MV_NUMPIECE
        {
            get { return _MV_NUMPIECE; }
            set { _MV_NUMPIECE = value; }
        }
        public string NO_CODENATUREOPERATION1
        {
            get { return _NO_CODENATUREOPERATION1; }
            set { _NO_CODENATUREOPERATION1 = value; }
        }
        public string MS_NUMPIECE
        {
            get { return _MS_NUMPIECE; }
            set { _MS_NUMPIECE = value; }
        }
        public double MV_MONTANTDEBIT
        {
            get { return _MV_MONTANTDEBIT; }
            set { _MV_MONTANTDEBIT = value; }
        }
        public double MV_MONTANTCREDIT
        {
            get { return _MV_MONTANTCREDIT; }
            set { _MV_MONTANTCREDIT = value; }
        }

        public string MV_DATEPIECE
        {
            get { return _MV_DATEPIECE; }
            set { _MV_DATEPIECE = value; }
        }
        public string MV_ANNULATIONPIECE
        {
            get { return _MV_ANNULATIONPIECE; }
            set { _MV_ANNULATIONPIECE = value; }
        }
        public string MV_REFERENCEPIECE
        {
            get { return _MV_REFERENCEPIECE; }
            set { _MV_REFERENCEPIECE = value; }
        }
        public string MV_LIBELLEOPERATION
        {
            get { return _MV_LIBELLEOPERATION; }
            set { _MV_LIBELLEOPERATION= value; }
        }
        public string MV_NOMTIERS
        {
            get { return _MV_NOMTIERS; }
            set { _MV_NOMTIERS = value; }
        }
        public string NUMEROBORDEREAU
        {
            get { return _NUMEROBORDEREAU; }
            set { _NUMEROBORDEREAU = value; }
        }
        public double MV_SOLDEPRECEDENT
        {
            get { return _MV_SOLDEPRECEDENT; }
            set { _MV_SOLDEPRECEDENT = value; }
        }
        public String MV_NUMSEQUENCE
        {
            get { return _MV_NUMSEQUENCE; }
            set { _MV_NUMSEQUENCE = value; }
        }

        public double MV_SOLDE
        {
            get { return _MV_SOLDE; }
            set { _MV_SOLDE = value; }
        }


        public string NUMEROBORDEREAU1
        {
            get { return _NUMEROBORDEREAU1; }
            set { _NUMEROBORDEREAU1 = value; }
        }



        public double MV_SOLDEFINAL
        {
            get { return _MV_SOLDEFINAL; }
            set { _MV_SOLDEFINAL = value; }
        }

       

        public string MS_NUMSEQUENCE
        {
            get { return _MS_NUMSEQUENCE; }
            set { _MS_NUMSEQUENCE = value; }
        }

        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }

        public double MC_SOLDEPRECEDENT
        {
            get { return _MC_SOLDEPRECEDENT; }
            set { _MC_SOLDEPRECEDENT = value; }
        }

        public string TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }

        public string TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }

        public string OP_NOMPRENOM
        {
            get { return _OP_NOMPRENOM; }
            set { _OP_NOMPRENOM = value; }
        }

        public string MR_LIBELLE
        {
            get { return _MR_LIBELLE; }
            set { _MR_LIBELLE = value; }
        }

        public double TOTALCAISSE
        {
            get { return _TOTALCAISSE; }
            set { _TOTALCAISSE = value; }
        }

        public double TOTALBANQUE
        {
            get { return _TOTALBANQUE; }
            set { _TOTALBANQUE = value; }
        }


        public string AG_BOITEPOSTAL
        {
            get { return _AG_BOITEPOSTAL; }
            set { _AG_BOITEPOSTAL = value; }
        }

        public string AG_TELEPHONE
        {
            get { return _AG_TELEPHONE; }
            set { _AG_TELEPHONE = value; }
        }

        public string EN_NUMENTREPOT
        {
            get { return _EN_NUMENTREPOT; }
            set { _EN_NUMENTREPOT = value; }
        }

        public string EN_DENOMINATION
        {
            get { return _EN_DENOMINATION; }
            set { _EN_DENOMINATION = value; }
        }


        public string PL_LIBELLE
        {
            get { return _PL_LIBELLE; }
            set { _PL_LIBELLE = value; }
        }

        public string MV_NUMEROPIECE
        {
            get { return _MV_NUMEROPIECE; }
            set { _MV_NUMEROPIECE = value; }
        }

        public string MS_REFPIECE
        {
            get { return _MS_REFPIECE; }
            set { _MS_REFPIECE = value; }
        }

        public string MS_DATEPIECE
        {
            get { return _MS_DATEPIECE; }
            set { _MS_DATEPIECE = value; }
        }

        public string JO_JOURNALCODE
        {
            get { return _JO_JOURNALCODE; }
            set { _JO_JOURNALCODE = value; }
        }

        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }

        public double MC_SOLDE
        {
            get { return _MC_SOLDE; }
            set { _MC_SOLDE = value; }
        }

        public string JO_LIBELLE
        {
            get { return _JO_LIBELLE; }
            set { _JO_LIBELLE = value; }
        }

        public string CO_CODECOMPTE
        {
            get { return _CO_CODECOMPTE; }
            set { _CO_CODECOMPTE = value; }
        }

        public string CO_NUMEROSEQUENCE
        {
            get { return _CO_NUMEROSEQUENCE; }
            set { _CO_NUMEROSEQUENCE = value; }
        }

        public string CL_CODECLIENT
        {
            get { return _CL_CODECLIENT; }
            set { _CL_CODECLIENT = value; }
        }

        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }

        public string PS_ABREVIATION
        {
            get { return _PS_ABREVIATION; }
            set { _PS_ABREVIATION = value; }
        }

        //public string OP_LOGIN
        //{
        //    get { return _OP_LOGIN; }
        //    set { _OP_LOGIN = value; }
        //}        
        
        public string COCHER
        {
            get { return _COCHER; }
            set { _COCHER = value; }
        }

        public string LT_CODELETTRAGE
        {
            get { return _LT_CODELETTRAGE; }
            set { _LT_CODELETTRAGE = value; }
        }

        public string LT_LIBELLELETTRAGE
        {
            get { return _LT_LIBELLELETTRAGE; }
            set { _LT_LIBELLELETTRAGE = value; }
        }





        public string NC_CODENATURECOMPTE
        {
            get { return _NC_CODENATURECOMPTE; }
            set { _NC_CODENATURECOMPTE = value; }
        }
        public string PL_TYPECOMPTE
        {
            get { return _PL_TYPECOMPTE; }
            set { _PL_TYPECOMPTE = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTDEBIT
        {
            get { return _PL_MONTANTPERIODEPRECEDENTDEBIT; }
            set { _PL_MONTANTPERIODEPRECEDENTDEBIT = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTCREDIT
        {
            get { return _PL_MONTANTPERIODEPRECEDENTCREDIT; }
            set { _PL_MONTANTPERIODEPRECEDENTCREDIT = value; }
        }

        public double PL_MONTANTPERIODEDEBITENCOURS
        {
            get { return _PL_MONTANTPERIODEDEBITENCOURS; }
            set { _PL_MONTANTPERIODEDEBITENCOURS = value; }
        }
        public double PL_MONTANTPERIODECREDITENCOURS
        {
            get { return _PL_MONTANTPERIODECREDITENCOURS; }
            set { _PL_MONTANTPERIODECREDITENCOURS = value; }
        }
        public double PL_MONTANTSOLDEFINALDEBIT
        {
            get { return _PL_MONTANTSOLDEFINALDEBIT; }
            set { _PL_MONTANTSOLDEFINALDEBIT = value; }
        }
        public double PL_MONTANTSOLDEFINALCREDIT
        {
            get { return _PL_MONTANTSOLDEFINALCREDIT; }
            set { _PL_MONTANTSOLDEFINALCREDIT = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTDEBITTOTAL
        {
            get { return _PL_MONTANTPERIODEPRECEDENTDEBITTOTAL; }
            set { _PL_MONTANTPERIODEPRECEDENTDEBITTOTAL = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTCREDITTOTAL
        {
            get { return _PL_MONTANTPERIODEPRECEDENTCREDITTOTAL; }
            set { _PL_MONTANTPERIODEPRECEDENTCREDITTOTAL = value; }
        }
        public double PL_MONTANTPERIODEDEBITENCOURSTOTAL
        {
            get { return _PL_MONTANTPERIODEDEBITENCOURSTOTAL; }
            set { _PL_MONTANTPERIODEDEBITENCOURSTOTAL = value; }
        }
        public double PL_MONTANTPERIODECREDITENCOURSTOTAL
        {
            get { return _PL_MONTANTPERIODECREDITENCOURSTOTAL; }
            set { _PL_MONTANTPERIODECREDITENCOURSTOTAL = value; }
        }
        public double PL_MONTANTSOLDEFINALDEBITTOTAL
        {
            get { return _PL_MONTANTSOLDEFINALDEBITTOTAL; }
            set { _PL_MONTANTSOLDEFINALDEBITTOTAL = value; }
        }
        public double PL_MONTANTSOLDEFINALCREDITTOTAL
        {
            get { return _PL_MONTANTSOLDEFINALCREDITTOTAL; }
            set { _PL_MONTANTSOLDEFINALCREDITTOTAL = value; }
        }
        
        public double PL_MONTANTPERIODEPRECEDENTCREDITGESTION
        {
            get { return _PL_MONTANTPERIODEPRECEDENTCREDITGESTION; }
            set { _PL_MONTANTPERIODEPRECEDENTCREDITGESTION = value; }
        }
        public double PL_MONTANTPERIODEDEBITENCOURSGESTION
        {
            get { return _PL_MONTANTPERIODEDEBITENCOURSGESTION; }
            set { _PL_MONTANTPERIODEDEBITENCOURSGESTION = value; }
        }
        public double PL_MONTANTPERIODECREDITENCOURSGESTION
        {
            get { return _PL_MONTANTPERIODECREDITENCOURSGESTION; }
            set { _PL_MONTANTPERIODECREDITENCOURSGESTION = value; }
        }
        public double PL_MONTANTSOLDEFINALDEBITGESTION
        {
            get { return _PL_MONTANTSOLDEFINALDEBITGESTION; }
            set { _PL_MONTANTSOLDEFINALDEBITGESTION = value; }
        }
        public double PL_MONTANTSOLDEFINALCREDITGESTION
        {
            get { return _PL_MONTANTSOLDEFINALCREDITGESTION; }
            set { _PL_MONTANTSOLDEFINALCREDITGESTION = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTDEBITBILAN
        {
            get { return _PL_MONTANTPERIODEPRECEDENTDEBITBILAN; }
            set { _PL_MONTANTPERIODEPRECEDENTDEBITBILAN = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTCREDITBILAN
        {
            get { return _PL_MONTANTPERIODEPRECEDENTCREDITBILAN; }
            set { _PL_MONTANTPERIODEPRECEDENTCREDITBILAN = value; }
        }
        public double PL_MONTANTPERIODEDEBITENCOURSBILAN
        {
            get { return _PL_MONTANTPERIODEDEBITENCOURSBILAN; }
            set { _PL_MONTANTPERIODEDEBITENCOURSBILAN = value; }
        }
        public double PL_MONTANTPERIODECREDITENCOURSBILAN
        {
            get { return _PL_MONTANTPERIODECREDITENCOURSBILAN; }
            set { _PL_MONTANTPERIODECREDITENCOURSBILAN = value; }
        }
        public double PL_MONTANTSOLDEFINALDEBITBILAN
        {
            get { return _PL_MONTANTSOLDEFINALDEBITBILAN; }
            set { _PL_MONTANTSOLDEFINALDEBITBILAN = value; }
        }
        public double PL_MONTANTSOLDEFINALCREDITBILAN
        {
            get { return _PL_MONTANTSOLDEFINALCREDITBILAN; }
            set { _PL_MONTANTSOLDEFINALCREDITBILAN = value; }
        }
        public double PL_TOTALCHARGEFINPERIODE
        {
            get { return _PL_TOTALCHARGEFINPERIODE; }
            set { _PL_TOTALCHARGEFINPERIODE = value; }
        }
        public double PL_TOTALPRODUITFINPERIODE
        {
            get { return _PL_TOTALPRODUITFINPERIODE; }
            set { _PL_TOTALPRODUITFINPERIODE = value; }
        }

        public double PL_RESULTATNETPROVISOIRE
        {
            get { return _PL_RESULTATNETPROVISOIRE; }
            set { _PL_RESULTATNETPROVISOIRE = value; }
        }
        public double PL_TOTALCOMPTEGESTION
        {
            get { return _PL_TOTALCOMPTEGESTION; }
            set { _PL_TOTALCOMPTEGESTION = value; }
        }
        public double PL_TOTALCOMPTEBILAN
        {
            get { return _PL_TOTALCOMPTEBILAN; }
            set { _PL_TOTALCOMPTEBILAN = value; }
        }


        public string COMPTAPAR_SENS_CODE
        {
            get { return _COMPTAPAR_SENS_CODE; }
            set { _COMPTAPAR_SENS_CODE = value; }
        }

        public string PL_COMPTECOLLECTIF
        {
            get { return _PL_COMPTECOLLECTIF; }
            set { _PL_COMPTECOLLECTIF = value; }
        }


        public double PL_MONTANTPERIODEPRECEDENTDEBITGESTION
        {
            get { return _PL_MONTANTPERIODEPRECEDENTDEBITGESTION; }
            set { _PL_MONTANTPERIODEPRECEDENTDEBITGESTION = value; }
        }

        public clsEditionEtatCaisse() {} 

		

		public clsEditionEtatCaisse(clsEditionEtatCaisse clsEditionEtatCaisse)
		{
			AG_CODEAGENCE = clsEditionEtatCaisse.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatCaisse.EN_CODEENTREPOT;
            TP_CODETYPETIERS = clsEditionEtatCaisse.TP_CODETYPETIERS;
			OP_CODEOPERATEUREDITION = clsEditionEtatCaisse.OP_CODEOPERATEUREDITION;
            OP_CODEOPERATEUR = clsEditionEtatCaisse.OP_CODEOPERATEUR;

            DATEDEBUT = clsEditionEtatCaisse.DATEDEBUT;
            DATEFIN = clsEditionEtatCaisse.DATEFIN;

            MR_CODEMODEREGLEMENT = clsEditionEtatCaisse.MR_CODEMODEREGLEMENT;
            NO_CODENATUREOPERATION = clsEditionEtatCaisse.NO_CODENATUREOPERATION;
            PL_NUMCOMPTE1 = clsEditionEtatCaisse.PL_NUMCOMPTE1;
            PL_NUMCOMPTE2 = clsEditionEtatCaisse.PL_NUMCOMPTE2;
            PL_NUMCOMPTETIERS = clsEditionEtatCaisse.PL_NUMCOMPTETIERS;
            ET_TYPEETAT = clsEditionEtatCaisse.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatCaisse.ET_TYPERETOURS;
            PL_OPTION = clsEditionEtatCaisse.PL_OPTION;
            JO_CODEJOURNAL = clsEditionEtatCaisse.JO_CODEJOURNAL;
            MV_STATUTGLVRE = clsEditionEtatCaisse.MV_STATUTGLVRE;
            GP_CODEGROUPE = clsEditionEtatCaisse.GP_CODEGROUPE;
            PY_CODEPAYS = clsEditionEtatCaisse.PY_CODEPAYS;
            NT_CODENATURETIERS = clsEditionEtatCaisse.NT_CODENATURETIERS;
            TI_IDTIERSMEDECIN = clsEditionEtatCaisse.TI_IDTIERSMEDECIN;


            AG_RAISONSOCIAL = clsEditionEtatCaisse.AG_RAISONSOCIAL;
            MV_NUMPIECE = clsEditionEtatCaisse.MV_NUMPIECE;
            NO_CODENATUREOPERATION1 = clsEditionEtatCaisse.NO_CODENATUREOPERATION1;
            MS_NUMPIECE = clsEditionEtatCaisse.MS_NUMPIECE;
            MV_MONTANTDEBIT = clsEditionEtatCaisse.MV_MONTANTDEBIT;
            MV_MONTANTCREDIT = clsEditionEtatCaisse.MV_MONTANTCREDIT;
            MV_DATEPIECE = clsEditionEtatCaisse.MV_DATEPIECE;

            MV_ANNULATIONPIECE = clsEditionEtatCaisse.MV_ANNULATIONPIECE;
            MV_REFERENCEPIECE = clsEditionEtatCaisse.MV_REFERENCEPIECE;
            MV_LIBELLEOPERATION = clsEditionEtatCaisse.MV_LIBELLEOPERATION;
            MV_NOMTIERS = clsEditionEtatCaisse.MV_NOMTIERS;
            NUMEROBORDEREAU = clsEditionEtatCaisse.NUMEROBORDEREAU;
            MV_SOLDEPRECEDENT = clsEditionEtatCaisse.MV_SOLDEPRECEDENT;
            MV_NUMSEQUENCE = clsEditionEtatCaisse.MV_NUMSEQUENCE;
            MV_SOLDE = clsEditionEtatCaisse.MV_SOLDE;
            NUMEROBORDEREAU1 = clsEditionEtatCaisse.NUMEROBORDEREAU1;
            MV_SOLDEFINAL = clsEditionEtatCaisse.MV_SOLDEFINAL;
            MS_NUMSEQUENCE = clsEditionEtatCaisse.MS_NUMSEQUENCE;
            PL_CODENUMCOMPTE = clsEditionEtatCaisse.PL_CODENUMCOMPTE;
            MC_SOLDEPRECEDENT = clsEditionEtatCaisse.MC_SOLDEPRECEDENT;
            TI_NUMTIERS = clsEditionEtatCaisse.TI_NUMTIERS;
            TI_DENOMINATION = clsEditionEtatCaisse.TI_DENOMINATION;
            OP_NOMPRENOM = clsEditionEtatCaisse.OP_NOMPRENOM;
            MR_LIBELLE = clsEditionEtatCaisse.MR_LIBELLE;
            TOTALCAISSE = clsEditionEtatCaisse.TOTALCAISSE;
            TOTALBANQUE = clsEditionEtatCaisse.TOTALBANQUE;

            AG_BOITEPOSTAL = clsEditionEtatCaisse.AG_BOITEPOSTAL;
            AG_TELEPHONE = clsEditionEtatCaisse.AG_TELEPHONE;
            EN_NUMENTREPOT = clsEditionEtatCaisse.EN_NUMENTREPOT;
            EN_DENOMINATION = clsEditionEtatCaisse.EN_DENOMINATION;
            PL_LIBELLE = clsEditionEtatCaisse.PL_LIBELLE;
            MV_NUMEROPIECE = clsEditionEtatCaisse.MV_NUMEROPIECE;
            MS_REFPIECE = clsEditionEtatCaisse.MS_REFPIECE;
            MS_DATEPIECE = clsEditionEtatCaisse.MS_DATEPIECE;
            JO_JOURNALCODE = clsEditionEtatCaisse.JO_JOURNALCODE;
            PL_NUMCOMPTE = clsEditionEtatCaisse.PL_NUMCOMPTE;
            MC_SOLDE = clsEditionEtatCaisse.MC_SOLDE;
            JO_LIBELLE = clsEditionEtatCaisse.JO_LIBELLE;
            CO_CODECOMPTE = clsEditionEtatCaisse.CO_CODECOMPTE;
            CO_NUMEROSEQUENCE = clsEditionEtatCaisse.CO_NUMEROSEQUENCE;
            CL_CODECLIENT = clsEditionEtatCaisse.CL_CODECLIENT;
            TI_IDTIERS = clsEditionEtatCaisse.TI_IDTIERS;
            PS_ABREVIATION = clsEditionEtatCaisse.PS_ABREVIATION;
            OP_LOGIN = clsEditionEtatCaisse.OP_LOGIN;
            COCHER = clsEditionEtatCaisse.COCHER;
            LT_CODELETTRAGE = clsEditionEtatCaisse.LT_CODELETTRAGE;
            LT_LIBELLELETTRAGE = clsEditionEtatCaisse.LT_LIBELLELETTRAGE;


            NC_CODENATURECOMPTE = clsEditionEtatCaisse.NC_CODENATURECOMPTE;
            PL_COMPTECOLLECTIF = clsEditionEtatCaisse.PL_COMPTECOLLECTIF;
            PL_TYPECOMPTE = clsEditionEtatCaisse.PL_TYPECOMPTE;
            PL_MONTANTPERIODEPRECEDENTDEBIT = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBIT;
            PL_MONTANTPERIODEPRECEDENTCREDIT = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDIT;
            PL_MONTANTPERIODEDEBITENCOURS = clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURS;
            PL_MONTANTPERIODECREDITENCOURS = clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURS;
            PL_MONTANTSOLDEFINALDEBIT = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBIT;
            PL_MONTANTSOLDEFINALCREDIT = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDIT;
            PL_MONTANTPERIODEPRECEDENTDEBITTOTAL = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBITTOTAL;
            PL_MONTANTPERIODEPRECEDENTCREDITTOTAL = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDITTOTAL;
            PL_MONTANTPERIODEDEBITENCOURSTOTAL = clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURSTOTAL;
            PL_MONTANTPERIODECREDITENCOURSTOTAL = clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURSTOTAL;
            PL_MONTANTSOLDEFINALDEBITTOTAL = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBITTOTAL;
            PL_MONTANTSOLDEFINALCREDITTOTAL = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDITTOTAL;
            PL_MONTANTPERIODEPRECEDENTDEBITGESTION = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBITGESTION;
            PL_MONTANTPERIODEPRECEDENTCREDITGESTION = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDITGESTION;
            PL_MONTANTPERIODEDEBITENCOURSGESTION = clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURSGESTION;
            PL_MONTANTPERIODECREDITENCOURSGESTION = clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURSGESTION;
            PL_MONTANTSOLDEFINALDEBITGESTION = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBITGESTION;
            PL_MONTANTSOLDEFINALCREDITGESTION = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDITGESTION;
            PL_MONTANTPERIODEPRECEDENTDEBITBILAN = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBITBILAN;
            PL_MONTANTPERIODEPRECEDENTCREDITBILAN = clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDITBILAN;
            PL_MONTANTPERIODEDEBITENCOURSBILAN = clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURSBILAN;
            PL_MONTANTPERIODECREDITENCOURSBILAN = clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURSBILAN;
            PL_MONTANTSOLDEFINALDEBITBILAN = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBITBILAN;
            PL_MONTANTSOLDEFINALCREDITBILAN = clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDITBILAN;
            PL_TOTALCHARGEFINPERIODE = clsEditionEtatCaisse.PL_TOTALCHARGEFINPERIODE;
            PL_TOTALPRODUITFINPERIODE = clsEditionEtatCaisse.PL_TOTALPRODUITFINPERIODE;
            PL_RESULTATNETPROVISOIRE = clsEditionEtatCaisse.PL_RESULTATNETPROVISOIRE;
            PL_TOTALCOMPTEGESTION = clsEditionEtatCaisse.PL_TOTALCOMPTEGESTION;
            PL_TOTALCOMPTEBILAN = clsEditionEtatCaisse.PL_TOTALCOMPTEBILAN;
            COMPTAPAR_SENS_CODE = clsEditionEtatCaisse.COMPTAPAR_SENS_CODE;

        }
        }
}