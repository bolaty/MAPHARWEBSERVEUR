using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCliadherantsassurance
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _TI_IDTIERSADHERANT = "";
		private string _AP_CODEPRODUIT = "";
		private DateTime _AS_DATESAISIE = DateTime.Parse("01/01/1900");
		private DateTime _AS_DATEADHESION = DateTime.Parse("01/01/1900");
		private DateTime _AS_DATERESILIATION = DateTime.Parse("01/01/1900");
		private double _AS_TAUX = 0;
		private double _AS_MONTANT = 0;
		private double _AS_PLAFOND = 0;
		private string _OP_CODEOPERATEUR = "";
		private string _AS_MATRICULE = "";
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string TI_IDTIERSADHERANT
		{
			get { return _TI_IDTIERSADHERANT; }
			set {  _TI_IDTIERSADHERANT = value; }
		}

		public string AP_CODEPRODUIT
		{
			get { return _AP_CODEPRODUIT; }
			set {  _AP_CODEPRODUIT = value; }
		}

		public DateTime AS_DATESAISIE
		{
			get { return _AS_DATESAISIE; }
			set {  _AS_DATESAISIE = value; }
		}

		public DateTime AS_DATEADHESION
		{
			get { return _AS_DATEADHESION; }
			set {  _AS_DATEADHESION = value; }
		}

		public DateTime AS_DATERESILIATION
		{
			get { return _AS_DATERESILIATION; }
			set {  _AS_DATERESILIATION = value; }
		}

		public double AS_TAUX
		{
			get { return _AS_TAUX; }
			set {  _AS_TAUX = value; }
		}

		public double AS_MONTANT
		{
			get { return _AS_MONTANT; }
			set {  _AS_MONTANT = value; }
		}

		public double AS_PLAFOND
		{
			get { return _AS_PLAFOND; }
			set {  _AS_PLAFOND = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}
        public string AS_MATRICULE
        {
	        get { return _AS_MATRICULE; }
	        set { _AS_MATRICULE = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCliadherantsassurance(){}

		public clsCliadherantsassurance(clsCliadherantsassurance clsCliadherantsassurance)
		{
			this.AG_CODEAGENCE = clsCliadherantsassurance.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCliadherantsassurance.EN_CODEENTREPOT;
			this.TI_IDTIERSADHERANT = clsCliadherantsassurance.TI_IDTIERSADHERANT;
			this.AP_CODEPRODUIT = clsCliadherantsassurance.AP_CODEPRODUIT;
			this.AS_DATESAISIE = clsCliadherantsassurance.AS_DATESAISIE;
			this.AS_DATEADHESION = clsCliadherantsassurance.AS_DATEADHESION;
			this.AS_DATERESILIATION = clsCliadherantsassurance.AS_DATERESILIATION;
			this.AS_TAUX = clsCliadherantsassurance.AS_TAUX;
			this.AS_MONTANT = clsCliadherantsassurance.AS_MONTANT;
			this.AS_PLAFOND = clsCliadherantsassurance.AS_PLAFOND;
			this.OP_CODEOPERATEUR = clsCliadherantsassurance.OP_CODEOPERATEUR;
			this.AS_MATRICULE = clsCliadherantsassurance.AS_MATRICULE;

		}

		#endregion

	}
}
