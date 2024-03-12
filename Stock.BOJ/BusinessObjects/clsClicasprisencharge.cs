using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsClicasprisencharge
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _AR_CODEARTICLE = "";
		private string _AP_CODEPRODUIT = "";
		private string _PE_CODEPERIODICITE = "";
		private double _CP_TAUXREMBOURSEMENT = 0;
		private double _CP_MONTANT = 0;
		private double _CP_PLAFOND = 0;
		private int _CP_NOMBRE = 0;
		private string _COCHER = "";
		private string _APPLIQUERAUXADHERANTS = "";
		private string _EN_CODEENTREPOT = "";
		private DateTime _AS_DATESAISIE1 =DateTime.Parse("01/01/1900");
		private DateTime _AS_DATESAISIE2 = DateTime.Parse("01/01/1900");

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string AP_CODEPRODUIT
		{
			get { return _AP_CODEPRODUIT; }
			set {  _AP_CODEPRODUIT = value; }
		}

        public string PE_CODEPERIODICITE
        {
	        get { return _PE_CODEPERIODICITE; }
	        set { _PE_CODEPERIODICITE = value; }
        }

        public double CP_TAUXREMBOURSEMENT
        {
	        get { return _CP_TAUXREMBOURSEMENT; }
	        set { _CP_TAUXREMBOURSEMENT = value; }
        }

        public double CP_MONTANT
        {
	        get { return _CP_MONTANT; }
	        set { _CP_MONTANT = value; }
        }

        public double CP_PLAFOND
        {
	        get { return _CP_PLAFOND; }
	        set { _CP_PLAFOND = value; }
        }



        public int CP_NOMBRE
        {
	        get { return _CP_NOMBRE; }
	        set { _CP_NOMBRE = value; }
        }
        public string COCHER
        {
	        get { return _COCHER; }
	        set { _COCHER = value; }
        }
        public string APPLIQUERAUXADHERANTS
        {
	        get { return _APPLIQUERAUXADHERANTS; }
	        set { _APPLIQUERAUXADHERANTS = value; }
        }
        public string EN_CODEENTREPOT
        {
	        get { return _EN_CODEENTREPOT; }
	        set { _EN_CODEENTREPOT = value; }
        }
        public DateTime AS_DATESAISIE1
        {
	        get { return _AS_DATESAISIE1; }
	        set { _AS_DATESAISIE1 = value; }
        }
        public DateTime AS_DATESAISIE2
        {
	        get { return _AS_DATESAISIE2; }
	        set { _AS_DATESAISIE2 = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsClicasprisencharge(){}
		
		public clsClicasprisencharge(clsClicasprisencharge clsClicasprisencharge)
		{
			this.AG_CODEAGENCE = clsClicasprisencharge.AG_CODEAGENCE;
			this.AR_CODEARTICLE = clsClicasprisencharge.AR_CODEARTICLE;
			this.AP_CODEPRODUIT = clsClicasprisencharge.AP_CODEPRODUIT;
			this.PE_CODEPERIODICITE = clsClicasprisencharge.PE_CODEPERIODICITE;
			this.CP_TAUXREMBOURSEMENT = clsClicasprisencharge.CP_TAUXREMBOURSEMENT;
			this.CP_MONTANT = clsClicasprisencharge.CP_MONTANT;
			this.CP_PLAFOND = clsClicasprisencharge.CP_PLAFOND;
			this.CP_NOMBRE = clsClicasprisencharge.CP_NOMBRE;
			this.COCHER = clsClicasprisencharge.COCHER;
			this.APPLIQUERAUXADHERANTS = clsClicasprisencharge.APPLIQUERAUXADHERANTS;
			this.EN_CODEENTREPOT = clsClicasprisencharge.EN_CODEENTREPOT;
			this.AS_DATESAISIE1 = clsClicasprisencharge.AS_DATESAISIE1;
			this.AS_DATESAISIE2 = clsClicasprisencharge.AS_DATESAISIE2;
        }

		#endregion

	}
}
