using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontrat
	{
		#region VARIABLES LOCALES

		private string _CA_CODECONTRAT = "";
		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_NUMPOLICE = "";
		private DateTime _CA_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _TI_IDTIERS = "";
		private string _IT_CODEINTERMEDIAIRE = "";
		private string _AP_CODETYPEAPPARTEMENT = "";
		private string _OC_CODETYPEOCCUPANT = "";
		private string _ZA_CODEZONEAUTO = "";
		private string _CB_IDBRANCHE = "";
		private DateTime _CA_DATEEFFET = DateTime.Parse("01/01/1900");
		private DateTime _CA_DATEECHEANCE = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";
		private string _CA_AVENANT = "";
		private string _CA_SITUATIONGEOGRAPHIQUE = "";
		private string _CA_CONDITIONHABITUEL = "";
		private string _ST_CODESTATUTSOCIOPROF = "";
		private string _AU_CODECATEGORIE = "";
		private string _TA_CODETARIF = "";
		private string _US_CODEUSAGE = "";
		private string _GE_CODEGENRE = "";
		private string _TVH_CODETYPE = "";
		private string _EN_CODEENERGIE = "";
		private float _CA_TAUX = 0;
		private string _CA_TYPE = "";
		private string _CA_NUMSERIE = "";
		private string _CA_IMMATRICULATION = "";
		private int _CA_PUISSANCEADMISE = 0;
		private float _CA_CHARGEUTILE = 0;
		private int _CA_NBREPLACE = 0;
		private double _CA_VALNEUVE = 0;
		private double _CA_VALVENALE = 0;
		private DateTime _CA_DATEMISECIRCULATION = DateTime.Parse("01/01/1900");
		private string _CA_CLIENTEXONERETAXE = "";
		private string _TI_IDTIERSCOMMERCIAL = "";
		private string _TI_IDTIERSASSUREUR = "";
		private DateTime _CA_DATETRANSMISSIONAASSUREUR = DateTime.Parse("01/01/1900");
		private DateTime _CA_DATEVALIDATIONASSUREUR = DateTime.Parse("01/01/1900");
		private DateTime _CA_DATEVALIDATIONCONTRAASS = DateTime.Parse("01/01/1900");
		private DateTime _CA_DATESUSPENSION = DateTime.Parse("01/01/1900");
		private DateTime _CA_DATECLOTURE = DateTime.Parse("01/01/1900");
		private DateTime _CA_DATERESILIATION = DateTime.Parse("01/01/1900");
		private string _CA_NOMINTERLOCUTEUR = "";
		private string _CA_CONTACTINTERLOCUTEUR = "";
		private string _DI_CODEDESIGNATION = "";
		private string _TA_CODETYPECONTRATSANTE = "";
		private string _CA_CODECONTRATSECONDAIRE = "";
		private string _CA_GESA = "";
		private string _CO_CODECOMMUNE = "";
		private string _RQ_CODERISQUE = "";
		private string _TA_CODETYPEAFFAIRES = "";
		private int _TYPEOPERATION = 0;
		private string _MF_CODEMAINFORTE = "";
		private string _ZM_CODEZONEVOYAGE = "";

        private int _CA_NOMBREPIECE = 0;
        private float _CA_SUPERFICIE = 0;
        private double _CA_LOYERMENSUEL = 0;

        private int _CA_DUREEENMOIS = 0;
        private string _AC_SPORT = "";
        private string _CA_ADRESSE = "";

        private DateTime _CA_DATENAISSANCE =DateTime.Parse("01/01/1900");
        private string _PF_CODEPROFESSION = "";
        private string _CA_LIEUNAISSANCE = "";
        private string _CD_CODECONDITION = "";
        private string _GA_CODEGARANTIE = "";

        private string _CA_NUMPASSEPORT = "";
        private string _PY_CODEPAYSDESTINATION = "";
        private int _CA_DUREESEJOUR = 0;
        private string _CA_OPTION = "";
        private string _AU_CODETYPECONTRATAUTO = "";
        private DateTime _CA_DATEDEMANDERENOUVELEMENT = DateTime.Parse("01/01/1900");
        private string _CA_CODECONTRATORIGINE = "";

        private string _GR_CODEGARENTIEPRIME = "";
        private string _GR_LIBELLEGARENTIEPRIME = "";
        private string _CA_OBSERVATION = "";
        private string _DE_CODEDEMANADE = "";
        private string _TI_NUMWHATSAPP = "";
        private string _EX_EXERCICE = "";
        private string _AS_NUMEROASSUREUR = "";
        //private string _CA_NUMPASSEPORT = "";
        //private string _PY_CODEPAYSDESTINATION = "";
        //private string _CA_DUREESEJOUR = "0";
        //private string _CA_OPTION = "";
        #endregion

        #region ACCESSEURS

        public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string CA_NUMPOLICE
		{
			get { return _CA_NUMPOLICE; }
			set {  _CA_NUMPOLICE = value; }
		}

		public DateTime CA_DATESAISIE
		{
			get { return _CA_DATESAISIE; }
			set {  _CA_DATESAISIE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string IT_CODEINTERMEDIAIRE
		{
			get { return _IT_CODEINTERMEDIAIRE; }
			set {  _IT_CODEINTERMEDIAIRE = value; }
		}

		public string AP_CODETYPEAPPARTEMENT
		{
			get { return _AP_CODETYPEAPPARTEMENT; }
			set {  _AP_CODETYPEAPPARTEMENT = value; }
		}

		public string OC_CODETYPEOCCUPANT
		{
			get { return _OC_CODETYPEOCCUPANT; }
			set {  _OC_CODETYPEOCCUPANT = value; }
		}

		

		public string ZA_CODEZONEAUTO
		{
			get { return _ZA_CODEZONEAUTO; }
			set {  _ZA_CODEZONEAUTO = value; }
		}

		public string CB_IDBRANCHE
		{
			get { return _CB_IDBRANCHE; }
			set {  _CB_IDBRANCHE = value; }
		}

		public DateTime CA_DATEEFFET
		{
			get { return _CA_DATEEFFET; }
			set {  _CA_DATEEFFET = value; }
		}

		public DateTime CA_DATEECHEANCE
		{
			get { return _CA_DATEECHEANCE; }
			set {  _CA_DATEECHEANCE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string CA_AVENANT
		{
			get { return _CA_AVENANT; }
			set {  _CA_AVENANT = value; }
		}

		public string CA_SITUATIONGEOGRAPHIQUE
		{
			get { return _CA_SITUATIONGEOGRAPHIQUE; }
			set {  _CA_SITUATIONGEOGRAPHIQUE = value; }
		}

		public string CA_CONDITIONHABITUEL
		{
			get { return _CA_CONDITIONHABITUEL; }
			set {  _CA_CONDITIONHABITUEL = value; }
		}

		public string ST_CODESTATUTSOCIOPROF
		{
			get { return _ST_CODESTATUTSOCIOPROF; }
			set {  _ST_CODESTATUTSOCIOPROF = value; }
		}

		

		public string AU_CODECATEGORIE
		{
			get { return _AU_CODECATEGORIE; }
			set {  _AU_CODECATEGORIE = value; }
		}

		public string TA_CODETARIF
		{
			get { return _TA_CODETARIF; }
			set {  _TA_CODETARIF = value; }
		}

		public string US_CODEUSAGE
		{
			get { return _US_CODEUSAGE; }
			set {  _US_CODEUSAGE = value; }
		}

		public string GE_CODEGENRE
		{
			get { return _GE_CODEGENRE; }
			set {  _GE_CODEGENRE = value; }
		}

		public string TVH_CODETYPE
		{
			get { return _TVH_CODETYPE; }
			set {  _TVH_CODETYPE = value; }
		}

		public string EN_CODEENERGIE
		{
			get { return _EN_CODEENERGIE; }
			set {  _EN_CODEENERGIE = value; }
		}

		public float CA_TAUX
		{
			get { return _CA_TAUX; }
			set {  _CA_TAUX = value; }
		}

		public string CA_TYPE
		{
			get { return _CA_TYPE; }
			set {  _CA_TYPE = value; }
		}

		public string CA_NUMSERIE
		{
			get { return _CA_NUMSERIE; }
			set {  _CA_NUMSERIE = value; }
		}

		public string CA_IMMATRICULATION
		{
			get { return _CA_IMMATRICULATION; }
			set {  _CA_IMMATRICULATION = value; }
		}

		public int CA_PUISSANCEADMISE
		{
			get { return _CA_PUISSANCEADMISE; }
			set {  _CA_PUISSANCEADMISE = value; }
		}

		public float CA_CHARGEUTILE
		{
			get { return _CA_CHARGEUTILE; }
			set {  _CA_CHARGEUTILE = value; }
		}

		public int CA_NBREPLACE
		{
			get { return _CA_NBREPLACE; }
			set {  _CA_NBREPLACE = value; }
		}

		public double CA_VALNEUVE
		{
			get { return _CA_VALNEUVE; }
			set {  _CA_VALNEUVE = value; }
		}

		public double CA_VALVENALE
		{
			get { return _CA_VALVENALE; }
			set {  _CA_VALVENALE = value; }
		}

		public DateTime CA_DATEMISECIRCULATION
		{
			get { return _CA_DATEMISECIRCULATION; }
			set {  _CA_DATEMISECIRCULATION = value; }
		}

		public string CA_CLIENTEXONERETAXE
		{
			get { return _CA_CLIENTEXONERETAXE; }
			set {  _CA_CLIENTEXONERETAXE = value; }
		}

		public string TI_IDTIERSCOMMERCIAL
		{
			get { return _TI_IDTIERSCOMMERCIAL; }
			set {  _TI_IDTIERSCOMMERCIAL = value; }
		}

		public string TI_IDTIERSASSUREUR
		{
			get { return _TI_IDTIERSASSUREUR; }
			set {  _TI_IDTIERSASSUREUR = value; }
		}

		public DateTime CA_DATETRANSMISSIONAASSUREUR
		{
			get { return _CA_DATETRANSMISSIONAASSUREUR; }
			set {  _CA_DATETRANSMISSIONAASSUREUR = value; }
		}

		public DateTime CA_DATEVALIDATIONASSUREUR
		{
			get { return _CA_DATEVALIDATIONASSUREUR; }
			set {  _CA_DATEVALIDATIONASSUREUR = value; }
		}

		

		public DateTime CA_DATEVALIDATIONCONTRAASS
		{
			get { return _CA_DATEVALIDATIONCONTRAASS; }
			set {  _CA_DATEVALIDATIONCONTRAASS = value; }
		}

		public DateTime CA_DATESUSPENSION
		{
			get { return _CA_DATESUSPENSION; }
			set {  _CA_DATESUSPENSION = value; }
		}

		public DateTime CA_DATECLOTURE
		{
			get { return _CA_DATECLOTURE; }
			set {  _CA_DATECLOTURE = value; }
		}

		public DateTime CA_DATERESILIATION
		{
			get { return _CA_DATERESILIATION; }
			set {  _CA_DATERESILIATION = value; }
		}

		public string CA_NOMINTERLOCUTEUR
		{
			get { return _CA_NOMINTERLOCUTEUR; }
			set {  _CA_NOMINTERLOCUTEUR = value; }
		}

		public string CA_CONTACTINTERLOCUTEUR
		{
			get { return _CA_CONTACTINTERLOCUTEUR; }
			set {  _CA_CONTACTINTERLOCUTEUR = value; }
		}

		public string DI_CODEDESIGNATION
		{
			get { return _DI_CODEDESIGNATION; }
			set {  _DI_CODEDESIGNATION = value; }
		}

		public string TA_CODETYPECONTRATSANTE
		{
			get { return _TA_CODETYPECONTRATSANTE; }
			set {  _TA_CODETYPECONTRATSANTE = value; }
		}

		public string CA_CODECONTRATSECONDAIRE
		{
			get { return _CA_CODECONTRATSECONDAIRE; }
			set {  _CA_CODECONTRATSECONDAIRE = value; }
		}

		public string CA_GESA
		{
			get { return _CA_GESA; }
			set {  _CA_GESA = value; }
		}

		public string CO_CODECOMMUNE
		{
			get { return _CO_CODECOMMUNE; }
			set {  _CO_CODECOMMUNE = value; }
		}
        public int TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }
		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}
		public string TA_CODETYPEAFFAIRES
        {
			get { return _TA_CODETYPEAFFAIRES; }
			set { _TA_CODETYPEAFFAIRES = value; }
		}
        public string MF_CODEMAINFORTE
        {
	        get { return _MF_CODEMAINFORTE; }
	        set { _MF_CODEMAINFORTE = value; }
        }
        public string ZM_CODEZONEVOYAGE
        {
	        get { return _ZM_CODEZONEVOYAGE; }
	        set { _ZM_CODEZONEVOYAGE = value; }
        }

        public int CA_NOMBREPIECE
        {
            get { return _CA_NOMBREPIECE; }
            set { _CA_NOMBREPIECE = value; }
        }
        public float CA_SUPERFICIE
        {
            get { return _CA_SUPERFICIE; }
            set { _CA_SUPERFICIE = value; }
        }
        public double CA_LOYERMENSUEL
        {
            get { return _CA_LOYERMENSUEL; }
            set { _CA_LOYERMENSUEL = value; }
        }

        public DateTime CA_DATENAISSANCE
        {
            get { return _CA_DATENAISSANCE; }
            set { _CA_DATENAISSANCE = value; }
        }


        public String PF_CODEPROFESSION
        {
            get { return _PF_CODEPROFESSION; }
            set { _PF_CODEPROFESSION = value; }
        }
       

        public String CA_LIEUNAISSANCE
        {
            get { return _CA_LIEUNAISSANCE; }
            set { _CA_LIEUNAISSANCE = value; }
        }
        public String CD_CODECONDITION
        {
            get { return _CD_CODECONDITION; }
            set { _CD_CODECONDITION = value; }
        }

        public int CA_DUREEENMOIS
        {
            get { return _CA_DUREEENMOIS; }
            set { _CA_DUREEENMOIS = value; }
        }
        public String AC_SPORT
        {
            get { return _AC_SPORT; }
            set { _AC_SPORT = value; }
        }
        public String CA_ADRESSE
        {
            get { return _CA_ADRESSE; }
            set { _CA_ADRESSE = value; }
        }
        public String GA_CODEGARANTIE
        {
            get { return _GA_CODEGARANTIE; }
            set { _GA_CODEGARANTIE = value; }
        }


        public String CA_NUMPASSEPORT
        {
            get { return _CA_NUMPASSEPORT; }
            set { _CA_NUMPASSEPORT = value; }
        }
        public String PY_CODEPAYSDESTINATION
        {
            get { return _PY_CODEPAYSDESTINATION; }
            set { _PY_CODEPAYSDESTINATION = value; }
        }
        public int CA_DUREESEJOUR
        {
            get { return _CA_DUREESEJOUR; }
            set { _CA_DUREESEJOUR = value; }
        }
        public String CA_OPTION
        {
            get { return _CA_OPTION; }
            set { _CA_OPTION = value; }
        }
        public String AU_CODETYPECONTRATAUTO
        {
            get { return _AU_CODETYPECONTRATAUTO; }
            set { _AU_CODETYPECONTRATAUTO = value; }
        }

        public DateTime CA_DATEDEMANDERENOUVELEMENT
        {
            get { return _CA_DATEDEMANDERENOUVELEMENT; }
            set { _CA_DATEDEMANDERENOUVELEMENT = value; }
        }
        public string CA_CODECONTRATORIGINE
        {
            get { return _CA_CODECONTRATORIGINE; }
            set { _CA_CODECONTRATORIGINE = value; }
        }


        public String GR_CODEGARENTIEPRIME
        {
            get { return _GR_CODEGARENTIEPRIME; }
            set { _GR_CODEGARENTIEPRIME = value; }
        }
        public String GR_LIBELLEGARENTIEPRIME
        {
            get { return _GR_LIBELLEGARENTIEPRIME; }
            set { _GR_LIBELLEGARENTIEPRIME = value; }
        }
        public String CA_OBSERVATION
        {
            get { return _CA_OBSERVATION; }
            set { _CA_OBSERVATION = value; }
        }
        public String DE_CODEDEMANADE
        {
            get { return _DE_CODEDEMANADE; }
            set { _DE_CODEDEMANADE = value; }
        }

        public String TI_NUMWHATSAPP
        {
            get { return _TI_NUMWHATSAPP; }
            set { _TI_NUMWHATSAPP = value; }
        }
        public String EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
        }
        public String AS_NUMEROASSUREUR
        {
            get { return _AS_NUMEROASSUREUR; }
            set { _AS_NUMEROASSUREUR = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsCtcontrat(){}
		
		public clsCtcontrat(clsCtcontrat clsCtcontrat)
		{
			this.CA_CODECONTRAT = clsCtcontrat.CA_CODECONTRAT;
			this.AG_CODEAGENCE = clsCtcontrat.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontrat.EN_CODEENTREPOT;
			this.CA_NUMPOLICE = clsCtcontrat.CA_NUMPOLICE;
			this.CA_DATESAISIE = clsCtcontrat.CA_DATESAISIE;
			this.TI_IDTIERS = clsCtcontrat.TI_IDTIERS;
			this.IT_CODEINTERMEDIAIRE = clsCtcontrat.IT_CODEINTERMEDIAIRE;
			this.AP_CODETYPEAPPARTEMENT = clsCtcontrat.AP_CODETYPEAPPARTEMENT;
			this.OC_CODETYPEOCCUPANT = clsCtcontrat.OC_CODETYPEOCCUPANT;
			
			this.ZA_CODEZONEAUTO = clsCtcontrat.ZA_CODEZONEAUTO;
			this.CB_IDBRANCHE = clsCtcontrat.CB_IDBRANCHE;
			this.CA_DATEEFFET = clsCtcontrat.CA_DATEEFFET;
			this.CA_DATEECHEANCE = clsCtcontrat.CA_DATEECHEANCE;
			this.OP_CODEOPERATEUR = clsCtcontrat.OP_CODEOPERATEUR;
			this.CA_AVENANT = clsCtcontrat.CA_AVENANT;
			this.CA_SITUATIONGEOGRAPHIQUE = clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE;
			this.CA_CONDITIONHABITUEL = clsCtcontrat.CA_CONDITIONHABITUEL;
			this.ST_CODESTATUTSOCIOPROF = clsCtcontrat.ST_CODESTATUTSOCIOPROF;
			this.AU_CODECATEGORIE = clsCtcontrat.AU_CODECATEGORIE;
			this.TA_CODETARIF = clsCtcontrat.TA_CODETARIF;
			this.US_CODEUSAGE = clsCtcontrat.US_CODEUSAGE;
			this.GE_CODEGENRE = clsCtcontrat.GE_CODEGENRE;
			this.TVH_CODETYPE = clsCtcontrat.TVH_CODETYPE;
			this.EN_CODEENERGIE = clsCtcontrat.EN_CODEENERGIE;
			this.CA_TAUX = clsCtcontrat.CA_TAUX;
			this.CA_TYPE = clsCtcontrat.CA_TYPE;
			this.CA_NUMSERIE = clsCtcontrat.CA_NUMSERIE;
			this.CA_IMMATRICULATION = clsCtcontrat.CA_IMMATRICULATION;
			this.CA_PUISSANCEADMISE = clsCtcontrat.CA_PUISSANCEADMISE;
			this.CA_CHARGEUTILE = clsCtcontrat.CA_CHARGEUTILE;
			this.CA_NBREPLACE = clsCtcontrat.CA_NBREPLACE;
			this.CA_VALNEUVE = clsCtcontrat.CA_VALNEUVE;
			this.CA_VALVENALE = clsCtcontrat.CA_VALVENALE;
			this.CA_DATEMISECIRCULATION = clsCtcontrat.CA_DATEMISECIRCULATION;
			this.CA_CLIENTEXONERETAXE = clsCtcontrat.CA_CLIENTEXONERETAXE;
			this.TI_IDTIERSCOMMERCIAL = clsCtcontrat.TI_IDTIERSCOMMERCIAL;
			this.TI_IDTIERSASSUREUR = clsCtcontrat.TI_IDTIERSASSUREUR;
			this.CA_DATETRANSMISSIONAASSUREUR = clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR;
			this.CA_DATEVALIDATIONASSUREUR = clsCtcontrat.CA_DATEVALIDATIONASSUREUR;
			this.CA_DATEVALIDATIONCONTRAASS = clsCtcontrat.CA_DATEVALIDATIONCONTRAASS;
			this.CA_DATESUSPENSION = clsCtcontrat.CA_DATESUSPENSION;
			this.CA_DATECLOTURE = clsCtcontrat.CA_DATECLOTURE;
			this.CA_DATERESILIATION = clsCtcontrat.CA_DATERESILIATION;
			this.CA_NOMINTERLOCUTEUR = clsCtcontrat.CA_NOMINTERLOCUTEUR;
			this.CA_CONTACTINTERLOCUTEUR = clsCtcontrat.CA_CONTACTINTERLOCUTEUR;
			this.DI_CODEDESIGNATION = clsCtcontrat.DI_CODEDESIGNATION;
			this.TA_CODETYPECONTRATSANTE = clsCtcontrat.TA_CODETYPECONTRATSANTE;
			this.CA_CODECONTRATSECONDAIRE = clsCtcontrat.CA_CODECONTRATSECONDAIRE;
			this.CA_GESA = clsCtcontrat.CA_GESA;
			this.CO_CODECOMMUNE = clsCtcontrat.CO_CODECOMMUNE;
			this.RQ_CODERISQUE = clsCtcontrat.RQ_CODERISQUE;
			this.TA_CODETYPEAFFAIRES = clsCtcontrat.TA_CODETYPEAFFAIRES;
			this.TYPEOPERATION = clsCtcontrat.TYPEOPERATION;
			this.MF_CODEMAINFORTE = clsCtcontrat.MF_CODEMAINFORTE;
			this.ZM_CODEZONEVOYAGE = clsCtcontrat.ZM_CODEZONEVOYAGE;
            this.CA_NOMBREPIECE = clsCtcontrat.CA_NOMBREPIECE;
            this.CA_SUPERFICIE = clsCtcontrat.CA_SUPERFICIE;
            this.CA_LOYERMENSUEL = clsCtcontrat.CA_LOYERMENSUEL;
            this.CA_DATENAISSANCE = clsCtcontrat.CA_DATENAISSANCE;
            this.PF_CODEPROFESSION = clsCtcontrat.PF_CODEPROFESSION;
            this.CA_LIEUNAISSANCE = clsCtcontrat.CA_LIEUNAISSANCE;
            this.CD_CODECONDITION = clsCtcontrat.CD_CODECONDITION;

            this.CA_DUREEENMOIS = clsCtcontrat.CA_DUREEENMOIS;
            this.AC_SPORT = clsCtcontrat.AC_SPORT;
            this.CA_ADRESSE = clsCtcontrat.CA_ADRESSE;
            this.GA_CODEGARANTIE = clsCtcontrat.GA_CODEGARANTIE;
            this.CA_NUMPASSEPORT = clsCtcontrat.CA_NUMPASSEPORT;
            this.PY_CODEPAYSDESTINATION = clsCtcontrat.PY_CODEPAYSDESTINATION;
            this.CA_DUREESEJOUR = clsCtcontrat.CA_DUREESEJOUR;
            this.CA_OPTION = clsCtcontrat.CA_OPTION;
            this.AU_CODETYPECONTRATAUTO = clsCtcontrat.AU_CODETYPECONTRATAUTO;
            this.CA_DATEDEMANDERENOUVELEMENT = clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT;
            this.CA_CODECONTRATORIGINE = clsCtcontrat.CA_CODECONTRATORIGINE;

            this.GR_CODEGARENTIEPRIME = clsCtcontrat.GR_CODEGARENTIEPRIME;
            this.GR_LIBELLEGARENTIEPRIME = clsCtcontrat.GR_LIBELLEGARENTIEPRIME;
            this.CA_OBSERVATION = clsCtcontrat.CA_OBSERVATION;
            this.DE_CODEDEMANADE = clsCtcontrat.DE_CODEDEMANADE;
            this.TI_NUMWHATSAPP = clsCtcontrat.TI_NUMWHATSAPP;
            this.EX_EXERCICE = clsCtcontrat.EX_EXERCICE;
            this.AS_NUMEROASSUREUR = clsCtcontrat.AS_NUMEROASSUREUR;
            //private string _MF_CODEMAINFORTE = "";
            //private string _ZM_CODEZONEVOYAGE = "";

        }

        #endregion

    }
}
