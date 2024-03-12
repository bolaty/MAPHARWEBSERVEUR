using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatAssurance
	{


    //    @AG_CODEAGENCE varchar(7000),	
    //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
    //@DATEDEBUT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _CA_CODECONTRAT = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _OP_CODEOPERATEUR = "";
        private string _DATEDEBUT = "";
        private string _DATEFIN = "";
        private string _CA_NUMPOLICE= "";
        private string _RQ_CODERISQUE = "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";
        private string _TI_IDTIERS = "";
        private string _TI_NUMTIERS = "";
        private string _TA_CODETYPEAFFAIRES = "";
        private string _CT_CODESTAUT = "";
        private string _TI_IDTIERSCOMMERCIAL = "";
        private string _PY_CODEPAYS = "";
        private string _VL_CODEVILLE = "";
        private string _CO_CODECOMMUNE = "";
        private string _ZA_CODEZONEAUTO = "";
        private string _NS_CODENATURESINISTRE = "";        
        private string _ZN_CODEZONECOMMERCIAL = "";
        private string _CH_REFCHEQUE = "";
        private string _CH_NOMTIREUR = "";
        private string _CH_NOMTIRE = "";
        private string _CH_NOMDUDEPOSANT = "";
        private string _CH_TELEPHONEDEPOSANT = "";
        private string _CH_DATESAISIECHEQUE = "";
        private double _CH_VALEURCHEQUE = 0;
        private string _CH_DATEVALIDATIONCHEQUE = "";
        private string _GR_LIBELLEGARENTIEPRIME = "";
        private string _TI_IDTIERSCLIENT = "";
        private string _EX_EXERCICE = "";

        //clsEditionEtatAssurance.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
        //clsEditionEtatAssurance.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
        //clsEditionEtatAssurance.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
        //clsEditionEtatAssurance.CH_NOMDUDEPOSANT = row["CH_NOMDUDEPOSANT"].ToString();
        //clsEditionEtatAssurance.CH_TELEPHONEDEPOSANT = row["CH_TELEPHONEDEPOSANT"].ToString();
        //clsEditionEtatAssurance.CH_DATESAISIECHEQUE = row["CH_DATESAISIECHEQUE"].ToString();
        //clsEditionEtatAssurance.CH_VALEURCHEQUE = row["CH_VALEURCHEQUE"].ToString();
        //clsEditionEtatAssurance.CH_DATEVALIDATIONCHEQUE = row["CH_DATEVALIDATIONCHEQUE"].ToString();


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

        public string CA_CODECONTRAT
        {
            get { return _CA_CODECONTRAT; }
            set { _CA_CODECONTRAT = value; }
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
        public string DATEDEBUT
		{
            get { return _DATEDEBUT; }
            set { _DATEDEBUT = value; }
		}
        public string DATEFIN
		{
            get { return _DATEFIN; }
            set { _DATEFIN = value; }
		}
        public string CA_NUMPOLICE
		{
            get { return _CA_NUMPOLICE; }
            set { _CA_NUMPOLICE = value; }
		}
        public string RQ_CODERISQUE
		{
            get { return _RQ_CODERISQUE; }
            set { _RQ_CODERISQUE = value; }
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

        public string TA_CODETYPEAFFAIRES
        {
            get { return _TA_CODETYPEAFFAIRES; }
            set { _TA_CODETYPEAFFAIRES = value; }
        }      
        public string CT_CODESTAUT
        {
            get { return _CT_CODESTAUT; }
            set { _CT_CODESTAUT = value; }
        }
        public string TI_IDTIERSCOMMERCIAL
        {
            get { return _TI_IDTIERSCOMMERCIAL; }
            set { _TI_IDTIERSCOMMERCIAL = value; }
        }
        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
        public string VL_CODEVILLE
        {
            get { return _VL_CODEVILLE; }
            set { _VL_CODEVILLE = value; }
        }
        public string CO_CODECOMMUNE
        {
            get { return _CO_CODECOMMUNE; }
            set { _CO_CODECOMMUNE = value; }
        }
        public string ZA_CODEZONEAUTO
        {
            get { return _ZA_CODEZONEAUTO; }
            set { _ZA_CODEZONEAUTO = value; }
        }
        public string NS_CODENATURESINISTRE
        {
            get { return _NS_CODENATURESINISTRE; }
            set { _NS_CODENATURESINISTRE = value; }
        }        
        public string ZN_CODEZONECOMMERCIAL
        {
            get { return _ZN_CODEZONECOMMERCIAL; }
            set { _ZN_CODEZONECOMMERCIAL = value; }
        }
        public string CH_REFCHEQUE
        {
            get { return _CH_REFCHEQUE; }
            set { _CH_REFCHEQUE = value; }
        }
        public string CH_NOMTIREUR
        {
            get { return _CH_NOMTIREUR; }
            set { _CH_NOMTIREUR = value; }
        }
        public string CH_NOMTIRE
        {
            get { return _CH_NOMTIRE; }
            set { _CH_NOMTIRE = value; }
        }
        public string CH_NOMDUDEPOSANT
        {
            get { return _CH_NOMDUDEPOSANT; }
            set { _CH_NOMDUDEPOSANT = value; }
        }
        public string CH_TELEPHONEDEPOSANT
        {
            get { return _CH_TELEPHONEDEPOSANT; }
            set { _CH_TELEPHONEDEPOSANT = value; }
        }
        public string CH_DATESAISIECHEQUE
        {
            get { return _CH_DATESAISIECHEQUE; }
            set { _CH_DATESAISIECHEQUE = value; }
        }
        public double CH_VALEURCHEQUE
        {
            get { return _CH_VALEURCHEQUE; }
            set { _CH_VALEURCHEQUE = value; }
        }
        public string CH_DATEVALIDATIONCHEQUE
        {
            get { return _CH_DATEVALIDATIONCHEQUE; }
            set { _CH_DATEVALIDATIONCHEQUE = value; }
        }
        public string GR_LIBELLEGARENTIEPRIME
        {
            get { return _GR_LIBELLEGARENTIEPRIME; }
            set { _GR_LIBELLEGARENTIEPRIME = value; }
        }

        public string TI_IDTIERSCLIENT
        {
            get { return _TI_IDTIERSCLIENT; }
            set { _TI_IDTIERSCLIENT = value; }
        }
        public string EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
        }

        public clsEditionEtatAssurance() {} 

		

		public clsEditionEtatAssurance(clsEditionEtatAssurance clsEditionEtatAssurance)
		{
			AG_CODEAGENCE = clsEditionEtatAssurance.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatAssurance.EN_CODEENTREPOT;
            CA_CODECONTRAT = clsEditionEtatAssurance.CA_CODECONTRAT;
			OP_CODEOPERATEUREDITION = clsEditionEtatAssurance.OP_CODEOPERATEUREDITION;
            OP_CODEOPERATEUR = clsEditionEtatAssurance.OP_CODEOPERATEUR;
            DATEDEBUT = clsEditionEtatAssurance.DATEDEBUT;
            DATEFIN = clsEditionEtatAssurance.DATEFIN;
            CA_NUMPOLICE = clsEditionEtatAssurance.CA_NUMPOLICE;
            RQ_CODERISQUE = clsEditionEtatAssurance.RQ_CODERISQUE;
            ET_TYPEETAT = clsEditionEtatAssurance.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatAssurance.ET_TYPERETOURS;
            TI_IDTIERS = clsEditionEtatAssurance.TI_IDTIERS;
            TI_NUMTIERS = clsEditionEtatAssurance.TI_NUMTIERS;
            TA_CODETYPEAFFAIRES = clsEditionEtatAssurance.TA_CODETYPEAFFAIRES;
            CT_CODESTAUT = clsEditionEtatAssurance.CT_CODESTAUT;
            TI_IDTIERSCOMMERCIAL = clsEditionEtatAssurance.TI_IDTIERSCOMMERCIAL;
            PY_CODEPAYS = clsEditionEtatAssurance.PY_CODEPAYS;
            VL_CODEVILLE = clsEditionEtatAssurance.VL_CODEVILLE;
            CO_CODECOMMUNE = clsEditionEtatAssurance.CO_CODECOMMUNE;
            ZA_CODEZONEAUTO = clsEditionEtatAssurance.ZA_CODEZONEAUTO;
            NS_CODENATURESINISTRE = clsEditionEtatAssurance.NS_CODENATURESINISTRE;
            ZN_CODEZONECOMMERCIAL = clsEditionEtatAssurance.ZN_CODEZONECOMMERCIAL;

            CH_REFCHEQUE = clsEditionEtatAssurance.CH_REFCHEQUE;
            CH_NOMTIREUR = clsEditionEtatAssurance.CH_NOMTIREUR;
            CH_NOMTIRE = clsEditionEtatAssurance.CH_NOMTIRE;
            CH_NOMDUDEPOSANT = clsEditionEtatAssurance.CH_NOMDUDEPOSANT;
            CH_TELEPHONEDEPOSANT = clsEditionEtatAssurance.CH_TELEPHONEDEPOSANT;
            CH_DATESAISIECHEQUE = clsEditionEtatAssurance.CH_DATESAISIECHEQUE;
            CH_VALEURCHEQUE = clsEditionEtatAssurance.CH_VALEURCHEQUE;
            CH_DATEVALIDATIONCHEQUE = clsEditionEtatAssurance.CH_DATEVALIDATIONCHEQUE;
            GR_LIBELLEGARENTIEPRIME = clsEditionEtatAssurance.GR_LIBELLEGARENTIEPRIME;
            TI_IDTIERSCLIENT = clsEditionEtatAssurance.TI_IDTIERSCLIENT;
            EX_EXERCICE = clsEditionEtatAssurance.EX_EXERCICE;
            //--@TI_IDTIERSCOMMERCIAL AS varchar(7000),
            //--@PY_CODEPAYS AS varchar(7000),
            //--@VL_CODEVILLE AS varchar(7000),
            //--@CO_CODECOMMUNE AS varchar(7000),
            //--@ZA_CODEZONEAUTO AS varchar(7000),

        }
    }
}