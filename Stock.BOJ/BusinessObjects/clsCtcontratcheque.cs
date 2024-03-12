using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratcheque
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private DateTime _CH_DATESAISIECHEQUE = DateTime.Parse("01/01/1900");
		private string _CH_IDEXCHEQUE = "";
		private string _EN_CODEENTREPOT = "";
		private string _AB_CODEAGENCEBANCAIRE = "";
		private string _AB_CODEAGENCEBANCAIREASSUREUR = "";

		private string _CA_CODECONTRAT = "";
		private string _CH_REFCHEQUE = "";
		private double _CH_VALEURCHEQUE = 0;
		private DateTime _CH_DATEANNULATIONCHEQUE = DateTime.Parse("01/01/1900");
		private DateTime _CH_DATEEMISSIONCHEQUE = DateTime.Parse("01/01/1900");
		private string _CH_NOMTIREUR = "";
		private string _CH_NOMTIRE = "";
		private DateTime _CH_DATERECEPTIONCHEQUE = DateTime.Parse("01/01/1900");
		private string _CH_NOMDUDEPOSANT = "";
		private string _CH_TELEPHONEDEPOSANT = "";
		private DateTime _CH_DATEEFFET = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";
		private DateTime _CH_DATEVALIDATIONCHEQUE = DateTime.Parse("01/01/1900");
		private double _CH_PRIMEAENCAISSER = 0;
		private int _TYPEOPERATION = 0;

        private DateTime _CH_DATEDEBUTCOUVERTURE = DateTime.Parse("01/01/1900");
        private DateTime _CH_DATEFINCOUVERTURE = DateTime.Parse("01/01/1900");



        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public DateTime CH_DATESAISIECHEQUE
		{
			get { return _CH_DATESAISIECHEQUE; }
			set {  _CH_DATESAISIECHEQUE = value; }
		}

		public string CH_IDEXCHEQUE
		{
			get { return _CH_IDEXCHEQUE; }
			set {  _CH_IDEXCHEQUE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string AB_CODEAGENCEBANCAIRE
		{
			get { return _AB_CODEAGENCEBANCAIRE; }
			set {  _AB_CODEAGENCEBANCAIRE = value; }
		}

		public string AB_CODEAGENCEBANCAIREASSUREUR
        {
			get { return _AB_CODEAGENCEBANCAIREASSUREUR; }
			set { _AB_CODEAGENCEBANCAIREASSUREUR = value; }
		}


		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string CH_REFCHEQUE
		{
			get { return _CH_REFCHEQUE; }
			set {  _CH_REFCHEQUE = value; }
		}

		public double CH_VALEURCHEQUE
		{
			get { return _CH_VALEURCHEQUE; }
			set {  _CH_VALEURCHEQUE = value; }
		}

		public DateTime CH_DATEANNULATIONCHEQUE
		{
			get { return _CH_DATEANNULATIONCHEQUE; }
			set {  _CH_DATEANNULATIONCHEQUE = value; }
		}

		public DateTime CH_DATEEMISSIONCHEQUE
		{
			get { return _CH_DATEEMISSIONCHEQUE; }
			set {  _CH_DATEEMISSIONCHEQUE = value; }
		}

		public string CH_NOMTIREUR
		{
			get { return _CH_NOMTIREUR; }
			set {  _CH_NOMTIREUR = value; }
		}

		public string CH_NOMTIRE
		{
			get { return _CH_NOMTIRE; }
			set {  _CH_NOMTIRE = value; }
		}

		public DateTime CH_DATERECEPTIONCHEQUE
		{
			get { return _CH_DATERECEPTIONCHEQUE; }
			set {  _CH_DATERECEPTIONCHEQUE = value; }
		}

		public string CH_NOMDUDEPOSANT
		{
			get { return _CH_NOMDUDEPOSANT; }
			set {  _CH_NOMDUDEPOSANT = value; }
		}

		public string CH_TELEPHONEDEPOSANT
		{
			get { return _CH_TELEPHONEDEPOSANT; }
			set {  _CH_TELEPHONEDEPOSANT = value; }
		}

		public DateTime CH_DATEEFFET
		{
			get { return _CH_DATEEFFET; }
			set {  _CH_DATEEFFET = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		

		public DateTime CH_DATEVALIDATIONCHEQUE
		{
			get { return _CH_DATEVALIDATIONCHEQUE; }
			set {  _CH_DATEVALIDATIONCHEQUE = value; }
		}

		public double CH_PRIMEAENCAISSER
		{
			get { return _CH_PRIMEAENCAISSER; }
			set {  _CH_PRIMEAENCAISSER = value; }
		}
        public int TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }

        public DateTime CH_DATEDEBUTCOUVERTURE
        {
            get { return _CH_DATEDEBUTCOUVERTURE; }
            set { _CH_DATEDEBUTCOUVERTURE = value; }
        }
        public DateTime CH_DATEFINCOUVERTURE
        {
            get { return _CH_DATEFINCOUVERTURE; }
            set { _CH_DATEFINCOUVERTURE = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsCtcontratcheque(){}

		public clsCtcontratcheque(clsCtcontratcheque clsCtcontratcheque)
		{
			this.AG_CODEAGENCE = clsCtcontratcheque.AG_CODEAGENCE;
			this.CH_DATESAISIECHEQUE = clsCtcontratcheque.CH_DATESAISIECHEQUE;
			this.CH_IDEXCHEQUE = clsCtcontratcheque.CH_IDEXCHEQUE;
			this.EN_CODEENTREPOT = clsCtcontratcheque.EN_CODEENTREPOT;
			this.AB_CODEAGENCEBANCAIRE = clsCtcontratcheque.AB_CODEAGENCEBANCAIRE;
			this.AB_CODEAGENCEBANCAIREASSUREUR = clsCtcontratcheque.AB_CODEAGENCEBANCAIREASSUREUR;
			this.CA_CODECONTRAT = clsCtcontratcheque.CA_CODECONTRAT;
			this.CH_REFCHEQUE = clsCtcontratcheque.CH_REFCHEQUE;
			this.CH_VALEURCHEQUE = clsCtcontratcheque.CH_VALEURCHEQUE;
			this.CH_DATEANNULATIONCHEQUE = clsCtcontratcheque.CH_DATEANNULATIONCHEQUE;
			this.CH_DATEEMISSIONCHEQUE = clsCtcontratcheque.CH_DATEEMISSIONCHEQUE;
			this.CH_NOMTIREUR = clsCtcontratcheque.CH_NOMTIREUR;
			this.CH_NOMTIRE = clsCtcontratcheque.CH_NOMTIRE;
			this.CH_DATERECEPTIONCHEQUE = clsCtcontratcheque.CH_DATERECEPTIONCHEQUE;
			this.CH_NOMDUDEPOSANT = clsCtcontratcheque.CH_NOMDUDEPOSANT;
			this.CH_TELEPHONEDEPOSANT = clsCtcontratcheque.CH_TELEPHONEDEPOSANT;
			this.CH_DATEEFFET = clsCtcontratcheque.CH_DATEEFFET;
			this.OP_CODEOPERATEUR = clsCtcontratcheque.OP_CODEOPERATEUR;
			this.CH_DATEVALIDATIONCHEQUE = clsCtcontratcheque.CH_DATEVALIDATIONCHEQUE;
			this.CH_PRIMEAENCAISSER = clsCtcontratcheque.CH_PRIMEAENCAISSER;
			this.TYPEOPERATION = clsCtcontratcheque.TYPEOPERATION;
            this.CH_DATEDEBUTCOUVERTURE = clsCtcontratcheque.CH_DATEDEBUTCOUVERTURE;
            this.CH_DATEFINCOUVERTURE = clsCtcontratcheque.CH_DATEFINCOUVERTURE;

        }

		#endregion

	}
}
