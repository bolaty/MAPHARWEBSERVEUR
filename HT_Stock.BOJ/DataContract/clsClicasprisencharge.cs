using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
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



		}

		#endregion

	}
}
