using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratchequereglementcaisse
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private DateTime _CHC_DATESAISIECHEQUE = DateTime.Parse("01/01/1900");
		private string _CHC_IDEXCHEQUE = "";
		private string _EN_CODEENTREPOT = "";
		private string _AB_CODEAGENCEBANCAIRE = "";
		private string _AB_CODEAGENCEBANCAIREASSUREUR = "";
		private string _CA_CODECONTRAT = "";
		private string _MV_NUMPIECE = "";
		private string _CHC_REFCHEQUE = "";
		private double _CHC_VALEURCHEQUE = 0;
		private DateTime _CHC_DATEANNULATIONCHEQUE = DateTime.Parse("01/01/1900");
		private DateTime _CHC_DATEEMISSIONCHEQUE = DateTime.Parse("01/01/1900");
		private string _CHC_NOMTIREUR = "";
		private string _CHC_NOMTIRE = "";
		private DateTime _CHC_DATERECEPTIONCHEQUE = DateTime.Parse("01/01/1900");
		private string _CHC_NOMDUDEPOSANT = "";
		private string _CHC_TELEPHONEDEPOSANT = "";
		private DateTime _CHC_DATEEFFET = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";
		private DateTime _CHC_DATEVALIDATIONCHEQUE = DateTime.Parse("01/01/1900");


        private DateTime _CHC_DATEDEBUTCOUVERTURE = DateTime.Parse("01/01/1900");
        private DateTime _CHC_DATEFINCOUVERTURE = DateTime.Parse("01/01/1900");

        private double _CHC_PRIMEAENCAISSER = 0;
		private int _TYPEOPERATION = 0;
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public DateTime CHC_DATESAISIECHEQUE
		{
			get { return _CHC_DATESAISIECHEQUE; }
			set {  _CHC_DATESAISIECHEQUE = value; }
		}

		public string CHC_IDEXCHEQUE
		{
			get { return _CHC_IDEXCHEQUE; }
			set {  _CHC_IDEXCHEQUE = value; }
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
		public string MV_NUMPIECE
        {
			get { return _MV_NUMPIECE; }
			set { _MV_NUMPIECE = value; }
		}
		public string CHC_REFCHEQUE
		{
			get { return _CHC_REFCHEQUE; }
			set {  _CHC_REFCHEQUE = value; }
		}

		public double CHC_VALEURCHEQUE
		{
			get { return _CHC_VALEURCHEQUE; }
			set {  _CHC_VALEURCHEQUE = value; }
		}

		public DateTime CHC_DATEANNULATIONCHEQUE
		{
			get { return _CHC_DATEANNULATIONCHEQUE; }
			set {  _CHC_DATEANNULATIONCHEQUE = value; }
		}

		public DateTime CHC_DATEEMISSIONCHEQUE
		{
			get { return _CHC_DATEEMISSIONCHEQUE; }
			set {  _CHC_DATEEMISSIONCHEQUE = value; }
		}

		public string CHC_NOMTIREUR
		{
			get { return _CHC_NOMTIREUR; }
			set {  _CHC_NOMTIREUR = value; }
		}

		public string CHC_NOMTIRE
		{
			get { return _CHC_NOMTIRE; }
			set {  _CHC_NOMTIRE = value; }
		}

		public DateTime CHC_DATERECEPTIONCHEQUE
		{
			get { return _CHC_DATERECEPTIONCHEQUE; }
			set {  _CHC_DATERECEPTIONCHEQUE = value; }
		}

		public string CHC_NOMDUDEPOSANT
		{
			get { return _CHC_NOMDUDEPOSANT; }
			set {  _CHC_NOMDUDEPOSANT = value; }
		}

		public string CHC_TELEPHONEDEPOSANT
		{
			get { return _CHC_TELEPHONEDEPOSANT; }
			set {  _CHC_TELEPHONEDEPOSANT = value; }
		}

		public DateTime CHC_DATEEFFET
		{
			get { return _CHC_DATEEFFET; }
			set {  _CHC_DATEEFFET = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		

		public DateTime CHC_DATEVALIDATIONCHEQUE
		{
			get { return _CHC_DATEVALIDATIONCHEQUE; }
			set {  _CHC_DATEVALIDATIONCHEQUE = value; }
		}

		public double CHC_PRIMEAENCAISSER
		{
			get { return _CHC_PRIMEAENCAISSER; }
			set {  _CHC_PRIMEAENCAISSER = value; }
		}
        public int TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }


        public DateTime CHC_DATEDEBUTCOUVERTURE
        {
            get { return _CHC_DATEDEBUTCOUVERTURE; }
            set { _CHC_DATEDEBUTCOUVERTURE = value; }
        }
        public DateTime CHC_DATEFINCOUVERTURE
        {
            get { return _CHC_DATEFINCOUVERTURE; }
            set { _CHC_DATEFINCOUVERTURE = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsCtcontratchequereglementcaisse(){}

		public clsCtcontratchequereglementcaisse(clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse)
		{
			this.AG_CODEAGENCE = clsCtcontratchequereglementcaisse.AG_CODEAGENCE;
			this.CHC_DATESAISIECHEQUE = clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE;
			this.CHC_IDEXCHEQUE = clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE;
			this.EN_CODEENTREPOT = clsCtcontratchequereglementcaisse.EN_CODEENTREPOT;
			this.AB_CODEAGENCEBANCAIRE = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE;
			this.AB_CODEAGENCEBANCAIREASSUREUR = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIREASSUREUR;
			this.CA_CODECONTRAT = clsCtcontratchequereglementcaisse.CA_CODECONTRAT;
			this.MV_NUMPIECE = clsCtcontratchequereglementcaisse.MV_NUMPIECE;
			this.CHC_REFCHEQUE = clsCtcontratchequereglementcaisse.CHC_REFCHEQUE;
			this.CHC_VALEURCHEQUE = clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE;
			this.CHC_DATEANNULATIONCHEQUE = clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE;
			this.CHC_DATEEMISSIONCHEQUE = clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE;
			this.CHC_NOMTIREUR = clsCtcontratchequereglementcaisse.CHC_NOMTIREUR;
			this.CHC_NOMTIRE = clsCtcontratchequereglementcaisse.CHC_NOMTIRE;
			this.CHC_DATERECEPTIONCHEQUE = clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE;
			this.CHC_NOMDUDEPOSANT = clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT;
			this.CHC_TELEPHONEDEPOSANT = clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT;
			this.CHC_DATEEFFET = clsCtcontratchequereglementcaisse.CHC_DATEEFFET;
			this.OP_CODEOPERATEUR = clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR;
			this.CHC_DATEVALIDATIONCHEQUE = clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE;
			this.CHC_PRIMEAENCAISSER = clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER;
			this.TYPEOPERATION = clsCtcontratchequereglementcaisse.TYPEOPERATION;

            this.CHC_DATEDEBUTCOUVERTURE = clsCtcontratchequereglementcaisse.CHC_DATEDEBUTCOUVERTURE;
            this.CHC_DATEFINCOUVERTURE = clsCtcontratchequereglementcaisse.CHC_DATEFINCOUVERTURE;


        }

        #endregion

    }
}
