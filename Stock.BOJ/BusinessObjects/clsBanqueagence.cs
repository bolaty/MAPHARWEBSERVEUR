using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsBanqueagence
	{

        private int _AB_CODEAGENCEBANCAIRE = 0;
		private int _BQ_CODEBANQUE = 0;
		private string _AB_LIBELLE = "";
		private string _AB_ADRESSEGEOGRAPHIQUE = "";
		private string _AB_BOITEPOSTALE = "";
		private string _AB_TELEPHONE = "";
		private string _AB_FAX = "";
		private string _AB_EMAIL = "";
        private string _BQ_ABREGE = "";
        private string _BQ_CODEBIC = "";
        private string _BQ_SITEWEB = "";
        private string _BQ_AUTREINFOS = "";
        private string _CO_CODECOMMUNE = "";




        public int AB_CODEAGENCEBANCAIRE
		{
			get { return _AB_CODEAGENCEBANCAIRE; }
			set { _AB_CODEAGENCEBANCAIRE = value; }
		}
		public int BQ_CODEBANQUE
		{
			get { return _BQ_CODEBANQUE; }
			set { _BQ_CODEBANQUE = value; }
		}
		public string AB_LIBELLE
		{
			get { return _AB_LIBELLE; }
			set { _AB_LIBELLE = value; }
		}
		public string AB_ADRESSEGEOGRAPHIQUE
		{
			get { return _AB_ADRESSEGEOGRAPHIQUE; }
			set { _AB_ADRESSEGEOGRAPHIQUE = value; }
		}
		public string AB_BOITEPOSTALE
		{
			get { return _AB_BOITEPOSTALE; }
			set { _AB_BOITEPOSTALE = value; }
		}
		public string AB_TELEPHONE
		{
			get { return _AB_TELEPHONE; }
			set { _AB_TELEPHONE = value; }
		}
		public string AB_FAX
		{
			get { return _AB_FAX; }
			set { _AB_FAX = value; }
		}
		public string AB_EMAIL
		{
			get { return _AB_EMAIL; }
			set { _AB_EMAIL = value; }
		}

        public string BQ_ABREGE
        {
            get { return _BQ_ABREGE; }
            set { _BQ_ABREGE = value; }
        }

        public string BQ_CODEBIC
        {
            get { return _BQ_CODEBIC; }
            set { _BQ_CODEBIC = value; }
        }

        public string BQ_SITEWEB
        {
            get { return _BQ_SITEWEB; }
            set { _BQ_SITEWEB = value; }
        }

        public string BQ_AUTREINFOS
        {
            get { return _BQ_AUTREINFOS; }
            set { _BQ_AUTREINFOS = value; }
        }

        public string CO_CODECOMMUNE
        {
            get { return _CO_CODECOMMUNE; }
            set { _CO_CODECOMMUNE = value; }
        }
    




        public clsBanqueagence() {} 

		public clsBanqueagence(int AB_CODEAGENCEBANCAIRE,int BQ_CODEBANQUE,string AB_LIBELLE,string AB_ADRESSEGEOGRAPHIQUE,string AB_BOITEPOSTALE,string AB_TELEPHONE,string AB_FAX,string AB_EMAIL)
		{
			this.AB_CODEAGENCEBANCAIRE = AB_CODEAGENCEBANCAIRE;
			this.BQ_CODEBANQUE = BQ_CODEBANQUE;
			this.AB_LIBELLE = AB_LIBELLE;
			this.AB_ADRESSEGEOGRAPHIQUE = AB_ADRESSEGEOGRAPHIQUE;
			this.AB_BOITEPOSTALE = AB_BOITEPOSTALE;
			this.AB_TELEPHONE = AB_TELEPHONE;
			this.AB_FAX = AB_FAX;
			this.AB_EMAIL = AB_EMAIL;

            this.BQ_ABREGE = BQ_ABREGE;
            this.BQ_CODEBIC = BQ_CODEBIC;
            this.BQ_SITEWEB = BQ_SITEWEB;
            this.BQ_AUTREINFOS = BQ_AUTREINFOS;
            this.CO_CODECOMMUNE = CO_CODECOMMUNE;
		}

		public clsBanqueagence(clsBanqueagence clsBanqueagence)
		{
			AB_CODEAGENCEBANCAIRE = clsBanqueagence.AB_CODEAGENCEBANCAIRE;
			BQ_CODEBANQUE = clsBanqueagence.BQ_CODEBANQUE;
			AB_LIBELLE = clsBanqueagence.AB_LIBELLE;
			AB_ADRESSEGEOGRAPHIQUE = clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE;
			AB_BOITEPOSTALE = clsBanqueagence.AB_BOITEPOSTALE;
			AB_TELEPHONE = clsBanqueagence.AB_TELEPHONE;
			AB_FAX = clsBanqueagence.AB_FAX;
			AB_EMAIL = clsBanqueagence.AB_EMAIL;

            BQ_ABREGE = clsBanqueagence.BQ_ABREGE;
            BQ_CODEBIC = clsBanqueagence.BQ_CODEBIC;
            BQ_SITEWEB = clsBanqueagence.BQ_SITEWEB;
            BQ_AUTREINFOS = clsBanqueagence.BQ_AUTREINFOS;
            CO_CODECOMMUNE = clsBanqueagence.CO_CODECOMMUNE;
            
		}
        }
}