using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaplantation
	{
		#region VARIABLES LOCALES

		private string _TI_IDTIERS = "";
		private int _AG_CODEAGENCE = 0;
		private string _OP_CODEOPERATEUR = "";
		private string _ZN_CODEZONE = "";
		private string _PL_IDPLANTATION = "";
		private string _PL_CODEPLANTATION = "";
		private string _QU_CODEQUARTIER = "";
		private string _AR_CODEARTICLE = "";
		private decimal _PL_SUPERFICIE = 0;
		private decimal _PL_DISTANCEALUSINE = 0;
		private string _PL_SECURISATIONFONCIERE = "";
		private string _PL_ASSURANCE = "";
		private decimal _PL_LONGITUDE = 0;
		private decimal _PL_LATITUDE = 0;
		private string _PL_ADRESSEGEOGRAPHIQUE = "";
		private DateTime _PL_DATESAISIE = DateTime.Parse("01/01/1900");
		private DateTime _PL_DATECREATION = DateTime.Parse("01/01/1900");
        private byte[] _PL_PHOTO = null;

        #endregion

        #region ACCESSEURS

        public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public int AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string ZN_CODEZONE
		{
			get { return _ZN_CODEZONE; }
			set {  _ZN_CODEZONE = value; }
		}

		public string PL_IDPLANTATION
		{
			get { return _PL_IDPLANTATION; }
			set {  _PL_IDPLANTATION = value; }
		}

		public string PL_CODEPLANTATION
		{
			get { return _PL_CODEPLANTATION; }
			set {  _PL_CODEPLANTATION = value; }
		}

		public string QU_CODEQUARTIER
		{
			get { return _QU_CODEQUARTIER; }
			set {  _QU_CODEQUARTIER = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public decimal PL_SUPERFICIE
		{
			get { return _PL_SUPERFICIE; }
			set {  _PL_SUPERFICIE = value; }
		}

		public decimal PL_DISTANCEALUSINE
		{
			get { return _PL_DISTANCEALUSINE; }
			set {  _PL_DISTANCEALUSINE = value; }
		}

		public string PL_SECURISATIONFONCIERE
		{
			get { return _PL_SECURISATIONFONCIERE; }
			set {  _PL_SECURISATIONFONCIERE = value; }
		}

		public string PL_ASSURANCE
		{
			get { return _PL_ASSURANCE; }
			set {  _PL_ASSURANCE = value; }
		}

		public decimal PL_LONGITUDE
		{
			get { return _PL_LONGITUDE; }
			set {  _PL_LONGITUDE = value; }
		}

		public decimal PL_LATITUDE
		{
			get { return _PL_LATITUDE; }
			set {  _PL_LATITUDE = value; }
		}

		public string PL_ADRESSEGEOGRAPHIQUE
		{
			get { return _PL_ADRESSEGEOGRAPHIQUE; }
			set {  _PL_ADRESSEGEOGRAPHIQUE = value; }
		}

		public DateTime PL_DATESAISIE
		{
			get { return _PL_DATESAISIE; }
			set {  _PL_DATESAISIE = value; }
		}

		public DateTime PL_DATECREATION
		{
			get { return _PL_DATECREATION; }
			set {  _PL_DATECREATION = value; }
		}


        public byte[] PL_PHOTO
        {
            get { return _PL_PHOTO; }
            set { _PL_PHOTO = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsPhaplantation(){}
		public clsPhaplantation( string TI_IDTIERS,int AG_CODEAGENCE,string OP_CODEOPERATEUR,string ZN_CODEZONE,string PL_IDPLANTATION,string PL_CODEPLANTATION,string QU_CODEQUARTIER,string AR_CODEARTICLE,decimal PL_SUPERFICIE,decimal PL_DISTANCEALUSINE,string PL_SECURISATIONFONCIERE,string PL_ASSURANCE,decimal PL_LONGITUDE,decimal PL_LATITUDE,string PL_ADRESSEGEOGRAPHIQUE,DateTime PL_DATESAISIE,DateTime PL_DATECREATION)
		{
			this.TI_IDTIERS = TI_IDTIERS;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.ZN_CODEZONE = ZN_CODEZONE;
			this.PL_IDPLANTATION = PL_IDPLANTATION;
			this.PL_CODEPLANTATION = PL_CODEPLANTATION;
			this.QU_CODEQUARTIER = QU_CODEQUARTIER;
			this.AR_CODEARTICLE = AR_CODEARTICLE;
			this.PL_SUPERFICIE = PL_SUPERFICIE;
			this.PL_DISTANCEALUSINE = PL_DISTANCEALUSINE;
			this.PL_SECURISATIONFONCIERE = PL_SECURISATIONFONCIERE;
			this.PL_ASSURANCE = PL_ASSURANCE;
			this.PL_LONGITUDE = PL_LONGITUDE;
			this.PL_LATITUDE = PL_LATITUDE;
			this.PL_ADRESSEGEOGRAPHIQUE = PL_ADRESSEGEOGRAPHIQUE;
			this.PL_DATESAISIE = PL_DATESAISIE;
			this.PL_DATECREATION = PL_DATECREATION;
		}
		public clsPhaplantation(clsPhaplantation clsPhaplantation)
		{
			this.TI_IDTIERS = clsPhaplantation.TI_IDTIERS;
			this.AG_CODEAGENCE = clsPhaplantation.AG_CODEAGENCE;
			this.OP_CODEOPERATEUR = clsPhaplantation.OP_CODEOPERATEUR;
			this.ZN_CODEZONE = clsPhaplantation.ZN_CODEZONE;
			this.PL_IDPLANTATION = clsPhaplantation.PL_IDPLANTATION;
			this.PL_CODEPLANTATION = clsPhaplantation.PL_CODEPLANTATION;
			this.QU_CODEQUARTIER = clsPhaplantation.QU_CODEQUARTIER;
			this.AR_CODEARTICLE = clsPhaplantation.AR_CODEARTICLE;
			this.PL_SUPERFICIE = clsPhaplantation.PL_SUPERFICIE;
			this.PL_DISTANCEALUSINE = clsPhaplantation.PL_DISTANCEALUSINE;
			this.PL_SECURISATIONFONCIERE = clsPhaplantation.PL_SECURISATIONFONCIERE;
			this.PL_ASSURANCE = clsPhaplantation.PL_ASSURANCE;
			this.PL_LONGITUDE = clsPhaplantation.PL_LONGITUDE;
			this.PL_LATITUDE = clsPhaplantation.PL_LATITUDE;
			this.PL_ADRESSEGEOGRAPHIQUE = clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE;
			this.PL_DATESAISIE = clsPhaplantation.PL_DATESAISIE;
			this.PL_DATECREATION = clsPhaplantation.PL_DATECREATION;
            this.PL_PHOTO = clsPhaplantation.PL_PHOTO;
        }

		#endregion

	}
}
