using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaentrevehicule
	{
		#region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private decimal _RV_IDENTREE = 0;
		private DateTime _RV_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _MS_NUMPIECE = "";
		private string _TI_IDTIERS = "";
		private string _AR_CODEARTICLE = "";
		private DateTime _RV_DATEPROCHAINEVISITETECH = DateTime.Parse("01/01/1900");
        private DateTime _RV_DATEPROCHAINEVIDANGE = DateTime.Parse("01/01/1900");
		private DateTime _RV_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _RV_DATEFIN = DateTime.Parse("01/01/1900");
		private DateTime _RV_DATECLOTURE = DateTime.Parse("01/01/1900");
        private string _RV_COMPTEENTREPRISE = "N";
        private string _RV_COMPTEPARTICULIER = "N";
        private string _RV_RECEPTEUR = "";
        private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

		public decimal RV_IDENTREE
		{
			get { return _RV_IDENTREE; }
			set {  _RV_IDENTREE = value; }
		}

		public DateTime RV_DATESAISIE
		{
			get { return _RV_DATESAISIE; }
			set {  _RV_DATESAISIE = value; }
		}

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set {  _MS_NUMPIECE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public DateTime RV_DATEPROCHAINEVISITETECH
		{
			get { return _RV_DATEPROCHAINEVISITETECH; }
			set {  _RV_DATEPROCHAINEVISITETECH = value; }
		}

        public DateTime RV_DATEPROCHAINEVIDANGE
		{
            get { return _RV_DATEPROCHAINEVIDANGE; }
            set { _RV_DATEPROCHAINEVIDANGE = value; }
		}

		public DateTime RV_DATEDEBUT
		{
			get { return _RV_DATEDEBUT; }
			set {  _RV_DATEDEBUT = value; }
		}

		public DateTime RV_DATEFIN
		{
			get { return _RV_DATEFIN; }
			set {  _RV_DATEFIN = value; }
		}

		public DateTime RV_DATECLOTURE
		{
			get { return _RV_DATECLOTURE; }
			set {  _RV_DATECLOTURE = value; }
		}

        public string RV_COMPTEENTREPRISE
        {
            get { return _RV_COMPTEENTREPRISE; }
            set { _RV_COMPTEENTREPRISE = value; }
        }
        public string RV_COMPTEPARTICULIER 
        {
            get { return _RV_COMPTEPARTICULIER; }
            set { _RV_COMPTEPARTICULIER = value; }
        }

        public string RV_RECEPTEUR 
        {
            get { return _RV_RECEPTEUR; }
            set { _RV_RECEPTEUR = value; }
        }

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsPhaentrevehicule(){}
		
		public clsPhaentrevehicule(clsPhaentrevehicule clsPhaentrevehicule)
		{
            this.AG_CODEAGENCE = clsPhaentrevehicule.AG_CODEAGENCE;
			this.RV_IDENTREE = clsPhaentrevehicule.RV_IDENTREE;
			this.RV_DATESAISIE = clsPhaentrevehicule.RV_DATESAISIE;
			this.MS_NUMPIECE = clsPhaentrevehicule.MS_NUMPIECE;
			this.TI_IDTIERS = clsPhaentrevehicule.TI_IDTIERS;
			this.AR_CODEARTICLE = clsPhaentrevehicule.AR_CODEARTICLE;
			this.RV_DATEPROCHAINEVISITETECH = clsPhaentrevehicule.RV_DATEPROCHAINEVISITETECH;
            this.RV_DATEPROCHAINEVIDANGE = clsPhaentrevehicule.RV_DATEPROCHAINEVIDANGE;
			this.RV_DATEDEBUT = clsPhaentrevehicule.RV_DATEDEBUT;
			this.RV_DATEFIN = clsPhaentrevehicule.RV_DATEFIN;
			this.RV_DATECLOTURE = clsPhaentrevehicule.RV_DATECLOTURE;
            this.RV_COMPTEENTREPRISE = clsPhaentrevehicule.RV_COMPTEENTREPRISE;
            this.RV_COMPTEPARTICULIER = clsPhaentrevehicule.RV_COMPTEPARTICULIER;
            this.RV_RECEPTEUR = clsPhaentrevehicule.RV_RECEPTEUR;
            this.OP_CODEOPERATEUR = clsPhaentrevehicule.OP_CODEOPERATEUR;


		}

		#endregion

	}
}
