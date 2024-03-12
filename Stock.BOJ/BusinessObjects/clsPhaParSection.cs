using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhaparsection
	{

        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _SC_CODESECTION = "";
        private string _SC_NUMSECTION = "";
		private string _SC_DENOMINATION = "";
		private string _SC_ADRESSEPOSTALE = "";
		private string _SC_ADRESSEGEOGRAPHIQUE = "";
		private string _SC_TELEPHONE = "";
		private string _SC_FAX = "";
		private string _SC_SITEWEB = "";
		private string _SC_EMAIL = "";
		private string _SC_GERANT = "";
  


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
		public string SC_CODESECTION
		{
			get { return _SC_CODESECTION; }
			set { _SC_CODESECTION = value; }
		}
        public string SC_NUMSECTION
        {
            get { return _SC_NUMSECTION; }
            set { _SC_NUMSECTION = value; }
        }

		public string SC_DENOMINATION
		{
			get { return _SC_DENOMINATION; }
			set { _SC_DENOMINATION = value; }
		}
		public string SC_ADRESSEPOSTALE
		{
			get { return _SC_ADRESSEPOSTALE; }
			set { _SC_ADRESSEPOSTALE = value; }
		}
		public string SC_ADRESSEGEOGRAPHIQUE
		{
			get { return _SC_ADRESSEGEOGRAPHIQUE; }
			set { _SC_ADRESSEGEOGRAPHIQUE = value; }
		}
		public string SC_TELEPHONE
		{
			get { return _SC_TELEPHONE; }
			set { _SC_TELEPHONE = value; }
		}
		public string SC_FAX
		{
			get { return _SC_FAX; }
			set { _SC_FAX = value; }
		}
		public string SC_SITEWEB
		{
			get { return _SC_SITEWEB; }
			set { _SC_SITEWEB = value; }
		}
		public string SC_EMAIL
		{
			get { return _SC_EMAIL; }
			set { _SC_EMAIL = value; }
		}
		public string SC_GERANT
		{
			get { return _SC_GERANT; }
			set { _SC_GERANT = value; }
		}

       

        public clsPhaparsection() {} 

        //public clsPhaparsection(string AG_CODEAGENCE,string SC_CODESECTION,string SC_DENOMINATION,string SC_ADRESSEPOSTALE,string SC_ADRESSEGEOGRAPHIQUE,string SC_TELEPHONE,string SC_FAX,string SC_SITEWEB,string SC_EMAIL,string SC_GERANT)
        //{
        //    this.AG_CODEAGENCE = AG_CODEAGENCE;
        //    this.SC_CODESECTION = SC_CODESECTION;
        //    this.SC_DENOMINATION = SC_DENOMINATION;
        //    this.SC_ADRESSEPOSTALE = SC_ADRESSEPOSTALE;
        //    this.SC_ADRESSEGEOGRAPHIQUE = SC_ADRESSEGEOGRAPHIQUE;
        //    this.SC_TELEPHONE = SC_TELEPHONE;
        //    this.SC_FAX = SC_FAX;
        //    this.SC_SITEWEB = SC_SITEWEB;
        //    this.SC_EMAIL = SC_EMAIL;
        //    this.SC_GERANT = SC_GERANT;
        //}

		public clsPhaparsection(clsPhaparsection clsPhaparsection)
		{
			AG_CODEAGENCE = clsPhaparsection.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsPhaparsection.EN_CODEENTREPOT;
			SC_CODESECTION = clsPhaparsection.SC_CODESECTION;
            SC_NUMSECTION = clsPhaparsection.SC_NUMSECTION;
			SC_DENOMINATION = clsPhaparsection.SC_DENOMINATION;
			SC_ADRESSEPOSTALE = clsPhaparsection.SC_ADRESSEPOSTALE;
			SC_ADRESSEGEOGRAPHIQUE = clsPhaparsection.SC_ADRESSEGEOGRAPHIQUE;
			SC_TELEPHONE = clsPhaparsection.SC_TELEPHONE;
			SC_FAX = clsPhaparsection.SC_FAX;
			SC_SITEWEB = clsPhaparsection.SC_SITEWEB;
			SC_EMAIL = clsPhaparsection.SC_EMAIL;
			SC_GERANT = clsPhaparsection.SC_GERANT;



		}
        }
}