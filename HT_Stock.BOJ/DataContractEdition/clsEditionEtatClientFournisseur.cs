using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEditionEtatClientFournisseur : clsEntitieBase
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

        private string _TP_CODETYPETIERS = "";
        private string _TP_LIBELLE = "";
        private string _NT_LIBELLE = "";
        private string _NT_DESCRIPTION = "";
        private string _NT_NUMEROORDRE = "";
        private string _NT_INVENTAIRE = "";
        private string _TP_DESCRIPTION = "";
        private string _MS_NUMPIECE = "";

       


        private string _CL_IDCLIENT = "";
        //private string _AG_CODEAGENCE = "";
        private string _SX_CODESEXE = "";
        private string _SM_CODESITUATIONMATRIMONIALE = "";
        private string _PF_CODEPROFESSION = "";
        private string _AC_CODEACTIVITE = "";
        //private string _TP_CODETYPECLIENT = "";
        //private string _TP_LIBELLE = "";
        private string _OP_CODEOPERATEUR = "";
        private string _CL_NUMCLIENT = "";
        private string _CL_DATENAISSANCE = "";
        private string _CL_DENOMINATION = "";
        private string _CL_DESCRIPTIONCLIENT = "";
        private string _CL_ADRESSEPOSTALE = "";
        private string _CL_ADRESSEGEOGRAPHIQUE = "";
        private string _CL_TELEPHONE = "";
        private string _CL_FAX = "";
        private string _CL_SITEWEB = "";
        private string _CL_EMAIL = "";
        private string _CL_GERANT = "";
        private string _CL_STATUT = "";
        private string _CL_DATESAISIE = "";
        private string _CL_DATEDEPART = "";
        private string _CL_ASDI = "";
        private string _CL_TVA = "";
        private double _CL_STATUTDOUTEUX = 0;
        private double _CL_PLAFONDCREDIT =0;
        private string _CL_NUMCPTECONTIBUABLE = "";
        private string _TI_IDTIERS = "";
        //private string _TP_CODETYPETIERS = "";
        private string _PL_CODENUMCOMPTE = "";
        //private string _TI_NUMTIERS = "";
        private string _TI_DATENAISSANCE = "";
        private string _TI_DENOMINATION = "";
        private string _TI_DESCRIPTIONTIERS = "";
        private string _TI_ADRESSEPOSTALE = "";
        private string _TI_ADRESSEGEOGRAPHIQUE = "";
        private string _TI_TELEPHONE = "";
        private string _TI_FAX = "";
        private string _TI_SITEWEB = "";
        private string _TI_EMAIL = "";
        private string _TI_GERANT = "";
        private string _TI_STATUT = "";
        private string _TI_DATESAISIE = "";
        private string _TI_DATEDEPART = "";
        //private string _TI_ASDI = "";
        //private string _TI_TVA = "";
        private string _TI_STATUTDOUTEUX = "";
        private double _TI_PLAFONDCREDIT = 0;
        private string _TI_NUMCPTECONTIBUABLE = "";
        private string _TI_TAUXREMISE = "";
        private double _TI_SOLDE =0;
        private double _TI_CHIFFREAFFAIRE = 0;
        private string _FR_CODEFOURNISSEUR = "";
        private string _TF_CODETYPEFOURNISSEUR = "";
        private string _TF_LIBELLE = "";
        private string _FR_MATRICULE = "";
        private string _FR_DENOMINATION = "";
        private string _FR_SIEGE = "";
        private string _FR_ADRESSEPOSTALE = "";
        private string _FR_ADRESSEGEOGRAPHIQUE = "";
        private string _FR_TELEPHONE = "";
        private string _FR_SITEWEB = "";
        private string _FR_EMAIL = "";
        private string _FR_GERANT = "";
        private string _FR_STATUT = "";
        private string _CO_CODECOMMUNE = "";
        private string _CO_LIBELLE = "";
        private string _SX_LIBELLE = "";
        private string _MS_DATERENDEZVOUS = "";
        private string _NUMEROBORDEREAU = "";
        private string _MD_REMETTANT = "";
        private string _MS_DATEPIECE = "";
        private string _MS_NUMSEQUENCE = "";


        private string _VH_CODEVEHICULE = "";
        private string _VH_MATRICULE = "";
        private string _TVH_CODETYPE = "";
        private string _TVH_LIBELE = "";
        private string _CH_IDCHAUFFEUR = "";
        private string _CH_NUMCHAUFFEUR = "";
        private string _CH_DATENAISSANCE = "";
        private string _CH_NOMPRENOM = "";
        private string _CH_ADRESSEPOSTALE = "";
        private string _CH_ADRESSEGEOGRAPHIQUE = "";
        private string _CH_TELEPHONE = "";
        private string _CH_EMAIL = "";
        private string _CH_STATUT = "";
        private string _CH_DATESAISIE = "";

        private string _CO_IDCOMMERCIAL = "";
        private string _CO_NUMCOMMERCIAL = "";
        private string _CO_DATENAISSANCE = "";
        private string _CO_NOMPRENOM = "";
        private string _CO_ADRESSEPOSTALE = "";
        private string _CO_ADRESSEGEOGRAPHIQUE = "";
        private string _CO_TELEPHONE = "";
        private string _CO_EMAIL = "";
        private string _CO_STATUT = "";
        private string _CO_TAUXCOMMISSION = "";
        private double _CO_MONTANTCOMMISSION = 0;
        private double _CO_ENCOURS = 0;
        private string _CO_DATESAISIE = "";

        private double _EC_MONTANTECHEANCE = 0;
        private string _EC_DATEECHEANCE = "";
        private double _MONTANTFACTURE = 0;
        private double _MONTANTAPAYER = 0;
        private double _MONTANTPAYER = 0;
        private double _RESTEAPAYER = 0;

        //CH_IDCHAUFFEUR = clsEditionEtatClientFournisseur.CH_IDCHAUFFEUR;
        //    CH_NUMCHAUFFEUR = clsEditionEtatClientFournisseur.CH_NUMCHAUFFEUR;
        //    CH_DATENAISSANCE = clsEditionEtatClientFournisseur.CH_DATENAISSANCE;
        //    CH_NOMPRENOM = clsEditionEtatClientFournisseur.CH_NOMPRENOM;
        //    CH_ADRESSEPOSTALE = clsEditionEtatClientFournisseur.CH_ADRESSEPOSTALE;
        //    CH_ADRESSEGEOGRAPHIQUE = clsEditionEtatClientFournisseur.CH_ADRESSEGEOGRAPHIQUE;
        //    CH_TELEPHONE = clsEditionEtatClientFournisseur.CH_TELEPHONE;
        //    CH_EMAIL = clsEditionEtatClientFournisseur.CH_EMAIL;
        //    CH_STATUT = clsEditionEtatClientFournisseur.CH_STATUT;
        //    CH_DATESAISIE = clsEditionEtatClientFournisseur.CH_DATESAISIE;


        //MS_DATERENDEZVOUS = clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS;
        //    NUMEROBORDEREAU = clsEditionEtatClientFournisseur.NUMEROBORDEREAU;
        //    MD_REMETTANT = clsEditionEtatClientFournisseur.MD_REMETTANT;
        //    MS_DATEPIECE = clsEditionEtatClientFournisseur.MS_DATEPIECE;
        //    MS_NUMSEQUENCE = clsEditionEtatClientFournisseur.MS_NUMSEQUENCE;












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
        public string TP_CODETYPETIERS
        {
            get { return _TP_CODETYPETIERS; }
            set { _TP_CODETYPETIERS = value; }
        }
        public string TP_LIBELLE
        {
            get { return _TP_LIBELLE; }
            set { _TP_LIBELLE = value; }
        }
        public string NT_LIBELLE
        {
            get { return _NT_LIBELLE; }
            set { _NT_LIBELLE = value; }
        }
        public string NT_DESCRIPTION
        {
            get { return _NT_DESCRIPTION; }
            set { _NT_DESCRIPTION = value; }
        }
        public string NT_NUMEROORDRE
        {
            get { return _NT_NUMEROORDRE; }
            set { _NT_NUMEROORDRE = value; }
        }
        public string NT_INVENTAIRE
        {
            get { return _NT_INVENTAIRE; }
            set { _NT_INVENTAIRE = value; }
        }
        public string TP_DESCRIPTION
        {
            get { return _TP_DESCRIPTION; }
            set { _TP_DESCRIPTION = value; }
        }


        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }
        public string SX_CODESEXE
        {
            get { return _SX_CODESEXE; }
            set { _SX_CODESEXE = value; }
        }
        public string SM_CODESITUATIONMATRIMONIALE
        {
            get { return _SM_CODESITUATIONMATRIMONIALE; }
            set { _SM_CODESITUATIONMATRIMONIALE = value; }
        }
        public string PF_CODEPROFESSION
        {
            get { return _PF_CODEPROFESSION; }
            set { _PF_CODEPROFESSION = value; }
        }
        public string AC_CODEACTIVITE
        {
            get { return _AC_CODEACTIVITE; }
            set { _AC_CODEACTIVITE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public string CL_NUMCLIENT
        {
            get { return _CL_NUMCLIENT; }
            set { _CL_NUMCLIENT = value; }
        }
        public string CL_DATENAISSANCE
        {
            get { return _CL_DATENAISSANCE; }
            set { _CL_DATENAISSANCE = value; }
        }

        public string CL_DENOMINATION
        {
            get { return _CL_DENOMINATION; }
            set { _CL_DENOMINATION = value; }
        }
        public string CL_DESCRIPTIONCLIENT
        {
            get { return _CL_DESCRIPTIONCLIENT; }
            set { _CL_DESCRIPTIONCLIENT = value; }
        }
        public string CL_ADRESSEPOSTALE
        {
            get { return _CL_ADRESSEPOSTALE; }
            set { _CL_ADRESSEPOSTALE = value; }
        }
        public string CL_ADRESSEGEOGRAPHIQUE
        {
            get { return _CL_ADRESSEGEOGRAPHIQUE; }
            set { _CL_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string CL_TELEPHONE
        {
            get { return _CL_TELEPHONE; }
            set { _CL_TELEPHONE = value; }
        }
        public string CL_FAX
        {
            get { return _CL_FAX; }
            set { _CL_FAX = value; }
        }
        public string CL_SITEWEB
        {
            get { return _CL_SITEWEB; }
            set { _CL_SITEWEB = value; }
        }
        public string CL_EMAIL
        {
            get { return _CL_EMAIL; }
            set { _CL_EMAIL = value; }
        }
        public string CL_GERANT
        {
            get { return _CL_GERANT; }
            set { _CL_GERANT = value; }
        }
        public string CL_STATUT
        {
            get { return _CL_STATUT; }
            set { _CL_STATUT = value; }
        }
        public string CL_DATESAISIE
        {
            get { return _CL_DATESAISIE; }
            set { _CL_DATESAISIE = value; }
        }
        public string CL_DATEDEPART
        {
            get { return _CL_DATEDEPART; }
            set { _CL_DATEDEPART = value; }
        }
        public string CL_ASDI
        {
            get { return _CL_ASDI; }
            set { _CL_ASDI = value; }
        }
        public string CL_TVA
        {
            get { return _CL_TVA; }
            set { _CL_TVA = value; }
        }
        public double CL_STATUTDOUTEUX
        {
            get { return _CL_STATUTDOUTEUX; }
            set { _CL_STATUTDOUTEUX = value; }
        }
        public double CL_PLAFONDCREDIT
        {
            get { return _CL_PLAFONDCREDIT; }
            set { _CL_PLAFONDCREDIT = value; }
        }
        public string CL_NUMCPTECONTIBUABLE
        {
            get { return _CL_NUMCPTECONTIBUABLE; }
            set { _CL_NUMCPTECONTIBUABLE = value; }
        }
        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }
        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }
        public string TI_DATENAISSANCE
        {
            get { return _TI_DATENAISSANCE; }
            set { _TI_DATENAISSANCE = value; }
        }
        public string TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }
        public string TI_DESCRIPTIONTIERS
        {
            get { return _TI_DESCRIPTIONTIERS; }
            set { _TI_DESCRIPTIONTIERS = value; }
        }
        public string TI_ADRESSEPOSTALE
        {
            get { return _TI_ADRESSEPOSTALE; }
            set { _TI_ADRESSEPOSTALE = value; }
        }
        public string TI_ADRESSEGEOGRAPHIQUE
        {
            get { return _TI_ADRESSEGEOGRAPHIQUE; }
            set { _TI_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string TI_TELEPHONE
        {
            get { return _TI_TELEPHONE; }
            set { _TI_TELEPHONE = value; }
        }
        public string TI_FAX
        {
            get { return _TI_FAX; }
            set { _TI_FAX = value; }
        }
        public string TI_SITEWEB
        {
            get { return _TI_SITEWEB; }
            set { _TI_SITEWEB = value; }
        }
        public string TI_EMAIL
        {
            get { return _TI_EMAIL; }
            set { _TI_EMAIL = value; }
        }
        public string TI_GERANT
        {
            get { return _TI_GERANT; }
            set { _TI_GERANT = value; }
        }
        public string TI_STATUT
        {
            get { return _TI_STATUT; }
            set { _TI_STATUT = value; }
        }
        public string TI_DATESAISIE
        {
            get { return _TI_DATESAISIE; }
            set { _TI_DATESAISIE = value; }
        }
        public string TI_DATEDEPART
        {
            get { return _TI_DATEDEPART; }
            set { _TI_DATEDEPART = value; }
        }

        public string TI_STATUTDOUTEUX
        {
            get { return _TI_STATUTDOUTEUX; }
            set { _TI_STATUTDOUTEUX = value; }
        }
        public double TI_PLAFONDCREDIT
        {
            get { return _TI_PLAFONDCREDIT; }
            set { _TI_PLAFONDCREDIT = value; }
        }
        public string TI_NUMCPTECONTIBUABLE
        {
            get { return _TI_NUMCPTECONTIBUABLE; }
            set { _TI_NUMCPTECONTIBUABLE = value; }
        }
        public string TI_TAUXREMISE
        {
            get { return _TI_TAUXREMISE; }
            set { _TI_TAUXREMISE = value; }
        }
        public double TI_SOLDE
        {
            get { return _TI_SOLDE; }
            set { _TI_SOLDE = value; }
        }
        public double TI_CHIFFREAFFAIRE
        {
            get { return _TI_CHIFFREAFFAIRE; }
            set { _TI_CHIFFREAFFAIRE = value; }
        }
        public string FR_CODEFOURNISSEUR
        {
            get { return _FR_CODEFOURNISSEUR; }
            set { _FR_CODEFOURNISSEUR = value; }
        }
        public string TF_CODETYPEFOURNISSEUR
        {
            get { return _TF_CODETYPEFOURNISSEUR; }
            set { _TF_CODETYPEFOURNISSEUR = value; }
        }
        public string TF_LIBELLE
        {
            get { return _TF_LIBELLE; }
            set { _TF_LIBELLE = value; }
        }
        public string FR_MATRICULE
        {
            get { return _FR_MATRICULE; }
            set { _FR_MATRICULE = value; }
        }
        public string FR_DENOMINATION
        {
            get { return _FR_DENOMINATION; }
            set { _FR_DENOMINATION = value; }
        }
        public string FR_SIEGE
        {
            get { return _FR_SIEGE; }
            set { _FR_SIEGE = value; }
        }
        public string FR_ADRESSEPOSTALE
        {
            get { return _FR_ADRESSEPOSTALE; }
            set { _FR_ADRESSEPOSTALE = value; }
        }
        public string FR_ADRESSEGEOGRAPHIQUE
        {
            get { return _FR_ADRESSEGEOGRAPHIQUE; }
            set { _FR_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string FR_TELEPHONE
        {
            get { return _FR_TELEPHONE; }
            set { _FR_TELEPHONE = value; }
        }
        public string FR_SITEWEB
        {
            get { return _FR_SITEWEB; }
            set { _FR_SITEWEB = value; }
        }
        public string FR_EMAIL
        {
            get { return _FR_EMAIL; }
            set { _FR_EMAIL = value; }
        }
        public string FR_GERANT
        {
            get { return _FR_GERANT; }
            set { _FR_GERANT = value; }
        }
        public string FR_STATUT
        {
            get { return _FR_STATUT; }
            set { _FR_STATUT = value; }
        }
        public string CO_CODECOMMUNE
        {
            get { return _CO_CODECOMMUNE; }
            set { _CO_CODECOMMUNE = value; }
        }
        public string CO_LIBELLE
        {
            get { return _CO_LIBELLE; }
            set { _CO_LIBELLE = value; }
        }
        public string SX_LIBELLE
        {
            get { return _SX_LIBELLE; }
            set { _SX_LIBELLE = value; }
        }
        public string MS_NUMPIECE
        {
            get { return _MS_NUMPIECE; }
            set { _MS_NUMPIECE = value; }
        }
        public string MS_DATERENDEZVOUS
        {
            get { return _MS_DATERENDEZVOUS; }
            set { _MS_DATERENDEZVOUS = value; }
        }
        public string NUMEROBORDEREAU
        {
            get { return _NUMEROBORDEREAU; }
            set { _NUMEROBORDEREAU = value; }
        }
        public string MD_REMETTANT
        {
            get { return _MD_REMETTANT; }
            set { _MD_REMETTANT = value; }
        }
        public string MS_DATEPIECE
        {
            get { return _MS_DATEPIECE; }
            set { _MS_DATEPIECE = value; }
        }
       public string MS_NUMSEQUENCE
        {
            get { return _MS_NUMSEQUENCE; }
            set { _MS_NUMSEQUENCE = value; }
        }

        public string VH_CODEVEHICULE
        {
            get { return _VH_CODEVEHICULE; }
            set { _VH_CODEVEHICULE = value; }
        }
        public string VH_MATRICULE
        {
            get { return _VH_MATRICULE; }
            set { _VH_MATRICULE = value; }
        }    
        
        public string TVH_CODETYPE
        {
            get { return _TVH_CODETYPE; }
            set { _TVH_CODETYPE = value; }
        }         
        public string TVH_LIBELE
        {
            get { return _TVH_LIBELE; }
            set { _TVH_LIBELE = value; }
        }
        public string CH_IDCHAUFFEUR
        {
            get { return _CH_IDCHAUFFEUR; }
            set { _CH_IDCHAUFFEUR = value; }
        }
        public string CH_NUMCHAUFFEUR
        {
            get { return _CH_NUMCHAUFFEUR; }
            set { _CH_NUMCHAUFFEUR = value; }
        }
        public string CH_DATENAISSANCE
        {
            get { return _CH_DATENAISSANCE; }
            set { _CH_DATENAISSANCE = value; }
        }
        public string CH_NOMPRENOM
        {
            get { return _CH_NOMPRENOM; }
            set { _CH_NOMPRENOM = value; }
        }
        public string CH_ADRESSEPOSTALE
        {
            get { return _CH_ADRESSEPOSTALE; }
            set { _CH_ADRESSEPOSTALE = value; }
        }
        public string CH_ADRESSEGEOGRAPHIQUE
        {
            get { return _CH_ADRESSEGEOGRAPHIQUE; }
            set { _CH_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string CH_TELEPHONE
        {
            get { return _CH_TELEPHONE; }
            set { _CH_TELEPHONE = value; }
        }
        public string CH_EMAIL
        {
            get { return _CH_EMAIL; }
            set { _CH_EMAIL = value; }
        }
        public string CH_STATUT
        {
            get { return _CH_STATUT; }
            set { _CH_STATUT = value; }
        }
        public string CH_DATESAISIE
        {
            get { return _CH_DATESAISIE; }
            set { _CH_DATESAISIE = value; }
        }
        public string CO_IDCOMMERCIAL
        {
            get { return _CO_IDCOMMERCIAL; }
            set { _CO_IDCOMMERCIAL = value; }
        }
        public string CO_NUMCOMMERCIAL
        {
            get { return _CO_NUMCOMMERCIAL; }
            set { _CO_NUMCOMMERCIAL = value; }
        }
        public string CO_DATENAISSANCE
        {
            get { return _CO_DATENAISSANCE; }
            set { _CO_DATENAISSANCE = value; }
        }
        public string CO_NOMPRENOM
        {
            get { return _CO_NOMPRENOM; }
            set { _CO_NOMPRENOM = value; }
        }
        public string CO_ADRESSEPOSTALE
        {
            get { return _CO_ADRESSEPOSTALE; }
            set { _CO_ADRESSEPOSTALE = value; }
        }
        public string CO_ADRESSEGEOGRAPHIQUE
        {
            get { return _CO_ADRESSEGEOGRAPHIQUE; }
            set { _CO_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string CO_TELEPHONE
        {
            get { return _CO_TELEPHONE; }
            set { _CO_TELEPHONE = value; }
        }
        public string CO_EMAIL
        {
            get { return _CO_EMAIL; }
            set { _CO_EMAIL = value; }
        }
        public string CO_STATUT
        {
            get { return _CO_STATUT; }
            set { _CO_STATUT = value; }
        }
        public string CO_TAUXCOMMISSION
        {
            get { return _CO_TAUXCOMMISSION; }
            set { _CO_TAUXCOMMISSION = value; }
        }
        public double CO_MONTANTCOMMISSION
        {
            get { return _CO_MONTANTCOMMISSION; }
            set { _CO_MONTANTCOMMISSION = value; }
        }
        public double CO_ENCOURS
        {
            get { return _CO_ENCOURS; }
            set { _CO_ENCOURS = value; }
        }
        public string CO_DATESAISIE
        {
            get { return _CO_DATESAISIE; }
            set { _CO_DATESAISIE = value; }
        }
        public double EC_MONTANTECHEANCE
        {
            get { return _EC_MONTANTECHEANCE; }
            set { _EC_MONTANTECHEANCE = value; }
        }
        public string EC_DATEECHEANCE
        {
            get { return _EC_DATEECHEANCE; }
            set { _EC_DATEECHEANCE = value; }
        }
        public double MONTANTFACTURE
        {
            get { return _MONTANTFACTURE; }
            set { _MONTANTFACTURE = value; }
        }
        public double MONTANTAPAYER
        {
            get { return _MONTANTAPAYER; }
            set { _MONTANTAPAYER = value; }
        }
        public double MONTANTPAYER
        {
            get { return _MONTANTPAYER; }
            set { _MONTANTPAYER = value; }
        }
        public double RESTEAPAYER
        {
            get { return _RESTEAPAYER; }
            set { _RESTEAPAYER = value; }
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
            TP_DESCRIPTION = clsEditionEtatClientFournisseur.TP_DESCRIPTION;


            CL_IDCLIENT = clsEditionEtatClientFournisseur.CL_IDCLIENT;
            AG_CODEAGENCE = clsEditionEtatClientFournisseur.AG_CODEAGENCE;
            SX_CODESEXE = clsEditionEtatClientFournisseur.SX_CODESEXE;
            SM_CODESITUATIONMATRIMONIALE = clsEditionEtatClientFournisseur.SM_CODESITUATIONMATRIMONIALE;
            PF_CODEPROFESSION = clsEditionEtatClientFournisseur.PF_CODEPROFESSION;
            AC_CODEACTIVITE = clsEditionEtatClientFournisseur.AC_CODEACTIVITE;
            TP_CODETYPECLIENT = clsEditionEtatClientFournisseur.TP_CODETYPECLIENT;
            TP_LIBELLE = clsEditionEtatClientFournisseur.TP_LIBELLE;
            OP_CODEOPERATEUR = clsEditionEtatClientFournisseur.OP_CODEOPERATEUR;
            CL_NUMCLIENT = clsEditionEtatClientFournisseur.CL_NUMCLIENT;
            CL_DATENAISSANCE = clsEditionEtatClientFournisseur.CL_DATENAISSANCE;
            CL_DENOMINATION = clsEditionEtatClientFournisseur.CL_DENOMINATION;
            CL_DESCRIPTIONCLIENT = clsEditionEtatClientFournisseur.CL_DESCRIPTIONCLIENT;
            CL_ADRESSEPOSTALE = clsEditionEtatClientFournisseur.CL_ADRESSEPOSTALE;
            CL_ADRESSEGEOGRAPHIQUE = clsEditionEtatClientFournisseur.CL_ADRESSEGEOGRAPHIQUE;
            CL_TELEPHONE = clsEditionEtatClientFournisseur.CL_TELEPHONE;
            CL_FAX = clsEditionEtatClientFournisseur.CL_FAX;
            CL_SITEWEB = clsEditionEtatClientFournisseur.CL_SITEWEB;
            CL_EMAIL = clsEditionEtatClientFournisseur.CL_EMAIL;
            CL_GERANT = clsEditionEtatClientFournisseur.CL_GERANT;
            CL_STATUT = clsEditionEtatClientFournisseur.CL_STATUT;
            CL_DATESAISIE = clsEditionEtatClientFournisseur.CL_DATESAISIE;
            CL_DATEDEPART = clsEditionEtatClientFournisseur.CL_DATEDEPART;
            CL_ASDI = clsEditionEtatClientFournisseur.CL_ASDI;
            CL_TVA = clsEditionEtatClientFournisseur.CL_TVA;
            CL_STATUTDOUTEUX = clsEditionEtatClientFournisseur.CL_STATUTDOUTEUX;
            CL_PLAFONDCREDIT = clsEditionEtatClientFournisseur.CL_PLAFONDCREDIT;
            CL_NUMCPTECONTIBUABLE = clsEditionEtatClientFournisseur.CL_NUMCPTECONTIBUABLE;
            TI_IDTIERS = clsEditionEtatClientFournisseur.TI_IDTIERS;
            TP_CODETYPETIERS = clsEditionEtatClientFournisseur.TP_CODETYPETIERS;
            PL_CODENUMCOMPTE = clsEditionEtatClientFournisseur.PL_CODENUMCOMPTE;
            TI_NUMTIERS = clsEditionEtatClientFournisseur.TI_NUMTIERS;
            TI_DATENAISSANCE = clsEditionEtatClientFournisseur.TI_DATENAISSANCE;
            TI_DENOMINATION = clsEditionEtatClientFournisseur.TI_DENOMINATION;
            TI_DESCRIPTIONTIERS = clsEditionEtatClientFournisseur.TI_DESCRIPTIONTIERS;
            TI_ADRESSEPOSTALE = clsEditionEtatClientFournisseur.TI_ADRESSEPOSTALE;
            TI_ADRESSEGEOGRAPHIQUE = clsEditionEtatClientFournisseur.TI_ADRESSEGEOGRAPHIQUE;
            TI_TELEPHONE = clsEditionEtatClientFournisseur.TI_TELEPHONE;
            TI_FAX = clsEditionEtatClientFournisseur.TI_FAX;
            TI_SITEWEB = clsEditionEtatClientFournisseur.TI_SITEWEB;
            TI_EMAIL = clsEditionEtatClientFournisseur.TI_EMAIL;
            TI_GERANT = clsEditionEtatClientFournisseur.TI_GERANT;
            TI_STATUT = clsEditionEtatClientFournisseur.TI_STATUT;
            TI_DATESAISIE = clsEditionEtatClientFournisseur.TI_DATESAISIE;
            TI_DATEDEPART = clsEditionEtatClientFournisseur.TI_DATEDEPART;
            TI_ASDI = clsEditionEtatClientFournisseur.TI_ASDI;
            TI_TVA = clsEditionEtatClientFournisseur.TI_TVA;
            TI_STATUTDOUTEUX = clsEditionEtatClientFournisseur.TI_STATUTDOUTEUX;
            TI_PLAFONDCREDIT = clsEditionEtatClientFournisseur.TI_PLAFONDCREDIT;
            TI_NUMCPTECONTIBUABLE = clsEditionEtatClientFournisseur.TI_NUMCPTECONTIBUABLE;
            TI_TAUXREMISE = clsEditionEtatClientFournisseur.TI_TAUXREMISE;
            TI_SOLDE = clsEditionEtatClientFournisseur.TI_SOLDE;
            TI_CHIFFREAFFAIRE = clsEditionEtatClientFournisseur.TI_CHIFFREAFFAIRE;
            FR_CODEFOURNISSEUR = clsEditionEtatClientFournisseur.FR_CODEFOURNISSEUR;
            TF_CODETYPEFOURNISSEUR = clsEditionEtatClientFournisseur.TF_CODETYPEFOURNISSEUR;
            TF_LIBELLE = clsEditionEtatClientFournisseur.TF_LIBELLE;
            FR_MATRICULE = clsEditionEtatClientFournisseur.FR_MATRICULE;
            FR_DENOMINATION = clsEditionEtatClientFournisseur.FR_DENOMINATION;
            FR_SIEGE = clsEditionEtatClientFournisseur.FR_SIEGE;
            FR_ADRESSEPOSTALE = clsEditionEtatClientFournisseur.FR_ADRESSEPOSTALE;
            FR_ADRESSEGEOGRAPHIQUE = clsEditionEtatClientFournisseur.FR_ADRESSEGEOGRAPHIQUE;
            FR_TELEPHONE = clsEditionEtatClientFournisseur.FR_TELEPHONE;
            FR_SITEWEB = clsEditionEtatClientFournisseur.FR_SITEWEB;
            FR_EMAIL = clsEditionEtatClientFournisseur.FR_EMAIL;
            FR_GERANT = clsEditionEtatClientFournisseur.FR_GERANT;
            FR_STATUT = clsEditionEtatClientFournisseur.FR_STATUT;
            CO_CODECOMMUNE = clsEditionEtatClientFournisseur.CO_CODECOMMUNE;
            CO_LIBELLE = clsEditionEtatClientFournisseur.CO_LIBELLE;
            SX_LIBELLE = clsEditionEtatClientFournisseur.SX_LIBELLE;
            MS_NUMPIECE = clsEditionEtatClientFournisseur.MS_NUMPIECE;
            MS_DATERENDEZVOUS = clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS;
            NUMEROBORDEREAU = clsEditionEtatClientFournisseur.NUMEROBORDEREAU;
            MD_REMETTANT = clsEditionEtatClientFournisseur.MD_REMETTANT;
            MS_DATEPIECE = clsEditionEtatClientFournisseur.MS_DATEPIECE;
            MS_NUMSEQUENCE = clsEditionEtatClientFournisseur.MS_NUMSEQUENCE;
            VH_CODEVEHICULE = clsEditionEtatClientFournisseur.VH_CODEVEHICULE;
            VH_MATRICULE = clsEditionEtatClientFournisseur.VH_MATRICULE;
            TVH_CODETYPE = clsEditionEtatClientFournisseur.TVH_CODETYPE;
            TVH_LIBELE = clsEditionEtatClientFournisseur.TVH_LIBELE;

            CH_IDCHAUFFEUR = clsEditionEtatClientFournisseur.CH_IDCHAUFFEUR;
            CH_NUMCHAUFFEUR = clsEditionEtatClientFournisseur.CH_NUMCHAUFFEUR;
            CH_DATENAISSANCE = clsEditionEtatClientFournisseur.CH_DATENAISSANCE;
            CH_NOMPRENOM = clsEditionEtatClientFournisseur.CH_NOMPRENOM;
            CH_ADRESSEPOSTALE = clsEditionEtatClientFournisseur.CH_ADRESSEPOSTALE;
            CH_ADRESSEGEOGRAPHIQUE = clsEditionEtatClientFournisseur.CH_ADRESSEGEOGRAPHIQUE;
            CH_TELEPHONE = clsEditionEtatClientFournisseur.CH_TELEPHONE;
            CH_EMAIL = clsEditionEtatClientFournisseur.CH_EMAIL;
            CH_STATUT = clsEditionEtatClientFournisseur.CH_STATUT;
            CH_DATESAISIE = clsEditionEtatClientFournisseur.CH_DATESAISIE;
            CO_IDCOMMERCIAL = clsEditionEtatClientFournisseur.CO_IDCOMMERCIAL;
            CO_NUMCOMMERCIAL = clsEditionEtatClientFournisseur.CO_NUMCOMMERCIAL;
            CO_DATENAISSANCE = clsEditionEtatClientFournisseur.CO_DATENAISSANCE;
            CO_NOMPRENOM = clsEditionEtatClientFournisseur.CO_NOMPRENOM;
            CO_ADRESSEPOSTALE = clsEditionEtatClientFournisseur.CO_ADRESSEPOSTALE;
            CO_ADRESSEGEOGRAPHIQUE = clsEditionEtatClientFournisseur.CO_ADRESSEGEOGRAPHIQUE;
            CO_TELEPHONE = clsEditionEtatClientFournisseur.CO_TELEPHONE;
            CO_EMAIL = clsEditionEtatClientFournisseur.CO_EMAIL;
            CO_STATUT = clsEditionEtatClientFournisseur.CO_STATUT;
            CO_TAUXCOMMISSION = clsEditionEtatClientFournisseur.CO_TAUXCOMMISSION;
            CO_MONTANTCOMMISSION = clsEditionEtatClientFournisseur.CO_MONTANTCOMMISSION;
            CO_ENCOURS = clsEditionEtatClientFournisseur.CO_ENCOURS;
            CO_DATESAISIE = clsEditionEtatClientFournisseur.CO_DATESAISIE;
            EC_MONTANTECHEANCE = clsEditionEtatClientFournisseur.EC_MONTANTECHEANCE;
            EC_DATEECHEANCE = clsEditionEtatClientFournisseur.EC_DATEECHEANCE;
            MONTANTFACTURE = clsEditionEtatClientFournisseur.MONTANTFACTURE;
            MONTANTAPAYER = clsEditionEtatClientFournisseur.MONTANTAPAYER;
            MONTANTPAYER = clsEditionEtatClientFournisseur.MONTANTPAYER;
            RESTEAPAYER = clsEditionEtatClientFournisseur.RESTEAPAYER;
            //private double _EC_MONTANTECHEANCE = 0;
            //private string _EC_DATEECHEANCE = "";
            //private double _MONTANTFACTURE = 0;
            //private double _MONTANTAPAYER = 0;
            //private double _MONTANTPAYER = 0;
            //private double _RESTEAPAYER = 0;


        }
    }
}