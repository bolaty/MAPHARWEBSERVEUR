using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsMicbudgetdetailhisto
	{
		#region VARIABLES LOCALES

		private string _BU_CODEBUDGET = "";
		private string _BG_CODEPOSTEBUDGETAIRE = "";
		private string _SR_CODESERVICE = "";
		private DateTime _BE_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _BE_DATEFIN = DateTime.Parse("01/01/1900");
		private string _TY_TYPEBUDGETDEATAIL = "";
		private string _AG_CODEAGENCE = "";
		private string _PV_CODEPOINTVENTE = "";
		private string _PE_CODEPERIODICITE = "";
		private double _BE_MONTANT = 0;
		private DateTime _BE_DATESAISIE = DateTime.Parse("01/01/1900");
		private DateTime _BE_DATEVALIDATION = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEURVALIDATION = "";
		private string _OP_CODEOPERATEUR = "";
		private string _BU_CODEBUDGETLIAISON = "";
		private double _BE_MONTANTREALISATIONMONTANT = 0;
		private double _BE_MONTANTREALISATIONTAUX = 0;
		private double _BE_MONTANTSOLDE = 0;
		private string _BE_OBSERVATION = "";
		private string _BN_CODENATUREPOSTEBUDGETAIRE = "";
		private string _BT_CODETYPEBUDGET = "";
		private string _BD_CODETYPEBUDGETDETAIL = "";
		private string _OP_CODEOPERATEURBUDGETDETAIL = "";

		#endregion

		#region ACCESSEURS

		public string BU_CODEBUDGET
		{
			get { return _BU_CODEBUDGET; }
			set {  _BU_CODEBUDGET = value; }
		}

		public string BG_CODEPOSTEBUDGETAIRE
		{
			get { return _BG_CODEPOSTEBUDGETAIRE; }
			set {  _BG_CODEPOSTEBUDGETAIRE = value; }
		}

		public string SR_CODESERVICE
		{
			get { return _SR_CODESERVICE; }
			set {  _SR_CODESERVICE = value; }
		}

		public DateTime BE_DATEDEBUT
		{
			get { return _BE_DATEDEBUT; }
			set {  _BE_DATEDEBUT = value; }
		}

		public DateTime BE_DATEFIN
		{
			get { return _BE_DATEFIN; }
			set {  _BE_DATEFIN = value; }
		}

		public string TY_TYPEBUDGETDEATAIL
		{
			get { return _TY_TYPEBUDGETDEATAIL; }
			set {  _TY_TYPEBUDGETDEATAIL = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string PV_CODEPOINTVENTE
		{
			get { return _PV_CODEPOINTVENTE; }
			set {  _PV_CODEPOINTVENTE = value; }
		}

		public string PE_CODEPERIODICITE
		{
			get { return _PE_CODEPERIODICITE; }
			set {  _PE_CODEPERIODICITE = value; }
		}

		public double BE_MONTANT
		{
			get { return _BE_MONTANT; }
			set {  _BE_MONTANT = value; }
		}

		public DateTime BE_DATESAISIE
		{
			get { return _BE_DATESAISIE; }
			set {  _BE_DATESAISIE = value; }
		}

		public DateTime BE_DATEVALIDATION
		{
			get { return _BE_DATEVALIDATION; }
			set {  _BE_DATEVALIDATION = value; }
		}

		public string OP_CODEOPERATEURVALIDATION
		{
			get { return _OP_CODEOPERATEURVALIDATION; }
			set {  _OP_CODEOPERATEURVALIDATION = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string BU_CODEBUDGETLIAISON
		{
			get { return _BU_CODEBUDGETLIAISON; }
			set {  _BU_CODEBUDGETLIAISON = value; }
		}

		public double BE_MONTANTREALISATIONMONTANT
		{
			get { return _BE_MONTANTREALISATIONMONTANT; }
			set {  _BE_MONTANTREALISATIONMONTANT = value; }
		}

		public double BE_MONTANTREALISATIONTAUX
		{
			get { return _BE_MONTANTREALISATIONTAUX; }
			set {  _BE_MONTANTREALISATIONTAUX = value; }
		}

		public double BE_MONTANTSOLDE
		{
			get { return _BE_MONTANTSOLDE; }
			set {  _BE_MONTANTSOLDE = value; }
		}

		public string BE_OBSERVATION
		{
			get { return _BE_OBSERVATION; }
			set {  _BE_OBSERVATION = value; }
		}

		public string BN_CODENATUREPOSTEBUDGETAIRE
		{
			get { return _BN_CODENATUREPOSTEBUDGETAIRE; }
			set {  _BN_CODENATUREPOSTEBUDGETAIRE = value; }
		}

		public string BT_CODETYPEBUDGET
		{
			get { return _BT_CODETYPEBUDGET; }
			set {  _BT_CODETYPEBUDGET = value; }
		}

		public string BD_CODETYPEBUDGETDETAIL
		{
			get { return _BD_CODETYPEBUDGETDETAIL; }
			set {  _BD_CODETYPEBUDGETDETAIL = value; }
		}

		public string OP_CODEOPERATEURBUDGETDETAIL
		{
			get { return _OP_CODEOPERATEURBUDGETDETAIL; }
			set {  _OP_CODEOPERATEURBUDGETDETAIL = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsMicbudgetdetailhisto(){}
		public clsMicbudgetdetailhisto( string BU_CODEBUDGET,string BG_CODEPOSTEBUDGETAIRE,string SR_CODESERVICE,DateTime BE_DATEDEBUT,DateTime BE_DATEFIN,string TY_TYPEBUDGETDEATAIL,string AG_CODEAGENCE,string PV_CODEPOINTVENTE,string PE_CODEPERIODICITE,double BE_MONTANT,DateTime BE_DATESAISIE,DateTime BE_DATEVALIDATION,string OP_CODEOPERATEURVALIDATION,string OP_CODEOPERATEUR,string BU_CODEBUDGETLIAISON,double BE_MONTANTREALISATIONMONTANT,double BE_MONTANTREALISATIONTAUX,double BE_MONTANTSOLDE,string BE_OBSERVATION,string BN_CODENATUREPOSTEBUDGETAIRE,string BT_CODETYPEBUDGET,string BD_CODETYPEBUDGETDETAIL,string OP_CODEOPERATEURBUDGETDETAIL)
		{
			this.BU_CODEBUDGET = BU_CODEBUDGET;
			this.BG_CODEPOSTEBUDGETAIRE = BG_CODEPOSTEBUDGETAIRE;
			this.SR_CODESERVICE = SR_CODESERVICE;
			this.BE_DATEDEBUT = BE_DATEDEBUT;
			this.BE_DATEFIN = BE_DATEFIN;
			this.TY_TYPEBUDGETDEATAIL = TY_TYPEBUDGETDEATAIL;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.PV_CODEPOINTVENTE = PV_CODEPOINTVENTE;
			this.PE_CODEPERIODICITE = PE_CODEPERIODICITE;
			this.BE_MONTANT = BE_MONTANT;
			this.BE_DATESAISIE = BE_DATESAISIE;
			this.BE_DATEVALIDATION = BE_DATEVALIDATION;
			this.OP_CODEOPERATEURVALIDATION = OP_CODEOPERATEURVALIDATION;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.BU_CODEBUDGETLIAISON = BU_CODEBUDGETLIAISON;
			this.BE_MONTANTREALISATIONMONTANT = BE_MONTANTREALISATIONMONTANT;
			this.BE_MONTANTREALISATIONTAUX = BE_MONTANTREALISATIONTAUX;
			this.BE_MONTANTSOLDE = BE_MONTANTSOLDE;
			this.BE_OBSERVATION = BE_OBSERVATION;
			this.BN_CODENATUREPOSTEBUDGETAIRE = BN_CODENATUREPOSTEBUDGETAIRE;
			this.BT_CODETYPEBUDGET = BT_CODETYPEBUDGET;
			this.BD_CODETYPEBUDGETDETAIL = BD_CODETYPEBUDGETDETAIL;
			this.OP_CODEOPERATEURBUDGETDETAIL = OP_CODEOPERATEURBUDGETDETAIL;
		}
		public clsMicbudgetdetailhisto(clsMicbudgetdetailhisto clsMicbudgetdetailhisto)
		{
			this.BU_CODEBUDGET = clsMicbudgetdetailhisto.BU_CODEBUDGET;
			this.BG_CODEPOSTEBUDGETAIRE = clsMicbudgetdetailhisto.BG_CODEPOSTEBUDGETAIRE;
			this.SR_CODESERVICE = clsMicbudgetdetailhisto.SR_CODESERVICE;
			this.BE_DATEDEBUT = clsMicbudgetdetailhisto.BE_DATEDEBUT;
			this.BE_DATEFIN = clsMicbudgetdetailhisto.BE_DATEFIN;
			this.TY_TYPEBUDGETDEATAIL = clsMicbudgetdetailhisto.TY_TYPEBUDGETDEATAIL;
			this.AG_CODEAGENCE = clsMicbudgetdetailhisto.AG_CODEAGENCE;
			this.PV_CODEPOINTVENTE = clsMicbudgetdetailhisto.PV_CODEPOINTVENTE;
			this.PE_CODEPERIODICITE = clsMicbudgetdetailhisto.PE_CODEPERIODICITE;
			this.BE_MONTANT = clsMicbudgetdetailhisto.BE_MONTANT;
			this.BE_DATESAISIE = clsMicbudgetdetailhisto.BE_DATESAISIE;
			this.BE_DATEVALIDATION = clsMicbudgetdetailhisto.BE_DATEVALIDATION;
			this.OP_CODEOPERATEURVALIDATION = clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION;
			this.OP_CODEOPERATEUR = clsMicbudgetdetailhisto.OP_CODEOPERATEUR;
			this.BU_CODEBUDGETLIAISON = clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON;
			this.BE_MONTANTREALISATIONMONTANT = clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT;
			this.BE_MONTANTREALISATIONTAUX = clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX;
			this.BE_MONTANTSOLDE = clsMicbudgetdetailhisto.BE_MONTANTSOLDE;
			this.BE_OBSERVATION = clsMicbudgetdetailhisto.BE_OBSERVATION;
			this.BN_CODENATUREPOSTEBUDGETAIRE = clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE;
			this.BT_CODETYPEBUDGET = clsMicbudgetdetailhisto.BT_CODETYPEBUDGET;
			this.BD_CODETYPEBUDGETDETAIL = clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL;
			this.OP_CODEOPERATEURBUDGETDETAIL = clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL;
		}

		#endregion

	}
}
