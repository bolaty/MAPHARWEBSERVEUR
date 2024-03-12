using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPlancomptable
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
        private int _TYPEOPERATION =0;
        private string _PL_AFFICHERSURECRANDROIT = "";

        private string _PL_CODENUMERODEBUT = "";
        private string _PL_LIBELLENUMERODEBUT = "";


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
        public int TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        public string PL_AFFICHERSURECRANDROIT
        {
            get { return _PL_AFFICHERSURECRANDROIT; }
            set { _PL_AFFICHERSURECRANDROIT = value; }
        }

        public clsPlancomptable() {} 

		public clsPlancomptable(clsPlancomptable clsPlancomptable)
		{
            PL_CODENUMERODEBUT = clsPlancomptable.PL_CODENUMERODEBUT;
            PL_LIBELLENUMERODEBUT = clsPlancomptable.PL_LIBELLENUMERODEBUT;

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
            TYPEOPERATION = clsPlancomptable.TYPEOPERATION;
            PL_AFFICHERSURECRANDROIT = clsPlancomptable.PL_AFFICHERSURECRANDROIT;
            //private string _PL_COMPTEDEFICIT = "";
            //private string _PL_COMPTEEXCEDANT = "";
            //private string _PLAN_REPORTING_CODE = "";
            //private string _PL_NOMBRELIGNE = "";
            //private string _TS_CODE = "";
            //private string _PL_SAISIE_ANALYTIQUE = "";
        }
        }
}