using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPh_fournisseurbon
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _FB_IDFOURNISSEUR = "";
		private string _SX_CODESEXE = "";
		private string _SM_CODESITUATIONMATRIMONIALE = "";
		private string _OP_CODEOPERATEUR = "";
		private string _FB_NUMFOURNISSEUR = "";
		private DateTime _FB_DATENAISSANCE = DateTime.Parse("01/01/1900");
		private string _FB_NOMPRENOM = "";
		private string _FB_ADRESSEPOSTALE = "";
		private string _FB_ADRESSEGEOGRAPHIQUE = "";
		private string _FB_TELEPHONE = "";
		private string _FB_EMAIL = "";
		private string _FB_STATUT = "";
		private DateTime _FB_DATESAISIE = DateTime.Parse("01/01/1900");

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string FB_IDFOURNISSEUR
		{
			get { return _FB_IDFOURNISSEUR; }
			set {  _FB_IDFOURNISSEUR = value; }
		}

		public string SX_CODESEXE
		{
			get { return _SX_CODESEXE; }
			set {  _SX_CODESEXE = value; }
		}

		public string SM_CODESITUATIONMATRIMONIALE
		{
			get { return _SM_CODESITUATIONMATRIMONIALE; }
			set {  _SM_CODESITUATIONMATRIMONIALE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string FB_NUMFOURNISSEUR
		{
			get { return _FB_NUMFOURNISSEUR; }
			set {  _FB_NUMFOURNISSEUR = value; }
		}

		public DateTime FB_DATENAISSANCE
		{
			get { return _FB_DATENAISSANCE; }
			set {  _FB_DATENAISSANCE = value; }
		}

		public string FB_NOMPRENOM
		{
			get { return _FB_NOMPRENOM; }
			set {  _FB_NOMPRENOM = value; }
		}

		public string FB_ADRESSEPOSTALE
		{
			get { return _FB_ADRESSEPOSTALE; }
			set {  _FB_ADRESSEPOSTALE = value; }
		}

		public string FB_ADRESSEGEOGRAPHIQUE
		{
			get { return _FB_ADRESSEGEOGRAPHIQUE; }
			set {  _FB_ADRESSEGEOGRAPHIQUE = value; }
		}

		public string FB_TELEPHONE
		{
			get { return _FB_TELEPHONE; }
			set {  _FB_TELEPHONE = value; }
		}

		public string FB_EMAIL
		{
			get { return _FB_EMAIL; }
			set {  _FB_EMAIL = value; }
		}

		public string FB_STATUT
		{
			get { return _FB_STATUT; }
			set {  _FB_STATUT = value; }
		}

		public DateTime FB_DATESAISIE
		{
			get { return _FB_DATESAISIE; }
			set {  _FB_DATESAISIE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPh_fournisseurbon(){}
		public clsPh_fournisseurbon( string AG_CODEAGENCE,string FB_IDFOURNISSEUR,string SX_CODESEXE,string SM_CODESITUATIONMATRIMONIALE,string OP_CODEOPERATEUR,string FB_NUMFOURNISSEUR,DateTime FB_DATENAISSANCE,string FB_NOMPRENOM,string FB_ADRESSEPOSTALE,string FB_ADRESSEGEOGRAPHIQUE,string FB_TELEPHONE,string FB_EMAIL,string FB_STATUT,DateTime FB_DATESAISIE)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.FB_IDFOURNISSEUR = FB_IDFOURNISSEUR;
			this.SX_CODESEXE = SX_CODESEXE;
			this.SM_CODESITUATIONMATRIMONIALE = SM_CODESITUATIONMATRIMONIALE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.FB_NUMFOURNISSEUR = FB_NUMFOURNISSEUR;
			this.FB_DATENAISSANCE = FB_DATENAISSANCE;
			this.FB_NOMPRENOM = FB_NOMPRENOM;
			this.FB_ADRESSEPOSTALE = FB_ADRESSEPOSTALE;
			this.FB_ADRESSEGEOGRAPHIQUE = FB_ADRESSEGEOGRAPHIQUE;
			this.FB_TELEPHONE = FB_TELEPHONE;
			this.FB_EMAIL = FB_EMAIL;
			this.FB_STATUT = FB_STATUT;
			this.FB_DATESAISIE = FB_DATESAISIE;
		}
		public clsPh_fournisseurbon(clsPh_fournisseurbon clsPh_fournisseurbon)
		{
			this.AG_CODEAGENCE = clsPh_fournisseurbon.AG_CODEAGENCE;
			this.FB_IDFOURNISSEUR = clsPh_fournisseurbon.FB_IDFOURNISSEUR;
			this.SX_CODESEXE = clsPh_fournisseurbon.SX_CODESEXE;
			this.SM_CODESITUATIONMATRIMONIALE = clsPh_fournisseurbon.SM_CODESITUATIONMATRIMONIALE;
			this.OP_CODEOPERATEUR = clsPh_fournisseurbon.OP_CODEOPERATEUR;
			this.FB_NUMFOURNISSEUR = clsPh_fournisseurbon.FB_NUMFOURNISSEUR;
			this.FB_DATENAISSANCE = clsPh_fournisseurbon.FB_DATENAISSANCE;
			this.FB_NOMPRENOM = clsPh_fournisseurbon.FB_NOMPRENOM;
			this.FB_ADRESSEPOSTALE = clsPh_fournisseurbon.FB_ADRESSEPOSTALE;
			this.FB_ADRESSEGEOGRAPHIQUE = clsPh_fournisseurbon.FB_ADRESSEGEOGRAPHIQUE;
			this.FB_TELEPHONE = clsPh_fournisseurbon.FB_TELEPHONE;
			this.FB_EMAIL = clsPh_fournisseurbon.FB_EMAIL;
			this.FB_STATUT = clsPh_fournisseurbon.FB_STATUT;
			this.FB_DATESAISIE = clsPh_fournisseurbon.FB_DATESAISIE;
		}

		#endregion

	}
}
