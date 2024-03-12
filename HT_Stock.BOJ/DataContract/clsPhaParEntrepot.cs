using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparentrepot : clsEntitieBase
    {
        
        private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
        private string _EN_NUMENTREPOT = "";
		private string _EN_DENOMINATION = "";
		private string _EN_ADRESSEPOSTALE = "";
		private string _EN_ADRESSEGEOGRAPHIQUE = "";
		private string _EN_TELEPHONE = "";
		private string _EN_FAX = "";
		private string _EN_SITEWEB = "";
		private string _EN_EMAIL = "";
		private string _EN_GERANT = "";
        private string _EN_ENTREPOTPARDEFAUT = "";
        private string _EN_REFERENCE = "N";
        private string _EN_STOCKMINI = "0";
        private string _EN_STOCKMAXI = "0";
        private string _EN_ACTIF = "";
        private string _CODEOPERATEUR = "";


        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set { _EN_CODEENTREPOT = value; }
		}
        public string EN_NUMENTREPOT
        {
            get { return _EN_NUMENTREPOT; }
            set { _EN_NUMENTREPOT = value; }
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
		public string EN_ADRESSEGEOGRAPHIQUE
		{
			get { return _EN_ADRESSEGEOGRAPHIQUE; }
			set { _EN_ADRESSEGEOGRAPHIQUE = value; }
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
		public string EN_SITEWEB
		{
			get { return _EN_SITEWEB; }
			set { _EN_SITEWEB = value; }
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

        public string EN_ENTREPOTPARDEFAUT
        {
            get { return _EN_ENTREPOTPARDEFAUT; }
            set { _EN_ENTREPOTPARDEFAUT = value; }
        }
        public string EN_REFERENCE
        {
            get { return _EN_REFERENCE; }
            set { _EN_REFERENCE = value; }
        }



        public string EN_STOCKMINI
        {
            get { return _EN_STOCKMINI; }
            set { _EN_STOCKMINI = value; }
        }

        public string EN_STOCKMAXI
        {
            get { return _EN_STOCKMAXI; }
            set { _EN_STOCKMAXI = value; }
        }

        public string EN_ACTIF
        {
            get { return _EN_ACTIF; }
            set { _EN_ACTIF = value; }
        }
        public string CODEOPERATEUR
        {
            get { return _CODEOPERATEUR; }
            set { _CODEOPERATEUR = value; }
        }
        

        public clsPhaparentrepot() {} 

        

		public clsPhaparentrepot(clsPhaparentrepot clsPhaparentrepot)
		{
			AG_CODEAGENCE = clsPhaparentrepot.AG_CODEAGENCE;
			EN_CODEENTREPOT = clsPhaparentrepot.EN_CODEENTREPOT;
            EN_NUMENTREPOT = clsPhaparentrepot.EN_NUMENTREPOT;
			EN_DENOMINATION = clsPhaparentrepot.EN_DENOMINATION;
			EN_ADRESSEPOSTALE = clsPhaparentrepot.EN_ADRESSEPOSTALE;
			EN_ADRESSEGEOGRAPHIQUE = clsPhaparentrepot.EN_ADRESSEGEOGRAPHIQUE;
			EN_TELEPHONE = clsPhaparentrepot.EN_TELEPHONE;
			EN_FAX = clsPhaparentrepot.EN_FAX;
			EN_SITEWEB = clsPhaparentrepot.EN_SITEWEB;
			EN_EMAIL = clsPhaparentrepot.EN_EMAIL;
			EN_GERANT = clsPhaparentrepot.EN_GERANT;
            EN_ENTREPOTPARDEFAUT = clsPhaparentrepot.EN_ENTREPOTPARDEFAUT;
            EN_REFERENCE = clsPhaparentrepot.EN_REFERENCE;

            EN_STOCKMINI = clsPhaparentrepot.EN_STOCKMINI;
            EN_STOCKMAXI = clsPhaparentrepot.EN_STOCKMAXI;
            EN_ACTIF = clsPhaparentrepot.EN_ACTIF;
            CODEOPERATEUR = clsPhaparentrepot.CODEOPERATEUR;



        }
        }
}