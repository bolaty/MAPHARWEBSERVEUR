using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsOperateur : clsEntitieBase
    {

        private string _OP_CODEOPERATEUR = "";
		private string _AG_CODEAGENCE = "";
		private string _AG_RAISONSOCIAL = "";
        private string _SO_CODESOCIETE = "";
		private string _PO_CODEPROFIL = "";
        private string _TO_CODETYPEOERATEUR = "";
		private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";
        private string _PL_CODENUMCOMPTECOFFREFORT = "";
        private string _PL_NUMCOMPTECOFFREFORT = "";
        private string _PL_LIBELLE = "";
		private string _OP_NOMPRENOM = "";
		//private string _OP_LOGIN = "";
		private string _OP_MOTPASSE = "";
		private string _OP_ACTIF = "O";
		private string _OP_TELEPHONE = "";
		private string _OP_EMAIL = "";
		private string _OP_JOURNEEOUVERTE = "O";
        private string _OP_GESTIONNAIRE = "N";
        private string _OP_CAISSIER = "N";
        private string _OP_IMPRESSIONAUTOMATIQUE = "";
		private string _OP_DATESAISIE = "";
        private string _OP_MONTANTTOTALENCAISSEAUTORISE = "0";
        private string _EN_CODEENTREPOT = "";
        private string _TI_IDTIERS = "";
        private string _OP_EXTOURNE = "N";
        private string _OP_CREATIONJOURNE = "N";
        private string _OP_FERMETUREJOURNE = "N";
        private string _SR_CODESERVICE = "";
        private string _OP_CREATIONPROFILE = "N";
        private string _OP_CREATIONOPERATEUR = "N";
        private string _OP_SELECTIONOPERATEURAPPRO = "N";
        private string _OP_SELECTIONOPERATEURVENTE = "N";
        private string _OP_CONTREPARTIEAUTOMATIQUEOD = "N";

        private string _PO_LIBELLE = "";
        private string _EN_DENOMINATION = "";
        private string _SR_LIBELLE = "";
        private string _TO_LIBELLE = "";
        private string _OH_PHOTO = "";
        private string _OH_SIGNATURE = "";
        private string _COCHER = "";

        private string _EX_DATEDEBUT = "";
        private string _SL_NOMBRECONNECTION = "";
        private string _SL_CLESESSION = "";
        private string _SL_URL_NOTIFICATION = "";
        private string _SL_API_KEY = "";
        private string _SL_SITE_ID = "";
        private string _TK_TOKEN = "";
        private string _SL_MESSAGECLIENT = "";
        private string _SL_MESSAGEOBJET = "";
        private string _CL_CODECLIENT = "";
        private string _OP_CODEOPERATEURGESTIONNAIRE = "";
        private string _TI_NUMTIERS = "";
        private string _TI_DENOMINATION = "";
        private string _PP_LONGUEUR_DES_COMPTES_IMPUTABLES = "0";
        private string _URL_DOC_SINISTRES_AUTOMOBILE = "";
        private string _URL_DOC_SINISTRES_RISQUE = "";
        private string _PY_CODEPAYS_REF = "";
        private string _VL_CODEVILLE_REF = "";
        private List<clsExercice> _clsExercices = null;
        private List<clsJourneetravail> _clsJourneetravails = null;
        private List<clsAgence> _clsAgences = null;

        public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string AG_RAISONSOCIAL
        {
			get { return _AG_RAISONSOCIAL; }
			set { _AG_RAISONSOCIAL = value; }
		}
        public string SO_CODESOCIETE
		{
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
		}

		public string PO_CODEPROFIL
		{
			get { return _PO_CODEPROFIL; }
			set { _PO_CODEPROFIL = value; }
		}

        public string TO_CODETYPEOERATEUR
		{
            get { return _TO_CODETYPEOERATEUR; }
            set { _TO_CODETYPEOERATEUR = value; }
		}

		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set { _PL_CODENUMCOMPTE = value; }
		}
        public string PL_NUMCOMPTE
		{
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
		}

        public string PL_CODENUMCOMPTECOFFREFORT
		{
            get { return _PL_CODENUMCOMPTECOFFREFORT; }
            set { _PL_CODENUMCOMPTECOFFREFORT = value; }
		}
        public string PL_NUMCOMPTECOFFREFORT
		{
            get { return _PL_NUMCOMPTECOFFREFORT; }
            set { _PL_NUMCOMPTECOFFREFORT = value; }
		}

        public string PL_LIBELLE
		{
            get { return _PL_LIBELLE; }
            set { _PL_LIBELLE = value; }
		}
		public string OP_NOMPRENOM
		{
			get { return _OP_NOMPRENOM; }
			set { _OP_NOMPRENOM = value; }
		}
		//public string OP_LOGIN
		//{
		//	get { return _OP_LOGIN; }
		//	set { _OP_LOGIN = value; }
		//}
		public string OP_MOTPASSE
		{
			get { return _OP_MOTPASSE; }
			set { _OP_MOTPASSE = value; }
		}
		public string OP_ACTIF
		{
			get { return _OP_ACTIF; }
			set { _OP_ACTIF = value; }
		}
		public string OP_TELEPHONE
		{
			get { return _OP_TELEPHONE; }
			set { _OP_TELEPHONE = value; }
		}
		public string OP_EMAIL
		{
			get { return _OP_EMAIL; }
			set { _OP_EMAIL = value; }
		}
		public string OP_JOURNEEOUVERTE
		{
			get { return _OP_JOURNEEOUVERTE; }
			set { _OP_JOURNEEOUVERTE = value; }
		}
        public string OP_GESTIONNAIRE
		{
            get { return _OP_GESTIONNAIRE; }
            set { _OP_GESTIONNAIRE = value; }
		}
        public string OP_CAISSIER
		{
            get { return _OP_CAISSIER; }
            set { _OP_CAISSIER = value; }
		}
        public string OP_IMPRESSIONAUTOMATIQUE
		{
            get { return _OP_IMPRESSIONAUTOMATIQUE; }
            set { _OP_IMPRESSIONAUTOMATIQUE = value; }
		}

		public string OP_DATESAISIE
		{
			get { return _OP_DATESAISIE; }
			set { _OP_DATESAISIE = value; }
		}

        public string OP_MONTANTTOTALENCAISSEAUTORISE
		{
            get { return _OP_MONTANTTOTALENCAISSEAUTORISE; }
            set { _OP_MONTANTTOTALENCAISSEAUTORISE = value; }
		}
        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }
        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }

        public string OP_EXTOURNE
        {
            get { return _OP_EXTOURNE; }
            set { _OP_EXTOURNE = value; }
        }

        public string OP_CREATIONJOURNE
        {
            get { return _OP_CREATIONJOURNE; }
            set { _OP_CREATIONJOURNE = value; }
        }
        public string OP_FERMETUREJOURNE
        {
            get { return _OP_FERMETUREJOURNE; }
            set { _OP_FERMETUREJOURNE = value; }
        }
        public string SR_CODESERVICE
        {
            get { return _SR_CODESERVICE; }
            set { _SR_CODESERVICE = value; }
        }

        public string OP_CREATIONPROFILE
        {
            get { return _OP_CREATIONPROFILE; }
            set { _OP_CREATIONPROFILE = value; }
        }
        public string OP_CREATIONOPERATEUR 
        {
            get { return _OP_CREATIONOPERATEUR; }
            set { _OP_CREATIONOPERATEUR = value; }
        }

        public string OP_SELECTIONOPERATEURAPPRO
        {
            get { return _OP_SELECTIONOPERATEURAPPRO; }
            set { _OP_SELECTIONOPERATEURAPPRO = value; }
        }

        public string OP_SELECTIONOPERATEURVENTE
        {
            get { return _OP_SELECTIONOPERATEURVENTE; }
            set { _OP_SELECTIONOPERATEURVENTE = value; }
        }

        public string OP_CONTREPARTIEAUTOMATIQUEOD
        {
            get { return _OP_CONTREPARTIEAUTOMATIQUEOD; }
            set { _OP_CONTREPARTIEAUTOMATIQUEOD = value; }
        }
        public string PO_LIBELLE
        {
            get { return _PO_LIBELLE; }
            set { _PO_LIBELLE = value; }
        }
        public string EN_DENOMINATION
        {
            get { return _EN_DENOMINATION; }
            set { _EN_DENOMINATION = value; }
        }
        public string SR_LIBELLE
        {
            get { return _SR_LIBELLE; }
            set { _SR_LIBELLE = value; }
        }
        public string TO_LIBELLE
        {
            get { return _TO_LIBELLE; }
            set { _TO_LIBELLE = value; }
        }
        public string OH_PHOTO
        {
            get { return _OH_PHOTO; }
            set { _OH_PHOTO = value; }
        }
        public string OH_SIGNATURE
        {
            get { return _OH_SIGNATURE; }
            set { _OH_SIGNATURE = value; }
        }

        public string COCHER
        {
            get { return _COCHER; }
            set { _COCHER = value; }
        }
        public string EX_DATEDEBUT
        {
            get { return _EX_DATEDEBUT; }
            set { _EX_DATEDEBUT = value; }
        }
        public string SL_NOMBRECONNECTION
        {
            get { return _SL_NOMBRECONNECTION; }
            set { _SL_NOMBRECONNECTION = value; }
        }
        public string SL_URL_NOTIFICATION
        {
            get { return _SL_URL_NOTIFICATION; }
            set { _SL_URL_NOTIFICATION = value; }
        }
        public string SL_API_KEY
        {
            get { return _SL_API_KEY; }
            set { _SL_API_KEY = value; }
        }
        public string SL_SITE_ID
        {
            get { return _SL_SITE_ID; }
            set { _SL_SITE_ID = value; }
        }
        public string TK_TOKEN
        {
            get { return _TK_TOKEN; }
            set { _TK_TOKEN = value; }
        }
        public string SL_MESSAGECLIENT
        {
            get { return _SL_MESSAGECLIENT; }
            set { _SL_MESSAGECLIENT = value; }
        }
        public string SL_MESSAGEOBJET
        {
            get { return _SL_MESSAGEOBJET; }
            set { _SL_MESSAGEOBJET = value; }
        }
        public string CL_CODECLIENT
        {
            get { return _CL_CODECLIENT; }
            set { _CL_CODECLIENT = value; }
        }
        public string OP_CODEOPERATEURGESTIONNAIRE
        {
            get { return _OP_CODEOPERATEURGESTIONNAIRE; }
            set { _OP_CODEOPERATEURGESTIONNAIRE = value; }
        }

        public string TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }
        public string TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }
        public string PP_LONGUEUR_DES_COMPTES_IMPUTABLES
        {
            get { return _PP_LONGUEUR_DES_COMPTES_IMPUTABLES; }
            set { _PP_LONGUEUR_DES_COMPTES_IMPUTABLES = value; }
        }

        public string URL_DOC_SINISTRES_AUTOMOBILE
        {
            get { return _URL_DOC_SINISTRES_AUTOMOBILE; }
            set { _URL_DOC_SINISTRES_AUTOMOBILE = value; }
        }
        public string URL_DOC_SINISTRES_RISQUE
        {
            get { return _URL_DOC_SINISTRES_RISQUE; }
            set { _URL_DOC_SINISTRES_RISQUE = value; }
        }
        public string PY_CODEPAYS_REF
        {
            get { return _PY_CODEPAYS_REF; }
            set { _PY_CODEPAYS_REF = value; }
        }
        public string VL_CODEVILLE_REF
        {
            get { return _VL_CODEVILLE_REF; }
            set { _VL_CODEVILLE_REF = value; }
        }
       
        public List<clsExercice> clsExercices
        {
            get { return _clsExercices; }
            set { _clsExercices = value; }
        }
        public List<clsJourneetravail> clsJourneetravails
        {
            get { return _clsJourneetravails; }
            set { _clsJourneetravails = value; }
        }
        public List<clsAgence> clsAgences
        {
            get { return _clsAgences; }
            set { _clsAgences = value; }
        }


        public clsOperateur() {} 


		public clsOperateur(clsOperateur clsOperateur)
		{
			OP_CODEOPERATEUR = clsOperateur.OP_CODEOPERATEUR;
			AG_CODEAGENCE = clsOperateur.AG_CODEAGENCE;
            AG_RAISONSOCIAL = clsOperateur.AG_RAISONSOCIAL;
            SO_CODESOCIETE = clsOperateur.SO_CODESOCIETE;
			PO_CODEPROFIL = clsOperateur.PO_CODEPROFIL;
            TO_CODETYPEOERATEUR = clsOperateur.TO_CODETYPEOERATEUR;
			PL_CODENUMCOMPTE = clsOperateur.PL_CODENUMCOMPTE;
            PL_NUMCOMPTE = clsOperateur.PL_NUMCOMPTE;
            PL_CODENUMCOMPTECOFFREFORT = clsOperateur.PL_CODENUMCOMPTECOFFREFORT;
            PL_NUMCOMPTECOFFREFORT = clsOperateur.PL_NUMCOMPTECOFFREFORT;

            PL_LIBELLE = clsOperateur.PL_LIBELLE;
			OP_NOMPRENOM = clsOperateur.OP_NOMPRENOM;
			//OP_LOGIN = clsOperateur.OP_LOGIN;
			OP_MOTPASSE = clsOperateur.OP_MOTPASSE;
			OP_ACTIF = clsOperateur.OP_ACTIF;
			OP_TELEPHONE = clsOperateur.OP_TELEPHONE;
			OP_EMAIL = clsOperateur.OP_EMAIL;
			OP_JOURNEEOUVERTE = clsOperateur.OP_JOURNEEOUVERTE;
            OP_GESTIONNAIRE = clsOperateur.OP_GESTIONNAIRE;
            OP_CAISSIER = clsOperateur.OP_CAISSIER;
            OP_IMPRESSIONAUTOMATIQUE = clsOperateur.OP_IMPRESSIONAUTOMATIQUE;
			OP_DATESAISIE = clsOperateur.OP_DATESAISIE;
            OP_MONTANTTOTALENCAISSEAUTORISE = clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE;
            EN_CODEENTREPOT = clsOperateur.EN_CODEENTREPOT;
            TI_IDTIERS = clsOperateur.TI_IDTIERS;
            OP_EXTOURNE = clsOperateur.OP_EXTOURNE;
            OP_CREATIONJOURNE = clsOperateur.OP_CREATIONJOURNE;
            OP_FERMETUREJOURNE = clsOperateur.OP_FERMETUREJOURNE;
            SR_CODESERVICE = clsOperateur.SR_CODESERVICE;
            OP_CREATIONPROFILE = clsOperateur.OP_CREATIONPROFILE;
            OP_CREATIONOPERATEUR = clsOperateur.OP_CREATIONOPERATEUR;
            OP_SELECTIONOPERATEURAPPRO = clsOperateur.OP_SELECTIONOPERATEURAPPRO;
            OP_SELECTIONOPERATEURVENTE = clsOperateur.OP_SELECTIONOPERATEURVENTE;
            OP_CONTREPARTIEAUTOMATIQUEOD = clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD;
            PO_LIBELLE = clsOperateur.PO_LIBELLE;
            EN_DENOMINATION = clsOperateur.EN_DENOMINATION;
            SR_LIBELLE = clsOperateur.SR_LIBELLE;
            TO_LIBELLE = clsOperateur.TO_LIBELLE;
            OH_PHOTO = clsOperateur.OH_PHOTO;
            OH_SIGNATURE = clsOperateur.OH_SIGNATURE;
            COCHER = clsOperateur.COCHER;
            PP_LONGUEUR_DES_COMPTES_IMPUTABLES = clsOperateur.PP_LONGUEUR_DES_COMPTES_IMPUTABLES;
            EX_DATEDEBUT = clsOperateur.EX_DATEDEBUT;
            SL_NOMBRECONNECTION = clsOperateur.SL_NOMBRECONNECTION;
            SL_URL_NOTIFICATION = clsOperateur.SL_URL_NOTIFICATION;
            SL_API_KEY = clsOperateur.SL_API_KEY;
            SL_SITE_ID = clsOperateur.SL_SITE_ID;
            TK_TOKEN = clsOperateur.TK_TOKEN;
            SL_MESSAGECLIENT = clsOperateur.SL_MESSAGECLIENT;
            SL_MESSAGEOBJET = clsOperateur.SL_MESSAGEOBJET;
            CL_CODECLIENT = clsOperateur.CL_CODECLIENT;
            OP_CODEOPERATEURGESTIONNAIRE = clsOperateur.OP_CODEOPERATEURGESTIONNAIRE;
            TI_NUMTIERS = clsOperateur.TI_NUMTIERS;
            TI_DENOMINATION = clsOperateur.TI_DENOMINATION;
            URL_DOC_SINISTRES_AUTOMOBILE = clsOperateur.URL_DOC_SINISTRES_AUTOMOBILE;
            URL_DOC_SINISTRES_RISQUE = clsOperateur.URL_DOC_SINISTRES_RISQUE;
            PY_CODEPAYS_REF = clsOperateur.PY_CODEPAYS_REF;
            VL_CODEVILLE_REF = clsOperateur.VL_CODEVILLE_REF;
            this.clsExercices = clsOperateur.clsExercices;
            this.clsJourneetravails = clsOperateur.clsJourneetravails;
            this.clsAgences = clsOperateur.clsAgences;

        }
        }
}