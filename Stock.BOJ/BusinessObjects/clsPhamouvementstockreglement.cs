using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstockreglement
	{
		#region VARIABLES LOCALES
        private List<clsMouvementcomptableanalytique> _MOUVEMENTCOMPTABLEANALYTIQUE;
		private string _MV_NUMPIECE = "";
		private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _MR_CODEMODEREGLEMENT = "";
		private string _MS_NUMPIECE = "";
        private string _MV_ANNULATIONPIECE = "N";
        private double _MV_MONTANTDEBIT = 0;
		private double _MV_MONTANTCREDIT = 0;
        private double _RESTEMONTANTFACTURE = 0;
        private double _MONTANTREMISE = 0;
        private double _MONTANTTVA = 0;
        private double _MONTANTAIRSI = 0;
        private double _MONTANTFACTURE = 0;
        private double _MONTANTIMPAYER = 0;
        private double _MONTANTTRANSPORT = 0;
        private double _MONTANTFACTURETTC = 0;
        private double _MONTANTASSUREUR = 0;
        private double _MONTANTVERSEMENT = 0;

		private DateTime _MV_DATEPIECE = DateTime.Parse("01/01/1900");
        private DateTime _CH_DATEDEBUTCOUVERTURE = DateTime.Parse("01/01/1900");
        private DateTime _CH_DATEFINCOUVERTURE = DateTime.Parse("01/01/1900");
        private string _NO_CODENATUREOPERATION = "";
        private string _MV_LIBELLEOPERATION = "";
        private string _MV_REFERENCEPIECE = "";
        private string _MV_NOMTIERS = "";
        private DateTime _MV_DATESAISIE = DateTime.Parse("01/01/1900");
        private string _MV_NUMPIECE1 = "";
        private int _TYPEOPERATION = 0;
        private string _CL_NUMCLIENT = "";
        private string _FR_MATRICULE = "";

        private string _PL_NUMCOMPTE = "";
        private string _PL_NUMCOMPTEBANQUE = "";

        private string _MV_NUMEROPIECE = "";
        private string _MV_NUMSEQUENCE = "";
        private string _OP_CODEOPERATEUR = "";
        private int _MS_UTILISERSUPLUS = 0;
        private String _FB_IDFOURNISSEUR = "";
        private String _TI_IDTIERS = "";
        private string _TI_NUMTIERS = "";
        private int _JO_CODEJOURNAL= 0;
        private string _NO_SENS = "";
        private string _MV_MTSURPLUS = "N";
        private string _MS_NUMPIECEANNULER= "";
        private string _TO_CODEOPERATION = "";
        private string _TA_CODETYPEARTICLE = "";
        private string _NA_CODENATUREOPERATION = "";
        private string _MV_REGLEMENTGROUPE= "N";
        private double _IM_DUREE = 0;
        private string _SO_CODESOCIETE = "";
        private string _TS_CODETYPESCHEMACOMPTABLE = "";
        private string _TI_IDTIERSIMMOBILISATION = "";
        private int _LT_CODELETTRAGE = 0;
        private string _CA_CODECONTRAT = "";
        private string _DT_NUMEROTRANSACTION = "";
        private string _DT_NUMEROFACTURE = "";
        private string _DT_REFERENCE = "";
        private string _DT_DESIGNATION = "";
        private string _DT_QUANTITE = "0";
        private string _DT_PU = "0";
        private string _DT_TOTALARTICLE = "0";
        private string _DT_TOTALFACTURE = "0";
        private string _PY_CODESTATUT = "";
        private string _DT_DATEVALIDATION = "";
        private string _PI_CODEPIECE = "";
        private string _SO_CODESOUSCRIPTION = "";
        //private string _MV_ABREVIATION= "";
        #endregion

        #region ACCESSEURS

        public string MV_NUMPIECE
		{
			get { return _MV_NUMPIECE; }
			set {  _MV_NUMPIECE = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}
        public string EN_CODEENTREPOT
		{
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
		}


		public string MR_CODEMODEREGLEMENT
		{
			get { return _MR_CODEMODEREGLEMENT; }
			set {  _MR_CODEMODEREGLEMENT = value; }
		}

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set {  _MS_NUMPIECE = value; }
		}

        public string MV_ANNULATIONPIECE
		{
            get { return _MV_ANNULATIONPIECE; }
            set { _MV_ANNULATIONPIECE = value; }
		}

		public double MV_MONTANTDEBIT
		{
			get { return _MV_MONTANTDEBIT; }
			set {  _MV_MONTANTDEBIT = value; }
		}

		public double MV_MONTANTCREDIT
		{
			get { return _MV_MONTANTCREDIT; }
			set {  _MV_MONTANTCREDIT = value; }
		}
        public double RESTEMONTANTFACTURE
		{
            get { return _RESTEMONTANTFACTURE; }
            set { _RESTEMONTANTFACTURE = value; }
		}


        public double MONTANTFACTURE
        {
            get { return _MONTANTFACTURE; }
            set { _MONTANTFACTURE = value; }
        }

        public double MONTANTTVA
        {
            get { return _MONTANTTVA; }
            set { _MONTANTTVA = value; }
        }
        public double MONTANTAIRSI
        {
            get { return _MONTANTAIRSI; }
            set { _MONTANTAIRSI = value; }
        }
        public double MONTANTREMISE
        {
            get { return _MONTANTREMISE; }
            set { _MONTANTREMISE = value; }
        }

        public double MONTANTIMPAYER
        {
            get { return _MONTANTIMPAYER; }
            set { _MONTANTIMPAYER = value; }
        }
        public double MONTANTTRANSPORT 
        {
            get { return _MONTANTTRANSPORT; }
            set { _MONTANTTRANSPORT = value; }
        }
        public double MONTANTFACTURETTC 
        {
            get { return _MONTANTFACTURETTC; }
            set { _MONTANTFACTURETTC = value; }
        }

        public double MONTANTASSUREUR
        {
            get { return _MONTANTASSUREUR; }
            set { _MONTANTASSUREUR = value; }
        }

        public double MONTANTVERSEMENT
        {
            get { return _MONTANTVERSEMENT; }
            set { _MONTANTVERSEMENT = value; }
        }
		public DateTime MV_DATEPIECE
		{
			get { return _MV_DATEPIECE; }
			set {  _MV_DATEPIECE = value; }
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



        public string NO_CODENATUREOPERATION
		{
            get { return _NO_CODENATUREOPERATION; }
            set { _NO_CODENATUREOPERATION = value; }
		}

        public string MV_LIBELLEOPERATION
		{
            get { return _MV_LIBELLEOPERATION; }
            set { _MV_LIBELLEOPERATION = value; }
		}
        public string MV_REFERENCEPIECE
		{
            get { return _MV_REFERENCEPIECE; }
            set { _MV_REFERENCEPIECE = value; }
		}

        public string MV_NOMTIERS
		{
            get { return _MV_NOMTIERS; }
            set { _MV_NOMTIERS = value; }
		}


        public int TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        public DateTime MV_DATESAISIE
		{
            get { return _MV_DATESAISIE; }
            set { _MV_DATESAISIE = value; }
		}

        public string MV_NUMPIECE1
        {
            get { return _MV_NUMPIECE1; }
            set { _MV_NUMPIECE1 = value; }
        }

        public string CL_NUMCLIENT
        {
            get { return _CL_NUMCLIENT; }
            set { _CL_NUMCLIENT = value; }
        }

        public string FR_MATRICULE
        {
            get { return _FR_MATRICULE; }
            set { _FR_MATRICULE = value; }
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
        public string MV_NUMEROPIECE
        {
            get { return _MV_NUMEROPIECE; }
            set { _MV_NUMEROPIECE = value; }
        }

        public string MV_NUMSEQUENCE
        {
            get { return _MV_NUMSEQUENCE; }
            set { _MV_NUMSEQUENCE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public int MS_UTILISERSUPLUS
        {
            get { return _MS_UTILISERSUPLUS; }
            set { _MS_UTILISERSUPLUS = value; }
        }

        public string FB_IDFOURNISSEUR
        {
            get { return _FB_IDFOURNISSEUR; }
            set { _FB_IDFOURNISSEUR = value; }
        }
        public string TI_IDTIERS
    {
        get { return _TI_IDTIERS; }
        set { _TI_IDTIERS = value; }
    }

    public string TI_NUMTIERS
    {
        get { return _TI_NUMTIERS; }
        set { _TI_NUMTIERS = value; }
    }
        public int JO_CODEJOURNAL
    {
        get { return _JO_CODEJOURNAL; }
        set { _JO_CODEJOURNAL = value; }
    }

        public string NO_SENS
    {
        get { return _NO_SENS; }
        set { _NO_SENS = value; }
    }

        public string MV_MTSURPLUS
    {
        get { return _MV_MTSURPLUS; }
        set { _MV_MTSURPLUS = value; }
    }
        public string MS_NUMPIECEANNULER
    {
        get { return _MS_NUMPIECEANNULER; }
        set { _MS_NUMPIECEANNULER = value; }
    }

        public string TO_CODEOPERATION
    {
        get { return _TO_CODEOPERATION; }
        set { _TO_CODEOPERATION = value; }
    }
        public string TA_CODETYPEARTICLE
    {
        get { return _TA_CODETYPEARTICLE; }
        set { _TA_CODETYPEARTICLE = value; }
    }

        public string NA_CODENATUREOPERATION
    {
        get { return _NA_CODENATUREOPERATION; }
        set { _NA_CODENATUREOPERATION = value; }
    }

        public string MV_REGLEMENTGROUPE
        {
            get { return _MV_REGLEMENTGROUPE; }
            set { _MV_REGLEMENTGROUPE = value; }
        }


        public double IM_DUREE
        {
            get { return _IM_DUREE; }
            set { _IM_DUREE = value; }
        }

        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }

        public string TS_CODETYPESCHEMACOMPTABLE
        {
            get { return _TS_CODETYPESCHEMACOMPTABLE; }
            set { _TS_CODETYPESCHEMACOMPTABLE = value; }
        }



        public List<clsMouvementcomptableanalytique> MOUVEMENTCOMPTABLEANALYTIQUE
        {
            get { return _MOUVEMENTCOMPTABLEANALYTIQUE; }
            set { _MOUVEMENTCOMPTABLEANALYTIQUE = value; }
        }

        public string TI_IDTIERSIMMOBILISATION
        {
            get { return _TI_IDTIERSIMMOBILISATION; }
            set { _TI_IDTIERSIMMOBILISATION = value; }
        }

        public int LT_CODELETTRAGE
        {
            get { return _LT_CODELETTRAGE; }
            set { _LT_CODELETTRAGE = value; }
        }

        public string CA_CODECONTRAT
        {
            get { return _CA_CODECONTRAT; }
            set { _CA_CODECONTRAT = value; }
        }
        public string DT_NUMEROTRANSACTION
        {
            get { return _DT_NUMEROTRANSACTION; }
            set { _DT_NUMEROTRANSACTION = value; }
        }
        public string DT_NUMEROFACTURE
        {
            get { return _DT_NUMEROFACTURE; }
            set { _DT_NUMEROFACTURE = value; }
        }
        public string DT_REFERENCE
        {
            get { return _DT_REFERENCE; }
            set { _DT_REFERENCE = value; }
        }
        public string DT_DESIGNATION
        {
            get { return _DT_DESIGNATION; }
            set { _DT_DESIGNATION = value; }
        }
        public string DT_QUANTITE
        {
            get { return _DT_QUANTITE; }
            set { _DT_QUANTITE = value; }
        }
        public string DT_PU
        {
            get { return _DT_PU; }
            set { _DT_PU = value; }
        }
        public string DT_TOTALARTICLE
        {
            get { return _DT_TOTALARTICLE; }
            set { _DT_TOTALARTICLE = value; }
        }
        public string DT_TOTALFACTURE
        {
            get { return _DT_TOTALFACTURE; }
            set { _DT_TOTALFACTURE = value; }
        }
        public string PY_CODESTATUT
        {
            get { return _PY_CODESTATUT; }
            set { _PY_CODESTATUT = value; }
        }
        public string DT_DATEVALIDATION
        {
            get { return _DT_DATEVALIDATION; }
            set { _DT_DATEVALIDATION = value; }
        }
        public string PI_CODEPIECE
        {
            get { return _PI_CODEPIECE; }
            set { _PI_CODEPIECE = value; }
        }
        public string SO_CODESOUSCRIPTION
        {
            get { return _SO_CODESOUSCRIPTION; }
            set { _SO_CODESOUSCRIPTION = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsPhamouvementstockreglement(){}
		public clsPhamouvementstockreglement(clsPhamouvementstockreglement clsPhamouvementstockreglement)
		{

            this.MOUVEMENTCOMPTABLEANALYTIQUE = clsPhamouvementstockreglement.MOUVEMENTCOMPTABLEANALYTIQUE;
            this.MV_NUMPIECE = clsPhamouvementstockreglement.MV_NUMPIECE;
			this.AG_CODEAGENCE = clsPhamouvementstockreglement.AG_CODEAGENCE;
            this.EN_CODEENTREPOT = clsPhamouvementstockreglement.EN_CODEENTREPOT;
			this.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT;
			this.MS_NUMPIECE = clsPhamouvementstockreglement.MS_NUMPIECE;
			this.MV_MONTANTDEBIT = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
			this.MV_MONTANTCREDIT = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
            this.RESTEMONTANTFACTURE = clsPhamouvementstockreglement.RESTEMONTANTFACTURE;
            this.MONTANTFACTURE = clsPhamouvementstockreglement.MONTANTFACTURE;
            this.MONTANTTVA = clsPhamouvementstockreglement.MONTANTTVA;
            this.MONTANTAIRSI = clsPhamouvementstockreglement.MONTANTAIRSI;

            this.MONTANTREMISE = clsPhamouvementstockreglement.MONTANTREMISE;
            this.MONTANTIMPAYER = clsPhamouvementstockreglement.MONTANTIMPAYER;
            this.MONTANTTRANSPORT = clsPhamouvementstockreglement.MONTANTTRANSPORT;
            this.MONTANTFACTURETTC = clsPhamouvementstockreglement.MONTANTFACTURETTC;
            this.MONTANTASSUREUR = clsPhamouvementstockreglement.MONTANTASSUREUR;

            this.MONTANTVERSEMENT = clsPhamouvementstockreglement.MONTANTVERSEMENT;
			this.MV_DATEPIECE = clsPhamouvementstockreglement.MV_DATEPIECE;
            this.CH_DATEDEBUTCOUVERTURE = clsPhamouvementstockreglement.CH_DATEDEBUTCOUVERTURE;
            this.CH_DATEFINCOUVERTURE = clsPhamouvementstockreglement.CH_DATEFINCOUVERTURE;


            this.MV_ANNULATIONPIECE = clsPhamouvementstockreglement.MV_ANNULATIONPIECE;
            this.NO_CODENATUREOPERATION = clsPhamouvementstockreglement.NO_CODENATUREOPERATION;

            this.MV_LIBELLEOPERATION = clsPhamouvementstockreglement.MV_LIBELLEOPERATION;
            this.MV_REFERENCEPIECE = clsPhamouvementstockreglement.MV_REFERENCEPIECE;
            this.MV_NOMTIERS = clsPhamouvementstockreglement.MV_NOMTIERS;
            this.MV_DATESAISIE = clsPhamouvementstockreglement.MV_DATESAISIE;
            this.MV_NUMPIECE1 = clsPhamouvementstockreglement.MV_NUMPIECE1;

            this.CL_NUMCLIENT = clsPhamouvementstockreglement.CL_NUMCLIENT;
            this.FR_MATRICULE = clsPhamouvementstockreglement.FR_MATRICULE;
            this.PL_NUMCOMPTE = clsPhamouvementstockreglement.PL_NUMCOMPTE;
            this.PL_NUMCOMPTEBANQUE = clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE;
            this.MV_NUMEROPIECE = clsPhamouvementstockreglement.MV_NUMEROPIECE;
            this.MV_NUMSEQUENCE = clsPhamouvementstockreglement.MV_NUMSEQUENCE;
            this.OP_CODEOPERATEUR = clsPhamouvementstockreglement.OP_CODEOPERATEUR;

            this.MS_UTILISERSUPLUS = clsPhamouvementstockreglement.MS_UTILISERSUPLUS;
            FB_IDFOURNISSEUR = clsPhamouvementstockreglement.FB_IDFOURNISSEUR;
            TI_IDTIERS = clsPhamouvementstockreglement.TI_IDTIERS;
            TI_NUMTIERS = clsPhamouvementstockreglement.TI_NUMTIERS;
            JO_CODEJOURNAL = clsPhamouvementstockreglement.JO_CODEJOURNAL;
            NO_SENS = clsPhamouvementstockreglement.NO_SENS;
            MV_MTSURPLUS = clsPhamouvementstockreglement.MV_MTSURPLUS;
            MS_NUMPIECEANNULER = clsPhamouvementstockreglement.MS_NUMPIECEANNULER;
            TO_CODEOPERATION = clsPhamouvementstockreglement.TO_CODEOPERATION;
            TA_CODETYPEARTICLE = clsPhamouvementstockreglement.TA_CODETYPEARTICLE;
            NA_CODENATUREOPERATION = clsPhamouvementstockreglement.NA_CODENATUREOPERATION;
            MV_REGLEMENTGROUPE = clsPhamouvementstockreglement.MV_REGLEMENTGROUPE;

            IM_DUREE = clsPhamouvementstockreglement.IM_DUREE;
            SO_CODESOCIETE = clsPhamouvementstockreglement.SO_CODESOCIETE;
            TS_CODETYPESCHEMACOMPTABLE = clsPhamouvementstockreglement.TS_CODETYPESCHEMACOMPTABLE;
            TI_IDTIERSIMMOBILISATION = clsPhamouvementstockreglement.TI_IDTIERSIMMOBILISATION;
            this.LT_CODELETTRAGE = clsPhamouvementstockreglement.LT_CODELETTRAGE;
            this.CA_CODECONTRAT = clsPhamouvementstockreglement.CA_CODECONTRAT;
            this.DT_NUMEROTRANSACTION = clsPhamouvementstockreglement.DT_NUMEROTRANSACTION;
            this.DT_NUMEROFACTURE = clsPhamouvementstockreglement.DT_NUMEROFACTURE;
           this.DT_REFERENCE = clsPhamouvementstockreglement.DT_REFERENCE;
           this.DT_DESIGNATION = clsPhamouvementstockreglement.DT_DESIGNATION;
           this.DT_QUANTITE = clsPhamouvementstockreglement.DT_QUANTITE;
           this.DT_PU = clsPhamouvementstockreglement.DT_PU;
           this.DT_TOTALARTICLE = clsPhamouvementstockreglement.DT_TOTALARTICLE;
           this.DT_TOTALFACTURE = clsPhamouvementstockreglement.DT_TOTALFACTURE;
           this.PY_CODESTATUT = clsPhamouvementstockreglement.PY_CODESTATUT;
           this.DT_DATEVALIDATION = clsPhamouvementstockreglement.DT_DATEVALIDATION;
           this.PI_CODEPIECE = clsPhamouvementstockreglement.PI_CODEPIECE;
           this.SO_CODESOUSCRIPTION = clsPhamouvementstockreglement.SO_CODESOUSCRIPTION;
        }

		#endregion

	}
}
