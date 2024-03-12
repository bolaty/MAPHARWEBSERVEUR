using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhapararticle : clsEntitieBase
    {

        private string _AR_CODEARTICLE = "";
		private string _AR_CODECIP = "";
		private string _AR_CODEBARRE = "";
		private string _RY_CODERAYON = "";
		private string _FO_CODEFORME = "";
		private string _TB_CODETABLEAU = "";
        private string _NT_CODENATURETYPEARTICLE = "";
		private string _TA_CODETYPEARTICLE = "";
        private string _TA_LIBELLE = "";
		private string _FA_CODEFABRICANT = "";
		private string _MO_CODEMODEL = "";
		private string _MA_CODEMARQUE = "";
		private string _DA_CODEDESTINATION = "";
		private string _UN_CODEUNITE = "";
		private string _AR_NOMCOMMERCIALE = "";
		private string _AR_NOMSCIENTIFIQUE = "";
		private string _AR_DESCRIPTION = "";
		private string _AR_CONDITIONNEMENT = "";
        private string _AR_CONTENANCE = "0";
		private string _AR_SEUILMINI = "0";
		private string _AR_SEUILMAXI = "0";
		private string _AR_RATTACHE = "";
		private string _AR_STATUT = "";
		private string _AR_ASDI = "";
		private string _AR_TVA = "";
        private string _AR_QUANTIFIABLE = "O";
		private string _AR_DUREEGARANTIE = "0";
		private string _AR_TAUXCOMMISSION = "0";
		private string _AR_MONTANTCOMMISSION = "0";
		private string _AR_TAUXREMISE = "0";
		private string _AR_MONTANTTOTALREMISE = "0";
		private string _AR_DATEREMISE1 = "01/01/1900";
		private string _AR_DATEREMISE2 = "01/01/1900";
		private string _AR_DATECLOTURE = "01/01/1900";
        private string _AR_DATECREATION ="01/01/1900";
		private string _AR_REPORTSORTIE = "0";
		private string _AR_REPORTENTREE = "0";
		private string _AR_NOMBREPERIODEPRECEDENTSORTIE = "0";
		private string _AR_NOMBREPERIODEPRECEDENTENTREE = "0";
		private string _AR_NOMBREPERIODESORTIEENCOURS = "0";
		private string _AR_NOMBREPERIODEENTREEENCOURS = "0";
		private string _AR_NOMBRESTOCKFINALSORTIE = "0";
		private string _AR_NOMBRESTOCKFINALENTREE = "0";
        private string _PRIXARTICLE = "0";
        private string _AR_MONTANTVERSE = "0";
        private string _PH_PHOTO = "";
        //private string _TYPEOPERATION = "";
        private string _AR_NUMEROORDRE = "0";
        private string _AR_PAOBLIGATOIRE = "";
        private string _AR_PVOBLIGATOIRE = "";
        private string _IN_CODEINGREDIENT = "";
        private string _AR_DATEPREMIEREMISEENSERVICE = "01/01/1900";

        private string _IN_CODETYPEARTICLE = "";
        private string _AR_PRESENTATIONPRODUIT = "";
        private string    _AR_COLLISAGE = "0";
        private string _MF_IDFILTRAGEDESTOCK ="";
        private string _ME_IDFILTRAGEDESTOCKEXPIRATION = "";
        private string _MF_IDFILTRAGEDESTOCKM1 = "";
        private string _MF_IDFILTRAGEDESTOCKM2 = "";



        private string _MF_NUMEROLOTFILTRAGEDESTOCK = "";
        private string _ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = "";
        private string _MF_DATEFABRICATIONFILTRAGEDESTOCKM1 ="";
        private string _MF_NUMEROLOTFILTRAGEDESTOCKM2 = "";


        private string _AR_PERISSABLE = "";
        private string _AR_DUREEPEREMPTION = "0";
        private string _AR_STATUTARTICLEPERIME = "N";
        private string _CF_CODECOEFICIENT = "";


        public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set { _AR_CODEARTICLE = value; }
		}
		public string AR_CODECIP
		{
			get { return _AR_CODECIP; }
			set { _AR_CODECIP = value; }
		}
		public string AR_CODEBARRE
		{
			get { return _AR_CODEBARRE; }
			set { _AR_CODEBARRE = value; }
		}
		public string RY_CODERAYON
		{
			get { return _RY_CODERAYON; }
			set { _RY_CODERAYON = value; }
		}
		public string FO_CODEFORME
		{
			get { return _FO_CODEFORME; }
			set { _FO_CODEFORME = value; }
		}
		public string TB_CODETABLEAU
		{
			get { return _TB_CODETABLEAU; }
			set { _TB_CODETABLEAU = value; }
		}

        public string NT_CODENATURETYPEARTICLE
		{
            get { return _NT_CODENATURETYPEARTICLE; }
            set { _NT_CODENATURETYPEARTICLE = value; }
		}
		public string TA_CODETYPEARTICLE
		{
			get { return _TA_CODETYPEARTICLE; }
			set { _TA_CODETYPEARTICLE = value; }
		}

        public string TA_LIBELLE
		{
            get { return _TA_LIBELLE; }
            set { _TA_LIBELLE = value; }
		}


		public string FA_CODEFABRICANT
		{
			get { return _FA_CODEFABRICANT; }
			set { _FA_CODEFABRICANT = value; }
		}
		public string MO_CODEMODEL
		{
			get { return _MO_CODEMODEL; }
			set { _MO_CODEMODEL = value; }
		}
		public string MA_CODEMARQUE
		{
			get { return _MA_CODEMARQUE; }
			set { _MA_CODEMARQUE = value; }
		}
		public string DA_CODEDESTINATION
		{
			get { return _DA_CODEDESTINATION; }
			set { _DA_CODEDESTINATION = value; }
		}
		public string UN_CODEUNITE
		{
			get { return _UN_CODEUNITE; }
			set { _UN_CODEUNITE = value; }
		}
		public string AR_NOMCOMMERCIALE
		{
			get { return _AR_NOMCOMMERCIALE; }
			set { _AR_NOMCOMMERCIALE = value; }
		}
		public string AR_NOMSCIENTIFIQUE
		{
			get { return _AR_NOMSCIENTIFIQUE; }
			set { _AR_NOMSCIENTIFIQUE = value; }
		}
		public string AR_DESCRIPTION
		{
			get { return _AR_DESCRIPTION; }
			set { _AR_DESCRIPTION = value; }
		}
		public string AR_CONDITIONNEMENT
		{
			get { return _AR_CONDITIONNEMENT; }
			set { _AR_CONDITIONNEMENT = value; }
		}
		public string AR_CONTENANCE
		{
			get { return _AR_CONTENANCE; }
			set { _AR_CONTENANCE = value; }
		}
		public string AR_SEUILMINI
		{
			get { return _AR_SEUILMINI; }
			set { _AR_SEUILMINI = value; }
		}
		public string AR_SEUILMAXI
		{
			get { return _AR_SEUILMAXI; }
			set { _AR_SEUILMAXI = value; }
		}
		public string AR_RATTACHE
		{
			get { return _AR_RATTACHE; }
			set { _AR_RATTACHE = value; }
		}
		public string AR_STATUT
		{
			get { return _AR_STATUT; }
			set { _AR_STATUT = value; }
		}
		public string AR_ASDI
		{
			get { return _AR_ASDI; }
			set { _AR_ASDI = value; }
		}
		public string AR_TVA
		{
			get { return _AR_TVA; }
			set { _AR_TVA = value; }
		}
        public string AR_QUANTIFIABLE
		{
            get { return _AR_QUANTIFIABLE; }
            set { _AR_QUANTIFIABLE = value; }
		}
		public string AR_DUREEGARANTIE
		{
			get { return _AR_DUREEGARANTIE; }
			set { _AR_DUREEGARANTIE = value; }
		}
		public string AR_TAUXCOMMISSION
		{
			get { return _AR_TAUXCOMMISSION; }
			set { _AR_TAUXCOMMISSION = value; }
		}
		public string AR_MONTANTCOMMISSION
		{
			get { return _AR_MONTANTCOMMISSION; }
			set { _AR_MONTANTCOMMISSION = value; }
		}
		public string AR_TAUXREMISE
		{
			get { return _AR_TAUXREMISE; }
			set { _AR_TAUXREMISE = value; }
		}
		public string AR_MONTANTTOTALREMISE
		{
			get { return _AR_MONTANTTOTALREMISE; }
			set { _AR_MONTANTTOTALREMISE = value; }
		}
		public string AR_DATEREMISE1
		{
			get { return _AR_DATEREMISE1; }
			set { _AR_DATEREMISE1 = value; }
		}
		public string AR_DATEREMISE2
		{
			get { return _AR_DATEREMISE2; }
			set { _AR_DATEREMISE2 = value; }
		}
		public string AR_DATECLOTURE
		{
			get { return _AR_DATECLOTURE; }
			set { _AR_DATECLOTURE = value; }
		}
        public string AR_DATECREATION
		{
            get { return _AR_DATECREATION; }
            set { _AR_DATECREATION = value; }
		}
		public string AR_REPORTSORTIE
		{
			get { return _AR_REPORTSORTIE; }
			set { _AR_REPORTSORTIE = value; }
		}
		public string AR_REPORTENTREE
		{
			get { return _AR_REPORTENTREE; }
			set { _AR_REPORTENTREE = value; }
		}
		public string AR_NOMBREPERIODEPRECEDENTSORTIE
		{
			get { return _AR_NOMBREPERIODEPRECEDENTSORTIE; }
			set { _AR_NOMBREPERIODEPRECEDENTSORTIE = value; }
		}
		public string AR_NOMBREPERIODEPRECEDENTENTREE
		{
			get { return _AR_NOMBREPERIODEPRECEDENTENTREE; }
			set { _AR_NOMBREPERIODEPRECEDENTENTREE = value; }
		}
		public string AR_NOMBREPERIODESORTIEENCOURS
		{
			get { return _AR_NOMBREPERIODESORTIEENCOURS; }
			set { _AR_NOMBREPERIODESORTIEENCOURS = value; }
		}
		public string AR_NOMBREPERIODEENTREEENCOURS
		{
			get { return _AR_NOMBREPERIODEENTREEENCOURS; }
			set { _AR_NOMBREPERIODEENTREEENCOURS = value; }
		}
		public string AR_NOMBRESTOCKFINALSORTIE
		{
			get { return _AR_NOMBRESTOCKFINALSORTIE; }
			set { _AR_NOMBRESTOCKFINALSORTIE = value; }
		}
        public string AR_NOMBRESTOCKFINALENTREE
        {
            get { return _AR_NOMBRESTOCKFINALENTREE; }
            set { _AR_NOMBRESTOCKFINALENTREE = value; }
        }

        public string PRIXARTICLE
        {
            get { return _PRIXARTICLE; }
            set { _PRIXARTICLE = value; }
        }

        public string AR_MONTANTVERSE
        {
            get { return _AR_MONTANTVERSE; }
            set { _AR_MONTANTVERSE = value; }
        }

        public string PH_PHOTO
        {
            get { return _PH_PHOTO; }
            set { _PH_PHOTO = value; }
        }
        //public string TYPEOPERATION
        //{
        //    get { return _TYPEOPERATION; }
        //    set { _TYPEOPERATION = value; }
        //}
        public string AR_NUMEROORDRE
        {
            get { return _AR_NUMEROORDRE; }
            set { _AR_NUMEROORDRE = value; }
        }
     

        public string IN_CODETYPEARTICLE
        {
            get { return _IN_CODETYPEARTICLE; }
            set { _IN_CODETYPEARTICLE = value; }
        }

        public string PR_CODEPRESENTATION
        {
            get { return _AR_PRESENTATIONPRODUIT; }
            set { _AR_PRESENTATIONPRODUIT = value; }
        }

        public string AR_PAOBLIGATOIRE
        {
            get { return _AR_PAOBLIGATOIRE; }
            set { _AR_PAOBLIGATOIRE = value; }
        }
        public string AR_PVOBLIGATOIRE
        {
            get { return _AR_PVOBLIGATOIRE; }
            set { _AR_PVOBLIGATOIRE = value; }
        }

        public string IN_CODEINGREDIENT
        {
            get { return _IN_CODEINGREDIENT; }
            set { _IN_CODEINGREDIENT = value; }
        }

        public string AR_DATEPREMIEREMISEENSERVICE
        {
            get { return _AR_DATEPREMIEREMISEENSERVICE; }
            set { _AR_DATEPREMIEREMISEENSERVICE = value; }
        }
        public string AR_COLLISAGE
        {
            get { return _AR_COLLISAGE; }
            set { _AR_COLLISAGE = value; }
        }



        public string MF_IDFILTRAGEDESTOCK
        {
            get { return _MF_IDFILTRAGEDESTOCK; }
            set { _MF_IDFILTRAGEDESTOCK = value; }
        }

        public string ME_IDFILTRAGEDESTOCKEXPIRATION
        {
            get { return _ME_IDFILTRAGEDESTOCKEXPIRATION; }
            set { _ME_IDFILTRAGEDESTOCKEXPIRATION = value; }
        }
        public string MF_IDFILTRAGEDESTOCKM1
        {
            get { return _MF_IDFILTRAGEDESTOCKM1; }
            set { _MF_IDFILTRAGEDESTOCKM1 = value; }
        }

        public string MF_IDFILTRAGEDESTOCKM2
        {
            get { return _MF_IDFILTRAGEDESTOCKM2; }
            set { _MF_IDFILTRAGEDESTOCKM2 = value; }
        }

        public string MF_NUMEROLOTFILTRAGEDESTOCK
        {
            get { return _MF_NUMEROLOTFILTRAGEDESTOCK; }
            set { _MF_NUMEROLOTFILTRAGEDESTOCK = value; }
        }

        public string ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION
        {
            get { return _ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION; }
            set { _ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = value; }
        }
        public string MF_DATEFABRICATIONFILTRAGEDESTOCKM1
        {
            get { return _MF_DATEFABRICATIONFILTRAGEDESTOCKM1; }
            set { _MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = value; }
        }

        public string MF_NUMEROLOTFILTRAGEDESTOCKM2
        {
            get { return _MF_NUMEROLOTFILTRAGEDESTOCKM2; }
            set { _MF_NUMEROLOTFILTRAGEDESTOCKM2 = value; }
        }

        public string AR_PERISSABLE
        {
            get { return _AR_PERISSABLE; }
            set { _AR_PERISSABLE = value; }
        }

        public string AR_DUREEPEREMPTION
        {
            get { return _AR_DUREEPEREMPTION; }
            set { _AR_DUREEPEREMPTION = value; }
        }
        public String AR_STATUTARTICLEPERIME
        {
            get { return _AR_STATUTARTICLEPERIME; }
            set { _AR_STATUTARTICLEPERIME = value; }
        }

        public String CF_CODECOEFICIENT
        {
            get { return _CF_CODECOEFICIENT; }
            set { _CF_CODECOEFICIENT = value; }
        }
        public clsPhapararticle() { }

        
       

		public clsPhapararticle(clsPhapararticle clsPhapararticle)
		{
			AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
			AR_CODECIP = clsPhapararticle.AR_CODECIP;
			AR_CODEBARRE = clsPhapararticle.AR_CODEBARRE;
			RY_CODERAYON = clsPhapararticle.RY_CODERAYON;
			FO_CODEFORME = clsPhapararticle.FO_CODEFORME;
			TB_CODETABLEAU = clsPhapararticle.TB_CODETABLEAU;
            NT_CODENATURETYPEARTICLE = clsPhapararticle.NT_CODENATURETYPEARTICLE;
			TA_CODETYPEARTICLE = clsPhapararticle.TA_CODETYPEARTICLE;
            TA_LIBELLE = clsPhapararticle.TA_LIBELLE;

			FA_CODEFABRICANT = clsPhapararticle.FA_CODEFABRICANT;
			MO_CODEMODEL = clsPhapararticle.MO_CODEMODEL;
			MA_CODEMARQUE = clsPhapararticle.MA_CODEMARQUE;
			DA_CODEDESTINATION = clsPhapararticle.DA_CODEDESTINATION;
			UN_CODEUNITE = clsPhapararticle.UN_CODEUNITE;
			AR_NOMCOMMERCIALE = clsPhapararticle.AR_NOMCOMMERCIALE;
			AR_NOMSCIENTIFIQUE = clsPhapararticle.AR_NOMSCIENTIFIQUE;
			AR_DESCRIPTION = clsPhapararticle.AR_DESCRIPTION;
			AR_CONDITIONNEMENT = clsPhapararticle.AR_CONDITIONNEMENT;
			AR_CONTENANCE = clsPhapararticle.AR_CONTENANCE;
			AR_SEUILMINI = clsPhapararticle.AR_SEUILMINI;
			AR_SEUILMAXI = clsPhapararticle.AR_SEUILMAXI;
			AR_RATTACHE = clsPhapararticle.AR_RATTACHE;
			AR_STATUT = clsPhapararticle.AR_STATUT;
			AR_ASDI = clsPhapararticle.AR_ASDI;
			AR_TVA = clsPhapararticle.AR_TVA;
            AR_QUANTIFIABLE = clsPhapararticle.AR_QUANTIFIABLE;
			AR_DUREEGARANTIE = clsPhapararticle.AR_DUREEGARANTIE;
			AR_TAUXCOMMISSION = clsPhapararticle.AR_TAUXCOMMISSION;
			AR_MONTANTCOMMISSION = clsPhapararticle.AR_MONTANTCOMMISSION;
			AR_TAUXREMISE = clsPhapararticle.AR_TAUXREMISE;
			AR_MONTANTTOTALREMISE = clsPhapararticle.AR_MONTANTTOTALREMISE;
			AR_DATEREMISE1 = clsPhapararticle.AR_DATEREMISE1;
			AR_DATEREMISE2 = clsPhapararticle.AR_DATEREMISE2;
			AR_DATECLOTURE = clsPhapararticle.AR_DATECLOTURE;
            AR_DATECREATION = clsPhapararticle.AR_DATECREATION;
			AR_REPORTSORTIE = clsPhapararticle.AR_REPORTSORTIE;
			AR_REPORTENTREE = clsPhapararticle.AR_REPORTENTREE;
			AR_NOMBREPERIODEPRECEDENTSORTIE = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTSORTIE;
			AR_NOMBREPERIODEPRECEDENTENTREE = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTENTREE;
			AR_NOMBREPERIODESORTIEENCOURS = clsPhapararticle.AR_NOMBREPERIODESORTIEENCOURS;
			AR_NOMBREPERIODEENTREEENCOURS = clsPhapararticle.AR_NOMBREPERIODEENTREEENCOURS;
			AR_NOMBRESTOCKFINALSORTIE = clsPhapararticle.AR_NOMBRESTOCKFINALSORTIE;
			AR_NOMBRESTOCKFINALENTREE = clsPhapararticle.AR_NOMBRESTOCKFINALENTREE;
            PH_PHOTO = clsPhapararticle.PH_PHOTO;
            //TYPEOPERATION = clsPhapararticle.TYPEOPERATION;
            AR_NUMEROORDRE = clsPhapararticle.AR_NUMEROORDRE;
            IN_CODETYPEARTICLE = clsPhapararticle.IN_CODETYPEARTICLE;
            PR_CODEPRESENTATION = clsPhapararticle.PR_CODEPRESENTATION;
            AR_PAOBLIGATOIRE = clsPhapararticle.AR_PAOBLIGATOIRE;
            AR_PVOBLIGATOIRE = clsPhapararticle.AR_PVOBLIGATOIRE;
            IN_CODEINGREDIENT = clsPhapararticle.IN_CODEINGREDIENT;
            AR_DATEPREMIEREMISEENSERVICE = clsPhapararticle.AR_DATEPREMIEREMISEENSERVICE;
            AR_COLLISAGE = clsPhapararticle.AR_COLLISAGE;
            MF_IDFILTRAGEDESTOCK = clsPhapararticle.MF_IDFILTRAGEDESTOCK;
            ME_IDFILTRAGEDESTOCKEXPIRATION = clsPhapararticle.ME_IDFILTRAGEDESTOCKEXPIRATION;
            MF_IDFILTRAGEDESTOCKM1 = clsPhapararticle.MF_IDFILTRAGEDESTOCKM1;
            MF_IDFILTRAGEDESTOCKM2 = clsPhapararticle.MF_IDFILTRAGEDESTOCKM2;

            MF_NUMEROLOTFILTRAGEDESTOCK = clsPhapararticle.MF_NUMEROLOTFILTRAGEDESTOCK;
            ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = clsPhapararticle.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION;
            MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = clsPhapararticle.MF_DATEFABRICATIONFILTRAGEDESTOCKM1;
            MF_NUMEROLOTFILTRAGEDESTOCKM2 = clsPhapararticle.MF_NUMEROLOTFILTRAGEDESTOCKM2;
            AR_PERISSABLE = clsPhapararticle.AR_PERISSABLE;
            AR_DUREEPEREMPTION = clsPhapararticle.AR_DUREEPEREMPTION;
            AR_STATUTARTICLEPERIME = clsPhapararticle.AR_STATUTARTICLEPERIME;
            CF_CODECOEFICIENT = clsPhapararticle.CF_CODECOEFICIENT;

        }

    }
}