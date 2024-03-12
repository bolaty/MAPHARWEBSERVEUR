using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatImmobilisation
	{


    //    @AG_CODEAGENCE varchar(7000),	
    //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
    //@DATEDEBUT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _TP_CODETYPETIERS = "";
        private string _TI_IDTIERS = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _OP_CODEOPERATEUR = "";
        private string _DATEDEBUT = "";
        private string _DATEFIN = "";
        private string _MR_CODEMODEREGLEMENT= "";
        private string _NO_CODENATUREOPERATION = "";
        private string _PL_NUMCOMPTE1 = "";
        private string _PL_NUMCOMPTE2 = "";
        private string _PL_NUMCOMPTETIERS = "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";
        private string _STATUT = "";
        private string _JO_CODEJOURNAL = "";
        private string _OV_NUMEROORDREVIREMENT = "";
        private string _PS_CODESOUSPRODUIT = "";
        private string _PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = "";

        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}

        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }

        public string TP_CODETYPETIERS
        {
            get { return _TP_CODETYPETIERS; }
            set { _TP_CODETYPETIERS = value; }
        }


        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }


		public string OP_CODEOPERATEUREDITION
		{
			get { return _OP_CODEOPERATEUREDITION; }
			set { _OP_CODEOPERATEUREDITION = value; }
		}

        public string OP_CODEOPERATEUR
		{
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
		}
        public string DATEDEBUT
		{
            get { return _DATEDEBUT; }
            set { _DATEDEBUT = value; }
		}
        public string DATEFIN
		{
            get { return _DATEFIN; }
            set { _DATEFIN = value; }
		}
        public string MR_CODEMODEREGLEMENT
		{
            get { return _MR_CODEMODEREGLEMENT; }
            set { _MR_CODEMODEREGLEMENT = value; }
		}
        public string NO_CODENATUREOPERATION
		{
            get { return _NO_CODENATUREOPERATION; }
            set { _NO_CODENATUREOPERATION = value; }
		}
        public string PL_NUMCOMPTE1
		{
            get { return _PL_NUMCOMPTE1; }
            set { _PL_NUMCOMPTE1 = value; }
		}
        public string PL_NUMCOMPTE2
		{
            get { return _PL_NUMCOMPTE2; }
            set { _PL_NUMCOMPTE2= value; }
		}

        public string PL_NUMCOMPTETIERS
        {
            get { return _PL_NUMCOMPTETIERS; }
            set { _PL_NUMCOMPTETIERS = value; }
        }
        public string ET_TYPEETAT
		{
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
		}
        public string ET_TYPERETOURS
		{
            get { return _ET_TYPERETOURS; }
            set { _ET_TYPERETOURS = value; }
		}

        public string STATUT
        {
            get { return _STATUT; }
            set { _STATUT = value; }
        }

        public string JO_CODEJOURNAL
        {
            get { return _JO_CODEJOURNAL; }
            set { _JO_CODEJOURNAL = value; }
        }

        public string OV_NUMEROORDREVIREMENT
        {
            get { return _OV_NUMEROORDREVIREMENT; }
            set { _OV_NUMEROORDREVIREMENT = value; }
        }

        public string PS_CODESOUSPRODUIT
        {
            get { return _PS_CODESOUSPRODUIT; }
            set { _PS_CODESOUSPRODUIT = value; }
        }

        public string PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT
        {
            get { return _PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT; }
            set { _PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = value; }
        }


        public clsEditionEtatImmobilisation() {} 

		

		public clsEditionEtatImmobilisation(clsEditionEtatImmobilisation clsEditionEtatImmobilisation)
		{
			AG_CODEAGENCE = clsEditionEtatImmobilisation.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatImmobilisation.EN_CODEENTREPOT;
            TP_CODETYPETIERS = clsEditionEtatImmobilisation.TP_CODETYPETIERS;

            TI_IDTIERS = clsEditionEtatImmobilisation.TI_IDTIERS;
			OP_CODEOPERATEUREDITION = clsEditionEtatImmobilisation.OP_CODEOPERATEUREDITION;
            OP_CODEOPERATEUR = clsEditionEtatImmobilisation.OP_CODEOPERATEUR;

            DATEDEBUT = clsEditionEtatImmobilisation.DATEDEBUT;
            DATEFIN = clsEditionEtatImmobilisation.DATEFIN;

            MR_CODEMODEREGLEMENT = clsEditionEtatImmobilisation.MR_CODEMODEREGLEMENT;
            NO_CODENATUREOPERATION = clsEditionEtatImmobilisation.NO_CODENATUREOPERATION;
            PL_NUMCOMPTE1 = clsEditionEtatImmobilisation.PL_NUMCOMPTE1;
            PL_NUMCOMPTE2 = clsEditionEtatImmobilisation.PL_NUMCOMPTE2;
            PL_NUMCOMPTETIERS = clsEditionEtatImmobilisation.PL_NUMCOMPTETIERS;
            ET_TYPEETAT = clsEditionEtatImmobilisation.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatImmobilisation.ET_TYPERETOURS;
            STATUT = clsEditionEtatImmobilisation.STATUT;
            JO_CODEJOURNAL = clsEditionEtatImmobilisation.JO_CODEJOURNAL;
            OV_NUMEROORDREVIREMENT = clsEditionEtatImmobilisation.OV_NUMEROORDREVIREMENT;
            PS_CODESOUSPRODUIT = clsEditionEtatImmobilisation.PS_CODESOUSPRODUIT;
            PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = clsEditionEtatImmobilisation.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT;

		}
        }
}