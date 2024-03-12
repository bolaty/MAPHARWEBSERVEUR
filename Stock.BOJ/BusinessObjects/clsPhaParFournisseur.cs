using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparfournisseur
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _FR_CODEFOURNISSEUR = "";
		private string _FR_DENOMINATION = "";
		private string _FR_SIEGE = "";
		private string _FR_ADRESSEPOSTALE = "";
		private string _FR_ADRESSEGEOGRAPHIQUE = "";
		private string _FR_TELEPHONE = "";
		private string _FR_SITEWEB = "";
		private string _FR_EMAIL = "";
		private string _FR_GERANT = "";
		private string _FR_STATUT = "";
		private string _FR_MATRICULE = "";
        private string _TF_CODETYPEFOURNISSEUR = "";
        private string _PL_NUMCOMPTE = "";
		#endregion

		#region ACCESSEURS
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

		public string FR_CODEFOURNISSEUR
		{
			get { return _FR_CODEFOURNISSEUR; }
			set {  _FR_CODEFOURNISSEUR = value; }
		}

		public string FR_DENOMINATION
		{
			get { return _FR_DENOMINATION; }
			set {  _FR_DENOMINATION = value; }
		}

		public string FR_SIEGE
		{
			get { return _FR_SIEGE; }
			set {  _FR_SIEGE = value; }
		}

		public string FR_ADRESSEPOSTALE
		{
			get { return _FR_ADRESSEPOSTALE; }
			set {  _FR_ADRESSEPOSTALE = value; }
		}

		public string FR_ADRESSEGEOGRAPHIQUE
		{
			get { return _FR_ADRESSEGEOGRAPHIQUE; }
			set {  _FR_ADRESSEGEOGRAPHIQUE = value; }
		}

		public string FR_TELEPHONE
		{
			get { return _FR_TELEPHONE; }
			set {  _FR_TELEPHONE = value; }
		}

		public string FR_SITEWEB
		{
			get { return _FR_SITEWEB; }
			set {  _FR_SITEWEB = value; }
		}

		public string FR_EMAIL
		{
			get { return _FR_EMAIL; }
			set {  _FR_EMAIL = value; }
		}

		public string FR_GERANT
		{
			get { return _FR_GERANT; }
			set {  _FR_GERANT = value; }
		}

		public string FR_STATUT
		{
			get { return _FR_STATUT; }
			set {  _FR_STATUT = value; }
		}

		public string FR_MATRICULE
		{
			get { return _FR_MATRICULE; }
			set {  _FR_MATRICULE = value; }
		}

        public string TF_CODETYPEFOURNISSEUR
		{
            get { return _TF_CODETYPEFOURNISSEUR; }
            set { _TF_CODETYPEFOURNISSEUR = value; }
		}
        public string PL_NUMCOMPTE
		{
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
		}
		#endregion

		#region INSTANCIATEURS

		public clsPhaparfournisseur(){}
        public clsPhaparfournisseur(string AG_CODEAGENCE, string FR_CODEFOURNISSEUR, string FR_DENOMINATION, string FR_SIEGE, string FR_ADRESSEPOSTALE, string FR_ADRESSEGEOGRAPHIQUE, string FR_TELEPHONE, string FR_SITEWEB, string FR_EMAIL, string FR_GERANT, string FR_STATUT, string FR_MATRICULE, string TF_CODETYPEFOURNISSEUR, string PL_NUMCOMPTE)
		{
            this.AG_CODEAGENCE = AG_CODEAGENCE; 
			this.FR_CODEFOURNISSEUR = FR_CODEFOURNISSEUR;
			this.FR_DENOMINATION = FR_DENOMINATION;
			this.FR_SIEGE = FR_SIEGE;
			this.FR_ADRESSEPOSTALE = FR_ADRESSEPOSTALE;
			this.FR_ADRESSEGEOGRAPHIQUE = FR_ADRESSEGEOGRAPHIQUE;
			this.FR_TELEPHONE = FR_TELEPHONE;
			this.FR_SITEWEB = FR_SITEWEB;
			this.FR_EMAIL = FR_EMAIL;
			this.FR_GERANT = FR_GERANT;
			this.FR_STATUT = FR_STATUT;
			this.FR_MATRICULE = FR_MATRICULE;
            this.TF_CODETYPEFOURNISSEUR = TF_CODETYPEFOURNISSEUR;
            this.PL_NUMCOMPTE = PL_NUMCOMPTE;

		}
		public clsPhaparfournisseur(clsPhaparfournisseur clsPhaparfournisseur)
		{
            this.AG_CODEAGENCE = clsPhaparfournisseur.AG_CODEAGENCE;
			this.FR_CODEFOURNISSEUR = clsPhaparfournisseur.FR_CODEFOURNISSEUR;
			this.FR_DENOMINATION = clsPhaparfournisseur.FR_DENOMINATION;
			this.FR_SIEGE = clsPhaparfournisseur.FR_SIEGE;
			this.FR_ADRESSEPOSTALE = clsPhaparfournisseur.FR_ADRESSEPOSTALE;
			this.FR_ADRESSEGEOGRAPHIQUE = clsPhaparfournisseur.FR_ADRESSEGEOGRAPHIQUE;
			this.FR_TELEPHONE = clsPhaparfournisseur.FR_TELEPHONE;
			this.FR_SITEWEB = clsPhaparfournisseur.FR_SITEWEB;
			this.FR_EMAIL = clsPhaparfournisseur.FR_EMAIL;
			this.FR_GERANT = clsPhaparfournisseur.FR_GERANT;
			this.FR_STATUT = clsPhaparfournisseur.FR_STATUT;
			this.FR_MATRICULE = clsPhaparfournisseur.FR_MATRICULE;
            this.TF_CODETYPEFOURNISSEUR = clsPhaparfournisseur.TF_CODETYPEFOURNISSEUR;
            this.PL_NUMCOMPTE = clsPhaparfournisseur.PL_NUMCOMPTE;

		}

		#endregion

	}
}
