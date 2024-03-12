using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatClientFournisseur
	{


    //    @AG_CODEAGENCE varchar(7000),	
    //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
    //@TP_CODETYPECLIENT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _TP_CODETYPECLIENT = "";
        private string _TC_CODECOMPTETYPETIERS = "";

        private string _TI_NUMTIERS = "";
        private string _SC_CODESECTION = "";
        private string _MS_DATERENDEZVOUS1 = "";
        private string _MS_DATERENDEZVOUS2= "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";
        private string _TI_ASDI = "";
        private string _TI_TVA = "";
        private string _GP_CODEGROUPE = "";
        private string _MS_NUMPIECEPARAM = "";
        private string _PY_CODEPAYS = "";
        private string _NT_CODENATURETIERS = "";

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



		public string OP_CODEOPERATEUREDITION
		{
			get { return _OP_CODEOPERATEUREDITION; }
			set { _OP_CODEOPERATEUREDITION = value; }
		}
        public string TP_CODETYPECLIENT
		{
            get { return _TP_CODETYPECLIENT; }
            set { _TP_CODETYPECLIENT = value; }
		}

        public string TC_CODECOMPTETYPETIERS
		{
            get { return _TC_CODECOMPTETYPETIERS; }
            set { _TC_CODECOMPTETYPETIERS = value; }
		}


        public string TI_NUMTIERS
		{
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
		}

        public string SC_CODESECTION
		{
            get { return _SC_CODESECTION; }
            set { _SC_CODESECTION = value; }
		}

        public string MS_DATERENDEZVOUS1
		{
            get { return _MS_DATERENDEZVOUS1; }
            set { _MS_DATERENDEZVOUS1 = value; }
		}
       public string MS_DATERENDEZVOUS2
		{
            get { return _MS_DATERENDEZVOUS2; }
            set { _MS_DATERENDEZVOUS2 = value; }
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
        public string TI_TVA
        {
            get { return _TI_TVA; }
            set { _TI_TVA = value; }
        }
        public string TI_ASDI
        {
            get { return _TI_ASDI; }
            set { _TI_ASDI = value; }
        }

        public string GP_CODEGROUPE
        {
            get { return _GP_CODEGROUPE; }
            set { _GP_CODEGROUPE = value; }
        }

        public string MS_NUMPIECEPARAM
        {
            get { return _MS_NUMPIECEPARAM; }
            set { _MS_NUMPIECEPARAM = value; }
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

        public clsEditionEtatClientFournisseur() {} 

		

		public clsEditionEtatClientFournisseur(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur)
		{
			AG_CODEAGENCE = clsEditionEtatClientFournisseur.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatClientFournisseur.EN_CODEENTREPOT;
			OP_CODEOPERATEUREDITION = clsEditionEtatClientFournisseur.OP_CODEOPERATEUREDITION;
            TP_CODETYPECLIENT = clsEditionEtatClientFournisseur.TP_CODETYPECLIENT;
            TC_CODECOMPTETYPETIERS = clsEditionEtatClientFournisseur.TC_CODECOMPTETYPETIERS;
            TI_NUMTIERS = clsEditionEtatClientFournisseur.TI_NUMTIERS;
            SC_CODESECTION = clsEditionEtatClientFournisseur.SC_CODESECTION;
            MS_DATERENDEZVOUS1 = clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS1;
            MS_DATERENDEZVOUS2 = clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2;
            ET_TYPEETAT = clsEditionEtatClientFournisseur.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatClientFournisseur.ET_TYPERETOURS;
            TI_ASDI = clsEditionEtatClientFournisseur.TI_ASDI;
            TI_TVA = clsEditionEtatClientFournisseur.TI_TVA;
            GP_CODEGROUPE = clsEditionEtatClientFournisseur.GP_CODEGROUPE;
            MS_NUMPIECEPARAM = clsEditionEtatClientFournisseur.MS_NUMPIECEPARAM;
            PY_CODEPAYS = clsEditionEtatClientFournisseur.PY_CODEPAYS;
            NT_CODENATURETIERS = clsEditionEtatClientFournisseur.NT_CODENATURETIERS;



		}
        }
}