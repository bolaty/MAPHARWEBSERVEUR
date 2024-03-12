using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEtatComptaAnalytique
	{

        //@AG_CODEAGENCE varchar(7000),	
        //@OP_CODEOPERATEUR AS VARCHAR(25),
        //@MI_CODEMISE varchar(7000),
        //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
        //@DATEDEBUT AS DATETIME,
        //@ET_TYPEETAT AS varchar(50),
        //@NUMERODEBUT AS varchar(7000),
        //@DATEFIN AS varchar(7000),
        //@NUMEROFIN varchar(50),

        private string _ET_INDEX = "";
        private string _CODEDECRYPTAGE = "";                    
        private string _AG_CODEAGENCE = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _ZONE = "";
        private string _EXERCICE = "";
        private string _PERIODICITE = "";
        private string _PERIODE;
        private string _OPTION;              
        private string _ET_TYPEETAT = "";
        private string _DATEDEBUT = "";
        private string _DATEFIN = "";

        private string _OP_CODEOPERATEUR = "";
        private string _MI_CODEMISE = "";
        private string _NUMERODEBUT = "";
        private string _OP_CODEOPERATEUREDITION = "";
        
        private string _NUMEROFIN = "";
        private string _CODESTATUT = "";
        private string _CODESTATUTMOUVEMENT = "";
        private string _TYPERETOUR = "";
        private string _TYPEECRAN = "";

        private string _SUPPRIMERTABLEINTERMEDIAIRE = "";

        public string ET_TYPEETAT
        {
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
        }

        public string ET_INDEX
        {
            get { return _ET_INDEX; }
            set { _ET_INDEX = value; }
        }

        public string CODEDECRYPTAGE
        {
            get { return _CODEDECRYPTAGE; }
            set { _CODEDECRYPTAGE = value; }
        }        

        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
        public string PV_CODEPOINTVENTE
		{
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
       
        public string ZONE
        {
            get { return _ZONE; }
			set { _ZONE = value; }
        }

        public string EXERCICE
        {
            get { return _EXERCICE; }
			set { _EXERCICE = value; }
        }

        public string PERIODICITE
        {
            get { return _PERIODICITE; }
			set { _PERIODICITE = value; }
        }

        public string OPTION
        {
            get { return _OPTION; }
            set { _OPTION = value; }
        }

        public string PERIODE
        {
            get { return _PERIODE; }
            set { _PERIODE = value; }
        }
        

        public string MI_CODEMISE
		{
            get { return _MI_CODEMISE; }
            set { _MI_CODEMISE = value; }
		}
        public string DATEDEBUT
		{
            get { return _DATEDEBUT; }
            set { _DATEDEBUT = value; }
		}
        
        public string NUMERODEBUT
		{
            get { return _NUMERODEBUT; }
            set { _NUMERODEBUT = value; }
		}
        public string DATEFIN
		{
            get { return _DATEFIN; }
            set { _DATEFIN = value; }
		}
        public string NUMEROFIN
		{
            get { return _NUMEROFIN; }
            set { _NUMEROFIN = value; }
		}

        public string CODESTATUT
		{
            get { return _CODESTATUT; }
            set { _CODESTATUT = value; }
		}

        public string CODESTATUTMOUVEMENT
		{
            get { return _CODESTATUTMOUVEMENT; }
            set { _CODESTATUTMOUVEMENT = value; }
		}
       
        public string OP_CODEOPERATEUREDITION
		{
            get { return _OP_CODEOPERATEUREDITION; }
            set { _OP_CODEOPERATEUREDITION = value; }
		}

        public string TYPERETOUR
		{
            get { return _TYPERETOUR; }
            set { _TYPERETOUR = value; }
		}

        public string TYPEECRAN
		{
            get { return _TYPEECRAN; }
            set { _TYPEECRAN = value; }
		}

        public string SUPPRIMERTABLEINTERMEDIAIRE
		{
            get { return _SUPPRIMERTABLEINTERMEDIAIRE; }
            set { _SUPPRIMERTABLEINTERMEDIAIRE = value; }
		}

        public clsEtatComptaAnalytique() {} 

		public clsEtatComptaAnalytique(clsEtatComptaAnalytique clsEtatComptaAnalytique)
		{
        OPTION = clsEtatComptaAnalytique.OPTION;
        PERIODE = clsEtatComptaAnalytique.PERIODE;
        PERIODICITE = clsEtatComptaAnalytique.PERIODICITE;
        ZONE = clsEtatComptaAnalytique.ZONE;
        EXERCICE = clsEtatComptaAnalytique.EXERCICE;
        ET_INDEX = clsEtatComptaAnalytique.ET_INDEX;
        ET_TYPEETAT = clsEtatComptaAnalytique.ET_TYPEETAT;
        AG_CODEAGENCE =clsEtatComptaAnalytique.AG_CODEAGENCE;
        PV_CODEPOINTVENTE = clsEtatComptaAnalytique.PV_CODEPOINTVENTE;

        OP_CODEOPERATEUR = clsEtatComptaAnalytique.OP_CODEOPERATEUR;
        MI_CODEMISE = clsEtatComptaAnalytique.MI_CODEMISE;
        OP_CODEOPERATEUREDITION = clsEtatComptaAnalytique.OP_CODEOPERATEUREDITION;
        DATEDEBUT = clsEtatComptaAnalytique.DATEDEBUT;
        CODEDECRYPTAGE = clsEtatComptaAnalytique.CODEDECRYPTAGE;
        NUMERODEBUT = clsEtatComptaAnalytique.NUMERODEBUT;
        DATEFIN = clsEtatComptaAnalytique.DATEFIN;
        NUMEROFIN = clsEtatComptaAnalytique.NUMEROFIN;
        CODESTATUT = clsEtatComptaAnalytique.CODESTATUT;
        CODESTATUTMOUVEMENT = clsEtatComptaAnalytique.CODESTATUTMOUVEMENT;

        TYPERETOUR = clsEtatComptaAnalytique.TYPERETOUR;
        TYPEECRAN = clsEtatComptaAnalytique.TYPEECRAN;
        SUPPRIMERTABLEINTERMEDIAIRE = clsEtatComptaAnalytique.SUPPRIMERTABLEINTERMEDIAIRE;
			
		}
    }
}