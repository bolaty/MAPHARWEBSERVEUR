using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsMicparametrelisteproduitsousproduitvaleur
	{
		#region VARIABLES LOCALES

		private double _LP_CODEPARAMETRELISTEVALEUR = 0;
		private string _AP_CODEPRODUIT = "";
		private string _PL_CODEPARAMETRELISTE = "";
        private double _LP_BORNEMIN = 0;
        private double _LP_BORNEMAX = 0;
        private decimal _LP_MONTANTMINI = 0;
        private decimal _LP_MONTANTMAXI = 0;
		private decimal _LP_TAUX = 0;
        private decimal _LP_MONTANT = 0;
        private decimal _LP_TAUXREMUNERATIONCOMMERCIAL = 0;
        private decimal _LP_MONTANTREMUNERATIONCOMMERCIAL = 0;
        private string _LP_VALEUR = "";
        private string _TP_CODETYPETIERS = "";
        private string _FM_CODEFORMEJURIDIQUE = "";
        private string _SX_CODESEXE = "";
        private int _TYPEOPERATION = 0;

		#endregion

		#region ACCESSEURS

		public double LP_CODEPARAMETRELISTEVALEUR
		{
			get { return _LP_CODEPARAMETRELISTEVALEUR; }
			set {  _LP_CODEPARAMETRELISTEVALEUR = value; }
		}

		public string AP_CODEPRODUIT
		{
			get { return _AP_CODEPRODUIT; }
			set {  _AP_CODEPRODUIT = value; }
		}

		public string PL_CODEPARAMETRELISTE
		{
			get { return _PL_CODEPARAMETRELISTE; }
			set {  _PL_CODEPARAMETRELISTE = value; }
		}

        public double LP_BORNEMIN
		{
			get { return _LP_BORNEMIN; }
			set {  _LP_BORNEMIN = value; }
		}

        public double LP_BORNEMAX
		{
			get { return _LP_BORNEMAX; }
			set {  _LP_BORNEMAX = value; }
		}

        public decimal LP_MONTANTMINI
		{
			get { return _LP_MONTANTMINI; }
			set {  _LP_MONTANTMINI = value; }
		}

        public decimal LP_MONTANTMAXI
		{
			get { return _LP_MONTANTMAXI; }
			set {  _LP_MONTANTMAXI = value; }
		}

		public decimal LP_TAUX
		{
			get { return _LP_TAUX; }
			set {  _LP_TAUX = value; }
		}

        public decimal LP_MONTANT
		{
			get { return _LP_MONTANT; }
			set {  _LP_MONTANT = value; }
		}

        public decimal LP_TAUXREMUNERATIONCOMMERCIAL
        {
	        get { return _LP_TAUXREMUNERATIONCOMMERCIAL; }
	        set { _LP_TAUXREMUNERATIONCOMMERCIAL = value; }
        }

        public decimal LP_MONTANTREMUNERATIONCOMMERCIAL
        {
	        get { return _LP_MONTANTREMUNERATIONCOMMERCIAL; }
	        set { _LP_MONTANTREMUNERATIONCOMMERCIAL = value; }
        }
     

        public string LP_VALEUR
		{
			get { return _LP_VALEUR; }
			set {  _LP_VALEUR = value; }
		}

        public string TP_CODETYPETIERS
        {
            get { return _TP_CODETYPETIERS; }
            set { _TP_CODETYPETIERS = value; }
        }

        public string FM_CODEFORMEJURIDIQUE
        {
            get { return _FM_CODEFORMEJURIDIQUE; }
            set { _FM_CODEFORMEJURIDIQUE = value; }
        }

        public string SX_CODESEXE
        {
            get { return _SX_CODESEXE; }
            set { _SX_CODESEXE = value; }
        }
       

        public int TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsMicparametrelisteproduitsousproduitvaleur(){}
      
		public clsMicparametrelisteproduitsousproduitvaleur(clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur)
		{
			this.LP_CODEPARAMETRELISTEVALEUR = clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR;
			this.AP_CODEPRODUIT = clsMicparametrelisteproduitsousproduitvaleur.AP_CODEPRODUIT;
			this.PL_CODEPARAMETRELISTE = clsMicparametrelisteproduitsousproduitvaleur.PL_CODEPARAMETRELISTE;
			this.LP_BORNEMIN = clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMIN;
			this.LP_BORNEMAX = clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMAX;
			this.LP_MONTANTMINI = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMINI;
			this.LP_MONTANTMAXI = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMAXI;
			this.LP_TAUX = clsMicparametrelisteproduitsousproduitvaleur.LP_TAUX;
			this.LP_MONTANT = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANT;
            this.LP_TAUXREMUNERATIONCOMMERCIAL = clsMicparametrelisteproduitsousproduitvaleur.LP_TAUXREMUNERATIONCOMMERCIAL;
            this.LP_MONTANTREMUNERATIONCOMMERCIAL = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTREMUNERATIONCOMMERCIAL;
			this.LP_VALEUR = clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR;
            this.TP_CODETYPETIERS = clsMicparametrelisteproduitsousproduitvaleur.TP_CODETYPETIERS;
            this.FM_CODEFORMEJURIDIQUE = clsMicparametrelisteproduitsousproduitvaleur.FM_CODEFORMEJURIDIQUE;
            this.SX_CODESEXE = clsMicparametrelisteproduitsousproduitvaleur.SX_CODESEXE;
            this.TYPEOPERATION = clsMicparametrelisteproduitsousproduitvaleur.TYPEOPERATION;
		}

		#endregion

	}
}
