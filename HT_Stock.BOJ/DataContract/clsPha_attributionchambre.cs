using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPha_attributionchambre
	{
		#region VARIABLES LOCALES
        private string _MS_NUMPIECE = "";
        private string _AG_CODEAGENCE = "";
		private string _TI_IDATTRIBUTION = "";
		private DateTime _AT_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _TI_IDTIERS = "";
		private string _AR_CODEARTICLE = "";
		private string _PI_CODEPIECE = "";
		private string _PY_CODEPAYS = "";
		private string _AT_NUMPIECE = "";
		private DateTime _AT_DATEETABLISSEMENTPIECE = DateTime.Parse("01/01/1900");
		private string _AT_LIEUETABLISSEMENTPIECE = "";
		private string _AT_EMETTEURPIECE = "";
		private DateTime _AT_DATEENTREENATIONALE = DateTime.Parse("01/01/1900");
		private DateTime _AT_DATEDEPARTNATIONALE = DateTime.Parse("01/01/1900");
		private DateTime _AT_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _AT_DATEFIN = DateTime.Parse("01/01/1900");
		private DateTime _AT_DATECLOTURE = DateTime.Parse("01/01/1900");
        private DateTime _AT_DATEFINEFFECTIVE = DateTime.Parse("01/01/1900");
        private string _ECRANAPPELANT = "";
        private int _TYPEOPERATION = 0;
        private string _OP_CODEOPERATEUR = "";
		#endregion

		#region ACCESSEURS
        public string MS_NUMPIECE
        {
            get { return _MS_NUMPIECE; }
            set { _MS_NUMPIECE = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
		public string TI_IDATTRIBUTION
		{
			get { return _TI_IDATTRIBUTION; }
			set {  _TI_IDATTRIBUTION = value; }
		}

		public DateTime AT_DATESAISIE
		{
			get { return _AT_DATESAISIE; }
			set {  _AT_DATESAISIE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string PI_CODEPIECE
		{
			get { return _PI_CODEPIECE; }
			set {  _PI_CODEPIECE = value; }
		}

		public string PY_CODEPAYS
		{
			get { return _PY_CODEPAYS; }
			set {  _PY_CODEPAYS = value; }
		}

		public string AT_NUMPIECE
		{
			get { return _AT_NUMPIECE; }
			set {  _AT_NUMPIECE = value; }
		}

		public DateTime AT_DATEETABLISSEMENTPIECE
		{
			get { return _AT_DATEETABLISSEMENTPIECE; }
			set {  _AT_DATEETABLISSEMENTPIECE = value; }
		}

		public string AT_LIEUETABLISSEMENTPIECE
		{
			get { return _AT_LIEUETABLISSEMENTPIECE; }
			set {  _AT_LIEUETABLISSEMENTPIECE = value; }
		}

		public string AT_EMETTEURPIECE
		{
			get { return _AT_EMETTEURPIECE; }
			set {  _AT_EMETTEURPIECE = value; }
		}

		public DateTime AT_DATEENTREENATIONALE
		{
			get { return _AT_DATEENTREENATIONALE; }
			set {  _AT_DATEENTREENATIONALE = value; }
		}

		public DateTime AT_DATEDEPARTNATIONALE
		{
			get { return _AT_DATEDEPARTNATIONALE; }
			set {  _AT_DATEDEPARTNATIONALE = value; }
		}

		public DateTime AT_DATEDEBUT
		{
			get { return _AT_DATEDEBUT; }
			set {  _AT_DATEDEBUT = value; }
		}

		public DateTime AT_DATEFIN
		{
			get { return _AT_DATEFIN; }
			set {  _AT_DATEFIN = value; }
		}

		public DateTime AT_DATECLOTURE
		{
			get { return _AT_DATECLOTURE; }
			set {  _AT_DATECLOTURE = value; }
		}
        public DateTime AT_DATEFINEFFECTIVE
        {
            get { return _AT_DATEFINEFFECTIVE; }
            set { _AT_DATEFINEFFECTIVE = value; }
        }
        public string ECRANAPPELANT
		{
            get { return _ECRANAPPELANT; }
            set { _ECRANAPPELANT = value; }
		}
        public int TYPEOPERATION
		{
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
		}
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPha_attributionchambre(){}
		
		public clsPha_attributionchambre(clsPha_attributionchambre clsPha_attributionchambre)
		{

            this.MS_NUMPIECE = clsPha_attributionchambre.MS_NUMPIECE;
            this.AG_CODEAGENCE = clsPha_attributionchambre.AG_CODEAGENCE;
			this.TI_IDATTRIBUTION = clsPha_attributionchambre.TI_IDATTRIBUTION;
			this.AT_DATESAISIE = clsPha_attributionchambre.AT_DATESAISIE;
			this.TI_IDTIERS = clsPha_attributionchambre.TI_IDTIERS;
			this.AR_CODEARTICLE = clsPha_attributionchambre.AR_CODEARTICLE;
			this.PI_CODEPIECE = clsPha_attributionchambre.PI_CODEPIECE;
			this.PY_CODEPAYS = clsPha_attributionchambre.PY_CODEPAYS;
			this.AT_NUMPIECE = clsPha_attributionchambre.AT_NUMPIECE;
			this.AT_DATEETABLISSEMENTPIECE = clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE;
			this.AT_LIEUETABLISSEMENTPIECE = clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE;
			this.AT_EMETTEURPIECE = clsPha_attributionchambre.AT_EMETTEURPIECE;
			this.AT_DATEENTREENATIONALE = clsPha_attributionchambre.AT_DATEENTREENATIONALE;
			this.AT_DATEDEPARTNATIONALE = clsPha_attributionchambre.AT_DATEDEPARTNATIONALE;
			this.AT_DATEDEBUT = clsPha_attributionchambre.AT_DATEDEBUT;
			this.AT_DATEFIN = clsPha_attributionchambre.AT_DATEFIN;
			this.AT_DATECLOTURE = clsPha_attributionchambre.AT_DATECLOTURE;
            this.AT_DATEFINEFFECTIVE = clsPha_attributionchambre.AT_DATEFINEFFECTIVE;
            this.ECRANAPPELANT = clsPha_attributionchambre.ECRANAPPELANT;
            this.TYPEOPERATION = clsPha_attributionchambre.TYPEOPERATION;
            this.OP_CODEOPERATEUR = clsPha_attributionchambre.OP_CODEOPERATEUR;



		}

		#endregion

	}
}
