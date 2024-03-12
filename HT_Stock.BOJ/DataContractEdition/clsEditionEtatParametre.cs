using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEditionEtatParametre : clsEntitieBase
    {



        private string _AG_CODEAGENCE = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _BT_CODETYPEBUDGET = "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";

        private string _EN_CODEENTREPOT = "";
        private string _EN_DENOMINATION = "";
        private string _EN_ADRESSEPOSTALE = "";
        private string _EN_ADRESSEGEOGRAPHIQUE = "";
        private string _EN_TELEPHONE = "";
        private string _EN_FAX = "";
        private string _EN_EMAIL = "";
        private string _EN_GERANT = "";


        private string _RY_CODERAYON = "";
        private string _RY_LIBELLE = "";
        private string _UN_CODEUNITE = "";
        private string _UN_LIBELLE = "";

        private string _PP_CODEPARAMETRE = "";
        private string _PP_AFFICHER = "";
        private string _PP_BORNEMAX = "";
        private string _PP_BORNEMIN = "";

        private string _PL_CODENUMCOMPTE = "";
        private string _PP_LIBELLE = "";
        private double _PP_MONTANT = 0;
        private double _PP_MONTANTMAXI = 0;
        private double _PP_MONTANTMINI = 0;
        private string _PP_TAUX = "";
        private string _SO_CODESOCIETE = "";
        private string _NC_CODENATURECOMPTE = "";
        private string _NC_LIBELLENATURECOMPTE = "";
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
        private string _PL_SENS = "";
        private string _PL_TYPECOMPTE = "";
        private string _PL_ACTIF = "";

        private string _JO_JOURNALCODE = "";
        private string _JO_C = ""; 
        private string _TJ_LIBELLE = ""; 
        private string _JO_LIBELLE = "";


        private string _JO_CODEJOURNAL = "";
        private string _TJ_CODETYPEJOURNAL = "";
        private string _JO_NUMEROORDRE = "";
        private string _PP_VALEUR = "";
        private string _TB_CODETABLEAU = "";
        private string _TB_LIBELLE = "";
        private string _TB_DESCRIPTION = "";
        private string _PA_CODEPARAMETRE = "";
        private string _PA_LIBELLE = "";
        private double _PA_MONTANTMINI = 0;
        private double _PA_MONTANTMAXI = 0;
        private string _PA_TAUX = "0";
        private double _PA_MONTANT = 0;
        private string _AR_CODEARTICLE = "";
        private string _AR_CODEARTICLE1 = "";
        private string _MP_QUANTITE = "0";
        private string _AR_NOMCOMMERCIALE = "";
        private string _AR_NOMCOMMERCIALE1 = "";
        private string _BT_LIBELLE = "";
        private string _BD_CODETYPEBUDGETDETAIL = "";
        private string _BD_LIBELLE = "";
        private string _BG_CODEPOSTEBUDGETAIRE = "";
        private string _BG_LIBELLE = "";
        private string _PL_NUMCOMPTEDETAIL = "";
        private string _TP_CODEPOSTETRESORERIE = "";
        private string _TR_CODERUBRIQUETRESORERIE = "";
        private string _TF_LIBELLE = "";
        private string _PD_LIBELLE = "";
        private string _TP_LIBELLE = "";
        private string _TR_LIBELLE = "";
        private string _PS_ABREGE = "";
        private string _TP_TAUX = "";
        private string _TN_LIBELLE = "";
        private string _PB_CODEDOCUMENT = "";
        private string _PD_CODEDOCUMENTDETAIL = "";
        private string _PO_CODEPOSTEBUSINESSPLAN = "";
        private string _PF_LIBELLE = "";
        private string _PB_LIBELLE = "";
        private string _PO_LIBELLE = "";
        private string _PN_LIBELLE = "0";
        private string _PO_TAUX = "0";


        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string OP_CODEOPERATEUREDITION
		{
			get { return _OP_CODEOPERATEUREDITION; }
			set { _OP_CODEOPERATEUREDITION = value; }
		}

        public string BT_CODETYPEBUDGET
		{
            get { return _BT_CODETYPEBUDGET; }
            set { _BT_CODETYPEBUDGET = value; }
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

        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }
        public string EN_DENOMINATION
        {
            get { return _EN_DENOMINATION; }
            set { _EN_DENOMINATION = value; }
        }
        public string EN_ADRESSEPOSTALE
        {
            get { return _EN_ADRESSEPOSTALE; }
            set { _EN_ADRESSEPOSTALE = value; }
        }
        public string EN_TELEPHONE
        {
            get { return _EN_TELEPHONE; }
            set { _EN_TELEPHONE = value; }
        }
        public string EN_FAX
        {
            get { return _EN_FAX; }
            set { _EN_FAX = value; }
        }
        public string EN_EMAIL
        {
            get { return _EN_EMAIL; }
            set { _EN_EMAIL = value; }
        }
        public string EN_GERANT
        {
            get { return _EN_GERANT; }
            set { _EN_GERANT = value; }
        }

        public string EN_ADRESSEGEOGRAPHIQUE
        {
            get { return _EN_ADRESSEGEOGRAPHIQUE; }
            set { _EN_ADRESSEGEOGRAPHIQUE = value; }
        }
       
        public string RY_CODERAYON
        {
            get { return _RY_CODERAYON; }
            set { _RY_CODERAYON = value; }
        }
        public string RY_LIBELLE
        {
            get { return _RY_LIBELLE; }
            set { _RY_LIBELLE = value; }
        }
        public string UN_CODEUNITE
        {
            get { return _UN_CODEUNITE; }
            set { _UN_CODEUNITE = value; }
        }

        public string UN_LIBELLE
        {
            get { return _UN_LIBELLE; }
            set { _UN_LIBELLE = value; }
        }

        public string PP_CODEPARAMETRE
        {
            get { return _PP_CODEPARAMETRE; }
            set { _PP_CODEPARAMETRE = value; }
        }
        public string PP_AFFICHER
        {
            get { return _PP_AFFICHER; }
            set { _PP_AFFICHER = value; }
        }
        public string PP_BORNEMAX
        {
            get { return _PP_BORNEMAX; }
            set { _PP_BORNEMAX = value; }
        }
        public string PP_BORNEMIN
        {
            get { return _PP_BORNEMIN; }
            set { _PP_BORNEMIN = value; }
        }
        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }

        public string PP_LIBELLE
        {
            get { return _PP_LIBELLE; }
            set { _PP_LIBELLE = value; }
        }
        public double PP_MONTANT
        {
            get { return _PP_MONTANT; }
            set { _PP_MONTANT = value; }
        }
        public double PP_MONTANTMAXI
        {
            get { return _PP_MONTANTMAXI; }
            set { _PP_MONTANTMAXI = value; }
        }
        public double PP_MONTANTMINI
        {
            get { return _PP_MONTANTMINI; }
            set { _PP_MONTANTMINI = value; }
        }
        public string PP_TAUX
        {
            get { return _PP_TAUX; }
            set { _PP_TAUX = value; }
        }

        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }
        public string NC_CODENATURECOMPTE
        {
            get { return _NC_CODENATURECOMPTE; }
            set { _NC_CODENATURECOMPTE = value; }
        }
        public string NC_LIBELLENATURECOMPTE
        {
            get { return _NC_LIBELLENATURECOMPTE; }
            set { _NC_LIBELLENATURECOMPTE = value; }
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
        public double  PL_MONTANTSOLDEFINALCREDIT
        {
            get { return _PL_MONTANTSOLDEFINALCREDIT; }
            set { _PL_MONTANTSOLDEFINALCREDIT = value; }
        }
        public string PL_SENS
        {
            get { return _PL_SENS; }
            set { _PL_SENS = value; }
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

        public string JO_JOURNALCODE
        {
            get { return _JO_JOURNALCODE; }
            set { _JO_JOURNALCODE = value; }
        }
        public string JO_C
        {
            get { return _JO_C; }
            set { _JO_C = value; }
        }
        public string TJ_LIBELLE
        {
            get { return _TJ_LIBELLE; }
            set { _TJ_LIBELLE = value; }
        }
        public string JO_LIBELLE
        {
            get { return _JO_LIBELLE; }
            set { _JO_LIBELLE = value; }
        }
        public string JO_CODEJOURNAL
        {
            get { return _JO_CODEJOURNAL; }
            set { _JO_CODEJOURNAL = value; }
        }
        public string TJ_CODETYPEJOURNAL
        {
            get { return _TJ_CODETYPEJOURNAL; }
            set { _TJ_CODETYPEJOURNAL = value; }
        }
        public string JO_NUMEROORDRE
        {
            get { return _JO_NUMEROORDRE; }
            set { _JO_NUMEROORDRE = value; }
        }
        public string PP_VALEUR
        {
            get { return _PP_VALEUR; }
            set { _PP_VALEUR = value; }
        }
        public string TB_CODETABLEAU
        {
            get { return _TB_CODETABLEAU; }
            set { _TB_CODETABLEAU = value; }
        }
        public string TB_LIBELLE
        {
            get { return _TB_LIBELLE; }
            set { _TB_LIBELLE = value; }
        }
        public string TB_DESCRIPTION
        {
            get { return _TB_DESCRIPTION; }
            set { _TB_DESCRIPTION = value; }
        }
        public string PA_CODEPARAMETRE
        {
            get { return _PA_CODEPARAMETRE; }
            set { _PA_CODEPARAMETRE = value; }
        }
        public string PA_LIBELLE
        {
            get { return _PA_LIBELLE; }
            set { _PA_LIBELLE = value; }
        }
        public double PA_MONTANTMINI
        {
            get { return _PA_MONTANTMINI; }
            set { _PA_MONTANTMINI = value; }
        }
        public double PA_MONTANTMAXI
        {
            get { return _PA_MONTANTMAXI; }
            set { _PA_MONTANTMAXI = value; }
        }
        public string PA_TAUX
        {
            get { return _PA_TAUX; }
            set { _PA_TAUX = value; }
        }
        public double PA_MONTANT
        {
            get { return _PA_MONTANT; }
            set { _PA_MONTANT = value; }
        }
        public string AR_CODEARTICLE
        {
            get { return _AR_CODEARTICLE; }
            set { _AR_CODEARTICLE = value; }
        }
        public string AR_CODEARTICLE1
        {
            get { return _AR_CODEARTICLE1; }
            set { _AR_CODEARTICLE1 = value; }
        }
        public string MP_QUANTITE
        {
            get { return _MP_QUANTITE; }
            set { _MP_QUANTITE = value; }
        }
        public string AR_NOMCOMMERCIALE
        {
            get { return _AR_NOMCOMMERCIALE; }
            set { _AR_NOMCOMMERCIALE = value; }
        }
        public string AR_NOMCOMMERCIALE1
        {
            get { return _AR_NOMCOMMERCIALE1; }
            set { _AR_NOMCOMMERCIALE1 = value; }
        }
        public string BT_LIBELLE
        {
            get { return _BT_LIBELLE; }
            set { _BT_LIBELLE = value; }
        }
        public string BD_CODETYPEBUDGETDETAIL
        {
            get { return _BD_CODETYPEBUDGETDETAIL; }
            set { _BD_CODETYPEBUDGETDETAIL = value; }
        }
        public string BD_LIBELLE
        {
            get { return _BD_LIBELLE; }
            set { _BD_LIBELLE = value; }
        }
        public string BG_LIBELLE
        {
            get { return _BG_LIBELLE; }
            set { _BG_LIBELLE = value; }
        }
        public string PL_NUMCOMPTEDETAIL
        {
            get { return _PL_NUMCOMPTEDETAIL; }
            set { _PL_NUMCOMPTEDETAIL = value; }
        }
        public string TP_CODEPOSTETRESORERIE
        {
            get { return _TP_CODEPOSTETRESORERIE; }
            set { _TP_CODEPOSTETRESORERIE = value; }
        }
        public string TR_CODERUBRIQUETRESORERIE
        {
            get { return _TR_CODERUBRIQUETRESORERIE; }
            set { _TR_CODERUBRIQUETRESORERIE = value; }
        }
        public string TF_LIBELLE
        {
            get { return _TF_LIBELLE; }
            set { _TF_LIBELLE = value; }
        }
        public string PD_LIBELLE
        {
            get { return _PD_LIBELLE; }
            set { _PD_LIBELLE = value; }
        }
        public string TP_LIBELLE
        {
            get { return _TP_LIBELLE; }
            set { _TP_LIBELLE = value; }
        }
        public string TR_LIBELLE
        {
            get { return _TR_LIBELLE; }
            set { _TR_LIBELLE = value; }
        }
        public string PS_ABREGE
        {
            get { return _PS_ABREGE; }
            set { _PS_ABREGE = value; }
        }
        public string TP_TAUX
        {
            get { return _TP_TAUX; }
            set { _TP_TAUX = value; }
        }
        public string TN_LIBELLE
        {
            get { return _TN_LIBELLE; }
            set { _TN_LIBELLE = value; }
        }
        public string PB_CODEDOCUMENT
        {
            get { return _PB_CODEDOCUMENT; }
            set { _PB_CODEDOCUMENT = value; }
        }
        public string PD_CODEDOCUMENTDETAIL
        {
            get { return _PD_CODEDOCUMENTDETAIL; }
            set { _PD_CODEDOCUMENTDETAIL = value; }
        }
        public string PO_CODEPOSTEBUSINESSPLAN
        {
            get { return _PO_CODEPOSTEBUSINESSPLAN; }
            set { _PO_CODEPOSTEBUSINESSPLAN = value; }
        }
        public string PF_LIBELLE
        {
            get { return _PF_LIBELLE; }
            set { _PF_LIBELLE = value; }
        }
        public string PB_LIBELLE
        {
            get { return _PB_LIBELLE; }
            set { _PB_LIBELLE = value; }
        }
        public string PO_LIBELLE
        {
            get { return _PO_LIBELLE; }
            set { _PO_LIBELLE = value; }
        }
        public string PN_LIBELLE
        {
            get { return _PN_LIBELLE; }
            set { _PN_LIBELLE = value; }
        }
        public string PO_TAUX
        {
            get { return _PO_TAUX; }
            set { _PO_TAUX = value; }
        }
    public string BG_CODEPOSTEBUDGETAIRE
        {
        get { return _BG_CODEPOSTEBUDGETAIRE; }
        set { _BG_CODEPOSTEBUDGETAIRE = value; }
    }









        public clsEditionEtatParametre() {} 

		

		public clsEditionEtatParametre(clsEditionEtatParametre clsEditionEtatParametre)
		{

            BT_CODETYPEBUDGET = clsEditionEtatParametre.BT_CODETYPEBUDGET;
            AG_CODEAGENCE = clsEditionEtatParametre.AG_CODEAGENCE;
			OP_CODEOPERATEUREDITION = clsEditionEtatParametre.OP_CODEOPERATEUREDITION;
            ET_TYPEETAT = clsEditionEtatParametre.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatParametre.ET_TYPERETOURS;

            EN_CODEENTREPOT = clsEditionEtatParametre.EN_CODEENTREPOT;
            EN_DENOMINATION = clsEditionEtatParametre.EN_DENOMINATION;
            EN_ADRESSEPOSTALE = clsEditionEtatParametre.EN_ADRESSEPOSTALE;
            EN_ADRESSEGEOGRAPHIQUE = clsEditionEtatParametre.EN_ADRESSEGEOGRAPHIQUE;
            EN_TELEPHONE = clsEditionEtatParametre.EN_TELEPHONE;
            EN_FAX = clsEditionEtatParametre.EN_FAX;
            EN_EMAIL = clsEditionEtatParametre.EN_EMAIL;
            EN_GERANT = clsEditionEtatParametre.EN_GERANT;
            RY_CODERAYON = clsEditionEtatParametre.RY_CODERAYON;
            RY_LIBELLE = clsEditionEtatParametre.RY_LIBELLE;
            UN_CODEUNITE = clsEditionEtatParametre.UN_CODEUNITE;
            UN_LIBELLE = clsEditionEtatParametre.UN_LIBELLE;

            PP_CODEPARAMETRE = clsEditionEtatParametre.PP_CODEPARAMETRE;
            PP_AFFICHER = clsEditionEtatParametre.PP_AFFICHER;
            PP_BORNEMAX = clsEditionEtatParametre.PP_BORNEMAX;
            PP_BORNEMIN = clsEditionEtatParametre.PP_BORNEMIN;
            PL_CODENUMCOMPTE = clsEditionEtatParametre.PL_CODENUMCOMPTE;
            PP_LIBELLE = clsEditionEtatParametre.PP_LIBELLE;
            PP_MONTANT = clsEditionEtatParametre.PP_MONTANT;
            PP_MONTANTMAXI = clsEditionEtatParametre.PP_MONTANTMAXI;
            PP_MONTANTMINI = clsEditionEtatParametre.PP_MONTANTMINI;
            PP_TAUX = clsEditionEtatParametre.PP_TAUX;
            SO_CODESOCIETE = clsEditionEtatParametre.SO_CODESOCIETE;
            NC_CODENATURECOMPTE = clsEditionEtatParametre.NC_CODENATURECOMPTE ;
            NC_LIBELLENATURECOMPTE = clsEditionEtatParametre.NC_LIBELLENATURECOMPTE;
            PL_NUMCOMPTE = clsEditionEtatParametre.PL_NUMCOMPTE;
            PL_LIBELLE = clsEditionEtatParametre.PL_LIBELLE;
            PL_COMPTECOLLECTIF = clsEditionEtatParametre.PL_COMPTECOLLECTIF;
            PL_REPORTDEBIT = clsEditionEtatParametre.PL_REPORTDEBIT;
            PL_REPORTCREDIT = clsEditionEtatParametre.PL_REPORTCREDIT;
            PL_MONTANTPERIODEPRECEDENTDEBIT = clsEditionEtatParametre.PL_MONTANTPERIODEPRECEDENTDEBIT;
            PL_MONTANTPERIODEPRECEDENTCREDIT = clsEditionEtatParametre.PL_MONTANTPERIODEPRECEDENTCREDIT;
            PL_MONTANTPERIODEDEBITENCOURS = clsEditionEtatParametre.PL_MONTANTPERIODEDEBITENCOURS;
            PL_MONTANTPERIODECREDITENCOURS = clsEditionEtatParametre.PL_MONTANTPERIODECREDITENCOURS;
            PL_MONTANTSOLDEFINALDEBIT = clsEditionEtatParametre.PL_MONTANTSOLDEFINALDEBIT;
            PL_MONTANTSOLDEFINALCREDIT = clsEditionEtatParametre.PL_MONTANTSOLDEFINALCREDIT;
            PL_SENS = clsEditionEtatParametre.PL_SENS;
            PL_TYPECOMPTE = clsEditionEtatParametre.PL_TYPECOMPTE;
            PL_ACTIF = clsEditionEtatParametre.PL_ACTIF;
            JO_JOURNALCODE = clsEditionEtatParametre.JO_JOURNALCODE;
            JO_C = clsEditionEtatParametre.JO_C;
            TJ_LIBELLE = clsEditionEtatParametre.TJ_LIBELLE;
            JO_LIBELLE = clsEditionEtatParametre.JO_LIBELLE;


            JO_CODEJOURNAL = clsEditionEtatParametre.JO_CODEJOURNAL;
            TJ_CODETYPEJOURNAL = clsEditionEtatParametre.TJ_CODETYPEJOURNAL;
            JO_NUMEROORDRE = clsEditionEtatParametre.JO_NUMEROORDRE;
            PP_VALEUR = clsEditionEtatParametre.PP_VALEUR;
            TB_CODETABLEAU = clsEditionEtatParametre.TB_CODETABLEAU;
            TB_LIBELLE = clsEditionEtatParametre.TB_LIBELLE;
            TB_DESCRIPTION = clsEditionEtatParametre.TB_DESCRIPTION;
            PA_CODEPARAMETRE = clsEditionEtatParametre.PA_CODEPARAMETRE;
            PA_LIBELLE = clsEditionEtatParametre.PA_LIBELLE;
            PA_MONTANTMINI = clsEditionEtatParametre.PA_MONTANTMINI;
            PA_MONTANTMAXI = clsEditionEtatParametre.PA_MONTANTMAXI;
            PA_TAUX = clsEditionEtatParametre.PA_TAUX;
            PA_MONTANT = clsEditionEtatParametre.PA_MONTANT;
            AR_CODEARTICLE = clsEditionEtatParametre.AR_CODEARTICLE;
            AR_CODEARTICLE1 = clsEditionEtatParametre.AR_CODEARTICLE1;
            MP_QUANTITE = clsEditionEtatParametre.MP_QUANTITE;
            AR_NOMCOMMERCIALE = clsEditionEtatParametre.AR_NOMCOMMERCIALE;
            AR_NOMCOMMERCIALE1 = clsEditionEtatParametre.AR_NOMCOMMERCIALE1;
            BT_LIBELLE = clsEditionEtatParametre.BT_LIBELLE;
            BD_CODETYPEBUDGETDETAIL = clsEditionEtatParametre.BD_CODETYPEBUDGETDETAIL;
            BD_LIBELLE = clsEditionEtatParametre.BD_LIBELLE;
            BG_CODEPOSTEBUDGETAIRE = clsEditionEtatParametre.BG_CODEPOSTEBUDGETAIRE;
            BG_LIBELLE = clsEditionEtatParametre.BG_LIBELLE;
            PL_NUMCOMPTEDETAIL = clsEditionEtatParametre.PL_NUMCOMPTEDETAIL;
            TP_CODEPOSTETRESORERIE = clsEditionEtatParametre.TP_CODEPOSTETRESORERIE;
            TR_CODERUBRIQUETRESORERIE = clsEditionEtatParametre.TR_CODERUBRIQUETRESORERIE;
            TF_LIBELLE = clsEditionEtatParametre.TF_LIBELLE;
            PD_LIBELLE = clsEditionEtatParametre.PD_LIBELLE;
            TP_LIBELLE = clsEditionEtatParametre.TP_LIBELLE;
            TR_LIBELLE = clsEditionEtatParametre.TR_LIBELLE;
            PS_ABREGE = clsEditionEtatParametre.PS_ABREGE;
            TP_TAUX = clsEditionEtatParametre.TP_TAUX;
            TN_LIBELLE = clsEditionEtatParametre.TN_LIBELLE;
            PB_CODEDOCUMENT = clsEditionEtatParametre.PB_CODEDOCUMENT;
            PD_CODEDOCUMENTDETAIL = clsEditionEtatParametre.PD_CODEDOCUMENTDETAIL;
            PO_CODEPOSTEBUSINESSPLAN = clsEditionEtatParametre.PO_CODEPOSTEBUSINESSPLAN;
            PF_LIBELLE = clsEditionEtatParametre.PF_LIBELLE;
            PB_LIBELLE = clsEditionEtatParametre.PB_LIBELLE;
            PO_LIBELLE = clsEditionEtatParametre.PO_LIBELLE;
            PN_LIBELLE = clsEditionEtatParametre.PN_LIBELLE;
            PO_TAUX = clsEditionEtatParametre.PO_TAUX;


            //private string _JO_JOURNALCODE = "";
            //private string _JO_C = "";
            //private string _TJ_LIBELLE = "";
            //private string _JO_LIBELLE = "";





        }
    }
}