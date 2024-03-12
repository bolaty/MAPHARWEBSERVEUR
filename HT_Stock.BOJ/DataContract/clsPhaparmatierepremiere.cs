using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparmatierepremiere
	{
		#region VARIABLES LOCALES

		private string _AR_CODEARTICLE = "";
		private string _AR_CODEARTICLE1 = "";
		private int _MP_QUANTITE = 0;
        private int _MP_QUANTITEPERTE = 0;
        private int _MP_QUANTITEPERTEFICTIF = 0;

		#endregion

		#region ACCESSEURS

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string AR_CODEARTICLE1
		{
			get { return _AR_CODEARTICLE1; }
			set {  _AR_CODEARTICLE1 = value; }
		}

		public int MP_QUANTITE
		{
			get { return _MP_QUANTITE; }
			set {  _MP_QUANTITE = value; }
		}
        public int MP_QUANTITEPERTE
        {
            get { return _MP_QUANTITEPERTE; }
            set { _MP_QUANTITEPERTE = value; }
        }
        public int MP_QUANTITEPERTEFICTIF
        {
            get { return _MP_QUANTITEPERTEFICTIF; }
            set { _MP_QUANTITEPERTEFICTIF = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsPhaparmatierepremiere(){}
        public clsPhaparmatierepremiere(string AR_CODEARTICLE, string AR_CODEARTICLE1, int MP_QUANTITE, int MP_QUANTITEPERTEFICTIF)
		{
			this.AR_CODEARTICLE = AR_CODEARTICLE;
			this.AR_CODEARTICLE1 = AR_CODEARTICLE1;
			this.MP_QUANTITE = MP_QUANTITE;
            this.MP_QUANTITEPERTE = MP_QUANTITEPERTE;
            this.MP_QUANTITEPERTEFICTIF = MP_QUANTITEPERTEFICTIF;

		}
		public clsPhaparmatierepremiere(clsPhaparmatierepremiere clsPhaparmatierepremiere)
		{
			this.AR_CODEARTICLE = clsPhaparmatierepremiere.AR_CODEARTICLE;
			this.AR_CODEARTICLE1 = clsPhaparmatierepremiere.AR_CODEARTICLE1;
			this.MP_QUANTITE = clsPhaparmatierepremiere.MP_QUANTITE;
            this.MP_QUANTITEPERTE = clsPhaparmatierepremiere.MP_QUANTITEPERTE;
            this.MP_QUANTITEPERTEFICTIF = clsPhaparmatierepremiere.MP_QUANTITEPERTEFICTIF;
		}

		#endregion

	}
}
