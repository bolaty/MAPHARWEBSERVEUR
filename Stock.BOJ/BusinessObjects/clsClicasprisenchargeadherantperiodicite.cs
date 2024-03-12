using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsClicasprisenchargeadherantperiodicite
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _AR_CODEARTICLE = "";
		private string _AP_CODEPRODUIT = "";
		private string _PE_CODEPERIODICITE = "";
		private string _TI_IDTIERSADHERANT = "";
		private float _CP_TAUXREMBOURSEMENT = 0;
		private double _CP_MONTANT = 0;
		private double _CP_PLAFOND = 0;
		private int _CP_NOMBRE = 0;
		private DateTime _CP_DATEFINDERNIEREPERIODICITE = DateTime.Parse("01/01/1900");

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
			set {  _PE_CODEPERIODICITE = value; }
		}

		public string TI_IDTIERSADHERANT
		{
			get { return _TI_IDTIERSADHERANT; }
			set {  _TI_IDTIERSADHERANT = value; }
		}

		public float CP_TAUXREMBOURSEMENT
		{
			get { return _CP_TAUXREMBOURSEMENT; }
			set {  _CP_TAUXREMBOURSEMENT = value; }
		}

		public double CP_MONTANT
        {
			get { return _CP_MONTANT; }
			set { _CP_MONTANT = value; }
		}


		public double CP_PLAFOND
		{
			get { return _CP_PLAFOND; }
			set {  _CP_PLAFOND = value; }
		}

		public int CP_NOMBRE
		{
			get { return _CP_NOMBRE; }
			set {  _CP_NOMBRE = value; }
		}

		public DateTime CP_DATEFINDERNIEREPERIODICITE
		{
			get { return _CP_DATEFINDERNIEREPERIODICITE; }
			set {  _CP_DATEFINDERNIEREPERIODICITE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsClicasprisenchargeadherantperiodicite(){}

		public clsClicasprisenchargeadherantperiodicite(clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite)
		{
			this.AG_CODEAGENCE = clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE;
			this.AR_CODEARTICLE = clsClicasprisenchargeadherantperiodicite.AR_CODEARTICLE;
			this.AP_CODEPRODUIT = clsClicasprisenchargeadherantperiodicite.AP_CODEPRODUIT;
			this.PE_CODEPERIODICITE = clsClicasprisenchargeadherantperiodicite.PE_CODEPERIODICITE;
			this.TI_IDTIERSADHERANT = clsClicasprisenchargeadherantperiodicite.TI_IDTIERSADHERANT;
			this.CP_TAUXREMBOURSEMENT = clsClicasprisenchargeadherantperiodicite.CP_TAUXREMBOURSEMENT;
			this.CP_MONTANT = clsClicasprisenchargeadherantperiodicite.CP_MONTANT;
			this.CP_PLAFOND = clsClicasprisenchargeadherantperiodicite.CP_PLAFOND;
			this.CP_NOMBRE = clsClicasprisenchargeadherantperiodicite.CP_NOMBRE;
			this.CP_DATEFINDERNIEREPERIODICITE = clsClicasprisenchargeadherantperiodicite.CP_DATEFINDERNIEREPERIODICITE;
		}

		#endregion

	}
}
