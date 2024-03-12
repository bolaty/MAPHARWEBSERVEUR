using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtsinistre
	{
		#region VARIABLES LOCALES

		private string _SI_CODESINISTRE = "";
		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _NS_CODENATURESINISTRE = "";
		private string _CA_CODECONTRAT = "";
		private string _SI_NUMSINISTRE = "";
		private DateTime _SI_DATESAISIE = DateTime.Parse("01/01/1900");
		private DateTime _SI_DATESINISTRE = DateTime.Parse("01/01/1900");
		private DateTime _SI_HEURESINISTRE = DateTime.Parse("01/01/1900");
		private string _SI_NOMPRENOMSCONDUCTEURSINISTRE = "";
		private string _CO_CODECOMMUNE = "";
		private string _SI_ADRESSEGEOGRPHIQUESINISTRE = "";
		private string _SI_DESCRIPTIONSINISTRE = "";
		private DateTime _SI_DATETRANSMISSIONSINISTRE = DateTime.Parse("01/01/1900");
		private DateTime _SI_DATEVALIDATIONSINISTRE = DateTime.Parse("01/01/1900");
		private DateTime _SI_DATESUSPENSIONSINISTRE = DateTime.Parse("01/01/1900");
		private DateTime _SI_DATECLOTURESINISTRE = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";
		private string _SI_DOCUMENTTRANSMIS = "";
		private double _SI_MONTANTPREJUDICE = 0;
		private string _EP_CODEEXPERTNOMME = "";
		private DateTime _SI_DATEEXPERTNOMMESINISTRE = DateTime.Parse("01/01/1900");
		private double _SI_MONTANTPREJUDICEVALIDER = 0;
		private string _OP_CODEOPERATEURSAISIEMONTANTVALIDER = "";
		private DateTime _SI_DATESAISIEMONTANTVALIDER = DateTime.Parse("01/01/1900");


        private string _SI_TELEPHONECONDUCTEURSINISTRE = "";
        private string _SI_NUMWHATSAPPCONDUCTEURSINISTRE = "";
        private DateTime _SI_DATENAISSANCECONDUCTEURSINISTRE = DateTime.Parse("01/01/1900");
        private string _SI_NUMPERMISCONDUCTEURSINISTRE = "";
        private DateTime _SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = DateTime.Parse("01/01/1900");
        private DateTime _SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = DateTime.Parse("01/01/1900");
        private string _SI_IMMATRICULATIONVEHICULE = "";
        private string _SI_MARQUEVEHICULE = "";
        private string _SI_NOMETCONTACTSVICTIMES = "";
        private string _SI_AILEARRIEREDROIT = "";
        private string _SI_AILEARRIEREGAUCHE = "";
        private string _SI_PARCHOCAVANT = "";
        private string _SI_PARCHOCARRIERE = "";
        private string _SI_LATERALGAUCHE = "";
        private string _SI_LATERALDROIT = "";
        private string _SI_CAPOTMOTEUR = "";
        private string _SI_AUTRES = "";
        private string _SI_REPARATEUR = "";
        private string _SI_NOMBREBLESSESVEHICULEASSURE = "";
        private string _SI_NOMBREDECESVEHICULEASSURE = "";
        private string _SI_NOMBREBLESSESVEHICULETIERS = "";
        private string _SI_NOMBREDECESVEHICULETIERS = "";
        private string _SI_PVCONSTATPOLICE = "";
        private string _SI_PVGENDARMERIE = "";
        private string _SI_PVAMIABLE = "";
        private string _SI_UNITE = "";
        private string _SI_NOMAGENT = "";
        private string _SI_TELPHONEAGENT = "";
        private string _SI_HUSSIER = "";

        private int _TYPEOPERATION = 0;
		#endregion

		#region ACCESSEURS

		public string SI_CODESINISTRE
		{
			get { return _SI_CODESINISTRE; }
			set {  _SI_CODESINISTRE = value; }
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

		public string NS_CODENATURESINISTRE
		{
			get { return _NS_CODENATURESINISTRE; }
			set {  _NS_CODENATURESINISTRE = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string SI_NUMSINISTRE
		{
			get { return _SI_NUMSINISTRE; }
			set {  _SI_NUMSINISTRE = value; }
		}

		public DateTime SI_DATESAISIE
		{
			get { return _SI_DATESAISIE; }
			set {  _SI_DATESAISIE = value; }
		}

		public DateTime SI_DATESINISTRE
		{
			get { return _SI_DATESINISTRE; }
			set {  _SI_DATESINISTRE = value; }
		}

		public DateTime SI_HEURESINISTRE
		{
			get { return _SI_HEURESINISTRE; }
			set {  _SI_HEURESINISTRE = value; }
		}

		public string SI_NOMPRENOMSCONDUCTEURSINISTRE
		{
			get { return _SI_NOMPRENOMSCONDUCTEURSINISTRE; }
			set {  _SI_NOMPRENOMSCONDUCTEURSINISTRE = value; }
		}

		public string CO_CODECOMMUNE
		{
			get { return _CO_CODECOMMUNE; }
			set {  _CO_CODECOMMUNE = value; }
		}

		public string SI_ADRESSEGEOGRPHIQUESINISTRE
		{
			get { return _SI_ADRESSEGEOGRPHIQUESINISTRE; }
			set {  _SI_ADRESSEGEOGRPHIQUESINISTRE = value; }
		}

		public string SI_DESCRIPTIONSINISTRE
		{
			get { return _SI_DESCRIPTIONSINISTRE; }
			set {  _SI_DESCRIPTIONSINISTRE = value; }
		}

		public DateTime SI_DATETRANSMISSIONSINISTRE
		{
			get { return _SI_DATETRANSMISSIONSINISTRE; }
			set {  _SI_DATETRANSMISSIONSINISTRE = value; }
		}

		public DateTime SI_DATEVALIDATIONSINISTRE
		{
			get { return _SI_DATEVALIDATIONSINISTRE; }
			set {  _SI_DATEVALIDATIONSINISTRE = value; }
		}

		public DateTime SI_DATESUSPENSIONSINISTRE
		{
			get { return _SI_DATESUSPENSIONSINISTRE; }
			set {  _SI_DATESUSPENSIONSINISTRE = value; }
		}

		public DateTime SI_DATECLOTURESINISTRE
		{
			get { return _SI_DATECLOTURESINISTRE; }
			set {  _SI_DATECLOTURESINISTRE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string SI_DOCUMENTTRANSMIS
		{
			get { return _SI_DOCUMENTTRANSMIS; }
			set {  _SI_DOCUMENTTRANSMIS = value; }
		}

		public double SI_MONTANTPREJUDICE
		{
			get { return _SI_MONTANTPREJUDICE; }
			set {  _SI_MONTANTPREJUDICE = value; }
		}

		public string EP_CODEEXPERTNOMME
		{
			get { return _EP_CODEEXPERTNOMME; }
			set {  _EP_CODEEXPERTNOMME = value; }
		}

		public DateTime SI_DATEEXPERTNOMMESINISTRE
		{
			get { return _SI_DATEEXPERTNOMMESINISTRE; }
			set {  _SI_DATEEXPERTNOMMESINISTRE = value; }
		}

        public Double SI_MONTANTPREJUDICEVALIDER
        {
	        get { return _SI_MONTANTPREJUDICEVALIDER; }
	        set { _SI_MONTANTPREJUDICEVALIDER = value; }
        }
        public string OP_CODEOPERATEURSAISIEMONTANTVALIDER
        {
	        get { return _OP_CODEOPERATEURSAISIEMONTANTVALIDER; }
	        set { _OP_CODEOPERATEURSAISIEMONTANTVALIDER = value; }
        }

        public DateTime SI_DATESAISIEMONTANTVALIDER
        {
	        get { return _SI_DATESAISIEMONTANTVALIDER; }
	        set { _SI_DATESAISIEMONTANTVALIDER = value; }
        }



        public string SI_TELEPHONECONDUCTEURSINISTRE
        {
            get { return _SI_TELEPHONECONDUCTEURSINISTRE; }
            set { _SI_TELEPHONECONDUCTEURSINISTRE = value; }
        }
        public string SI_NUMWHATSAPPCONDUCTEURSINISTRE
        {
            get { return _SI_NUMWHATSAPPCONDUCTEURSINISTRE; }
            set { _SI_NUMWHATSAPPCONDUCTEURSINISTRE = value; }
        }

        public DateTime SI_DATENAISSANCECONDUCTEURSINISTRE
        {
            get { return _SI_DATENAISSANCECONDUCTEURSINISTRE; }
            set { _SI_DATENAISSANCECONDUCTEURSINISTRE = value; }
        }

        public string SI_NUMPERMISCONDUCTEURSINISTRE
        {
            get { return _SI_NUMPERMISCONDUCTEURSINISTRE; }
            set { _SI_NUMPERMISCONDUCTEURSINISTRE = value; }
        }

        public DateTime SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE
        {
            get { return _SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE; }
            set { _SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = value; }
        }

        public DateTime SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE
        {
            get { return _SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE; }
            set { _SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = value; }
        }

        public string SI_IMMATRICULATIONVEHICULE
        {
            get { return _SI_IMMATRICULATIONVEHICULE; }
            set { _SI_IMMATRICULATIONVEHICULE = value; }
        }

        public string SI_MARQUEVEHICULE
        {
            get { return _SI_MARQUEVEHICULE; }
            set { _SI_MARQUEVEHICULE = value; }
        }

        public string SI_NOMETCONTACTSVICTIMES
        {
            get { return _SI_NOMETCONTACTSVICTIMES; }
            set { _SI_NOMETCONTACTSVICTIMES = value; }
        }

        public string SI_AILEARRIEREDROIT
        {
            get { return _SI_AILEARRIEREDROIT; }
            set { _SI_AILEARRIEREDROIT = value; }
        }

        public string SI_AILEARRIEREGAUCHE
        {
            get { return _SI_AILEARRIEREGAUCHE; }
            set { _SI_AILEARRIEREGAUCHE = value; }
        }

        public string SI_PARCHOCAVANT
        {
            get { return _SI_PARCHOCAVANT; }
            set { _SI_PARCHOCAVANT = value; }
        }

        public string SI_PARCHOCARRIERE
        {
            get { return _SI_PARCHOCARRIERE; }
            set { _SI_PARCHOCARRIERE = value; }
        }

        public string SI_LATERALGAUCHE
        {
            get { return _SI_LATERALGAUCHE; }
            set { _SI_LATERALGAUCHE = value; }
        }

        public string SI_LATERALDROIT
        {
            get { return _SI_LATERALDROIT; }
            set { _SI_LATERALDROIT = value; }
        }

        public string SI_CAPOTMOTEUR
        {
            get { return _SI_CAPOTMOTEUR; }
            set { _SI_CAPOTMOTEUR = value; }
        }

        public string SI_AUTRES
        {
            get { return _SI_AUTRES; }
            set { _SI_AUTRES = value; }
        }

        public string SI_REPARATEUR
        {
            get { return _SI_REPARATEUR; }
            set { _SI_REPARATEUR = value; }
        }

        public string SI_NOMBREBLESSESVEHICULEASSURE
        {
            get { return _SI_NOMBREBLESSESVEHICULEASSURE; }
            set { _SI_NOMBREBLESSESVEHICULEASSURE = value; }
        }

        public string SI_NOMBREDECESVEHICULEASSURE
        {
            get { return _SI_NOMBREDECESVEHICULEASSURE; }
            set { _SI_NOMBREDECESVEHICULEASSURE = value; }
        }

        public string SI_NOMBREBLESSESVEHICULETIERS
        {
            get { return _SI_NOMBREBLESSESVEHICULETIERS; }
            set { _SI_NOMBREBLESSESVEHICULETIERS = value; }
        }

        public string SI_NOMBREDECESVEHICULETIERS
        {
            get { return _SI_NOMBREDECESVEHICULETIERS; }
            set { _SI_NOMBREDECESVEHICULETIERS = value; }
        }

        public string SI_PVCONSTATPOLICE
        {
            get { return _SI_PVCONSTATPOLICE; }
            set { _SI_PVCONSTATPOLICE = value; }
        }

        public string SI_PVGENDARMERIE
        {
            get { return _SI_PVGENDARMERIE; }
            set { _SI_PVGENDARMERIE = value; }
        }

        public string SI_PVAMIABLE
        {
            get { return _SI_PVAMIABLE; }
            set { _SI_PVAMIABLE = value; }
        }

        public string SI_UNITE
        {
            get { return _SI_UNITE; }
            set { _SI_UNITE = value; }
        }

        public string SI_NOMAGENT
        {
            get { return _SI_NOMAGENT; }
            set { _SI_NOMAGENT = value; }
        }

        public string SI_TELPHONEAGENT
        {
            get { return _SI_TELPHONEAGENT; }
            set { _SI_TELPHONEAGENT = value; }
        }

        public string SI_HUSSIER
        {
            get { return _SI_HUSSIER; }
            set { _SI_HUSSIER = value; }
        }


        public int TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCtsinistre(){}
		
		public clsCtsinistre(clsCtsinistre clsCtsinistre)
		{
			this.SI_CODESINISTRE = clsCtsinistre.SI_CODESINISTRE;
			this.AG_CODEAGENCE = clsCtsinistre.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtsinistre.EN_CODEENTREPOT;
			this.NS_CODENATURESINISTRE = clsCtsinistre.NS_CODENATURESINISTRE;
			this.CA_CODECONTRAT = clsCtsinistre.CA_CODECONTRAT;
			this.SI_NUMSINISTRE = clsCtsinistre.SI_NUMSINISTRE;
			this.SI_DATESAISIE = clsCtsinistre.SI_DATESAISIE;
			this.SI_DATESINISTRE = clsCtsinistre.SI_DATESINISTRE;
			this.SI_HEURESINISTRE = clsCtsinistre.SI_HEURESINISTRE;
			this.SI_NOMPRENOMSCONDUCTEURSINISTRE = clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE;
			this.CO_CODECOMMUNE = clsCtsinistre.CO_CODECOMMUNE;
			this.SI_ADRESSEGEOGRPHIQUESINISTRE = clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE;
			this.SI_DESCRIPTIONSINISTRE = clsCtsinistre.SI_DESCRIPTIONSINISTRE;
			this.SI_DATETRANSMISSIONSINISTRE = clsCtsinistre.SI_DATETRANSMISSIONSINISTRE;
			this.SI_DATEVALIDATIONSINISTRE = clsCtsinistre.SI_DATEVALIDATIONSINISTRE;
			this.SI_DATESUSPENSIONSINISTRE = clsCtsinistre.SI_DATESUSPENSIONSINISTRE;
			this.SI_DATECLOTURESINISTRE = clsCtsinistre.SI_DATECLOTURESINISTRE;
			this.OP_CODEOPERATEUR = clsCtsinistre.OP_CODEOPERATEUR;
			this.SI_DOCUMENTTRANSMIS = clsCtsinistre.SI_DOCUMENTTRANSMIS;
			this.SI_MONTANTPREJUDICE = clsCtsinistre.SI_MONTANTPREJUDICE;
			this.EP_CODEEXPERTNOMME = clsCtsinistre.EP_CODEEXPERTNOMME;
			this.SI_DATEEXPERTNOMMESINISTRE = clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE;
			this.SI_MONTANTPREJUDICEVALIDER = clsCtsinistre.SI_MONTANTPREJUDICEVALIDER;
			this.OP_CODEOPERATEURSAISIEMONTANTVALIDER = clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER;
			this.SI_DATESAISIEMONTANTVALIDER = clsCtsinistre.SI_DATESAISIEMONTANTVALIDER;


            this.SI_TELEPHONECONDUCTEURSINISTRE = clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE;
            this.SI_NUMWHATSAPPCONDUCTEURSINISTRE = clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE;
            this.SI_DATENAISSANCECONDUCTEURSINISTRE = clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE;
            this.SI_NUMPERMISCONDUCTEURSINISTRE = clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE;
            this.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE;
            this.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE;
            this.SI_IMMATRICULATIONVEHICULE = clsCtsinistre.SI_IMMATRICULATIONVEHICULE;
            this.SI_MARQUEVEHICULE = clsCtsinistre.SI_MARQUEVEHICULE;
            this.SI_NOMETCONTACTSVICTIMES = clsCtsinistre.SI_NOMETCONTACTSVICTIMES;
            this.SI_AILEARRIEREDROIT = clsCtsinistre.SI_AILEARRIEREDROIT;
            this.SI_AILEARRIEREGAUCHE = clsCtsinistre.SI_AILEARRIEREGAUCHE;
            this.SI_PARCHOCAVANT = clsCtsinistre.SI_PARCHOCAVANT;
            this.SI_PARCHOCARRIERE = clsCtsinistre.SI_PARCHOCARRIERE;
            this.SI_LATERALGAUCHE = clsCtsinistre.SI_LATERALGAUCHE;
            this.SI_LATERALDROIT = clsCtsinistre.SI_LATERALDROIT;
            this.SI_CAPOTMOTEUR = clsCtsinistre.SI_CAPOTMOTEUR;
            this.SI_AUTRES = clsCtsinistre.SI_AUTRES;
            this.SI_REPARATEUR = clsCtsinistre.SI_REPARATEUR;
            this.SI_NOMBREBLESSESVEHICULEASSURE = clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE;
            this.SI_NOMBREDECESVEHICULEASSURE = clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE;
            this.SI_NOMBREBLESSESVEHICULETIERS = clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS;
            this.SI_NOMBREDECESVEHICULETIERS = clsCtsinistre.SI_NOMBREDECESVEHICULETIERS;
            this.SI_PVCONSTATPOLICE = clsCtsinistre.SI_PVCONSTATPOLICE;
            this.SI_PVGENDARMERIE = clsCtsinistre.SI_PVGENDARMERIE;
            this.SI_PVAMIABLE = clsCtsinistre.SI_PVAMIABLE;
            this.SI_UNITE = clsCtsinistre.SI_UNITE;
            this.SI_NOMAGENT = clsCtsinistre.SI_NOMAGENT;
            this.SI_TELPHONEAGENT = clsCtsinistre.SI_TELPHONEAGENT;
            this.SI_HUSSIER = clsCtsinistre.SI_HUSSIER;


            this.TYPEOPERATION = clsCtsinistre.TYPEOPERATION;
		}

		#endregion

	}
}
