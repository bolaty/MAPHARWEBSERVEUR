using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsBienimmobilise
	{
		#region VARIABLES LOCALES

		private string _TI_IDTIERS = "";
		private string _TI_NUMEROTIERS = "";
		private string _AG_CODEAGENCE = "";
		private string _RC_CODERAISONDEPART = "";
		private string _OP_CODEOPERATEUR = "";
		private string _TI_NOMTIERS = "";
		private DateTime _TI_DATECREATION = DateTime.Parse("01/01/1900");
		private DateTime _TI_DATEDEPART = DateTime.Parse("01/01/1900");
		private string _TI_DESCRIPTIONRAISONDEPART = "";
		private string _SR_CODESERVICE = "";
		private string _TI_IDTIERSCODEFOURNISSEUR ="";
		private string _SF_CODESOURCEFINANCEMENT = "";
		private string _PS_CODESOUSPRODUIT = "";
		private string _IM_NUMEROSERIE = "";
		private DateTime _IM_DATEACQUISITION = DateTime.Parse("01/01/1900");
		private DateTime _IM_DATEMISEENSERVICE = DateTime.Parse("01/01/1900");
		private double _IM_VALEURACQUISITION = 0;
		private string _IM_REFERENCEBONCOMMANDE = "";
		private string _IM_REFERENCEFACTURE = "";
		private string _IM_REFERENCEBONLIVRAISON = "";
		private DateTime _IM_DATEMISEAUREBUT = DateTime.Parse("01/01/1900");
		private DateTime _IM_DATECESSION = DateTime.Parse("01/01/1900");
		private double _IM_PRIXCESSION = 0;
		private double _IM_DUREE = 0;
		private double _IM_QUANTITE = 0;
		private string _IM_OBSERVATIONS = "";
		private string _TI_IDTIERSAVANTREPRISE ="";
		private string _TI_IDTIERSAVANTFACTUREAVOIR ="";
		private string _TI_CODETYPEAMORTISSEMENT = "";
        private string _OB_NOMOBJET = "";
        private double _IM_VALEURTVA = 0;
        private string _TC_CODETYPETIERS = "";

		#endregion

		#region ACCESSEURS

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string TI_NUMEROTIERS
		{
			get { return _TI_NUMEROTIERS; }
			set {  _TI_NUMEROTIERS = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string RC_CODERAISONDEPART
		{
			get { return _RC_CODERAISONDEPART; }
			set {  _RC_CODERAISONDEPART = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string TI_NOMTIERS
		{
			get { return _TI_NOMTIERS; }
			set {  _TI_NOMTIERS = value; }
		}

		public DateTime TI_DATECREATION
		{
			get { return _TI_DATECREATION; }
			set {  _TI_DATECREATION = value; }
		}

		public DateTime TI_DATEDEPART
		{
			get { return _TI_DATEDEPART; }
			set {  _TI_DATEDEPART = value; }
		}

		public string TI_DESCRIPTIONRAISONDEPART
		{
			get { return _TI_DESCRIPTIONRAISONDEPART; }
			set {  _TI_DESCRIPTIONRAISONDEPART = value; }
		}

		public string SR_CODESERVICE
		{
			get { return _SR_CODESERVICE; }
			set {  _SR_CODESERVICE = value; }
		}

		public string TI_IDTIERSCODEFOURNISSEUR
		{
			get { return _TI_IDTIERSCODEFOURNISSEUR; }
			set {  _TI_IDTIERSCODEFOURNISSEUR = value; }
		}

		public string SF_CODESOURCEFINANCEMENT
		{
			get { return _SF_CODESOURCEFINANCEMENT; }
			set {  _SF_CODESOURCEFINANCEMENT = value; }
		}

		public string PS_CODESOUSPRODUIT
		{
			get { return _PS_CODESOUSPRODUIT; }
			set {  _PS_CODESOUSPRODUIT = value; }
		}

		public string IM_NUMEROSERIE
		{
			get { return _IM_NUMEROSERIE; }
			set {  _IM_NUMEROSERIE = value; }
		}

		public DateTime IM_DATEACQUISITION
		{
			get { return _IM_DATEACQUISITION; }
			set {  _IM_DATEACQUISITION = value; }
		}

		public DateTime IM_DATEMISEENSERVICE
		{
			get { return _IM_DATEMISEENSERVICE; }
			set {  _IM_DATEMISEENSERVICE = value; }
		}

		public double IM_VALEURACQUISITION
		{
			get { return _IM_VALEURACQUISITION; }
			set {  _IM_VALEURACQUISITION = value; }
		}

		public string IM_REFERENCEBONCOMMANDE
		{
			get { return _IM_REFERENCEBONCOMMANDE; }
			set {  _IM_REFERENCEBONCOMMANDE = value; }
		}

		public string IM_REFERENCEFACTURE
		{
			get { return _IM_REFERENCEFACTURE; }
			set {  _IM_REFERENCEFACTURE = value; }
		}

		public string IM_REFERENCEBONLIVRAISON
		{
			get { return _IM_REFERENCEBONLIVRAISON; }
			set {  _IM_REFERENCEBONLIVRAISON = value; }
		}

		public DateTime IM_DATEMISEAUREBUT
		{
			get { return _IM_DATEMISEAUREBUT; }
			set {  _IM_DATEMISEAUREBUT = value; }
		}

		public DateTime IM_DATECESSION
		{
			get { return _IM_DATECESSION; }
			set {  _IM_DATECESSION = value; }
		}

		public double IM_PRIXCESSION
		{
			get { return _IM_PRIXCESSION; }
			set {  _IM_PRIXCESSION = value; }
		}

		public double IM_DUREE
		{
			get { return _IM_DUREE; }
			set {  _IM_DUREE = value; }
		}

		public double IM_QUANTITE
		{
			get { return _IM_QUANTITE; }
			set {  _IM_QUANTITE = value; }
		}

		public string IM_OBSERVATIONS
		{
			get { return _IM_OBSERVATIONS; }
			set {  _IM_OBSERVATIONS = value; }
		}

		public string TI_IDTIERSAVANTREPRISE
		{
			get { return _TI_IDTIERSAVANTREPRISE; }
			set {  _TI_IDTIERSAVANTREPRISE = value; }
		}

		public string TI_IDTIERSAVANTFACTUREAVOIR
		{
			get { return _TI_IDTIERSAVANTFACTUREAVOIR; }
			set {  _TI_IDTIERSAVANTFACTUREAVOIR = value; }
		}

		public string TI_CODETYPEAMORTISSEMENT
		{
			get { return _TI_CODETYPEAMORTISSEMENT; }
			set {  _TI_CODETYPEAMORTISSEMENT = value; }
		}

        public string OB_NOMOBJET
        {
	        get { return _OB_NOMOBJET; }
	        set { _OB_NOMOBJET = value; }
        }

        public double IM_VALEURTVA
        {
	        get { return _IM_VALEURTVA; }
	        set { _IM_VALEURTVA = value; }
        }
        public string TC_CODETYPETIERS
        {
	        get { return _TC_CODETYPETIERS; }
	        set { _TC_CODETYPETIERS = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsBienimmobilise(){}

		public clsBienimmobilise(clsBienimmobilise clsBienimmobilise)
		{
			this.TI_IDTIERS = clsBienimmobilise.TI_IDTIERS;
			this.TI_NUMEROTIERS = clsBienimmobilise.TI_NUMEROTIERS;
			this.AG_CODEAGENCE = clsBienimmobilise.AG_CODEAGENCE;
			this.RC_CODERAISONDEPART = clsBienimmobilise.RC_CODERAISONDEPART;
			this.OP_CODEOPERATEUR = clsBienimmobilise.OP_CODEOPERATEUR;
			this.TI_NOMTIERS = clsBienimmobilise.TI_NOMTIERS;
			this.TI_DATECREATION = clsBienimmobilise.TI_DATECREATION;
			this.TI_DATEDEPART = clsBienimmobilise.TI_DATEDEPART;
			this.TI_DESCRIPTIONRAISONDEPART = clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART;
			this.SR_CODESERVICE = clsBienimmobilise.SR_CODESERVICE;
			this.TI_IDTIERSCODEFOURNISSEUR = clsBienimmobilise.TI_IDTIERSCODEFOURNISSEUR;
			this.SF_CODESOURCEFINANCEMENT = clsBienimmobilise.SF_CODESOURCEFINANCEMENT;
			this.PS_CODESOUSPRODUIT = clsBienimmobilise.PS_CODESOUSPRODUIT;
			this.IM_NUMEROSERIE = clsBienimmobilise.IM_NUMEROSERIE;
			this.IM_DATEACQUISITION = clsBienimmobilise.IM_DATEACQUISITION;
			this.IM_DATEMISEENSERVICE = clsBienimmobilise.IM_DATEMISEENSERVICE;
			this.IM_VALEURACQUISITION = clsBienimmobilise.IM_VALEURACQUISITION;
			this.IM_REFERENCEBONCOMMANDE = clsBienimmobilise.IM_REFERENCEBONCOMMANDE;
			this.IM_REFERENCEFACTURE = clsBienimmobilise.IM_REFERENCEFACTURE;
			this.IM_REFERENCEBONLIVRAISON = clsBienimmobilise.IM_REFERENCEBONLIVRAISON;
			this.IM_DATEMISEAUREBUT = clsBienimmobilise.IM_DATEMISEAUREBUT;
			this.IM_DATECESSION = clsBienimmobilise.IM_DATECESSION;
			this.IM_PRIXCESSION = clsBienimmobilise.IM_PRIXCESSION;
			this.IM_DUREE = clsBienimmobilise.IM_DUREE;
			this.IM_QUANTITE = clsBienimmobilise.IM_QUANTITE;
			this.IM_OBSERVATIONS = clsBienimmobilise.IM_OBSERVATIONS;
			this.TI_IDTIERSAVANTREPRISE = clsBienimmobilise.TI_IDTIERSAVANTREPRISE;
			this.TI_IDTIERSAVANTFACTUREAVOIR = clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR;
			this.TI_CODETYPEAMORTISSEMENT = clsBienimmobilise.TI_CODETYPEAMORTISSEMENT;
            this.OB_NOMOBJET = clsBienimmobilise.OB_NOMOBJET;
            this.IM_VALEURTVA = clsBienimmobilise.IM_VALEURTVA;
            this.TC_CODETYPETIERS = clsBienimmobilise.TC_CODETYPETIERS;

		}

		#endregion

	}
}
