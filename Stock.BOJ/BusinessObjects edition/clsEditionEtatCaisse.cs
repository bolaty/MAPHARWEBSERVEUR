using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatCaisse
	{


    //    @AG_CODEAGENCE varchar(7000),	
    //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
    //@DATEDEBUT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _TP_CODETYPETIERS = "";
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
        private string _PL_OPTION = "";
        private string _JO_CODEJOURNAL = "";
        private string _MV_STATUTGLVRE = "";
        private string _GP_CODEGROUPE = "";
        private string _PY_CODEPAYS = "";
        private string _NT_CODENATURETIERS = "";
        private string _TI_IDTIERSMEDECIN = "";
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

        public string PL_OPTION
        {
            get { return _PL_OPTION; }
            set { _PL_OPTION = value; }
        }

        public string JO_CODEJOURNAL
        {
            get { return _JO_CODEJOURNAL; }
            set { _JO_CODEJOURNAL = value; }
        }

        public string MV_STATUTGLVRE
        {
            get { return _MV_STATUTGLVRE; }
            set { _MV_STATUTGLVRE = value; }
        }


        public string GP_CODEGROUPE
        {
            get { return _GP_CODEGROUPE; }
            set { _GP_CODEGROUPE = value; }
        }

        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
        public string NT_CODENATURETIERS
        {
            get { return _NT_CODENATURETIERS; }
            set { _NT_CODENATURETIERS = value; }
        }
        public string TI_IDTIERSMEDECIN
        {
            get { return _TI_IDTIERSMEDECIN; }
            set { _TI_IDTIERSMEDECIN = value; }
        }


        public clsEditionEtatCaisse() {} 

		

		public clsEditionEtatCaisse(clsEditionEtatCaisse clsEditionEtatCaisse)
		{
			AG_CODEAGENCE = clsEditionEtatCaisse.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatCaisse.EN_CODEENTREPOT;
            TP_CODETYPETIERS = clsEditionEtatCaisse.TP_CODETYPETIERS;
			OP_CODEOPERATEUREDITION = clsEditionEtatCaisse.OP_CODEOPERATEUREDITION;
            OP_CODEOPERATEUR = clsEditionEtatCaisse.OP_CODEOPERATEUR;

            DATEDEBUT = clsEditionEtatCaisse.DATEDEBUT;
            DATEFIN = clsEditionEtatCaisse.DATEFIN;

            MR_CODEMODEREGLEMENT = clsEditionEtatCaisse.MR_CODEMODEREGLEMENT;
            NO_CODENATUREOPERATION = clsEditionEtatCaisse.NO_CODENATUREOPERATION;
            PL_NUMCOMPTE1 = clsEditionEtatCaisse.PL_NUMCOMPTE1;
            PL_NUMCOMPTE2 = clsEditionEtatCaisse.PL_NUMCOMPTE2;
            PL_NUMCOMPTETIERS = clsEditionEtatCaisse.PL_NUMCOMPTETIERS;
            ET_TYPEETAT = clsEditionEtatCaisse.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatCaisse.ET_TYPERETOURS;
            PL_OPTION = clsEditionEtatCaisse.PL_OPTION;
            JO_CODEJOURNAL = clsEditionEtatCaisse.JO_CODEJOURNAL;
            MV_STATUTGLVRE = clsEditionEtatCaisse.MV_STATUTGLVRE;
            GP_CODEGROUPE = clsEditionEtatCaisse.GP_CODEGROUPE;
            PY_CODEPAYS = clsEditionEtatCaisse.PY_CODEPAYS;
            NT_CODENATURETIERS = clsEditionEtatCaisse.NT_CODENATURETIERS;
            TI_IDTIERSMEDECIN = clsEditionEtatCaisse.TI_IDTIERSMEDECIN;

        }
        }
}