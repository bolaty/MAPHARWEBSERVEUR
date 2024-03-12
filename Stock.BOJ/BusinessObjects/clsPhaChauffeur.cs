using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhachauffeur
	{

        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";

		private string _CH_IDCHAUFFEUR = "";
		private string _SX_CODESEXE = "";
		private string _SM_CODESITUATIONMATRIMONIALE = "";
		private string _CH_NUMCHAUFFEUR = "";
        private string _CH_NUMPERMIS = "";
		private DateTime _CH_DATENAISSANCE = DateTime.Parse("01/01/1900");
		private string _CH_NOMPRENOM = "";
		private string _CH_ADRESSEPOSTALE = "";
		private string _CH_ADRESSEGEOGRAPHIQUE = "";
		private string _CH_TELEPHONE = "";
		private string _CH_EMAIL = "";
		private string _CH_STATUT = "";
		private DateTime _CH_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";



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
		public string CH_IDCHAUFFEUR
		{
			get { return _CH_IDCHAUFFEUR; }
			set { _CH_IDCHAUFFEUR = value; }
		}
		public string SX_CODESEXE
		{
			get { return _SX_CODESEXE; }
			set { _SX_CODESEXE = value; }
		}
		public string SM_CODESITUATIONMATRIMONIALE
		{
			get { return _SM_CODESITUATIONMATRIMONIALE; }
			set { _SM_CODESITUATIONMATRIMONIALE = value; }
		}
		public string CH_NUMCHAUFFEUR
		{
			get { return _CH_NUMCHAUFFEUR; }
			set { _CH_NUMCHAUFFEUR = value; }
		}

        public string CH_NUMPERMIS
        {
            get { return _CH_NUMPERMIS; }
            set { _CH_NUMPERMIS = value; }
        }
		public DateTime CH_DATENAISSANCE
		{
			get { return _CH_DATENAISSANCE; }
			set { _CH_DATENAISSANCE = value; }
		}
		public string CH_NOMPRENOM
		{
			get { return _CH_NOMPRENOM; }
			set { _CH_NOMPRENOM = value; }
		}
		public string CH_ADRESSEPOSTALE
		{
			get { return _CH_ADRESSEPOSTALE; }
			set { _CH_ADRESSEPOSTALE = value; }
		}
		public string CH_ADRESSEGEOGRAPHIQUE
		{
			get { return _CH_ADRESSEGEOGRAPHIQUE; }
			set { _CH_ADRESSEGEOGRAPHIQUE = value; }
		}
		public string CH_TELEPHONE
		{
			get { return _CH_TELEPHONE; }
			set { _CH_TELEPHONE = value; }
		}
		public string CH_EMAIL
		{
			get { return _CH_EMAIL; }
			set { _CH_EMAIL = value; }
		}
		public string CH_STATUT
		{
			get { return _CH_STATUT; }
			set { _CH_STATUT = value; }
		}
		public DateTime CH_DATESAISIE
		{
			get { return _CH_DATESAISIE; }
			set { _CH_DATESAISIE = value; }
		}
		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}



        public clsPhachauffeur() {}

        public clsPhachauffeur(string AG_CODEAGENCE, string EN_CODEENTREPOT, string CH_IDCHAUFFEUR, string SX_CODESEXE, string SM_CODESITUATIONMATRIMONIALE, string CH_NUMCHAUFFEUR, string CH_NUMPERMIS, DateTime CH_DATENAISSANCE, string CH_NOMPRENOM, string CH_ADRESSEPOSTALE, string CH_ADRESSEGEOGRAPHIQUE, string CH_TELEPHONE, string CH_EMAIL, string CH_STATUT, DateTime CH_DATESAISIE, string OP_CODEOPERATEUR)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.EN_CODEENTREPOT = EN_CODEENTREPOT;
			this.CH_IDCHAUFFEUR = CH_IDCHAUFFEUR;
			this.SX_CODESEXE = SX_CODESEXE;
			this.SM_CODESITUATIONMATRIMONIALE = SM_CODESITUATIONMATRIMONIALE;
			this.CH_NUMCHAUFFEUR = CH_NUMCHAUFFEUR;
            this.CH_NUMPERMIS = CH_NUMPERMIS;
			this.CH_DATENAISSANCE = CH_DATENAISSANCE;
			this.CH_NOMPRENOM = CH_NOMPRENOM;
			this.CH_ADRESSEPOSTALE = CH_ADRESSEPOSTALE;
			this.CH_ADRESSEGEOGRAPHIQUE = CH_ADRESSEGEOGRAPHIQUE;
			this.CH_TELEPHONE = CH_TELEPHONE;
			this.CH_EMAIL = CH_EMAIL;
			this.CH_STATUT = CH_STATUT;
			this.CH_DATESAISIE = CH_DATESAISIE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}

		public clsPhachauffeur(clsPhachauffeur clsPhachauffeur)
		{
			AG_CODEAGENCE = clsPhachauffeur.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsPhachauffeur.EN_CODEENTREPOT;
			CH_IDCHAUFFEUR = clsPhachauffeur.CH_IDCHAUFFEUR;
			SX_CODESEXE = clsPhachauffeur.SX_CODESEXE;
			SM_CODESITUATIONMATRIMONIALE = clsPhachauffeur.SM_CODESITUATIONMATRIMONIALE;
			CH_NUMCHAUFFEUR = clsPhachauffeur.CH_NUMCHAUFFEUR;
            CH_NUMPERMIS = clsPhachauffeur.CH_NUMPERMIS;
			CH_DATENAISSANCE = clsPhachauffeur.CH_DATENAISSANCE;
			CH_NOMPRENOM = clsPhachauffeur.CH_NOMPRENOM;
			CH_ADRESSEPOSTALE = clsPhachauffeur.CH_ADRESSEPOSTALE;
			CH_ADRESSEGEOGRAPHIQUE = clsPhachauffeur.CH_ADRESSEGEOGRAPHIQUE;
			CH_TELEPHONE = clsPhachauffeur.CH_TELEPHONE;
			CH_EMAIL = clsPhachauffeur.CH_EMAIL;
			CH_STATUT = clsPhachauffeur.CH_STATUT;
			CH_DATESAISIE = clsPhachauffeur.CH_DATESAISIE;
			OP_CODEOPERATEUR = clsPhachauffeur.OP_CODEOPERATEUR;
		}
        }
}