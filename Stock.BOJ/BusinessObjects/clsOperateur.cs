using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsOperateur
	{

        private string _OP_CODEOPERATEUR = "";
		private string _AG_CODEAGENCE = "";
        private string _SO_CODESOCIETE = "";
		private string _PO_CODEPROFIL = "";
        private string _TO_CODETYPEOERATEUR = "";
		private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";
        private string _PL_CODENUMCOMPTECOFFREFORT = "";
        private string _PL_NUMCOMPTECOFFREFORT = "";
        private string _PL_LIBELLE = "";
		private string _OP_NOMPRENOM = "";
		private string _OP_LOGIN = "";
		private string _OP_MOTPASSE = "";
		private string _OP_ACTIF = "O";
		private string _OP_TELEPHONE = "";
		private string _OP_EMAIL = "";
		private string _OP_JOURNEEOUVERTE = "O";
        private string _OP_GESTIONNAIRE = "N";
        private string _OP_CAISSIER = "N";
        private string _OP_IMPRESSIONAUTOMATIQUE = "";
		private DateTime _OP_DATESAISIE = DateTime.Parse("01/01/1900");
        private double _OP_MONTANTTOTALENCAISSEAUTORISE = 0;
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
		public string OP_LOGIN
		{
			get { return _OP_LOGIN; }
			set { _OP_LOGIN = value; }
		}
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

		public DateTime OP_DATESAISIE
		{
			get { return _OP_DATESAISIE; }
			set { _OP_DATESAISIE = value; }
		}

        public double OP_MONTANTTOTALENCAISSEAUTORISE
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



        public clsOperateur() {} 


		public clsOperateur(clsOperateur clsOperateur)
		{
			OP_CODEOPERATEUR = clsOperateur.OP_CODEOPERATEUR;
			AG_CODEAGENCE = clsOperateur.AG_CODEAGENCE;
            SO_CODESOCIETE = clsOperateur.SO_CODESOCIETE;
			PO_CODEPROFIL = clsOperateur.PO_CODEPROFIL;
            TO_CODETYPEOERATEUR = clsOperateur.TO_CODETYPEOERATEUR;
			PL_CODENUMCOMPTE = clsOperateur.PL_CODENUMCOMPTE;
            PL_NUMCOMPTE = clsOperateur.PL_NUMCOMPTE;
            PL_CODENUMCOMPTECOFFREFORT = clsOperateur.PL_CODENUMCOMPTECOFFREFORT;
            PL_NUMCOMPTECOFFREFORT = clsOperateur.PL_NUMCOMPTECOFFREFORT;

            PL_LIBELLE = clsOperateur.PL_LIBELLE;
			OP_NOMPRENOM = clsOperateur.OP_NOMPRENOM;
			OP_LOGIN = clsOperateur.OP_LOGIN;
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
           

    }
        }
}