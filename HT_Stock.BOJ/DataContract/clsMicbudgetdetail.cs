using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsMicbudgetdetail
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _BU_CODEBUDGET = "";
		private string _BG_CODEPOSTEBUDGETAIRE = "";
        private string _SR_CODESERVICE = "";
		private double _BE_MONTANT = 0;
		private string _OP_CODEOPERATEURVALIDATION = "";

        private DateTime _BE_DATEVALIDATION = DateTime.Parse("01/01/1900");
        private DateTime _BE_DATESAISIE = DateTime.Parse("01/01/1900");
        private string _OP_CODEOPERATEUR = "";

        private string _PE_CODEPERIODICITE = "";
        private DateTime _BE_DATEDEBUT =DateTime.Parse( "01/01/1900");
        private DateTime _BE_DATEFIN = DateTime.Parse("01/01/1900");
        private string _TYPEOPERATION = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

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

		public double BE_MONTANT
		{
			get { return _BE_MONTANT; }
			set {  _BE_MONTANT = value; }
		}

		public string OP_CODEOPERATEURVALIDATION
		{
			get { return _OP_CODEOPERATEURVALIDATION; }
			set {  _OP_CODEOPERATEURVALIDATION = value; }
		}



        public DateTime BE_DATEVALIDATION
        {
            get { return _BE_DATEVALIDATION; }
            set { _BE_DATEVALIDATION = value; }
        }

        public DateTime BE_DATESAISIE
        {
            get { return _BE_DATESAISIE; }
            set { _BE_DATESAISIE = value; }
        }

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public string PE_CODEPERIODICITE
        {
            get { return _PE_CODEPERIODICITE; }
            set { _PE_CODEPERIODICITE = value; }
        }

        public DateTime BE_DATEDEBUT
        {
            get { return _BE_DATEDEBUT; }
            set { _BE_DATEDEBUT = value; }
        }

        public DateTime BE_DATEFIN
        {
            get { return _BE_DATEFIN; }
            set { _BE_DATEFIN = value; }
        }

        public String TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsMicbudgetdetail(){}

		public clsMicbudgetdetail(clsMicbudgetdetail clsMicbudgetdetail)
		{
			this.AG_CODEAGENCE = clsMicbudgetdetail.AG_CODEAGENCE;
			this.BU_CODEBUDGET = clsMicbudgetdetail.BU_CODEBUDGET;
			this.BG_CODEPOSTEBUDGETAIRE = clsMicbudgetdetail.BG_CODEPOSTEBUDGETAIRE;
			this.SR_CODESERVICE = clsMicbudgetdetail.SR_CODESERVICE;
			this.BE_MONTANT = clsMicbudgetdetail.BE_MONTANT;
			this.OP_CODEOPERATEURVALIDATION = clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION;


			this.BE_DATEVALIDATION = clsMicbudgetdetail.BE_DATEVALIDATION;
			this.BE_DATESAISIE = clsMicbudgetdetail.BE_DATESAISIE;
			this.OP_CODEOPERATEUR = clsMicbudgetdetail.OP_CODEOPERATEUR;
            this.PE_CODEPERIODICITE = clsMicbudgetdetail.PE_CODEPERIODICITE;
            this.BE_DATEDEBUT = clsMicbudgetdetail.BE_DATEDEBUT;
            this.BE_DATEFIN = clsMicbudgetdetail.BE_DATEFIN;
            this.TYPEOPERATION = clsMicbudgetdetail.TYPEOPERATION;


        }

		#endregion

	}
}
