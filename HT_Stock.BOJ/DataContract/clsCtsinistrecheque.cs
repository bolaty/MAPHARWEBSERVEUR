using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtsinistrecheque : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CH_DATESAISIECHEQUE = "";
		private string _CH_IDEXCHEQUE = "";
		private string _EN_CODEENTREPOT = "";
		private string _AB_CODEAGENCEBANCAIRE = "";
		private string _CA_CODECONTRAT = "";
		private string _SI_CODESINISTRE = "";
		private string _CH_REFCHEQUE = "";
		private string _CH_VALEURCHEQUE = "0";
		private string _CH_DATEANNULATIONCHEQUE = "";
		private string _CH_DATEEMISSIONCHEQUE = "";
		private string _CH_NOMTIREUR = "";
		private string _CH_NOMTIRE = "";
		private string _CH_DATERECEPTIONCHEQUE = "";
		private string _CH_NOMDUDEPOSANT = "";
		private string _CH_TELEPHONEDEPOSANT = "";
		private string _CH_DATEEFFET = "";
		private string _OP_CODEOPERATEUR = "";
		private string _CH_DATEVALIDATIONCHEQUE = "";
		private string _CH_PRIMEAENCAISSER = "0";
		private string _AB_LIBELLE = "";
		private string _BQ_CODEBANQUE = "";
		private string _BQ_RAISONSOCIAL = "";
		private string _BQ_SIGLE = "";
		private string _MS_NUMPIECE = "";
		private string _MV_NOMTIERS = "";
		private string _TI_NUMTIERS = "";
		private string _PL_NUMCOMPTE = "";
		private string _PL_NUMCOMPTEBANQUE = "";





		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string CH_DATESAISIECHEQUE
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

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}
		public string SI_CODESINISTRE
        {
			get { return _SI_CODESINISTRE; }
			set { _SI_CODESINISTRE = value; }
		}

		public string CH_REFCHEQUE
		{
			get { return _CH_REFCHEQUE; }
			set {  _CH_REFCHEQUE = value; }
		}

		public string CH_VALEURCHEQUE
		{
			get { return _CH_VALEURCHEQUE; }
			set {  _CH_VALEURCHEQUE = value; }
		}

		public string CH_DATEANNULATIONCHEQUE
		{
			get { return _CH_DATEANNULATIONCHEQUE; }
			set {  _CH_DATEANNULATIONCHEQUE = value; }
		}

		public string CH_DATEEMISSIONCHEQUE
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

		public string CH_DATERECEPTIONCHEQUE
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

		public string CH_DATEEFFET
		{
			get { return _CH_DATEEFFET; }
			set {  _CH_DATEEFFET = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		public string CH_DATEVALIDATIONCHEQUE
		{
			get { return _CH_DATEVALIDATIONCHEQUE; }
			set {  _CH_DATEVALIDATIONCHEQUE = value; }
		}

		public string CH_PRIMEAENCAISSER
		{
			get { return _CH_PRIMEAENCAISSER; }
			set {  _CH_PRIMEAENCAISSER = value; }
		}
		public string AB_LIBELLE
        {
			get { return _AB_LIBELLE; }
			set { _AB_LIBELLE = value; }
		}
		public string BQ_CODEBANQUE
        {
			get { return _BQ_CODEBANQUE; }
			set { _BQ_CODEBANQUE = value; }
		}
		public string BQ_RAISONSOCIAL
        {
			get { return _BQ_RAISONSOCIAL; }
			set { _BQ_RAISONSOCIAL = value; }
		}
		public string BQ_SIGLE
        {
			get { return _BQ_SIGLE; }
			set { _BQ_SIGLE = value; }
		}


        public string MS_NUMPIECE
        {
            get { return _MS_NUMPIECE; }
            set { _MS_NUMPIECE = value; }
        }
        public string MV_NOMTIERS
        {
            get { return _MV_NOMTIERS; }
            set { _MV_NOMTIERS = value; }
        }
        public string TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }



        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }
        public string PL_NUMCOMPTEBANQUE
        {
            get { return _PL_NUMCOMPTEBANQUE; }
            set { _PL_NUMCOMPTEBANQUE = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsCtsinistrecheque(){}
	
		public clsCtsinistrecheque(clsCtsinistrecheque clsCtsinistrecheque)
		{
			this.AG_CODEAGENCE = clsCtsinistrecheque.AG_CODEAGENCE;
			this.CH_DATESAISIECHEQUE = clsCtsinistrecheque.CH_DATESAISIECHEQUE;
			this.CH_IDEXCHEQUE = clsCtsinistrecheque.CH_IDEXCHEQUE;
			this.EN_CODEENTREPOT = clsCtsinistrecheque.EN_CODEENTREPOT;
			this.AB_CODEAGENCEBANCAIRE = clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE;
			this.CA_CODECONTRAT = clsCtsinistrecheque.CA_CODECONTRAT;
			this.SI_CODESINISTRE = clsCtsinistrecheque.SI_CODESINISTRE;
			this.CH_REFCHEQUE = clsCtsinistrecheque.CH_REFCHEQUE;
			this.CH_VALEURCHEQUE = clsCtsinistrecheque.CH_VALEURCHEQUE;
			this.CH_DATEANNULATIONCHEQUE = clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE;
			this.CH_DATEEMISSIONCHEQUE = clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE;
			this.CH_NOMTIREUR = clsCtsinistrecheque.CH_NOMTIREUR;
			this.CH_NOMTIRE = clsCtsinistrecheque.CH_NOMTIRE;
			this.CH_DATERECEPTIONCHEQUE = clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE;
			this.CH_NOMDUDEPOSANT = clsCtsinistrecheque.CH_NOMDUDEPOSANT;
			this.CH_TELEPHONEDEPOSANT = clsCtsinistrecheque.CH_TELEPHONEDEPOSANT;
			this.CH_DATEEFFET = clsCtsinistrecheque.CH_DATEEFFET;
			this.OP_CODEOPERATEUR = clsCtsinistrecheque.OP_CODEOPERATEUR;
			this.CH_DATEVALIDATIONCHEQUE = clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE;
			this.CH_PRIMEAENCAISSER = clsCtsinistrecheque.CH_PRIMEAENCAISSER;
			this.AB_LIBELLE = clsCtsinistrecheque.AB_LIBELLE;
			this.BQ_CODEBANQUE = clsCtsinistrecheque.BQ_CODEBANQUE;
			this.BQ_RAISONSOCIAL = clsCtsinistrecheque.BQ_RAISONSOCIAL;
			this.BQ_SIGLE = clsCtsinistrecheque.BQ_SIGLE;
			this.MS_NUMPIECE = clsCtsinistrecheque.MS_NUMPIECE;
			this.MV_NOMTIERS = clsCtsinistrecheque.MV_NOMTIERS;
			this.TI_NUMTIERS = clsCtsinistrecheque.TI_NUMTIERS;
			this.PL_NUMCOMPTE = clsCtsinistrecheque.PL_NUMCOMPTE;
			this.PL_NUMCOMPTEBANQUE = clsCtsinistrecheque.PL_NUMCOMPTEBANQUE;
            //private string _MS_NUMPIECE = "";
            //private string _MV_NOMTIERS = "";
            //private string _TI_NUMTIERS = "";
            //private string _PL_NUMCOMPTE = "";
            //private string _PL_NUMCOMPTEBANQUE = "";


        }

        #endregion

    }
}
