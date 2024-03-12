using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsMicbudget
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _BU_CODEBUDGET = "";
		private string _BU_LIBELLE = "";
		private DateTime _BU_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _BU_DATEFIN = DateTime.Parse("01/01/1900");
        private DateTime _BU_DATESAISIE = DateTime.Parse("01/01/1900");
        private string _BU_CODEBUDGETLIAISON = "";
        private string _OP_CODEOPERATEUR = "";

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

		public string BU_LIBELLE
		{
			get { return _BU_LIBELLE; }
			set {  _BU_LIBELLE = value; }
		}

		public DateTime BU_DATEDEBUT
		{
			get { return _BU_DATEDEBUT; }
			set {  _BU_DATEDEBUT = value; }
		}

		public DateTime BU_DATEFIN
		{
			get { return _BU_DATEFIN; }
			set {  _BU_DATEFIN = value; }
		}

        public DateTime BU_DATESAISIE
        {
            get { return _BU_DATESAISIE; }
            set { _BU_DATESAISIE = value; }
        }

        public string BU_CODEBUDGETLIAISON
        {
            get { return _BU_CODEBUDGETLIAISON; }
            set { _BU_CODEBUDGETLIAISON = value; }
        }


        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsMicbudget(){}
		public clsMicbudget(clsMicbudget clsMicbudget)
		{
			this.AG_CODEAGENCE = clsMicbudget.AG_CODEAGENCE;
			this.BU_CODEBUDGET = clsMicbudget.BU_CODEBUDGET;
			this.BU_LIBELLE = clsMicbudget.BU_LIBELLE;
			this.BU_DATEDEBUT = clsMicbudget.BU_DATEDEBUT;
			this.BU_DATEFIN = clsMicbudget.BU_DATEFIN;
            this.BU_DATESAISIE = clsMicbudget.BU_DATESAISIE;
            this.BU_CODEBUDGETLIAISON = clsMicbudget.BU_CODEBUDGETLIAISON;
			this.OP_CODEOPERATEUR = clsMicbudget.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
