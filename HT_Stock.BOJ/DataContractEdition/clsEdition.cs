using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEdition : clsEntitieBase
    {


    //    @AG_CODEAGENCE varchar(7000),	
    //@JT_DATEJOURNEETRAVAILAS VARCHAR(25),
    //@DATEDEBUT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _EX_EXERCICE = "";
        private string _JT_DATEJOURNEETRAVAIL = "";
        private string _EX_DATEDEBUT = "";
        private string _EX_DATEFIN = "";
        private string _EX_DESCEXERCICE = "";
        private string _EX_ETATEXERCICE = "";
        private string _EX_DATESAISIE = "";
        private string _EX_DATEDEBUTBILAN = "";
        private string _EX_DATEFINBILAN = "";
        private string _PE_CODEPERIODICITE = "";
        private string _PE_LIBELLE = "";
        private string _PE_ABREVIATION = "";
        private string _PE_UNITE = "";
        private string _PE_PERIODICITE = "";
        private string _PE_MULTIPLE = "";
        private string _PE_PRODUCTIONETATFINANCIER = "";
        private string _PE_PROCEDUREAUTOMATIQUE = "";
        private string _PE_ORDREVIREMENT = "";
        private string _PE_NUMEROORDRE = "";
        private string _PE_ACTIF = "";

        private string _ZN_CODEZONE = "";
        private string _ZN_NOMZONE = "";
        private string _SO_CODESOCIETE = "";
        private string _ZN_DESCRIPTION = "";
        private string _OP_CODEOPERATEUR = "";
         private string _AG_RAISONSOCIAL = "";
         private string _MO_CODEMOIS = "";
         private string _MO_LIBELLE = "";
         private string _MO_DATEDEBUT = "";
         private string _MO_DATEFIN = "";
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

        public string EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
        }
        public string JT_DATEJOURNEETRAVAIL
        {
            get { return _JT_DATEJOURNEETRAVAIL; }
            set { _JT_DATEJOURNEETRAVAIL = value; }
        }
        public string EX_DATEDEBUT
        {
            get { return _EX_DATEDEBUT; }
            set { _EX_DATEDEBUT = value; }
        }
        public string EX_DATEFIN
        {
            get { return _EX_DATEFIN; }
            set { _EX_DATEFIN = value; }
        }
        public string EX_DESCEXERCICE
        {
            get { return _EX_DESCEXERCICE; }
            set { _EX_DESCEXERCICE = value; }
        }                
        public string EX_ETATEXERCICE
        {
            get { return _EX_ETATEXERCICE; }
            set { _EX_ETATEXERCICE = value; }
        } 
        public string EX_DATESAISIE
        {
            get { return _EX_DATESAISIE; }
            set { _EX_DATESAISIE = value; }
        } 
        public string EX_DATEDEBUTBILAN
        {
            get { return _EX_DATEDEBUTBILAN; }
            set { _EX_DATEDEBUTBILAN = value; }
        } 

        public string EX_DATEFINBILAN
        {
            get { return _EX_DATEFINBILAN; }
            set { _EX_DATEFINBILAN = value; }
        }

        public string PE_CODEPERIODICITE
        {
            get { return _PE_CODEPERIODICITE; }
            set { _PE_CODEPERIODICITE = value; }
        }
        public string PE_LIBELLE
        {
            get { return _PE_LIBELLE; }
            set { _PE_LIBELLE = value; }
        }
        public string PE_ABREVIATION
        {
            get { return _PE_ABREVIATION; }
            set { _PE_ABREVIATION = value; }
        }
        public string PE_UNITE
        {
            get { return _PE_UNITE; }
            set { _PE_UNITE = value; }
        }
        public string PE_PERIODICITE
        {
            get { return _PE_PERIODICITE; }
            set { _PE_PERIODICITE = value; }
        }
        public string PE_MULTIPLE
        {
            get { return _PE_MULTIPLE; }
            set { _PE_MULTIPLE = value; }
        }
        public string PE_PRODUCTIONETATFINANCIER
        {
            get { return _PE_PRODUCTIONETATFINANCIER; }
            set { _PE_PRODUCTIONETATFINANCIER = value; }
        }
        public string PE_PROCEDUREAUTOMATIQUE
        {
            get { return _PE_PROCEDUREAUTOMATIQUE; }
            set { _PE_PROCEDUREAUTOMATIQUE = value; }
        }
        public string PE_ORDREVIREMENT
        {
            get { return _PE_ORDREVIREMENT; }
            set { _PE_ORDREVIREMENT = value; }
        }
        public string PE_NUMEROORDRE
        {
            get { return _PE_NUMEROORDRE; }
            set { _PE_NUMEROORDRE = value; }
        }
        public string PE_ACTIF
        {
            get { return _PE_ACTIF; }
            set { _PE_ACTIF = value; }
        }
        public string ZN_CODEZONE
        {
            get { return _ZN_CODEZONE; }
            set { _ZN_CODEZONE = value; }
        }

        public string ZN_NOMZONE
        {
            get { return _ZN_NOMZONE; }
            set { _ZN_NOMZONE = value; }
        }
        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }
        public string ZN_DESCRIPTION
        {
            get { return _ZN_DESCRIPTION; }
            set { _ZN_DESCRIPTION = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
        }

        public string MO_CODEMOIS
        {
            get { return _MO_CODEMOIS; }
            set { _MO_CODEMOIS = value; }
        }
        public string MO_LIBELLE
        {
            get { return _MO_LIBELLE; }
            set { _MO_LIBELLE = value; }
        }
        public string MO_DATEDEBUT
        {
            get { return _MO_DATEDEBUT; }
            set { _MO_DATEDEBUT = value; }
        }

        public string MO_DATEFIN
        {
            get { return _MO_DATEFIN; }
            set { _MO_DATEFIN = value; }
        }
        public clsEdition() {} 

		

		public clsEdition(clsEdition clsEdition)
		{
			AG_CODEAGENCE = clsEdition.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEdition.EN_CODEENTREPOT;
            EX_EXERCICE = clsEdition.EX_EXERCICE;
            JT_DATEJOURNEETRAVAIL = clsEdition.JT_DATEJOURNEETRAVAIL;
            EX_DATEDEBUT = clsEdition.EX_DATEDEBUT;
            EX_DATEFIN = clsEdition.EX_DATEFIN;
            EX_DESCEXERCICE = clsEdition.EX_DESCEXERCICE;
            EX_ETATEXERCICE = clsEdition.EX_ETATEXERCICE;
            EX_DATESAISIE = clsEdition.EX_DATESAISIE;
            EX_DATEDEBUTBILAN = clsEdition.EX_DATEDEBUTBILAN;
            EX_DATEFINBILAN = clsEdition.EX_DATEFINBILAN;

            PE_CODEPERIODICITE = clsEdition.PE_CODEPERIODICITE;
            PE_LIBELLE = clsEdition.PE_LIBELLE;
            PE_ABREVIATION = clsEdition.PE_ABREVIATION;
            PE_UNITE = clsEdition.PE_UNITE;
            PE_PERIODICITE = clsEdition.PE_PERIODICITE;
            PE_MULTIPLE = clsEdition.PE_MULTIPLE;
            PE_PRODUCTIONETATFINANCIER = clsEdition.PE_PRODUCTIONETATFINANCIER;
            PE_PROCEDUREAUTOMATIQUE = clsEdition.PE_PROCEDUREAUTOMATIQUE;
            PE_ORDREVIREMENT = clsEdition.PE_ORDREVIREMENT;
            PE_NUMEROORDRE = clsEdition.PE_NUMEROORDRE;
            PE_ACTIF = clsEdition.PE_ACTIF;


            ZN_CODEZONE = clsEdition.ZN_CODEZONE;
            ZN_NOMZONE = clsEdition.ZN_NOMZONE;
            SO_CODESOCIETE = clsEdition.SO_CODESOCIETE;
            ZN_DESCRIPTION = clsEdition.ZN_DESCRIPTION;
            OP_CODEOPERATEUR = clsEdition.OP_CODEOPERATEUR;
            AG_RAISONSOCIAL = clsEdition.AG_RAISONSOCIAL;
            MO_CODEMOIS = clsEdition.MO_CODEMOIS;
            MO_LIBELLE = clsEdition.MO_LIBELLE;
            MO_DATEDEBUT = clsEdition.MO_DATEDEBUT;
            MO_DATEFIN = clsEdition.MO_DATEFIN;
        }
    }
}