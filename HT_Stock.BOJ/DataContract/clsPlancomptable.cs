using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPlancomptable : clsEntitieBase
    {

        private string _SO_CODESOCIETE = "";
		private string _PL_CODENUMCOMPTE = "";
        private string _NC_CODENATURECOMPTE = "";
        private string _PL_FOCUSTIERS = "N";
		private string _PL_NUMCOMPTE = "";
		private string _PL_LIBELLE = "";
		private string _PL_COMPTECOLLECTIF = "";
		private double _PL_REPORTDEBIT = 0;
		private double _PL_REPORTCREDIT = 0;
		private double _PL_MONTANTPERIODEPRECEDENTDEBIT = 0;
		private double _PL_MONTANTPERIODEPRECEDENTCREDIT = 0;
		private double _PL_MONTANTPERIODEDEBITENCOURS = 0;
		private double _PL_MONTANTPERIODECREDITENCOURS = 0;
		private double _PL_MONTANTSOLDEFINALDEBIT = 0;
		private double _PL_MONTANTSOLDEFINALCREDIT = 0;
        private double _PL_SOLDECOMPTE = 0;
        private string _PL_COMPTETIERS = "0";//Est-ce que le compte appartient à la table MICCOMPTEPRODUITSOUSPRODUIT
		private string _COMPTAPAR_SENS_CODE= "";
		private string _PL_TYPECOMPTE = "";
		private string _PL_ACTIF = "";
		private string _PL_COMPTEREFERENTIELCOMPTABLE = "";

        private string _PL_COMPTEDEFICIT = "";
        private string _PL_COMPTEEXCEDANT = "";
        private string _PLAN_REPORTING_CODE = "";
        private string _PL_NOMBRELIGNE = "";
        private string _TS_CODE = "";
        private string _PL_SAISIE_ANALYTIQUE = "";
        private string _AG_CODEAGENCE = "";
        private string _OP_CODEOPERATEUR = "";
        private string _FO_CODEFAMILLEOPERATION = "";
        private string _NF_CODENATUREFAMILLEOPERATION = "";
        private string _NO_LIBELLE = "";
        private string _NO_CODENATUREOPERATION = "";
        private string _NO_SENS = "";
        private string _NO_PREFIXECOMPTE = "";
        private string _NO_REFPIECE = "";
        private string _COCHER = "";
        private string _NO_ABREVIATION = "";
        private string _NO_MONTANT = "";
        private string _PL_CODENUMCOMPTECONTREPARTIE = "";
        private string _PL_NUMCOMPTECONTREPARTIE = "";
        private string _NO_NUMEROORDRE = "";
        private string _NO_MODIFIERMONTANT = "";
        private string _NC_CODENATURECOMPTE1 = "";
        private string _NC_CODENATURECOMPTECONTREPARTIE = "";
        private string _JO_CODEJOURNAL = "";
        private string _PL_AFFICHERSURECRANDROIT = "";
        private string _PL_CODENUMERODEBUT = "";
        private string _PL_LIBELLENUMERODEBUT = "";        
        private string _FO_LIBELLEFAMILLEOPERATION = "";  
        private string _ET_TYPEETAT = "";

        private string _PL_SENS = "";   
        private string _PL_COMPTELIE = "";          
        private string _PL_COMPTEPRINCIPAL = ""; 
                 
        private string _PL_TYPECOMPTELIBELLE = "";            
        private string _PL_ACTIFLIBELLE = "";  
        private string _PLAN_RERPORTING_INTITULE = "";          
        private string _TS_LIBELLE = "";             
        private string _NC_LIBELLENATURECOMPTE = "";  
        private string _COMPTAPAR_SENS_LIBELLE = "";        
        
                                 
        public string SO_CODESOCIETE
		{
			get { return _SO_CODESOCIETE; }
			set { _SO_CODESOCIETE = value; }
		}
		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set { _PL_CODENUMCOMPTE = value; }
		}
        public string NC_CODENATURECOMPTE
		{
            get { return _NC_CODENATURECOMPTE; }
            set { _NC_CODENATURECOMPTE = value; }
		}
        public string PL_FOCUSTIERS
		{
            get { return _PL_FOCUSTIERS; }
            set { _PL_FOCUSTIERS = value; }
		}

		public string PL_NUMCOMPTE
		{
			get { return _PL_NUMCOMPTE; }
			set { _PL_NUMCOMPTE = value; }
		}
		public string PL_LIBELLE
		{
			get { return _PL_LIBELLE; }
			set { _PL_LIBELLE = value; }
		}
		public string PL_COMPTECOLLECTIF
		{
			get { return _PL_COMPTECOLLECTIF; }
			set { _PL_COMPTECOLLECTIF = value; }
		}
		public double PL_REPORTDEBIT
		{
			get { return _PL_REPORTDEBIT; }
			set { _PL_REPORTDEBIT = value; }
		}
		public double PL_REPORTCREDIT
		{
			get { return _PL_REPORTCREDIT; }
			set { _PL_REPORTCREDIT = value; }
		}
		public double PL_MONTANTPERIODEPRECEDENTDEBIT
		{
			get { return _PL_MONTANTPERIODEPRECEDENTDEBIT; }
			set { _PL_MONTANTPERIODEPRECEDENTDEBIT = value; }
		}
		public double PL_MONTANTPERIODEPRECEDENTCREDIT
		{
			get { return _PL_MONTANTPERIODEPRECEDENTCREDIT; }
			set { _PL_MONTANTPERIODEPRECEDENTCREDIT = value; }
		}
		public double PL_MONTANTPERIODEDEBITENCOURS
		{
			get { return _PL_MONTANTPERIODEDEBITENCOURS; }
			set { _PL_MONTANTPERIODEDEBITENCOURS = value; }
		}
		public double PL_MONTANTPERIODECREDITENCOURS
		{
			get { return _PL_MONTANTPERIODECREDITENCOURS; }
			set { _PL_MONTANTPERIODECREDITENCOURS = value; }
		}
		public double PL_MONTANTSOLDEFINALDEBIT
		{
			get { return _PL_MONTANTSOLDEFINALDEBIT; }
			set { _PL_MONTANTSOLDEFINALDEBIT = value; }
		}
		public double PL_MONTANTSOLDEFINALCREDIT
		{
			get { return _PL_MONTANTSOLDEFINALCREDIT; }
			set { _PL_MONTANTSOLDEFINALCREDIT = value; }
		}
        public double PL_SOLDECOMPTE
		{
            get { return _PL_SOLDECOMPTE; }
            set { _PL_SOLDECOMPTE = value; }
		}

        public string PL_COMPTETIERS
		{
            get { return _PL_COMPTETIERS; }
            set { _PL_COMPTETIERS = value; }
		}

		public string COMPTAPAR_SENS_CODE
		{
			get { return _COMPTAPAR_SENS_CODE; }
			set { _COMPTAPAR_SENS_CODE= value; }
		}
		public string PL_TYPECOMPTE
		{
			get { return _PL_TYPECOMPTE; }
			set { _PL_TYPECOMPTE = value; }
		}
		public string PL_ACTIF
		{
			get { return _PL_ACTIF; }
			set { _PL_ACTIF = value; }
		}
		public string PL_COMPTEREFERENTIELCOMPTABLE
		{
			get { return _PL_COMPTEREFERENTIELCOMPTABLE; }
			set { _PL_COMPTEREFERENTIELCOMPTABLE = value; }
		}

        
        public string PL_COMPTEDEFICIT
        {
            get { return _PL_COMPTEDEFICIT; }
            set { _PL_COMPTEDEFICIT = value; }
        }

        public string PL_COMPTEEXCEDANT
        {
            get { return _PL_COMPTEEXCEDANT; }
            set { _PL_COMPTEEXCEDANT = value; }
        }

        public string PLAN_REPORTING_CODE
        {
            get { return _PLAN_REPORTING_CODE; }
            set { _PLAN_REPORTING_CODE = value; }
        }

        public string PL_NOMBRELIGNE
        {
            get { return _PL_NOMBRELIGNE; }
            set { _PL_NOMBRELIGNE = value; }
        }
        public string TS_CODE
        {
            get { return _TS_CODE; }
            set { _TS_CODE = value; }
        }

        public string PL_SAISIE_ANALYTIQUE
        {
            get { return _PL_SAISIE_ANALYTIQUE; }
            set { _PL_SAISIE_ANALYTIQUE = value; }
        }
        //public string TYPEOPERATION
        //{
        //    get { return _TYPEOPERATION; }
        //    set { _TYPEOPERATION = value; }
        //}

        public string PL_AFFICHERSURECRANDROIT
        {
            get { return _PL_AFFICHERSURECRANDROIT; }
            set { _PL_AFFICHERSURECRANDROIT = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public string FO_CODEFAMILLEOPERATION
        {
            get { return _FO_CODEFAMILLEOPERATION; }
            set { _FO_CODEFAMILLEOPERATION = value; }
        }
        public string NF_CODENATUREFAMILLEOPERATION
        {
            get { return _NF_CODENATUREFAMILLEOPERATION; }
            set { _NF_CODENATUREFAMILLEOPERATION = value; }
        }

        public string NO_LIBELLE
        {
            get { return _NO_LIBELLE; }
            set { _NO_LIBELLE = value; }
        }
        public string NO_CODENATUREOPERATION
        {
            get { return _NO_CODENATUREOPERATION; }
            set { _NO_CODENATUREOPERATION = value; }
        }
        public string NO_SENS
        {
            get { return _NO_SENS; }
            set { _NO_SENS = value; }
        }
        public string NO_PREFIXECOMPTE
        {
            get { return _NO_PREFIXECOMPTE; }
            set { _NO_PREFIXECOMPTE = value; }
        }
        public string NO_REFPIECE
        {
            get { return _NO_REFPIECE; }
            set { _NO_REFPIECE = value; }
        }
        public string COCHER
        {
            get { return _COCHER; }
            set { _COCHER = value; }
        }
        public string NO_ABREVIATION
        {
            get { return _NO_ABREVIATION; }
            set { _NO_ABREVIATION = value; }
        }
        public string NO_MONTANT
        {
            get { return _NO_MONTANT; }
            set { _NO_MONTANT = value; }
        }
        public string PL_CODENUMCOMPTECONTREPARTIE
        {
            get { return _PL_CODENUMCOMPTECONTREPARTIE; }
            set { _PL_CODENUMCOMPTECONTREPARTIE = value; }
        }
        public string PL_NUMCOMPTECONTREPARTIE
        {
            get { return _PL_NUMCOMPTECONTREPARTIE; }
            set { _PL_NUMCOMPTECONTREPARTIE = value; }
        }
        public string NO_NUMEROORDRE
        {
            get { return _NO_NUMEROORDRE; }
            set { _NO_NUMEROORDRE = value; }
        }
        public string NO_MODIFIERMONTANT
        {
            get { return _NO_MODIFIERMONTANT; }
            set { _NO_MODIFIERMONTANT = value; }
        }
        public string NC_CODENATURECOMPTE1
        {
            get { return _NC_CODENATURECOMPTE1; }
            set { _NC_CODENATURECOMPTE1 = value; }
        }
        public string NC_CODENATURECOMPTECONTREPARTIE
        {
            get { return _NC_CODENATURECOMPTECONTREPARTIE; }
            set { _NC_CODENATURECOMPTECONTREPARTIE = value; }
        }
        public string JO_CODEJOURNAL
        {
            get { return _JO_CODEJOURNAL; }
            set { _JO_CODEJOURNAL = value; }
        }

        public string PL_CODENUMERODEBUT
        {
            get { return _PL_CODENUMERODEBUT; }
            set { _PL_CODENUMERODEBUT = value; }
        }
        public string PL_LIBELLENUMERODEBUT
        {
            get { return _PL_LIBELLENUMERODEBUT; }
            set { _PL_LIBELLENUMERODEBUT = value; }
        }
        public string FO_LIBELLEFAMILLEOPERATION
        {
            get { return _FO_LIBELLEFAMILLEOPERATION; }
            set { _FO_LIBELLEFAMILLEOPERATION = value; }
        }
        public string ET_TYPEETAT
        {
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
        }
        public string PL_SENS
        {
            get { return _PL_SENS; }
            set { _PL_SENS = value; }
        }
        public string PL_COMPTELIE
        {
            get { return _PL_COMPTELIE; }
            set { _PL_COMPTELIE = value; }
        }
        public string PL_COMPTEPRINCIPAL
        {
            get { return _PL_COMPTEPRINCIPAL; }
            set { _PL_COMPTEPRINCIPAL = value; }
        }
        public string PL_TYPECOMPTELIBELLE
        {
            get { return _PL_TYPECOMPTELIBELLE; }
            set { _PL_TYPECOMPTELIBELLE = value; }
        }
        public string PL_ACTIFLIBELLE
        {
            get { return _PL_ACTIFLIBELLE; }
            set { _PL_ACTIFLIBELLE = value; }
        }
        public string PLAN_RERPORTING_INTITULE
        {
            get { return _PLAN_RERPORTING_INTITULE; }
            set { _PLAN_RERPORTING_INTITULE = value; }
        }
        public string TS_LIBELLE
        {
            get { return _TS_LIBELLE; }
            set { _TS_LIBELLE = value; }
        }
        public string NC_LIBELLENATURECOMPTE
        {
            get { return _NC_LIBELLENATURECOMPTE; }
            set { _NC_LIBELLENATURECOMPTE = value; }
        }
        public string COMPTAPAR_SENS_LIBELLE
        {
            get { return _COMPTAPAR_SENS_LIBELLE; }
            set { _COMPTAPAR_SENS_LIBELLE = value; }
        }
        

        public clsPlancomptable() {} 

		public clsPlancomptable(clsPlancomptable clsPlancomptable)
		{
            SO_CODESOCIETE = clsPlancomptable.SO_CODESOCIETE;
			PL_CODENUMCOMPTE = clsPlancomptable.PL_CODENUMCOMPTE;
            NC_CODENATURECOMPTE = clsPlancomptable.NC_CODENATURECOMPTE;
            PL_FOCUSTIERS = clsPlancomptable.PL_FOCUSTIERS;

			PL_NUMCOMPTE = clsPlancomptable.PL_NUMCOMPTE;
			PL_LIBELLE = clsPlancomptable.PL_LIBELLE;
			PL_COMPTECOLLECTIF = clsPlancomptable.PL_COMPTECOLLECTIF;
			PL_REPORTDEBIT = clsPlancomptable.PL_REPORTDEBIT;
			PL_REPORTCREDIT = clsPlancomptable.PL_REPORTCREDIT;
			PL_MONTANTPERIODEPRECEDENTDEBIT = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;
			PL_MONTANTPERIODEPRECEDENTCREDIT = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;
			PL_MONTANTPERIODEDEBITENCOURS = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;
			PL_MONTANTPERIODECREDITENCOURS = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;
			PL_MONTANTSOLDEFINALDEBIT = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;
			PL_MONTANTSOLDEFINALCREDIT = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;
            PL_SOLDECOMPTE = clsPlancomptable.PL_SOLDECOMPTE;
            PL_COMPTETIERS = clsPlancomptable.PL_COMPTETIERS;
            COMPTAPAR_SENS_CODE = clsPlancomptable.COMPTAPAR_SENS_CODE;
			PL_TYPECOMPTE = clsPlancomptable.PL_TYPECOMPTE;
			PL_ACTIF = clsPlancomptable.PL_ACTIF;
			PL_COMPTEREFERENTIELCOMPTABLE = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;
            PL_COMPTEDEFICIT = clsPlancomptable.PL_COMPTEDEFICIT;
            PL_COMPTEEXCEDANT = clsPlancomptable.PL_COMPTEEXCEDANT;
            PLAN_REPORTING_CODE = clsPlancomptable.PLAN_REPORTING_CODE;
            PL_NOMBRELIGNE = clsPlancomptable.PL_NOMBRELIGNE;
            TS_CODE = clsPlancomptable.TS_CODE;
            PL_SAISIE_ANALYTIQUE = clsPlancomptable.PL_SAISIE_ANALYTIQUE;
            //TYPEOPERATION = clsPlancomptable.TYPEOPERATION;
            PL_AFFICHERSURECRANDROIT = clsPlancomptable.PL_AFFICHERSURECRANDROIT;
            AG_CODEAGENCE = clsPlancomptable.AG_CODEAGENCE;
            OP_CODEOPERATEUR = clsPlancomptable.OP_CODEOPERATEUR;
            FO_CODEFAMILLEOPERATION = clsPlancomptable.FO_CODEFAMILLEOPERATION;
            NF_CODENATUREFAMILLEOPERATION = clsPlancomptable.NF_CODENATUREFAMILLEOPERATION;
            NO_LIBELLE = clsPlancomptable.NO_LIBELLE;
            NO_CODENATUREOPERATION = clsPlancomptable.NO_CODENATUREOPERATION;
            NO_SENS = clsPlancomptable.NO_SENS;
            NO_PREFIXECOMPTE = clsPlancomptable.NO_PREFIXECOMPTE;
            NO_REFPIECE = clsPlancomptable.NO_REFPIECE;
            COCHER = clsPlancomptable.COCHER;
            NO_ABREVIATION = clsPlancomptable.NO_ABREVIATION;
            NO_MONTANT = clsPlancomptable.NO_MONTANT;
            PL_CODENUMCOMPTECONTREPARTIE = clsPlancomptable.PL_CODENUMCOMPTECONTREPARTIE;
            PL_NUMCOMPTECONTREPARTIE = clsPlancomptable.PL_NUMCOMPTECONTREPARTIE;
            NO_NUMEROORDRE = clsPlancomptable.NO_NUMEROORDRE;
            NO_MODIFIERMONTANT = clsPlancomptable.NO_MODIFIERMONTANT;
            NC_CODENATURECOMPTE1 = clsPlancomptable.NC_CODENATURECOMPTE1;
            NC_CODENATURECOMPTECONTREPARTIE = clsPlancomptable.NC_CODENATURECOMPTECONTREPARTIE;
            JO_CODEJOURNAL = clsPlancomptable.JO_CODEJOURNAL;
            PL_CODENUMERODEBUT = clsPlancomptable.PL_CODENUMERODEBUT;
            PL_LIBELLENUMERODEBUT = clsPlancomptable.PL_LIBELLENUMERODEBUT;
            FO_LIBELLEFAMILLEOPERATION = clsPlancomptable.FO_LIBELLEFAMILLEOPERATION;
            ET_TYPEETAT = clsPlancomptable.ET_TYPEETAT;

            PL_SENS = clsPlancomptable.PL_SENS;
            PL_COMPTELIE = clsPlancomptable.PL_COMPTELIE;
            PL_COMPTEPRINCIPAL = clsPlancomptable.PL_COMPTEPRINCIPAL;
            PL_TYPECOMPTELIBELLE = clsPlancomptable.PL_TYPECOMPTELIBELLE;
            PL_ACTIFLIBELLE = clsPlancomptable.PL_ACTIFLIBELLE;
            PLAN_RERPORTING_INTITULE = clsPlancomptable.PLAN_RERPORTING_INTITULE;
            TS_LIBELLE = clsPlancomptable.TS_LIBELLE;
            NC_LIBELLENATURECOMPTE = clsPlancomptable.NC_LIBELLENATURECOMPTE;
            COMPTAPAR_SENS_LIBELLE = clsPlancomptable.COMPTAPAR_SENS_LIBELLE;





            //private string _PL_SENS = "";
            //private string _PL_COMPTELIE = "";
            //private string _PL_COMPTEPRINCIPAL = "";


            //clsPlancomptable.NO_LIBELLE = row["NO_LIBELLE"].ToString();
            //clsPlancomptable.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
            //clsPlancomptable.NO_SENS = row["NO_SENS"].ToString();
            //clsPlancomptable.NO_PREFIXECOMPTE = row["NO_PREFIXECOMPTE"].ToString();
            //clsPlancomptable.NO_REFPIECE = row["NO_REFPIECE"].ToString();
            //clsPlancomptable.COCHER = row["COCHER"].ToString();
            //clsPlancomptable.NO_ABREVIATION = row["NO_ABREVIATION"].ToString();
            //clsPlancomptable.NO_MONTANT = row["NO_MONTANT"].ToString();
            //clsPlancomptable.PL_CODENUMCOMPTECONTREPARTIE = row["PL_CODENUMCOMPTECONTREPARTIE"].ToString();
            //clsPlancomptable.PL_NUMCOMPTECONTREPARTIE = row["PL_NUMCOMPTECONTREPARTIE"].ToString();
            //clsPlancomptable.NO_NUMEROORDRE = row["NO_NUMEROORDRE"].ToString();
            //clsPlancomptable.NO_MODIFIERMONTANT = row["NO_MODIFIERMONTANT"].ToString();
            //clsPlancomptable.NC_CODENATURECOMPTE1 = row["NC_CODENATURECOMPTE1"].ToString();
            //clsPlancomptable.NC_CODENATURECOMPTECONTREPARTIE = row["NC_CODENATURECOMPTECONTREPARTIE"].ToString();
            //clsPlancomptable.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
        }
    }
}