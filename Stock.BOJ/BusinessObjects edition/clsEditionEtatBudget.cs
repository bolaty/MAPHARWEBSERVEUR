using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatBudget
	{


    //    @AG_CODEAGENCE varchar(7000),	
    //@AG_TELEPHONE AS VARCHAR(25),
    //@BU_CODEBUDGET varchar(700),
    //@BG_CODEPOSTEBUDGETAIRE AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _AG_RAISONSOCIAL = "";
        private string _AG_BOITEPOSTAL= "";
		private string _AG_TELEPHONE = "";
        private string _AG_FAX = "";
        private string _BU_CODEBUDGET = "";
        private string _BU_LIBELLE = "";
        private string _BU_DATEDEBUT= "";
        private string _BU_DATEFIN = "";
        private string _BU_DATESAISIE = "";
        private string _BU_CODEBUDGETLIAISON = "";
        private string _OP_CODEOPERATEUR = "";
        private string _BG_CODEPOSTEBUDGETAIRE = "";
        private string _SR_CODESERVICE = "";
        private string _SR_LIBELLE = "";
        private string _BE_MONTANT = "";
        private string _BE_MONTANTREALISATIONMONTANT = "";
        private string _BE_MONTANTREALISATIONTAUX = "";
        private string _BE_MONTANTSOLDE = "";
        private string _BE_OBSERVATION = "";
        private string _BE_DATEVALIDATION = "";
        private string _BE_DATESAISIE = "";
        private string _OP_CODEOPERATEURVALIDATION = "";
        private string _BN_CODENATUREPOSTEBUDGETAIRE = "";
        private string _BN_LIBELLE = "";
        private string _BT_CODETYPEBUDGET = "";
        private string _BT_LIBELLE = "";
        private string _BD_CODETYPEBUDGETDETAIL = "";
        private string _BD_LIBELLE = "";
        private string _BG_LIBELLE = "";
        private string _OP_CODEOPERATEURBUDGETDETAIL = "";
 private string _OP_CODEOPERATEURSAISIE = "";
 private string _OP_CODEOPERATEUREDITION = "";
 private string _MONTANT1 = "";
 private string _MONTANT2 = "";
 private string _DATEDEBUT = "";
private string _DATEFIN = "";
private string _TYPEETAT = "";



        private string _SL_CODEMESSAGE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";





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

        public string AG_BOITEPOSTAL
        {
            get { return _AG_BOITEPOSTAL; }
            set { _AG_BOITEPOSTAL= value; }
        }

		public string AG_TELEPHONE
		{
			get { return _AG_TELEPHONE; }
			set { _AG_TELEPHONE = value; }
		}

        public string AG_FAX
		{
            get { return _AG_FAX; }
            set { _AG_FAX = value; }
		}
        public string BU_CODEBUDGET
		{
            get { return _BU_CODEBUDGET; }
            set { _BU_CODEBUDGET = value; }
		}
        public string BU_LIBELLE
		{
            get { return _BU_LIBELLE; }
            set { _BU_LIBELLE = value; }
		}
        public string BU_DATEDEBUT
		{
            get { return _BU_DATEDEBUT; }
            set { _BU_DATEDEBUT = value; }
		}
        public string BU_DATEFIN
		{
            get { return _BU_DATEFIN; }
            set { _BU_DATEFIN = value; }
		}
        public string BU_DATESAISIE
		{
            get { return _BU_DATESAISIE; }
            set { _BU_DATESAISIE = value; }
		}
        public string BU_CODEBUDGETLIAISON
		{
            get { return _BU_CODEBUDGETLIAISON; }
            set { _BU_CODEBUDGETLIAISON= value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public string BG_CODEPOSTEBUDGETAIRE
		{
            get { return _BG_CODEPOSTEBUDGETAIRE; }
            set { _BG_CODEPOSTEBUDGETAIRE = value; }
		}
        public string SR_CODESERVICE
		{
            get { return _SR_CODESERVICE; }
            set { _SR_CODESERVICE = value; }
		}

        public string SR_LIBELLE
        {
            get { return _SR_LIBELLE; }
            set { _SR_LIBELLE = value; }
        }

        public string BE_MONTANT
        {
            get { return _BE_MONTANT; }
            set { _BE_MONTANT = value; }
        }

        public string BE_MONTANTREALISATIONMONTANT
        {
            get { return _BE_MONTANTREALISATIONMONTANT; }
            set { _BE_MONTANTREALISATIONMONTANT = value; }
        }

        public string BE_MONTANTREALISATIONTAUX
        {
            get { return _BE_MONTANTREALISATIONTAUX; }
            set { _BE_MONTANTREALISATIONTAUX = value; }
        }


        public string BE_MONTANTSOLDE
        {
            get { return _BE_MONTANTSOLDE; }
            set { _BE_MONTANTSOLDE = value; }
        }

        public string BE_OBSERVATION
        {
            get { return _BE_OBSERVATION; }
            set { _BE_OBSERVATION = value; }
        }
        public string BE_DATEVALIDATION
        {
            get { return _BE_DATEVALIDATION; }
            set { _BE_DATEVALIDATION = value; }
        }

        public string BE_DATESAISIE
        {
            get { return _BE_DATESAISIE; }
            set { _BE_DATESAISIE = value; }
        }

        public string OP_CODEOPERATEURVALIDATION
        {
            get { return _OP_CODEOPERATEURVALIDATION; }
            set { _OP_CODEOPERATEURVALIDATION = value; }
        }

        public string BN_CODENATUREPOSTEBUDGETAIRE
        {
            get { return _BN_CODENATUREPOSTEBUDGETAIRE; }
            set { _BN_CODENATUREPOSTEBUDGETAIRE = value; }
        }

        public string BN_LIBELLE
        {
            get { return _BN_LIBELLE; }
            set { _BN_LIBELLE = value; }
        }
        public string BT_CODETYPEBUDGET
        {
            get { return _BT_CODETYPEBUDGET; }
            set { _BT_CODETYPEBUDGET = value; }
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

        public string OP_CODEOPERATEURBUDGETDETAIL
        {
            get { return _OP_CODEOPERATEURBUDGETDETAIL; }
            set { _OP_CODEOPERATEURBUDGETDETAIL = value; }
        }


        public string OP_CODEOPERATEURSAISIE
        {
            get { return _OP_CODEOPERATEURSAISIE; }
            set { _OP_CODEOPERATEURSAISIE = value; }
        }

        public string OP_CODEOPERATEUREDITION
        {
            get { return _OP_CODEOPERATEUREDITION; }
            set { _OP_CODEOPERATEUREDITION = value; }
        }

        public string MONTANT1
        {
            get { return _MONTANT1; }
            set { _MONTANT1 = value; }
        }

        public string MONTANT2
        {
            get { return _MONTANT2; }
            set { _MONTANT2 = value; }
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

        public string TYPEETAT
        {
            get { return _TYPEETAT; }
            set { _TYPEETAT = value; }
        }



     


        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }


        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }





        public clsEditionEtatBudget() {} 

		

		public clsEditionEtatBudget(clsEditionEtatBudget clsEditionEtatBudget)
		{
            this.AG_CODEAGENCE = clsEditionEtatBudget.AG_CODEAGENCE;
            this.AG_RAISONSOCIAL = clsEditionEtatBudget.AG_RAISONSOCIAL;
            this.AG_BOITEPOSTAL = clsEditionEtatBudget.AG_BOITEPOSTAL;
            this.AG_TELEPHONE = clsEditionEtatBudget.AG_TELEPHONE;
            this.AG_FAX = clsEditionEtatBudget.AG_FAX;
            this.BU_CODEBUDGET = clsEditionEtatBudget.BU_CODEBUDGET;
            this.BU_LIBELLE = clsEditionEtatBudget.BU_LIBELLE;
            this.BU_DATEDEBUT = clsEditionEtatBudget.BU_DATEDEBUT;
            this.BU_DATEFIN = clsEditionEtatBudget.BU_DATEFIN;
            this.BU_DATESAISIE = clsEditionEtatBudget.BU_DATESAISIE;
            this.BU_CODEBUDGETLIAISON = clsEditionEtatBudget.BU_CODEBUDGETLIAISON;
            this.OP_CODEOPERATEUR = clsEditionEtatBudget.OP_CODEOPERATEUR;
            this.BG_CODEPOSTEBUDGETAIRE = clsEditionEtatBudget.BG_CODEPOSTEBUDGETAIRE;
            this.SR_CODESERVICE = clsEditionEtatBudget.SR_CODESERVICE;
            this.SR_LIBELLE = clsEditionEtatBudget.SR_LIBELLE;
            this.BE_MONTANT = clsEditionEtatBudget.BE_MONTANT;
            this.BE_MONTANTREALISATIONMONTANT = clsEditionEtatBudget.BE_MONTANTREALISATIONMONTANT;
            this.BE_MONTANTREALISATIONTAUX = clsEditionEtatBudget.BE_MONTANTREALISATIONTAUX;
            this.BE_MONTANTSOLDE = clsEditionEtatBudget.BE_MONTANTSOLDE;
            this.BE_OBSERVATION = clsEditionEtatBudget.BE_OBSERVATION;
            this.BE_DATEVALIDATION = clsEditionEtatBudget.BE_DATEVALIDATION;
            this.BE_DATESAISIE = clsEditionEtatBudget.BE_DATESAISIE;
            this.OP_CODEOPERATEURVALIDATION = clsEditionEtatBudget.OP_CODEOPERATEURVALIDATION;
            this.BN_CODENATUREPOSTEBUDGETAIRE = clsEditionEtatBudget.BN_CODENATUREPOSTEBUDGETAIRE;
            this.BN_LIBELLE = clsEditionEtatBudget.BN_LIBELLE;
            this.BT_CODETYPEBUDGET = clsEditionEtatBudget.BT_CODETYPEBUDGET;
            this.BT_LIBELLE = clsEditionEtatBudget.BT_LIBELLE;
            this.BD_CODETYPEBUDGETDETAIL = clsEditionEtatBudget.BD_CODETYPEBUDGETDETAIL;
            this.BD_LIBELLE = clsEditionEtatBudget.BD_LIBELLE;
            this.BG_LIBELLE = clsEditionEtatBudget.BG_LIBELLE;
            this.OP_CODEOPERATEURBUDGETDETAIL = clsEditionEtatBudget.OP_CODEOPERATEURBUDGETDETAIL;
            this.OP_CODEOPERATEURSAISIE = clsEditionEtatBudget.OP_CODEOPERATEURSAISIE;
            this.OP_CODEOPERATEUREDITION = clsEditionEtatBudget.OP_CODEOPERATEUREDITION;
            this.MONTANT1 = clsEditionEtatBudget.MONTANT1;
            this.MONTANT2 = clsEditionEtatBudget.MONTANT2;
            this.DATEDEBUT = clsEditionEtatBudget.DATEDEBUT;
            this.DATEFIN = clsEditionEtatBudget.DATEFIN;
            this.TYPEETAT = clsEditionEtatBudget.TYPEETAT;
            this.SL_CODEMESSAGE = SL_CODEMESSAGE;
            this.SL_RESULTAT = SL_RESULTAT;
            this.SL_MESSAGE = SL_MESSAGE;


        }
        }
}