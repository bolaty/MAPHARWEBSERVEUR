using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaTransporteur
	{

        private string _AG_CODEAGENCE = "";
		private string _TR_IDTRANSPORTEUR = "";
		private string _SX_CODESEXE = "";
		private string _SM_CODESITUATIONMATRIMONIALE = "";
		private string _TR_NUMTRANSPORTEUR = "";
		private DateTime _TR_DATENAISSANCE = DateTime.Parse("01/01/1900");
		private string _TR_NOMPRENOM = "";
		private string _TR_ADRESSEPOSTALE = "";
		private string _TR_ADRESSEGEOGRAPHIQUE = "";
		private string _TR_TELEPHONE = "";
		private string _TR_EMAIL = "";
		private string _TR_STATUT = "";
		private DateTime _TR_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";



        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string TR_IDTRANSPORTEUR
		{
			get { return _TR_IDTRANSPORTEUR; }
			set { _TR_IDTRANSPORTEUR = value; }
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
		public string TR_NUMTRANSPORTEUR
		{
			get { return _TR_NUMTRANSPORTEUR; }
			set { _TR_NUMTRANSPORTEUR = value; }
		}
		public DateTime TR_DATENAISSANCE
		{
			get { return _TR_DATENAISSANCE; }
			set { _TR_DATENAISSANCE = value; }
		}
		public string TR_NOMPRENOM
		{
			get { return _TR_NOMPRENOM; }
			set { _TR_NOMPRENOM = value; }
		}
		public string TR_ADRESSEPOSTALE
		{
			get { return _TR_ADRESSEPOSTALE; }
			set { _TR_ADRESSEPOSTALE = value; }
		}
		public string TR_ADRESSEGEOGRAPHIQUE
		{
			get { return _TR_ADRESSEGEOGRAPHIQUE; }
			set { _TR_ADRESSEGEOGRAPHIQUE = value; }
		}
		public string TR_TELEPHONE
		{
			get { return _TR_TELEPHONE; }
			set { _TR_TELEPHONE = value; }
		}
		public string TR_EMAIL
		{
			get { return _TR_EMAIL; }
			set { _TR_EMAIL = value; }
		}
		public string TR_STATUT
		{
			get { return _TR_STATUT; }
			set { _TR_STATUT = value; }
		}
		public DateTime TR_DATESAISIE
		{
			get { return _TR_DATESAISIE; }
			set { _TR_DATESAISIE = value; }
		}
		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}



        public clsPhaTransporteur() {} 

		public clsPhaTransporteur(string AG_CODEAGENCE,string TR_IDTRANSPORTEUR,string SX_CODESEXE,string SM_CODESITUATIONMATRIMONIALE,string TR_NUMTRANSPORTEUR,DateTime TR_DATENAISSANCE,string TR_NOMPRENOM,string TR_ADRESSEPOSTALE,string TR_ADRESSEGEOGRAPHIQUE,string TR_TELEPHONE,string TR_EMAIL,string TR_STATUT,DateTime TR_DATESAISIE,string OP_CODEOPERATEUR)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.TR_IDTRANSPORTEUR = TR_IDTRANSPORTEUR;
			this.SX_CODESEXE = SX_CODESEXE;
			this.SM_CODESITUATIONMATRIMONIALE = SM_CODESITUATIONMATRIMONIALE;
			this.TR_NUMTRANSPORTEUR = TR_NUMTRANSPORTEUR;
			this.TR_DATENAISSANCE = TR_DATENAISSANCE;
			this.TR_NOMPRENOM = TR_NOMPRENOM;
			this.TR_ADRESSEPOSTALE = TR_ADRESSEPOSTALE;
			this.TR_ADRESSEGEOGRAPHIQUE = TR_ADRESSEGEOGRAPHIQUE;
			this.TR_TELEPHONE = TR_TELEPHONE;
			this.TR_EMAIL = TR_EMAIL;
			this.TR_STATUT = TR_STATUT;
			this.TR_DATESAISIE = TR_DATESAISIE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}

		public clsPhaTransporteur(clsPhaTransporteur clsPhaTransporteur)
		{
			AG_CODEAGENCE = clsPhaTransporteur.AG_CODEAGENCE;
			TR_IDTRANSPORTEUR = clsPhaTransporteur.TR_IDTRANSPORTEUR;
			SX_CODESEXE = clsPhaTransporteur.SX_CODESEXE;
			SM_CODESITUATIONMATRIMONIALE = clsPhaTransporteur.SM_CODESITUATIONMATRIMONIALE;
			TR_NUMTRANSPORTEUR = clsPhaTransporteur.TR_NUMTRANSPORTEUR;
			TR_DATENAISSANCE = clsPhaTransporteur.TR_DATENAISSANCE;
			TR_NOMPRENOM = clsPhaTransporteur.TR_NOMPRENOM;
			TR_ADRESSEPOSTALE = clsPhaTransporteur.TR_ADRESSEPOSTALE;
			TR_ADRESSEGEOGRAPHIQUE = clsPhaTransporteur.TR_ADRESSEGEOGRAPHIQUE;
			TR_TELEPHONE = clsPhaTransporteur.TR_TELEPHONE;
			TR_EMAIL = clsPhaTransporteur.TR_EMAIL;
			TR_STATUT = clsPhaTransporteur.TR_STATUT;
			TR_DATESAISIE = clsPhaTransporteur.TR_DATESAISIE;
			OP_CODEOPERATEUR = clsPhaTransporteur.OP_CODEOPERATEUR;
		}
        }
}