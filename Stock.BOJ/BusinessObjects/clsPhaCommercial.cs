using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhacommercial
	{

        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _CO_IDCOMMERCIAL = "";
		private string _SX_CODESEXE = "";
		private string _SM_CODESITUATIONMATRIMONIALE = "";
		private string _CO_NUMCOMMERCIAL = "";
		private DateTime _CO_DATENAISSANCE = DateTime.Parse("01/01/1900");
		private string _CO_NOMPRENOM = "";
		private string _CO_ADRESSEPOSTALE = "";
		private string _CO_ADRESSEGEOGRAPHIQUE = "";
		private string _CO_TELEPHONE = "";
		private string _CO_EMAIL = "";
		private string _CO_STATUT = "";
		private double _CO_TAUXCOMMISSION = 0;
		private double _CO_MONTANTCOMMISSION = 0;
		private DateTime _CO_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";
        private string _CO_MODECALCULECOMMISSION = "";


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
		public string CO_IDCOMMERCIAL
		{
			get { return _CO_IDCOMMERCIAL; }
			set { _CO_IDCOMMERCIAL = value; }
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
		public string CO_NUMCOMMERCIAL
		{
			get { return _CO_NUMCOMMERCIAL; }
			set { _CO_NUMCOMMERCIAL = value; }
		}
		public DateTime CO_DATENAISSANCE
		{
			get { return _CO_DATENAISSANCE; }
			set { _CO_DATENAISSANCE = value; }
		}
		public string CO_NOMPRENOM
		{
			get { return _CO_NOMPRENOM; }
			set { _CO_NOMPRENOM = value; }
		}
		public string CO_ADRESSEPOSTALE
		{
			get { return _CO_ADRESSEPOSTALE; }
			set { _CO_ADRESSEPOSTALE = value; }
		}
		public string CO_ADRESSEGEOGRAPHIQUE
		{
			get { return _CO_ADRESSEGEOGRAPHIQUE; }
			set { _CO_ADRESSEGEOGRAPHIQUE = value; }
		}
		public string CO_TELEPHONE
		{
			get { return _CO_TELEPHONE; }
			set { _CO_TELEPHONE = value; }
		}
		public string CO_EMAIL
		{
			get { return _CO_EMAIL; }
			set { _CO_EMAIL = value; }
		}
		public string CO_STATUT
		{
			get { return _CO_STATUT; }
			set { _CO_STATUT = value; }
		}
		public double CO_TAUXCOMMISSION
		{
			get { return _CO_TAUXCOMMISSION; }
			set { _CO_TAUXCOMMISSION = value; }
		}
		public double CO_MONTANTCOMMISSION
		{
			get { return _CO_MONTANTCOMMISSION; }
			set { _CO_MONTANTCOMMISSION = value; }
		}
		public DateTime CO_DATESAISIE
		{
			get { return _CO_DATESAISIE; }
			set { _CO_DATESAISIE = value; }
		}
		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
        public string CO_MODECALCULECOMMISSION
        {
            get { return _CO_MODECALCULECOMMISSION; }
            set { _CO_MODECALCULECOMMISSION = value; }
        }


        public clsPhacommercial() {}

        public clsPhacommercial(string AG_CODEAGENCE, string EN_CODEENTREPOT, string CO_IDCOMMERCIAL, string SX_CODESEXE, string SM_CODESITUATIONMATRIMONIALE, string CO_NUMCOMMERCIAL, DateTime CO_DATENAISSANCE, string CO_NOMPRENOM, string CO_ADRESSEPOSTALE, string CO_ADRESSEGEOGRAPHIQUE, string CO_TELEPHONE, string CO_EMAIL, string CO_STATUT, double CO_TAUXCOMMISSION, double CO_MONTANTCOMMISSION, DateTime CO_DATESAISIE, string OP_CODEOPERATEUR, string CO_MODECALCULECOMMISSION)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CO_IDCOMMERCIAL = CO_IDCOMMERCIAL;
			this.SX_CODESEXE = SX_CODESEXE;
			this.SM_CODESITUATIONMATRIMONIALE = SM_CODESITUATIONMATRIMONIALE;
			this.CO_NUMCOMMERCIAL = CO_NUMCOMMERCIAL;
			this.CO_DATENAISSANCE = CO_DATENAISSANCE;
			this.CO_NOMPRENOM = CO_NOMPRENOM;
			this.CO_ADRESSEPOSTALE = CO_ADRESSEPOSTALE;
			this.CO_ADRESSEGEOGRAPHIQUE = CO_ADRESSEGEOGRAPHIQUE;
			this.CO_TELEPHONE = CO_TELEPHONE;
			this.CO_EMAIL = CO_EMAIL;
			this.CO_STATUT = CO_STATUT;
			this.CO_TAUXCOMMISSION = CO_TAUXCOMMISSION;
			this.CO_MONTANTCOMMISSION = CO_MONTANTCOMMISSION;
			this.CO_DATESAISIE = CO_DATESAISIE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
            this.CO_MODECALCULECOMMISSION = CO_MODECALCULECOMMISSION;

		}

		public clsPhacommercial(clsPhacommercial clsPhacommercial)
		{
			AG_CODEAGENCE = clsPhacommercial.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsPhacommercial.EN_CODEENTREPOT;
			CO_IDCOMMERCIAL = clsPhacommercial.CO_IDCOMMERCIAL;
			SX_CODESEXE = clsPhacommercial.SX_CODESEXE;
			SM_CODESITUATIONMATRIMONIALE = clsPhacommercial.SM_CODESITUATIONMATRIMONIALE;
			CO_NUMCOMMERCIAL = clsPhacommercial.CO_NUMCOMMERCIAL;
			CO_DATENAISSANCE = clsPhacommercial.CO_DATENAISSANCE;
			CO_NOMPRENOM = clsPhacommercial.CO_NOMPRENOM;
			CO_ADRESSEPOSTALE = clsPhacommercial.CO_ADRESSEPOSTALE;
			CO_ADRESSEGEOGRAPHIQUE = clsPhacommercial.CO_ADRESSEGEOGRAPHIQUE;
			CO_TELEPHONE = clsPhacommercial.CO_TELEPHONE;
			CO_EMAIL = clsPhacommercial.CO_EMAIL;
			CO_STATUT = clsPhacommercial.CO_STATUT;
			CO_TAUXCOMMISSION = clsPhacommercial.CO_TAUXCOMMISSION;
			CO_MONTANTCOMMISSION = clsPhacommercial.CO_MONTANTCOMMISSION;
			CO_DATESAISIE = clsPhacommercial.CO_DATESAISIE;
			OP_CODEOPERATEUR = clsPhacommercial.OP_CODEOPERATEUR;
            CO_MODECALCULECOMMISSION = clsPhacommercial.CO_MODECALCULECOMMISSION;

		}
        }
}