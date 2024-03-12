using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpartauxauto
	{
		#region VARIABLES LOCALES

		private double _TX_CODETAUX = 0;
		private int _TX_DUREEMINIMUM = 0;
		private int _TX_DUREEMAXIMUM = 0;
		private decimal _TX_TAUX = 0;

		#endregion

		#region ACCESSEURS

		public double TX_CODETAUX
		{
			get { return _TX_CODETAUX; }
			set {  _TX_CODETAUX = value; }
		}

		public int TX_DUREEMINIMUM
		{
			get { return _TX_DUREEMINIMUM; }
			set {  _TX_DUREEMINIMUM = value; }
		}

		public int TX_DUREEMAXIMUM
		{
			get { return _TX_DUREEMAXIMUM; }
			set {  _TX_DUREEMAXIMUM = value; }
		}

		public decimal TX_TAUX
		{
			get { return _TX_TAUX; }
			set {  _TX_TAUX = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartauxauto(){}
		public clsCtpartauxauto( double TX_CODETAUX,int TX_DUREEMINIMUM,int TX_DUREEMAXIMUM,decimal TX_TAUX)
		{
			this.TX_CODETAUX = TX_CODETAUX;
			this.TX_DUREEMINIMUM = TX_DUREEMINIMUM;
			this.TX_DUREEMAXIMUM = TX_DUREEMAXIMUM;
			this.TX_TAUX = TX_TAUX;
		}
		public clsCtpartauxauto(clsCtpartauxauto clsCtpartauxauto)
		{
			this.TX_CODETAUX = clsCtpartauxauto.TX_CODETAUX;
			this.TX_DUREEMINIMUM = clsCtpartauxauto.TX_DUREEMINIMUM;
			this.TX_DUREEMAXIMUM = clsCtpartauxauto.TX_DUREEMAXIMUM;
			this.TX_TAUX = clsCtpartauxauto.TX_TAUX;
		}

		#endregion

	}
}
